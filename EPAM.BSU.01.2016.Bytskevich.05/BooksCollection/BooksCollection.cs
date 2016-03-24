using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBooksCollection
{
    public class BooksCollection
    {
        List<Book> collection = new List<Book>();

        public void AddBook(Book newBook)
        {
            if (collection.Contains(newBook))
                throw new DuplicateBookException("Book with such parameters already exists in this collection and can't be added one more time");
            collection.Add(newBook);
        }

        public void AddBook(string name, string author, string yearOfEdition, string genre)
        {
            Book newBook = new Book(name, author, yearOfEdition, genre);
            if (collection.Contains(newBook))
                throw new DuplicateBookException("Book with such parameters already exists in this collection and can't be added one more time");
            collection.Add(newBook);
        }

        public void RemoveBook(Book toBeRemoved)
        {
            if (!collection.Contains(toBeRemoved))
                throw new NotExistingBookException("Book with such parameters doesn't exist in collection and can't be removed");
            collection.Remove(toBeRemoved);
        }

        public void RemoveBook(string name, string author, string yearOfEdition, string genre)
        {
            Book toBeRemoved = new Book(name, author, yearOfEdition, genre);
            if (!collection.Contains(toBeRemoved))
                throw new NotExistingBookException("Book with such parameters doesn't exist in collection and can't be removed");
            collection.Remove(toBeRemoved);
        }

        public List<Book> FindByTag(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException("No parameter for search is given");
            List<Book> result = new List<Book>();
            foreach (Book book in collection)
                if (book.Name == tag || book.Author == tag || book.YearOfEdition == tag || book.Genre == tag)
                    result.Add((Book)book.Clone());
            return result;
        }

        public void SortBooksByTag(string tag)
        {
            tag = tag.ToLower();
            switch (tag)
            {
                case "n": case "name":
                      collection.Sort((first, second) => first.Name.CompareTo(second.Name));
                    break;
                case "a": case "author":
                    collection.Sort((first, second) => first.Author.CompareTo(second.Author));
                    break;
                case "y": case "year": case "yearofedition": case "edition":
                    collection.Sort((first, second) => first.YearOfEdition.CompareTo(second.YearOfEdition));
                    break;
                case "g": case "genre":
                    collection.Sort((first, second) => first.Genre.CompareTo(second.Genre));
                    break;
            }

                
            
        }

        public override string ToString()
        {
            string result = "";
            if (collection.Count == 0)
                result = "Books collection is empty";
            else
                result = collection.Aggregate(result, (current, book) => current + (book + "\n"));
            return result;
        }

        public void LoadCollection()
        {
            collection = BooksStorageAccessor.LoadCollection();
        }

        public void SaveCollection()
        {
            BooksStorageAccessor.SaveCollection(collection);
        }
    }

    class DuplicateBookException : Exception
    {
        public DuplicateBookException():base() { }
        public DuplicateBookException(string message):base(message) { }
        public DuplicateBookException(string message, Exception inner):base(message, inner) { }
    }

    class NotExistingBookException: Exception
    {
        public NotExistingBookException():base() { }
        public NotExistingBookException(string message):base(message) { }
        public NotExistingBookException(string message, Exception inner):base(message, inner) { }
    }

}
