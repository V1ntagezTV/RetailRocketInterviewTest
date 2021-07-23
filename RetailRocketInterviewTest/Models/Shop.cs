using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailRocketInterviewTest.Models
{
    public class Shop
    {
        [StringLength(50)][Key]
        public string Id { get; set; }
        
        public List<Offer> Offers { get; set; }
    }
}