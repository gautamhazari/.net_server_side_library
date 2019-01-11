using System.Collections.Generic;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Scope = GSMA.MobileConnect.Constants.Scope;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Version Auto detection mechanism
    /// </summary>
    public class VersionDetection
    {
        /// <summary>
        /// Validate or auto detect version
        /// </summary>
        /// <param name="version">from config</param>
        /// <param name="scope">from config</param>
        /// <param name="providerMetadata">from DiscoveryResponse</param>
        /// <returns>detected version</returns>
        public static string GetCurrentVersion(string version, string scope, ProviderMetadata providerMetadata)
        {
            bList<string> supportedVersion = GetSupportedVersions(providerMetadata);
            if (version != null && IsVersionSupported(version))
            {
                if (!supportedVersion.Contains(version))
                {
                    Log.Warning(() => $"Check version. It might be unsupported {version}");
                }

                return version;
            }

            List<string> currentScopes = StringUtils.ConvertToListBySpace(scope);
            if (supportedVersion.Contains(Version.MC_DI_R2_V2_3) & ContainsScopesV2_3(currentScopes))
            {
                return Version.MC_DI_R2_V2_3;
            } 
            if (supportedVersion.Contains(Version.MC_V2_0) & ContainsScopesV2_0(currentScopes))
            {
                return Version.MC_V2_0;
            } 
            if (supportedVersion.Contains(Version.MC_V1_1) & ContainsOpenidScope(currentScopes) & currentScopes.Count == 1)
            {
                return Version.MC_V1_1;
            }
            if (supportedVersion.Contains(Version.MC_V1_2) & ContainsOpenidScope(currentScopes) & supportedVersion.Count == 1)
            { 
                Log.Warning("Version is deprecated");
                return Version.MC_V1_2;
            }

            MobileConnectInvalidScopeException invalidScopeException = new MobileConnectInvalidScopeException(scope);
            throw invalidScopeException;
        }

        private static bool ContainsOpenidScope(List<string> currentScopes)
        {
            return currentScopes.Contains(Scope.OPENID);
        }

        private static bool ContainsScopesV2_0(List<string> currentScopes)
        {
            return ContainsOpenidScope(currentScopes) & (currentScopes.Contains(Scope.AUTHN) || currentScopes.Contains(Scope.AUTHZ) ||
                                                         currentScopes.Contains(Scope.IDENTITYPHONE) || currentScopes.Contains(Scope.IDENTITYNATIONALID) ||
                                                         currentScopes.Contains(Scope.IDENTITYSIGNUP) || currentScopes.Contains(Scope.IDENTITYSIGNUPPLUS));
        }

        private static bool ContainsScopesV2_3(List<string> currentScopes)
        {
            return ContainsOpenidScope(currentScopes) & (ContainsScopesV2_0(currentScopes) || currentScopes.Contains(Scope.KYCHASHED)
                                                                                           || currentScopes.Contains(Scope.KYCPLAIN));
        }


        private static bool IsVersionSupported(string version)
        {
            return version.Equals(Version.MC_V1_1) || version.Equals(Version.MC_V1_2) ||
                   version.Equals(Version.MC_V2_0) || version.Equals(Version.MC_DI_R2_V2_3);
        }

        private static List<string> GetSupportedVersions(ProviderMetadata providerMetadata)
        {
            List<string> supportedVersions = new List<string>();
            if (providerMetadata?.MCVersion == null)
            {
                supportedVersions.Add(Version.MC_V1_1);
            }
            else
            {
                supportedVersions = providerMetadata.MCVersion;
            }

            return supportedVersions;
        }
    }
}
