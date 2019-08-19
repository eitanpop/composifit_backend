using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
