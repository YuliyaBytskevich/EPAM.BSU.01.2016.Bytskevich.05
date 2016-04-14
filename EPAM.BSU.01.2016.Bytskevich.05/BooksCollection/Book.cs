using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBooksCollection
{

    [Serializable]
    public class Book : ICloneable
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string YearOfEdition { get; set; }
        public string Genre { get; set; }       

        public Book() { }

        public Book(string name, string author, string yearOfEdition, string genre)
        {
            Name = name;
            Author = author;
            YearOfEdition = yearOfEdition;
            Genre = genre;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Book Clone()
        {
            return new Book(Name, Author, YearOfEdition, Genre);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Book book = obj as Book;
            if ((System.Object)book == null)
            {
                return false;
            }
            return (this.Name == book.Name && this.Author == book.Author && this.Genre == book.Genre &&
                    this.YearOfEdition == book.YearOfEdition);
        }


        public override string ToString()
        {
            return "\"" + Name + "\", " + Author + "; year of edition: " + YearOfEdition + ", [" + Genre + "]";
        }
    }
}
