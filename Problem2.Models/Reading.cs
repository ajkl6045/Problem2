using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Models
{
   // [Keyless]
    public class Reading
    {
        [Key]
        public int Id { get; set; }
        public short BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
        public short  ObjectId { get; set; }
        [ForeignKey("ObjectId")]
        public Object Object { get; set; }
        public short DataFieldId { get; set; }
        [ForeignKey("DataFieldId")]
        public DataField DataField { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Value { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
