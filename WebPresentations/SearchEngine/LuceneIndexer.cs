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
using Version = Lucene.Net.Util.Version;

namespace WebPresentations.SearchEngine
{
    public static class LuceneIndexer
    {
        private static FSDirectory directory = null;

        private static FSDirectory Directory
        {
            get
            {
                return directory ??
                       (directory =
                        FSDirectory.Open(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\LuceneIndex")));
            }
            set { directory = value; }
        }

        public static void AddDocument(Document document)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            using (var writer = new IndexWriter(Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.AddDocument(document);
                writer.Optimize();
                writer.Commit();
                analyzer.Close();
            }
        }

        public static void ClearIndexRecord(int id)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            using (var writer = new IndexWriter(Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                var searchQuery = new TermQuery(new Term("Id", Convert.ToString(id)));
                writer.DeleteDocuments(searchQuery);
                analyzer.Close();
            }
        }

        public static List<Document> MultiQuery(string search, string[] searchFields)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            using (var indexSearcher = new IndexSearcher(Directory, false))
            {
                var queryParser = new MultiFieldQueryParser(Version.LUCENE_29, searchFields, analyzer);
                var query = queryParser.Parse(search);
                var hits = indexSearcher.Search(query,null,999,Sort.RELEVANCE).ScoreDocs;
                analyzer.Close();                
                return hits.Select(hit => indexSearcher.Doc(hit.Doc)).ToList();
            }
        }
    }
}