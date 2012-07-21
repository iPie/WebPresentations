using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;

namespace WebPresentations.SearchEngine
{
    public class LuceneIndexer
    {
        private static Directory GetDirectory()
        {
            return FSDirectory.Open(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\LuceneIndex"));
        }

        private static Analyzer GetAnalyzer()
        {
            return new StandardAnalyzer(Version.LUCENE_29);
        } 

        public static void AddDocument(Document document)
        {
            var directory = GetDirectory();
            var analyzer = GetAnalyzer();
            var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.LIMITED);
            writer.AddDocument(document);
            writer.Optimize();
            writer.Commit();
            writer.Close();
        }

        public static List<Document> MultiQuery(string search, string[] searchFields)
        {
            var directory = GetDirectory();
            var analyzer = GetAnalyzer();
            var indexReader = IndexReader.Open(directory, true);
            var indexSearch = new IndexSearcher(indexReader);

            var queryParser = new MultiFieldQueryParser(Version.LUCENE_29, searchFields, analyzer);
            var query = queryParser.Parse(search);
            var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
            var hits = resultDocs.ScoreDocs;
            return hits.Select(hit => indexSearch.Doc(hit.Doc)).ToList();

        }
    }
}