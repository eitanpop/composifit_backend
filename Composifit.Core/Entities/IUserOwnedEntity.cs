using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public interface IUserOwnedEntity
    {
        string UserId { get; set; }
    }
}
