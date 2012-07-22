using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lucene.Net.Documents;
using Newtonsoft.Json.Linq;
using WebPresentations.Models;
using WebPresentations.SearchEngine;

namespace WebPresentations.DatabaseEntities
{
    public class EntitiesIndexer
    {
        public static void AddPresentationToIndex(Presentation presentation)
        {
            var document = new Document();
            foreach (var tag in presentation.Tags)
            {
                document.Add(new Field("Tags", tag.Text, Field.Store.YES, Field.Index.ANALYZED));  
            }
            foreach (var word in ParseTextData(presentation.Json))
            {
                document.Add(new Field("TextData", word, Field.Store.YES, Field.Index.ANALYZED)); 
            }
            document.Add(new Field("Id", Convert.ToString(presentation.PresentationId), Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Title", presentation.Title, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Description", presentation.Description, Field.Store.YES, Field.Index.ANALYZED));
            LuceneIndexer.AddDocument(document);
        }

        public static void UpdatePresentationIndex(Presentation presentation)
        {
            LuceneIndexer.ClearIndexRecord(presentation.PresentationId);
            AddPresentationToIndex(presentation);
        }

        public static void RemovePresentationFromIndex(int id)
        {
            LuceneIndexer.ClearIndexRecord(id);
        }

        private static List<String> ParseTextData(string data)
        {
            var json = JObject.Parse(System.Web.HttpUtility.UrlDecode(data));
            var output = new List<String>();
            foreach (var node in json["slides"])
            {
                foreach (var component in node["components"])
                {
                    foreach (var word in Regex.Split((string)component["text"], "<\\w+>?"))
                    {
                        if (!string.IsNullOrEmpty(word))
                        {
                            if (!output.Contains(word)) output.Add(word);
                        }
                    }
                }
            }
            return output;
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