using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkingWithBooksCollection
{
    public static class BooksCollectionServiceExtensions
    {
        public static void LoadCollection(this BooksCollectionService service, IFormatter formatter)
        {
            List<Book> loadedCollection = BooksStorageAccessor.LoadCollection(formatter);
            foreach (var book in loadedCollection)
              {
                  try { service.AddBook(book); }
                  catch { /* do nothing */ }
              }
        }

        public static void LoadCollection(this BooksCollectionService service, XmlSerializer serializer)
        {
            List<Book> loadedCollection = BooksStorageAccessor.LoadCollection(serializer);
            foreach (var book in loadedCollection)
            {
                try { service.AddBook(book); }
                catch { /* do nothing */ }
            }
        }

        public static void SaveCollection(this BooksCollectionService service, IFormatter formatter)
        {
           BooksStorageAccessor.SaveCollection(service.GetCollectionCopy(), formatter);
        }

        public static void SaveCollection(this BooksCollectionService service, XmlSerializer serializer)
        {
            BooksStorageAccessor.SaveCollection(service.GetCollectionCopy(), serializer);
        }

    }
}
