using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Daily_Reflection.Models;
using Daily_Reflection.ViewModels;
using Raven.Client.Document;

namespace Daily_Reflection.Controllers
{
    public class RavenController : Controller
    {
        // GET: Raven
        public ActionResult Index()
        {


            List<CompanyUser> model = new List<CompanyUser>();
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

                    model = session.Query<CompanyUser>().ToList();

                }
            }


            return View(model);
        }

        



    }
}