using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Password { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }
        // TODO : mettre une regExp

        [Required]
        public string Mail { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100)]
        public string About { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime Birthday { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();

    }
}
