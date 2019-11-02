using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core
{
    public interface IIdentityProvider
    {
        string GetUserId();    
    }
}
