using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Core.Models
{
    public class MortgageRateDetails
    {
        public int YearTermLength { get; set; }
        public double InterestRate { get; set; }
        public string ProductName { get; set; }
        public int PointsAvailable { get; set; }
        public bool IsFixed { get; set; }
    }
}
