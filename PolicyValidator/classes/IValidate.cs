namespace PolicyValidator

{

    internal interface IValidate

    {

        bool ConnectToPC(string applicationName, string sid, string username, string pdpIpAddress, int port, float timeoutS);

        bool DisconnectFromPC();

        bool Evaluate(Requests[] req, string pql, bool ignoreBuiltInPolicies, out EnforcementResult[] enforcement, int timeout);

    }

}

