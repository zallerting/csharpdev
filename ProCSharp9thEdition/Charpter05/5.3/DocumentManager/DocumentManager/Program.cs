using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Generics
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Document() { }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
    public class DocumentManager<TDocument>
        where TDocument:IDocument // where子句指定实现IDocument接口的要求
    {
        // 定义只读对象队列的先进先出集合
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
        // 定义向队列添加文档的方法
        public void AddDocument(TDocument doc)
        {
            lock(this)
            {
                // 将对象添加到Queue<T>的结尾处
                documentQueue.Enqueue(doc);
            }
        }
        // 定义从队列读取文档的方法
        public TDocument GetDocument()
        {
            // default：泛型根据类型是引用类型还是
            // 值类型，将泛型类型初始化为null或0
            TDocument doc = default(TDocument);
            lock (this)
            {
                // 移除并返回位于Queue<TDocument>开始处的对象
                doc = documentQueue.Dequeue();
            }
            return doc;
        }
        public bool IsDocumentAvailable
        {
            get
            {
                // 判断Queue<T>中的元素数是否大于0
                return documentQueue.Count > 0;
            }
        }
        public void DispalyAllDocuments()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "Content A"));
            dm.AddDocument(new Document("Ttile B", "Content B"));
            dm.DispalyAllDocuments();
            if (dm.IsDocumentAvailable)
            {
                Document d1 = dm.GetDocument();
                Document d2 = dm.GetDocument();
                Console.WriteLine(d1.Content);
                Console.WriteLine(d2.Content);
            }
            Console.Read();
        }
    }
}