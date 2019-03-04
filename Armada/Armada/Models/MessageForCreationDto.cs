﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Models
{
    public class MessageForCreationDto
    {
       
        [Required]
        public DateTime MessageDateCreate { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "Ah dommage")]
        public string Content { get; set; }
    }
}