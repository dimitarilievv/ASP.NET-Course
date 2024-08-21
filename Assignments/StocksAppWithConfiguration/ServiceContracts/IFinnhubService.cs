namespace ServiceContracts
{
    /// Represents a service that makes HTTP requests to finnhub.io
    public interface IFinnhubService
    {
        /// Returns company details such as company country, currency, exchange, IPO date, logo image, market capitalization, name of the company, phone number etc.
        Dictionary<string, object>? GetCompanyProfile(string stockSymbol);
        /// Returns stock price details such as current price, change in price, percentage change, high price of the day, low price of the day, open price of the day, previous close price
        Dictionary<string, object>? GetStockPriceQuote(string stockSymbol);
    }
}