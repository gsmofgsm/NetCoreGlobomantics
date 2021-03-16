using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("cdrate")]
    public class CDTagHelper : TagHelper
    {
        private readonly IRateService rateService;

        public CDTagHelper(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public string Title { get; set; }
        public string MeterPercent { get; set; }
        public CDTermLength TermLength { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var rate = rateService.GetCDRateByTerm(TermLength);

            output.Content.SetHtmlContent(
                $@"<div class=""meter"">
                    <p>{ Title }</p>
                    <div class=""progress"">
                        <div class=""progress-bar bg-info"" style=""width: { MeterPercent }%""></div>
                    </div>
                </div>");
        }
    }
}
