using System;

namespace c_sharp_apps_Masarwa_Shadi.StockDemo
{
    internal class ExchangeDemo
    {
        string date = "21/5/2024";
        Stock appleStock;
        Stock teslaStock;
        Stock cokeStock;
        public ExchangeDemo()
        {
            appleStock = new Stock("Apple Inc.", "AAPL", "Electronics", "Nasdaq 100");
            teslaStock = new Stock("Tesla, Inc.", "TSLA", "Electronics", "Nasdaq 100");
            cokeStock = new Stock("Coca-Cola Consolidated, Inc.", "COKE", "Baverage", "Nasdaq 100");
        }

        public void MainEntry()
        {
            //Set price
            appleStock.SetPrice(191.09);
            teslaStock.SetPrice(175.51);
            cokeStock.SetPrice(944.17);

            //Set start of day - also will change the start price
            StartDay(appleStock);
            StartDay(teslaStock);
            StartDay(cokeStock);

            //Print details
            Console.WriteLine("On day open (" + date + "):");
            Console.WriteLine(appleStock.ToString());
            Console.WriteLine(teslaStock.ToString());
            Console.WriteLine(cokeStock.ToString());
            Console.WriteLine();

            //Set end of day and price
            EndDay(appleStock, 192.73);
            EndDay(teslaStock, 186.875);
            EndDay(cokeStock, 982.90);

            //Print details
            Console.WriteLine("After day end (" + date +"):");
            Console.WriteLine(appleStock.ToString());
            Console.WriteLine(teslaStock.ToString());
            Console.WriteLine(cokeStock.ToString());
            Console.WriteLine();
        }

        public void StartDay(Stock stock)
        {
            if (!stock.isDayActive)
                stock.SetStartDay();
        }

        public void EndDay(Stock stock, double price)
        {
            if (stock.isDayActive)
                stock.SetEndDay(price);
        }

    }
}
