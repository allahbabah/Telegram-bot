using System;
using System.Threading.Tasks;
using Telegram.Bot;
using project.Client;
using ConsoleApp1;
using System.Collections.Generic;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    
    internal class Program
    {
        public static double Price = 32000;
        public static double Low = 15000;
        public static double High = 20000;
        public static List<long> Id= new List<long>();
        public static bool PriceInfo;
        public static string[] hello = new string[] { "/bitcoin", "/ethereum", "/solana", "/dogecoin", "/polkadot" };
        const string TOKEN = "5422779754:AAF1YMChyJJcdnSpS-XlUvh9EtPXDym-oE8";
      
        static void Main(string[] args)
        {
            
            while (true)
            {
                try
                {
                    GetMessages().Wait();
                    
                }
                catch
                {
                    Console.WriteLine("Problem");
                }
            }
            
        }
        static async Task GetMessages()
        {
           
            TelegramBotClient bot = new TelegramBotClient(TOKEN);
            bool a = false; 
            int offset = 0;
            int timeout = 0;
            await bot.SetWebhookAsync("");
            while (true)
            {
                var priceClient2 = new PriceClient();
                var result2 = await priceClient2.GetPrice("bitcoin");
                Price = result2[0].Current_price;



                try
                {
                    if (Price > High)
                    {
                        foreach (var item in Id)
                        {
                            await bot.SendTextMessageAsync(item, "Bitcoin price ABOVE "+High + "\nPrice: " + Price);
                            
                        }
                        High = High + 5000;
                        Low = Low + 5000;
                    }
                    else if (Price<Low)
                    {
                        foreach (var item in Id)
                        {
                            await bot.SendTextMessageAsync(item, "Bitcoin price UNDER "+ Low+"\nPrice: "+Price);
                            
                        }
                        Low = Low - 5000;
                        High = High - 5000;
                    }

                    var updates = await bot.GetUpdatesAsync(offset, timeout);
                    foreach (var update in updates)
                    {
                        var message = update.Message;
                       
                        
                        if (Methods.Compare(message.Text, hello))
                        {
                            var text = message.Text.Remove(0,1);
                            var priceClient = new PriceClient();
                            var result = await priceClient.GetMarketPrice(text);
                            Console.WriteLine("Успех");
                            Console.WriteLine(message.Chat.Id);
                            await bot.SendTextMessageAsync(message.Chat.Id, "Market: "+result.NameBinance+"\nPrice: " + result.PriceBinance +"\nMarket: "+ result.NameBybit+"\nPrice: "+result.PriceBybit+"\nMarket: "+ result.NameFTX + "\nPrice: " + result.PriceFTX+ "\nMarket: " + result.NameCoinbase + "\nPrice: " + result.PriceCoinbase+ "\nMarket: " + result.NameKraken + "\nPrice: " + result.PriceKraken);
                        }
                        else if(message.Text == "/start")
                        {
                            Id.Add(message.Chat.Id);
                            Console.WriteLine("add");

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "info");

                        }

                        offset = update.Id + 1;

                    }
                }
                catch
                {
                    Console.WriteLine("Bot");
                }
                
            }
        }
        

    }
}
