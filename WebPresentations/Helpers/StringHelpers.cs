using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WebPresentations.Models;
using WebPresentations.ViewModels;

namespace WebPresentations.Helpers
{
    public static class StringHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            return input.Length <= length ? input : input.Substring(0, length) + "...";
        }
    }
}