using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core
{
    public class IdentityProvider : IIdentityProvider
    {
        private string _userId;
        public IdentityProvider(string userId) => _userId = userId;
       
        public string GetUserId() => _userId;       
    }
}
