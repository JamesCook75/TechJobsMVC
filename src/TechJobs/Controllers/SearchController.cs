using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobsController
    {
        public IActionResult Results(string searchTerm, string searchType)
        {
            IList<Dictionary<string, string>> values = new List<Dictionary<string, string>>();
            IEnumerable<Dictionary<string, string>> jobs = JobData.FindAll();
            
            ViewBag.search = searchType;
            if (searchTerm == null)
            {
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
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
                ViewBag.columns = ListController.columnChoices;
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
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = values;
                return View("Index");

            }

        }

    }
}
