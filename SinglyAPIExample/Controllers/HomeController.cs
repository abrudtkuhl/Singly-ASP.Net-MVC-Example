using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using SinglyAPIExample.Helpers;

namespace SinglyAPIExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["SinglyToken"] == null)
                return View();

            // setup rest client
            var client = new RestClient(AppConfig.SinglyApiBaseUrl);
            var request = new RestRequest("profiles", Method.GET);

            // add parameters
            request.AddParameter("access_token", Session["SinglyToken"]);

            // execute response
            var response = client.Execute(request);
            var content = response.Content;

            // parse data object
            var data = JObject.Parse(content);

            return View(data);
        }

    }
}
