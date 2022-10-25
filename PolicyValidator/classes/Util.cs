using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using log4net;
using PolicyValidator.Properties;



namespace PolicyValidator
{

    static class Util
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static Dictionary<string, bool> _treeViewState = new Dictionary<string, bool>();

        private static string _selectedNode;
        private static string _selectedNodeParent;
        private static string _selectedNodeNext;
        private static string _selectedNodePrev;

        public static string GetBaseDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Settings.Default.RootDir);
        }

        private static void SaveState(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                _treeViewState.Add(tn.FullPath, tn.IsExpanded);
                SaveState(tn);
            }
        }



        private static void SaveStateRecursive(TreeView treeView)
        {
            if (treeView.Nodes.Count > 0)
            {
                _selectedNode = treeView.SelectedNode.FullPath;
                if (treeView.SelectedNode.NextNode != null)
                    _selectedNodeNext = treeView.SelectedNode.NextNode.FullPath;
                if (treeView.SelectedNode.PrevNode != null)
                    _selectedNodePrev = treeView.SelectedNode.PrevNode.FullPath;
                if (treeView.SelectedNode.Parent != null)
                    _selectedNodeParent = treeView.SelectedNode.Parent.FullPath;
            }

            _treeViewState.Clear();

            TreeNodeCollection nodes = treeView.Nodes;

            foreach (TreeNode n in nodes)
            {
                _treeViewState.Add(n.FullPath, n.IsExpanded);
                SaveState(n);
            }
        }



        private static void RestoreState(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (_treeViewState.ContainsKey(tn.FullPath))
                {
                    if (_treeViewState[tn.FullPath])
                    {
                        tn.Expand();
                    }
                    else
                    {
                        tn.Collapse();
                    }
                }
                RestoreState(tn);
            }
        }



        private static void RestoreStateRecursive(TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                if (_treeViewState.ContainsKey(n.FullPath))
                {
                    if (_treeViewState[n.FullPath])
                    {
                        n.Expand();
                    }
                    else
                    {
                        n.Collapse();
                    }
                }
                RestoreState(n);
            }

            if (_selectedNode != null)
            {
                if (GetNodeFromPath(treeView.Nodes[0], _selectedNode) != null)
                    treeView.SelectedNode = GetNodeFromPath(treeView.Nodes[0], _selectedNode);
                else if (GetNodeFromPath(treeView.Nodes[0], _selectedNodeNext) != null)
                    treeView.SelectedNode = GetNodeFromPath(treeView.Nodes[0], _selectedNodeNext);
                else if (GetNodeFromPath(treeView.Nodes[0], _selectedNodePrev) != null)
                    treeView.SelectedNode = GetNodeFromPath(treeView.Nodes[0], _selectedNodePrev);
                else if (GetNodeFromPath(treeView.Nodes[0], _selectedNodeParent) != null)
                    treeView.SelectedNode = GetNodeFromPath(treeView.Nodes[0], _selectedNodeParent);
                else
                    treeView.SelectedNode = treeView.Nodes[0];
                treeView.SelectedNode.EnsureVisible();

                _selectedNode = null;
                _selectedNodeNext = null;
                _selectedNodeParent = null;
            }
        }



        public static TreeNode GetNodeFromPath(TreeNode node, string path)
        {
            TreeNode foundNode = null;
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.FullPath == path)
                {
                    return tn;
                }
                else if (tn.Nodes.Count > 0)
                {
                    foundNode = GetNodeFromPath(tn, path);
                }
                if (foundNode != null)
                    return foundNode;
            }
            return null;
        }

        public static void PopulateTreeView(NativeTreeView treeView)
        {
            Log.Debug("Populating tree view from filesystem.");

            SaveStateRecursive(treeView);
            treeView.BeginUpdate();

            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(GetBaseDirectory());
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name, 1, 1) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                foreach (var file in directoryInfo.GetFiles())
                    currentNode.Nodes.Add(new TreeNode(file.Name, 0, 0));
            }

            treeView.Nodes.Add(node);

            RestoreStateRecursive(treeView);
            treeView.EndUpdate();
        }

        public static void PopulateTreeViewFromDatabase(NativeTreeView treeView)
        {
            Log.Info("PopulateTreeViewFromDatabase() started.");

            SaveStateRecursive(treeView);
            treeView.BeginUpdate();

            treeView.Nodes.Clear();

            var rootNode = new TreeNode("root", 4, 4) {Tag = "Root"};
            var testSet = MongoDBUtil.GetAllTestSet().Result;

            foreach (string set in testSet) {
                var childSetNode = new TreeNode(set, 2, 2) { Tag = "Test Set" };
                rootNode.Nodes.Add(childSetNode);

                var testCases = MongoDBUtil.GetTestCaseNamesByTestSet(set).Result;
                foreach (string testCase in testCases) {
                    var childCaseNode = new TreeNode(testCase, 3, 3) {Tag = "Test Case"};
                    childSetNode.Nodes.Add(childCaseNode);
                }
            }

            treeView.Nodes.Add(rootNode);

            RestoreStateRecursive(treeView);
            treeView.EndUpdate();

            Log.Info("PopulateTreeViewFromDatabase() finished.");
        }



        public static void WriteTestCaseToFile(TestCase tc, string filename)
        {

            string testCaseFilePath = Path.Combine(Path.GetDirectoryName(GetBaseDirectory()), filename);

            using (FileStream writer = new FileStream(testCaseFilePath, FileMode.Create, FileAccess.Write))
            {

                DataContractSerializer ser = new DataContractSerializer(typeof(TestCase));

                ser.WriteObject(writer, tc);

            }

        }


        public static TestCase LoadTestCaseFromFile(string filename)
        {

            string testCaseFilePath = Path.Combine(Path.GetDirectoryName(GetBaseDirectory()), filename);



            TestCase tc = new TestCase();

            using (FileStream reader = new FileStream(testCaseFilePath, FileMode.Open, FileAccess.Read))
            {

                DataContractSerializer ser = new DataContractSerializer(typeof(TestCase));

                tc = (TestCase)ser.ReadObject(reader);

            }

            return tc;

        }



        public static uint IpAddressToIpNumber(string ipAddress)
        {
            ipAddress = GetIp4Address(ipAddress);

            if (string.IsNullOrEmpty(ipAddress))
            {
                return 0;
            }

            string[] arrDec = ipAddress.Split('.');
            return arrDec.Aggregate<string, uint>(0, (current, t) => current * 256 + uint.Parse(t) % 256);
        }



        public static string GetIp4Address(string ipAddress)
        {
            string ip4Address = String.Empty;

            if (!String.IsNullOrEmpty(ipAddress))
            {
                try
                {
                    foreach (
                        IPAddress ipa in
                            Dns.GetHostAddresses(ipAddress).Where(ipa => ipa.AddressFamily.ToString() == "InterNetwork")
                        )
                    {
                        ip4Address = ipa.ToString();
                        break;
                    }
                }

                catch (SocketException)
                {
                    ip4Address = String.Empty;
                }

                if (ip4Address != String.Empty)
                {
                    return ip4Address;
                }
            }


            foreach (
                IPAddress ipa in
                    Dns.GetHostAddresses(Dns.GetHostName()).Where(ipa => ipa.AddressFamily.ToString() == "InterNetwork")
                )
            {
                ip4Address = ipa.ToString();
                break;
            }

            return ip4Address;
        }



        public static TreeNode LocateNode(string Path, TreeNodeCollection TreeCol)
        {

            string[] PTms = Path.Split(new Char[] { '\\' });



            for (int k = 0; k < TreeCol.Count; k++)
            {

                if (TreeCol[k].Text == PTms[0])
                {

                    if (TreeCol[k].Nodes.Count == 0 || PTms.Length == 1)

                        return TreeCol[k];



                    return LocateNode(Path.Remove(0, PTms[0].Length + 1), TreeCol[k].Nodes);

                }

            }

            return null;

        }



    }

}

