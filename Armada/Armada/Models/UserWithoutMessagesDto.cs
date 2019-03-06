using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Models
{
    public class UserWithoutMessagesDto
    {
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        //[Required]
        //public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        // TODO : mettre une regExp

        [Required]
        public string Mail { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime Birthday { get; set; }
    }
}
