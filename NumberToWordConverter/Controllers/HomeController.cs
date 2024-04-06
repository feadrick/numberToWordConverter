using CoreConverter.core;
using CoreConverter.preprocessor;
using CoreConverter;
using Microsoft.AspNetCore.Mvc;
using NumberToWordConverter.Models;
using System.Diagnostics;

namespace NumberToWordConverter.Controllers
{
    public class HomeController : Controller
    {
        NumToWordConverter converter = new NumToWordConverter();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Convert() {
            string input = Request.Form["inputNum"];
            if (string.IsNullOrEmpty(input)) {
                return "invalid input";
            }
            if (input.Length>190) {
                return "input number is too large";
            }

            (List<NumberDescriptor> inputList, NumberDescriptor pointnum) = input.splitNumber();
            var res = converter.ConvertToWord(inputList, pointnum);
            return res;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}