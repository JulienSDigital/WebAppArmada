﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Models
{
    public class MessageDto
    {
        public int MessageID { get; set; }

        public DateTime MessageDateCreate { get; set; }
        public UserDto User { get; set; }
       
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}