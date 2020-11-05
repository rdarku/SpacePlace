using System;
using System.Security.Claims;
using System.Security.Principal;

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
            var claim = ((ClaimsIdentity)identity).FindFirst("Age");
            // Test for null to avoid issues during local testing
            return (claim != null) ? Convert.ToInt32(claim.Value) : 0;
        }
    }
}
