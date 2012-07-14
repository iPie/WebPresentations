using System.Web.Mvc;

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