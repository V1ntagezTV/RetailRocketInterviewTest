using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using RetailRocketInterviewTest.Models;

namespace RetailRocketInterviewTest.Commands
{
    class SaveCommand : ICommand
    {
        public const string Alias = "save";
        private readonly string _uri;
        private readonly string _shopId;

        public SaveCommand(string[] args)
        {
            _shopId = args[1];
            _uri = args[2];
        }
        
        public void Invoke()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var webClient = new WebClient() {Encoding = Encoding.GetEncoding(1251)};
            var content = webClient.DownloadString(new Uri(_uri));
            var offers = ParseOffers(content);
            var shop = new Shop() {Id = _shopId, Offers = offers};
            using var context = new ShopContext();
            context.Shops.Add(shop);
            context.Offers.AddRange(offers);
            offers.ForEach(o => Console.WriteLine($"{o.Id} {o.Name}"));
            context.SaveChanges();
            Console.WriteLine($"Store with name: \"{_shopId}\" and his offers has been saved to the database.");
        }

        private List<Offer> ParseOffers(string xmlContent)
        {
            List<Offer> result = new List<Offer>();
            var settings = new XmlReaderSettings() {DtdProcessing = DtdProcessing.Parse};
            using var strReader = new StringReader(xmlContent);
            using var reader = XmlReader.Create(strReader, settings);
            
            reader.ReadToFollowing("offers");
            while (reader.ReadToFollowing("offer"))
            {
                var id = int.Parse(reader.GetAttribute("id"));
                reader.ReadToFollowing("name");
                var name = reader.ReadInnerXml();
                result.Add(new Offer(){Id = id, Name = name});
            }
            return result;
        }
    }
}