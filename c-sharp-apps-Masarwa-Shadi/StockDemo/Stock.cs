namespace c_sharp_apps_Masarwa_Shadi.StockDemo
{
    public class Stock
    {
        public string officialName;
        public double price;
        public string symbol;
        public double startingPrice;
        public double closingPrice;
        public string industry;
        public string exchange;
        public bool isDayActive;

        public Stock(string officialName, string sign, string industry, string exchange)
        {
            this.officialName = officialName;
            this.symbol = sign;
            this.industry = industry;
            this.exchange = exchange;
        }

        public void SetStartDay()
        {
            startingPrice = price;
            isDayActive = true;
        }

        public void SetEndDay(double finalPrice)
        {
            closingPrice = finalPrice;
            price = finalPrice;
            isDayActive = false;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public override string ToString()
        {
            string str = symbol + " - " + officialName + " - Open Price: " + startingPrice;
            if (!isDayActive)
                return str + " - Close Price: " + closingPrice + " -- Change: " + ((closingPrice - startingPrice) / startingPrice * 100).ToString("0.00") + "%";
            else return str + " - Still Active";
        }

    }
}
