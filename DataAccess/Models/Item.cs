using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresApi.DataAccess.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(10, ErrorMessage = "The {0} value exceeds {1} characters")]
        public string Code { get; set; }
        [StringLength(128, ErrorMessage = "The {0} value exceeds {1} characters")]
        public string Name { get; set; }
    }
}
