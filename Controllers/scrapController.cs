using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Words;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scraping.Models;
namespace scraping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class scrapController : ControllerBase
    {
        
        public scrapController(){}

        [HttpGet]
        public IActionResult Get()
        {
            string uri1 = "https://www.mytek.tn/13-pc-portable?selected_filters=gamer-oui%2Ftype-ordinateur_portable&id_category=13&n=68";
            string uri2 = "https://www.mytek.tn/13-pc-portable?selected_filters=gamer-oui%2Ftype-ordinateur_portable";
                List<laptop> laptops = new List<laptop>();
            int i = 1;
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb() ;
            HtmlAgilityPack.HtmlDocument doc = web.Load(uri1);
            //string m = doc.DocumentNode.SelectNodes("//img[@class='replace-2x img-responsive'").First().Attributes[""].Value;
            //SelectNodes("//a/img")
            foreach (var item in doc.DocumentNode.SelectNodes("//a[@class='product_img_link']/img"))
            {
                string src = item.Attributes["src"].Value;
                laptop ilaptop = new laptop();
                ilaptop.photo = src;
                ilaptop.title = doc.DocumentNode.SelectNodes("//a[@class='product-name']")[i].InnerText;
                laptops.Add(ilaptop);
                i++;
            }
            return Ok(laptops);
        }
    }
}
