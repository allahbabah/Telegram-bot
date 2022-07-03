using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static project.Models.PriceModels;
using ConsoleApp1.Model;

namespace project.Client
{
    public class PriceClient
    {
        HttpClient client;
        private static string Adress;

        public PriceClient()
        {
            Adress = "https://localhost:44324";
            client = new HttpClient();
            client.BaseAddress = new Uri(Adress);

        }
        public async Task<List<PriceModel>> GetPrice(string cryptoCurrency)
        {
            var respoce = await client.GetAsync($"/GetCryptoPrice?CryptoCurrency={cryptoCurrency}");
            var content = respoce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<PriceModel>>(content);
            //var result = (List<PriceModel>)JsonConvert.DeserializeObject();
            return result;
        }
        public async Task<MarketModel> GetMarketPrice(string cryptoCurrency)
        {
            var respoce = await client.GetAsync($"/GetCryptoPrice/Markets?CryptoCurrency={cryptoCurrency}");
            var content = respoce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<MarketModel>(content);
            
            return result;
        }
    }
}
