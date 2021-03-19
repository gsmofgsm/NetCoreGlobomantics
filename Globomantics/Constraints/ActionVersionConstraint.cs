using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Constraints
{
    public class ActionVersionConstraint : IActionConstraint
    {
        private readonly double requiredVersion;

        public ActionVersionConstraint(double version)
        {
            // we can have the constructor because this constraint class doesn't inherit from Attribute
            requiredVersion = version;
        }

        public int Order { get; set; }

        public bool Accept(ActionConstraintContext context)
        {
            double parsedVersion = 0;
            if (double.TryParse(context.RouteContext.HttpContext.Request
                .Headers["x-version"].ToString(), 
                System.Globalization.NumberStyles.Any, 
                CultureInfo.GetCultureInfo("en-US"), 
                out parsedVersion))
            {
                return parsedVersion >= requiredVersion &&
                    parsedVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
