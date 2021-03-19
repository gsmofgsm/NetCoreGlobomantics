using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Controllers
{
    public class PromotionController : Controller
    {
        [HttpGet]
        [Route("promotion/{token:tokenCheck}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("promotion")]
        public IActionResult Submit()
        {
            // TODO: Sweepstakes entry logic
            return View();
        }
    }
}
