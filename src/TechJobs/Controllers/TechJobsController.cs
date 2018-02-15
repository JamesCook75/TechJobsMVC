using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechJobs.Controllers
{
    public class TechJobsController : Controller
    {
        static Dictionary<string, string> actionChoices = new Dictionary<string, string>();

        public IActionResult Index()
        {
            if (actionChoices.Count() == 0)
            {
                actionChoices.Add("search", "Search");
                actionChoices.Add("list", "List");
            }

            ViewBag.actionChoices = actionChoices;
            ViewBag.columns = ListController.columnChoices;
            return View();
        }

        public override ViewResult View()
        {
            ViewBag.actionChoices = actionChoices;
            return base.View();
        }

        public override ViewResult View(string viewName)
        {
            ViewBag.actionChoices = actionChoices;
            return base.View(viewName);
        }
    }
}