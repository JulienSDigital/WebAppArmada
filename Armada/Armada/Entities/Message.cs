using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        public DateTime MessageDateCreate { get; set; }

       // [ForeignKey("UserID")]
  //todo réactiver
        //public User User { get; set; }
        public int UserID { get; set; }
        

        [DataType(DataType.MultilineText)]
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}
