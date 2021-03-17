using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private readonly IRateService rateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string title, string subtitle)
        {
            var ratesVM = new CreditCardWidgetVM()
            {
                Rates = rateService.GetCreditCardRates(),
                WidgetTitle = title,
                WidgetSubTitle = subtitle
            };

            return View(ratesVM);
        }
    }

    // TODO: move to external class
    public class CreditCardWidgetVM
    {
        public List<Rate> Rates { get; set; }
        public string WidgetTitle { get; set; }
        public string WidgetSubTitle { get; set; }
    }
}
