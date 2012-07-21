﻿using System;
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
    public class LuceneIndexer : IDisposable
    {
        private Directory _directory;

        private Analyzer _analyzer;

        public LuceneIndexer()
        {
            _directory = Directory;
        }

        public LuceneIndexer(Directory luceneIndexPath)
        {
            _directory = luceneIndexPath;
        }

        private Analyzer Analyzer
        {
            get { return _analyzer ?? (_analyzer = new StandardAnalyzer(Version.LUCENE_29)); }
        }

        private Directory Directory
        {
            get { return _directory ?? (_directory = FSDirectory.Open((new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\LuceneIndex")))); }
        }

        public void Dispose()
        {
            _analyzer.Dispose();
            _directory.Close();
        }

        public void AddDocument(Document document)
        {
            var writer = new IndexWriter(Directory, Analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            writer.AddDocument(document);
            writer.Optimize();
            writer.Close();
            writer.Commit();
        }

        public List<Document> MultiQuery(string search, string[] searchFields)
        {
            var indexReader = IndexReader.Open(Directory, true);
            using (var indexSearch = new IndexSearcher(indexReader))
            {
                var queryParser = new MultiFieldQueryParser(Version.LUCENE_29, searchFields, Analyzer);
                var query = queryParser.Parse(search);
                var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
                var hits = resultDocs.ScoreDocs;
                return hits.Select(hit => indexSearch.Doc(hit.Doc)).ToList();
            }
        }
    }
}