using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Document;
using Daily_Reflection.Models;

namespace Daily_Reflection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (
                var documentstore = new DocumentStore
                {
                    Url = "http://localhost:8080/",
                    DefaultDatabase = "Daily_Reflection"
                })
            {
                documentstore.Initialize();
                using (var session = documentstore.Initialize().OpenSession())
                {
                    session.Store(new CompanyUser
                    {
                        Name = "Rushikesh Matale",
                        Age = 25,
                        Organization = "IDP",
                        Role = "XYZ",
                        Address = "Pune"
                    });
                    session.SaveChanges();
                    var allusers = session.Query<CompanyUser>().ToArray();

                }
            }
            

                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}