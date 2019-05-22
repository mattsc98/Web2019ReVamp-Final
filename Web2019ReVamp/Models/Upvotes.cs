using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2019ReVamp.Models
{
    public class Upvotes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ReportId { get; set; }
    }
}
