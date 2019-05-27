using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web2019ReVamp.Data;

namespace Web2019ReVamp.Models
{
    public class Investigations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ReportId { get; set; }
        [ForeignKey("ReportId")]
        public virtual Reports Reports { get; set; }

        public string InvEntry { get; set; }
    }
}
