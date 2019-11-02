using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Composifit.Extensions
{
    public static class User
    {
        public static string GetUsername(this System.Security.Claims.ClaimsPrincipal user) =>
            user.FindFirst(x => x.Type == "cognito:username").Value;
    }
}
