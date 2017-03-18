using Excel;
using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using ScrapySharp.Network;
using ScrapySharp.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class BeerController : ApiController
    {
        private const string DOWNLOAD_PATH = "http://www.jarngler.is/wp-content/uploads/2015/12/";
        private const string SCRAPING_PATH = "http://www.jarngler.is/serpantanir/";
        // GET api/values
        public async Task<IEnumerable<Beer>> Get(int? skipRows = 4)
        {
            var fileName = await ScrapePage();
            var strPath = string.Format(HttpContext.Current.Server.MapPath("/") + "{0}.xlsx", fileName);
            if (!File.Exists(strPath))
            {
                new WebClient().DownloadFile(DOWNLOAD_PATH + fileName + ".xlsx", strPath);
            }

            var stream = File.Open(strPath, FileMode.Open, FileAccess.Read);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            var result = excelReader.AsDataSet();
            var beers = new List<Beer>();
            for (int i = skipRows.Value; i < result.Tables[0].Rows.Count - 1; i++)
            {
                if (!string.IsNullOrEmpty(result.Tables[0].Rows[i].ItemArray[0].ToString()))
                {
                    beers.Add(new Beer
                    {
                        Id = result.Tables[0].Rows[i].ItemArray[0].ToString(),
                        Name = result.Tables[0].Rows[i].ItemArray[1].ToString(),
                        Price = result.Tables[0].Rows[i].ItemArray[2].ToString(),
                        PriceWithTax = result.Tables[0].Rows[i].ItemArray[3].ToString(),
                        PriceInAtvr = result.Tables[0].Rows[i].ItemArray[4].ToString()
                    });
                }
            }
            excelReader.Close();
            return beers;
        }

        private async Task<string> ScrapePage()
        {
            var Browser = new ScrapingBrowser();
            var pageResult = await Browser.NavigateToPageAsync(new Uri(SCRAPING_PATH));
            return pageResult.Html.CssSelect("p>a").Last().InnerText;
        }
    }

    public class Beer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PriceWithTax { get; set; }
        public string PriceInAtvr { get; set; }
    }
}
