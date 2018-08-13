using System.Reflection;


namespace GSMA.MobileConnect.Utils
{
    class VersionUtils
    {
        public static string GetSDKVersion()
        {
            var assembly = typeof(VersionUtils).GetTypeInfo().Assembly;
            string version = assembly.GetName().Version.ToString();
            version = version.Substring(0, version.Length - 2);
            Log.Debug(() => string.Format("Current SDK-Version: {0}", version));
            return string.Format(".NET-{0}", version);
        }
    }
}