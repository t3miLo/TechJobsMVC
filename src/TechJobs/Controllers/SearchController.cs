using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;


namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
			List<Dictionary<string, string>> allJobs = JobData.FindAll();
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
			ViewBag.allJobs = allJobs;
            return View();
        }

		// TODO #1 - Create a Results action method to process 
		// search request and display results
		public IActionResult Results()
		{
			string column = Request.Form["searchType"];
			string value = Request.Form["SearchTerm"];

			List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(column, value);

			ViewBag.jobs = jobs;
			ViewBag.column = column;
			ViewBag.value = value;


			return View("Results");

		}


	}
}
