using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2019ReVamp.Models
{
    public class Reports
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string userEmail { get; set; }
        public int InvId { get; set; }
        public string Title { get; set; }

       
        public DateTime RepDate { get; set; }
        public DateTime HazardDateTime { get; set; }

        public string Location { get; set; }
        public string HazardType { get; set; }
        public string RepDescription { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }
        public int Upvotes { get; set; }
    }
}
