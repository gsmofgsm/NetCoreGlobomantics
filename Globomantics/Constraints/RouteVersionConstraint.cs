using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Constraints
{
    public class RouteVersionConstraint : IRouteConstraint
    {
        private double requiredVersion;

        public RouteVersionConstraint(double version)
        {
            requiredVersion = version;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            double requestedVersion;
            var urlVersion = values["version"].ToString()?.Substring(1);

            // parse must be en-US for always using .
            if (double.TryParse(urlVersion, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out requestedVersion))
            {
                return requestedVersion >= requiredVersion &&
                    requestedVersion < requiredVersion + 1;  // only allow for minor version variation
            }

            return false;
        }
    }
}
