using System;

using System.Runtime.InteropServices;

using System.Windows.Forms;



namespace PolicyValidator
{

    public class NativeTreeView : TreeView
    {

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]

        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName,

              string pszSubIdList);



        protected override void CreateHandle()
        {

            base.CreateHandle();



            SetWindowTheme(Handle, "explorer", null);

        }

    }

}