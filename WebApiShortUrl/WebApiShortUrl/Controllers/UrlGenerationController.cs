using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiShortUrl.Controllers
{

   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UrlGenerationController : ApiController
    {

       
        [HttpGet]
        public string Get()
        {
            return "Welcome To Web Api";
        }

        [HttpGet]
        public IHttpActionResult GetUrl(string url)
        {
            string URL;
            //string originalUrl = "https://www.dailymail.co.uk/home/index.html";  // Original Url  
            string originalUrl = url;  // Original Url  

            //=====Read URL From Database================

            //============The Database Functionality is just to show the data access code. 

            //URLDBEntities ctx = new URLDBEntities();
            //TblUrl tblUrl = ctx.TblUrl.Where(u => u.BaseUrl == url).FirstOrDefault<TblUrl>();
            //string originalUrl = tblUrl.BaseUrl;


            URL = "http://tinyurl.com/api-create.php?url=" + originalUrl.ToLower(); // 

            System.Net.HttpWebRequest objWebRequest;
            System.Net.HttpWebResponse objWebResponse;

            System.IO.StreamReader srReader;

            string strHTML;
            //HttpWebRequest for creating the ShortUrl of the original Version
            objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            objWebRequest.Method = "GET";
            //Web Response is Creating in respect to the web request. 
            objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
            srReader = new System.IO.StreamReader(objWebResponse.GetResponseStream());


            strHTML = srReader.ReadToEnd(); // Response Link is Creating
            //Clean Up unused Objects. 
            srReader.Close();
            objWebResponse.Close();
            objWebRequest.Abort();

            return Ok(strHTML);

        }




    }
}
