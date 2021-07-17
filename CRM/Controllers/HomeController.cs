using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Data;
using CRM.Models;
using CRM.Models.Mapping;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {


            string temp = "ABVtemp1235TYTRRrdsfsf";

           var temp2 = temp.FirstCharacterUpperCase();
            try
            {
                if (id != null)
                {
                    var profile = new Profile(id.Value).Map();
                }
                else
                {
                    var profiles = new Profile().List().Select(a => a.Map()).ToList();
                }
            }
            catch (Exception ex)
            {
               //todo return to the Error page
            }

            return View();
        }

        public ActionResult Create(int? id)
        {
            return View(new Profile(id.Value).Map());
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Name")]ProfileDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                //todo call method from data layer to create userprofile
                
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
            ViewBag.Message = "UserProfile Created Successfully!";

            return View("Index");
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