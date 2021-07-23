using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailRocketInterviewTest.Commands
{
    public class PrintCommand : ICommand
    {
        private readonly string _shopId;

        public PrintCommand(string[] args)
        {
            _shopId = args[1];
        }
        
        public const string Alias = "print";
        public void Invoke()
        {
            using var context = new ShopContext();
            var shop = context.Shops
                .Include(s => s.Offers)
                .FirstOrDefault(s => s.Id == _shopId);
            if (shop == null)
            {
                throw new ArgumentException($"The {_shopId} does not exist in database. Try another arguments.");
            }
            shop.Offers.ForEach(o => Console.WriteLine($"{o.Id} {o.Name}"));
        }
    }
}