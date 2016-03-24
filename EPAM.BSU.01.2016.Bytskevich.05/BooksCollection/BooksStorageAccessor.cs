using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkingWithBooksCollection
{
    public static class BooksStorageAccessor
    {
        const string path = "books_collection.bin";

        public static void SaveCollection(List<Book> collection)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
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

        public static List<Book> LoadCollection()
        {
            List<Book> result = new List<Book>();
            string name, author, yearOfEdition, genre;
            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                       /* name = reader.ReadString();
                        author = reader.ReadString();
                        yearOfEdition = reader.ReadString();
                        genre = reader.ReadString();*/
                        result.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString()));
                    }
                }
            }
            return result;
        }

    }
}
