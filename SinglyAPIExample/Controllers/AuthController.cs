using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using SinglyAPIExample.Helpers;

namespace SinglyAPIExample.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Index(string id)
        {
            // if request url is null, leave. resharper
            if (Request.Url == null)
            {
                return RedirectToAction("index", "home");
            }

            // service we are authing against gets passedin via url
            var service = id;

            // build callback url
            var callBack = Url.Action("callback", "auth", routeValues: null, protocol: Request.Url.Scheme);

            // build url to send to singly
            var url = AppConfig.SinglyAuthBaseUrl + "?client_id=" + AppConfig.SinglyClientId + "&service=" + service + "&redirect_uri=" + callBack;

            // Check if there's already a token
            if (Session["SinglyToken"] != null)
                url = url + "&access_token=" + Session["SinglyToken"];

            // send to singly
            return Redirect(url);
        }

        public ActionResult Callback(string code)
        {
            // setup rest request for oauth token
            var client = new RestClient(AppConfig.SinglyApiBaseUrl);
            var request = new RestRequest("oauth/access_token", Method.POST);

            // if we already have a singly token, tack it on to chain service oauth
            if (Session["SinglyToken"] != null)
                request.AddParameter("access_token", Session["SinglyToken"]);

            // add parameters
            request.AddParameter("client_id", AppConfig.SinglyClientId);
            request.AddParameter("client_secret", AppConfig.SinglyClientSecretKey);
            request.AddParameter("code", code);
            request.AddParameter("profile", "all");

            // execute rest request
            var response = client.Execute(request);
            var content = response.Content;

            // parse response data
            var data = JObject.Parse(content);
            var token = data.Property("access_token").Value.ToString();
            var account = data.Property("account").Value.ToString();

            // set session data
            Session["SinglyUserId"] = account;
            Session["SinglyToken"] = token;

            // send them to dashboard
            return RedirectToAction("index", "home");
        }

    }
}
