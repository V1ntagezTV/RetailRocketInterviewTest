using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailRocketInterviewTest.Models
{
    public class Offer
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        public Shop Seller { get; set; }
    }
}