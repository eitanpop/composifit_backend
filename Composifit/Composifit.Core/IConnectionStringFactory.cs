using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core
{
    public interface IConnectionStringFactory
    {
        string DefaultConnection { get; set; }
    }
}
