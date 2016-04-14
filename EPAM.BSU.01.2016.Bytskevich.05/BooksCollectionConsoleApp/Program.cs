using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NLog;
using WorkingWithBooksCollection;

namespace BooksCollectionConsoleApp
{
    class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static BooksCollectionService _testCollectionService = new BooksCollectionService();

        static void Main(string[] args)
        {               
            TryToLoadCollectionFromStorage();
            TryToLoadWithBinaryFormatter();
            TryToLoadWithXmlSerializer();
            Console.WriteLine("BOOKS COLLECTION:");
            Console.WriteLine(_testCollectionService.ToString());
            TryToAddNewBook("Some name", "Some author", "some year", "some genre");
            TryToAddNewBook("How to be nice with people", "Darth Vader", "unknown", "social psychology");
            TryToAddNewBook("How to be nice with people", "Darth Vader", "unknown", "social psychology");
            TryToRemoveBook("Some name", "Some author", "some year", "some genre");
            TryToRemoveBook("you", "will", "never", "sleep enough");
            TryToFindByTag("programming");
            TryToFindByTag("unknown");
            TryToSortBooksByTag("author");
            Console.WriteLine("BOOKS COLLECTION:");
            Console.WriteLine(_testCollectionService.ToString());
            TryToSaveWithXmlSerializer();
            TryToSaveWithBinaryFormatter();
            TryToSaveCollection();
            Console.ReadLine();
        }

        private static void TryToLoadCollectionFromStorage()
        {
            try
            {
                logger.Trace("Loading collection from storage...");
                _testCollectionService.LoadCollection();
                logger.Trace("... collection loaded successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToLoadWithBinaryFormatter()
        {
            try
            {
                logger.Trace("Loading collection with BinaryFormetter...");
                _testCollectionService.LoadCollection(new BinaryFormatter());
                logger.Trace("... collection loaded successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToLoadWithXmlSerializer()
        {
            try
            {
                logger.Trace("Loading collection with XmlSerializer...");
                _testCollectionService.LoadCollection(new XmlSerializer(typeof(Book)));
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
                _testCollectionService.AddBook(name, author, yearOfEdition, genre);
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
                _testCollectionService.RemoveBook(name, author, yearOfEdition, genre);
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
                List<Book> searchResults =  _testCollectionService.FindByTag(tag);
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
                List<Book> searchResults = _testCollectionService.FindByTag(tag);
                _testCollectionService.SortBooksByTag(tag);
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
                _testCollectionService.SaveCollection();
                logger.Trace("... collection saved successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToSaveWithBinaryFormatter()
        {
            try
            {
                logger.Trace("Saving collection to storage with BinaryFormatter...");
                //_testCollectionService.SaveCollection();
                _testCollectionService.SaveCollection(new BinaryFormatter());
                
                logger.Trace("... collection saved successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

        private static void TryToSaveWithXmlSerializer()
        {
            try
            {
                logger.Trace("Saving collection to storage with XmlSerializer...");
                _testCollectionService.SaveCollection(new XmlSerializer(typeof(List<Book>)));
                logger.Trace("... collection saved successfully\n");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "\n");
            }
        }

    }
}
