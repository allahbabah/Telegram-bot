using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class MarketModel
    {
        public string NameBinance { get; set; } = "Binance";
        public double PriceBinance { get; set; }
        public string NameBybit { get; set; } = "Bybit";
        public double PriceBybit { get; set; }
        public string NameCoinbase { get; set; } = "Coinbase";
        public double PriceCoinbase { get; set; }
        public string NameKraken { get; set; } = "Kraken";
        public double PriceKraken { get; set; }
        public string NameFTX { get; set; } = "FTX";
        public double PriceFTX { get; set; }
    }
}
