﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Composifit.Core.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
