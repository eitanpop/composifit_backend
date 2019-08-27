using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public class UserSet : Entity
    {
        public int SetId { get; set; }
        public int ActualReps { get; set; }
        public string ActualWeight { get; set; }
    }
}
