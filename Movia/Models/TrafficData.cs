using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movia.Models
{
   
    public class TrafficData
    {
        public String Line { get; set; }

        [Key]
        // Der skal være en Primary Key forbundet med objektet
        public DateTime Date { get; set; }

        public String Message { get; set; }

    }
}