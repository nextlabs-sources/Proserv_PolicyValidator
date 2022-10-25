using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Runtime.InteropServices;

using CETYPE;



namespace PolicyValidator

{

    //[StructLayout(LayoutKind.Sequential)]

    //public struct MRequest

    //{

    //    public String operation;



    //    public CETYPE.CEResource source;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public String[] sourceAttr;



    //    public CETYPE.CEResource target;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public String[] targetAttr;



    //    public CETYPE.CEUser user;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public String[] userAttr;



    //    public CETYPE.CEApplication app;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public String[] appAttr;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public CETYPE.CEUser[] recipients;



    //    public int numRecipients;



    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

    //    public String[] additionalAttr;



    //    public int numAdditionalAttr;



    //    public Boolean performObligation;



    //    public CETYPE.CENoiseLevel_t noiseLevel;

    //}





    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

    public class MRequest

    {

        /*CEString operation;*/

        public IntPtr operation;



        public IntPtr source;



        /*CEAttributes *sourceAttributes;*/

        public IntPtr sourceAttributes;



        public IntPtr target;



        /*CEAttributes *targetAttributes;*/

        public IntPtr targetAttributes;



        public IntPtr user;

        /*CEAttributes *userAttributes;*/

        public IntPtr userAttributes;



        public IntPtr app;

        /* CEAttributes *appAttributes;*/

        public IntPtr appAttributes;



        /* CEString *recipients;*/

        public IntPtr recipients;

        /*CEint32 numRecipients;*/

        public int numRecipients;

        /*CENamedAttributes *additionalAttributes;*/

        public IntPtr additionalAttributes;

        /*CEint32 numAdditionalAttributes;*/

        public int numAdditionalAttributes;

        /*CEBoolean performObligation;*/

        public bool performObligation;

        /*CENoiseLevel_t noiseLevel;*/

        public int noiseLevel;

    }

    //CEString end





    [StructLayout(LayoutKind.Sequential)]

    public struct MObligation

    {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]

        public String[] attrs;

    }



    [StructLayout(LayoutKind.Sequential)]

    public struct MEnforcement

    {

        public MObligation obligation;



    }



    [StructLayout(LayoutKind.Sequential)]

    public struct MResult

    {



    }



    class Test

    {



        //[DllImport("cesdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]

        //public static extern CETYPE.CEResult_t CEEVALUATE_CheckResourcesEx(IntPtr handle, [MarshalAs(UnmanagedType.LPArray)] [In,Out] MRequest[] request, int numReq, String additionalPQL, Boolean ignoreBuiltInPolicy, int ip, out MEnforcement[] enf, int timeout);

        [DllImport("cesdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern CETYPE.CEResult_t CEEVALUATE_CheckResourcesEx(

            IntPtr handl,

            [In, Out]IntPtr requests,

            [In]int numRequests,

            [In]IntPtr additionalPQL,

            [In]bool ignoreBuiltinPolicies,

            [In]uint ipNumber,

            [In, Out]IntPtr enforcements,

            [In]int timeout_in_millisec);

    }

}



        