using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using WorkingWithBooksCollection;

namespace BooksCollectionConsoleApp
{
    class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static BooksCollection testCollection = new BooksCollection();

        static void Main(string[] args)
        {        
            TryToLoadCollectionFromStorage();
            Console.WriteLine("BOOKS COLLECTION:");
            Console.WriteLine(testCollection.ToString());
            TryToAddNewBook("Some name", "Some author", "some year", "some genre");
            TryToAddNewBook("How to be nice with people", "Darth Vader", "unknown", "social psychology");
            TryToRemoveBook("Some name", "Some author", "some year", "some genre");
            TryToRemoveBook("you", "will", "never", "sleep enough");
            TryToFindByTag("programming");
            TryToFindByTag("unknown");
            TryToSortBooksByTag("author");
            Console.WriteLine("BOOKS COLLECTION:");
            Console.WriteLine(testCollection.ToString());
            TryToSaveCollection();
            Console.ReadLine();
        }

        private static void TryToLoadCollectionFromStorage()
        {
            try
            {
                logger.Trace("Loading collection from storage...");
                testCollection.LoadCollection();
                logger.Trace("... collection loaded successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToAddNewBook(string name, string author, string yearOfEdition, string genre)
        {
            try
            {
                logger.Trace("Adding book with parameters [" + name + "," + author + "," + yearOfEdition + "," + genre +"]...");
                testCollection.AddBook(name, author, yearOfEdition, genre);
                logger.Trace("...book has been added successfully\n");

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToRemoveBook(string name, string author, string yearOfEdition, string genre)
        {
            try
            {
                logger.Trace("Removing book with parameters [" + name + "," + author + "," + yearOfEdition + "," + genre + "]...");
                testCollection.RemoveBook(name, author, yearOfEdition, genre);
                logger.Trace("...book has been removed successfully\n");

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToFindByTag(string tag)
        {
            try
            {
                logger.Trace("Trying to find book by tag '" + tag + "'...");
                List<Book> searchResults =  testCollection.FindByTag(tag);
                foreach (Book book in searchResults)
                {
                    Console.WriteLine("Book found: " + book);
                }
                logger.Trace("..."+ searchResults.Count +" book(-s) found\n");

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToSortBooksByTag(string tag)
        {
            try
            {
                logger.Trace("Sorting book by tag '" + tag + "'...");
                List<Book> searchResults = testCollection.FindByTag(tag);
                testCollection.SortBooksByTag(tag);
                logger.Trace("... books are sorted\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToSaveCollection()
        {
            try
            {
                logger.Trace("Saving collection to storage...");
                testCollection.SaveCollection();
                logger.Trace("... collection saved successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

    }
}
