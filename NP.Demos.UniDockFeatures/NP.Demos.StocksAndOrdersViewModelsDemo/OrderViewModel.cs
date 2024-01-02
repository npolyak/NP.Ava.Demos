﻿using NP.Utilities;

namespace NP.Demos.StocksAndOrdersViewModelsDemo
{
    public class OrderViewModel : VMBase
    {
        public string? Symbol { get; set; }

        public int NumberShares { get; set; }

        public decimal MarketPrice { get; set; }


        public override string ToString()
        {
            return $"OrderViewModel: Symbol={Symbol}";
        }
    }
}
