using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lucene.Net.Documents;
using WebPresentations.Models;
using WebPresentations.SearchEngine;

namespace WebPresentations.DatabaseEntities
{
    public class EntitiesIndexer
    {
        public static void AddPresentationToIndex(Presentation presentation)
        {
            var document = new Document();
            var tags = new StringBuilder();
            foreach (var tag in presentation.Tags)
            {
                tags.Append(tag.Text);
                tags.Append(" ");
            }
            document.Add(new Field("Id", presentation.PresentationId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Title", presentation.Title, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Tags", tags.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Description", presentation.Description, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("TextData", ParseTextData(presentation.Json), Field.Store.YES, Field.Index.ANALYZED));
            LuceneIndexer.AddDocument(document);

        }

        private static string ParseTextData(string data)
        {
            var output = new StringBuilder();
            string pattern = "(?<=\"text\":\")([^\"])*(?=\")";
            foreach (var token in Regex.Matches(System.Web.HttpUtility.UrlDecode(data), pattern))
            {
                foreach (var word in Regex.Split(token.ToString(), "<\\w+>?"))
                {
                    if (!string.IsNullOrEmpty(word))
                        output.Append(word).Append(" ");
                }
            }
            return output.ToString();
        }

        private static IEnumerable<int> FullTextSearch(string search)
        {

            string[] fields = { "Title", "Tags", "Description", "TextData" };
            var query = LuceneIndexer.MultiQuery(search, fields);
            return query.Select(document => int.Parse(document.Get("Id"))).ToList();

        }

        public static List<Presentation> QueryPresentations(string search)
        {
            var indexes = FullTextSearch(search);
            using (var db = new PresentationsEntities())
            {
                return indexes.Select(id => db.Presentations.Include("Tags").Include("LikedUsers").Single(p => p.PresentationId == id)).ToList();
            }
        }

    }
}