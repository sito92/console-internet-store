using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.CommandParser.Role
{
    public static class RoleExtension
    {
        private const string unautorizedRole = "Unauthorized";
        private static Dictionary<string, RoleKind> roleKinds = new Dictionary<string, RoleKind>()
        {
            {"Admin", RoleKind.Administrator},
            {"Client", RoleKind.Client},
            {"Unauthorized", RoleKind.Unauthorized},
        };
        public static RoleKind GetRole(this UserBase user)
        {
            var roleName = user.GetType().Name;
            return roleKinds.ContainsKey(roleName) ? roleKinds[roleName] : roleKinds[unautorizedRole];
        }
    }
}
