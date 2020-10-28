using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Data.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static DateTime GetDOB(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DOB");
            // Test for null to avoid issues during local testing
            return (claim != null) ? Convert.ToDateTime(claim.Value) : new DateTime();
        }

        public static int GetAge(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DOB");
            // Test for null to avoid issues during local testing
            var dob = GetDOB(identity);

            if (dob == new DateTime())
            {
                return 0;
            }

            DateTime DOB = Convert.ToDateTime(dob);

            TimeSpan ageSpan = DateTime.Now - DOB;
            double totalAgeInYears = ageSpan.TotalDays / 365.25;
            int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
            return yearsOfAge;
        }
    }
}
