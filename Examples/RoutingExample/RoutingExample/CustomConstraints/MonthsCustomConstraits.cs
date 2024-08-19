using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace RoutingExample.CustomConstraints
{
    //eg: sales-report/2020/apr
    public class MonthsCustomConstraits : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether the value exists
            if (!values.ContainsKey(routeKey)) //month
            {
                return false; //not a match
            }
            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthValue = Convert.ToString(values[routeKey]);
            if(regex.IsMatch(monthValue))
            {
                return true; //its a match
            }
            return false;

        }
    }
}
