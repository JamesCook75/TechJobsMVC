using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchTerm, string searchType)
        {
            List<Dictionary<string, string>> values = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> jobs = JobData.FindAll();
            if (searchType == "all")
            {               
                foreach (Dictionary<string, string> job in jobs)
                {
                    foreach (KeyValuePair<string, string> column in job)
                    {
                        if (column.Value.IndexOf(searchTerm, System.StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (!values.Contains(job))
                            {
                                values.Add(job);
                            }
                        }


                    }
                }
                ViewBag.jobs = values;
                return View("Index");
            }
            else
            {
                foreach (Dictionary<string, string> job in jobs)
                {
                    if (job[searchType].IndexOf(searchTerm, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (!values.Contains(job))
                        {
                            values.Add(job);
                        }
                    }
                }
                ViewBag.jobs = values;
                return View("Index");

            }

        }

    }
}
