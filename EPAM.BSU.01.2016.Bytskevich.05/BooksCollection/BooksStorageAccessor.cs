using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WorkingWithBooksCollection
{
    public static class BooksStorageAccessor
    {

        public static void SaveCollection(IEnumerable<Book> collection)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("books_collection.bin", FileMode.Create)))
            {
                foreach (Book book in collection)
                {
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.YearOfEdition);
                    writer.Write(book.Genre);
                }             
            }
        }

        public static void SaveCollection(IEnumerable<Book> collection, IFormatter formatter)
        {
            using (Stream fStream = new FileStream("books_collection.bxml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fStream, collection);
            }
        }

        public static void SaveCollection(IEnumerable<Book> collection, XmlSerializer serializer)
        {
            serializer = new XmlSerializer(typeof(List<Book>));
            using (Stream fStream = new FileStream("books_collection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fStream, collection);
            }
        }

        public static List<Book> LoadCollection()
        {
            List<Book> result = new List<Book>();
            string name, author, yearOfEdition, genre;
            if (File.Exists("books_collection.bin"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open("books_collection.bin", FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        result.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString()));
                    }
                }
            }
            return result;
        }

        public static List<Book> LoadCollection(IFormatter formatter)
        {
            List<Book> loaded = new List<Book>();
            using (Stream fStream = new FileStream("books_collection.bxml", FileMode.Open))
            {
                loaded = (List<Book>)formatter.Deserialize(fStream);
            }
            return loaded;
        }

        public static List<Book> LoadCollection(XmlSerializer serializer)
        {
            serializer = new XmlSerializer(typeof(List<Book>));
            List<Book> loaded = new List<Book>();
            using (Stream fStream = new FileStream("books_collection.xml", FileMode.Open))
            {
                loaded = (List<Book>)serializer.Deserialize(fStream);
            }
            return loaded;
        }

    }
}
