using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace Kenos
{
    public class SecurityHelper
    {

        public static bool IsInGroup(string groupname)
        {
            try
            {
                ContextType type = ContextType.Domain;

                if (!groupname.Contains("\\"))
                    type = ContextType.Machine;

                PrincipalContext context = new PrincipalContext(type);

                GroupPrincipal group = GroupPrincipal.FindByIdentity(
                    context, groupname);

                if (group != null)
                {
                    return group.GetMembers(true).Contains(UserPrincipal.Current);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                return false;
            }
        }

    }
}
