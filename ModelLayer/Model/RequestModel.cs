﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class RequestModel
    {
        [Key]
        public int key { get; set; }
        public string value { get; set; }

    }
}
