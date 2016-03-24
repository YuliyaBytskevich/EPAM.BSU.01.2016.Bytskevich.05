using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBooksCollection;

namespace BooksCollectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksCollection testCollection = new BooksCollection();
            testCollection.AddBook("Bridge", "Brian R. Senior", "1998", "education");
            testCollection.AddBook("How to be nice with people", "Darth Vader", "unknown", "social psychology");
            testCollection.SaveCollection();
            testCollection.LoadCollection();
            Console.Write(testCollection.ToString());
            Console.ReadLine();
        }
    }
}
