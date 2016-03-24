using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBooksCollection
{
    public class Book : ICloneable
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string YearOfEdition { get; private set; }
        public string Genre { get; private set; }       

        public Book(string name, string author, string yearOfEdition, string genre)
        {
            Name = name;
            Author = author;
            YearOfEdition = yearOfEdition;
            Genre = genre;
        }

        public object Clone()
        {
            return new Book(Name, Author, YearOfEdition, Genre);
        }

        public override string ToString()
        {
            return "\"" + Name + "\", " + Author + "; year of edition: " + YearOfEdition + ", [" + Genre + "]";
        }
    }
}
