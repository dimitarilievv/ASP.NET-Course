using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;
using StocksAppWithConfiguration.Models;

namespace StocksAppWithConfiguration.Controllers
{
    public class TradeController : Controller
    {
        private readonly TradingOptions _tradingOptions;
        private readonly IConfiguration _configuration;
        private readonly IFinnhubService _finnhubService;
        public TradeController(IOptions<TradingOptions> tradingOptions, IConfiguration configuration, IFinnhubService finnhubService)
        {
            _tradingOptions = tradingOptions.Value;
            _configuration = configuration;
            _finnhubService = finnhubService;

        }

        [Route("/")]
        public IActionResult Index()
        {
            //if doesn't exist reset stock symbol
            if (_tradingOptions.DefaultStockSymbol == null)
                _tradingOptions.DefaultStockSymbol = "MSFT";

            //get company profile from API server
            Dictionary<string, object>? companyProfileDictionary =
                _finnhubService.GetCompanyProfile(_tradingOptions.DefaultStockSymbol);

            //get stock price quotes from API server
            Dictionary<string, object>? stockQuoteDictionary =
                _finnhubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);

            //create model object
            StockTrade stockTrade=new StockTrade()
            {
                StockSymbol= _tradingOptions.DefaultStockSymbol

            };

            //load data from finnHubService into model object
            if (companyProfileDictionary != null && stockQuoteDictionary != null)
            {
                stockTrade = new StockTrade()
                {
                    StockSymbol = Convert.ToString(companyProfileDictionary["ticker"]),
                    StockName = Convert.ToString(companyProfileDictionary["name"]),
                    Price = Convert.ToDouble(stockQuoteDictionary["c"].ToString())
                };
            }

            //Send Finnhub token to view
            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            return View(stockTrade);
        }
    }
}
