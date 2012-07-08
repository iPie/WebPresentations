using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebPresentations.Models;

namespace WebPresentations.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            return input.Length <= length ? input : input.Substring(0, length) + "...";
        }

        private class TagItem
        {
            public string Tag;
            public int Count;
        }

        private static int GetTagRank(this TagItem tag, int tagsCount)
        {
            var result = (tag.Count * 100) / tagsCount;
            if (result <= 1)
                return 1;
            if (result <= 4)
                return 2;
            if (result <= 8)
                return 3;
            if (result <= 12)
                return 4;
            if (result <= 18)
                return 5;
            if (result <= 30)
                return 6;
            return result <= 50 ? 7 : 8;
        }

        public static string TagCloud(this HtmlHelper helper)
        {
            var output = new StringBuilder();
            output.Append(@"<div class=""tags"">");
            using (var db = new PresentationsEntities())
            {
                var tags = from tag in db.Tags
                           where tag.Count > 0
                           select new TagItem { Tag = tag.Text, Count = tag.Count };
                foreach (var tag in tags)
                {
                    output.AppendFormat(@"<div class=""tag{0}"">",
                        GetTagRank(tag, tags.Count()));
                    output.Append(tag.Tag);
                    output.Append("</div>");
                }
            }
            output.Append("</div>");
            return output.ToString();
        }
    }


}