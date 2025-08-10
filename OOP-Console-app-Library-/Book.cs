using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Console_app_Library_
{
    internal class Book
    {
        public string ID;
        public string Title;
        public string Author;
        public bool Availability;




        public Book(string id, string title, string author)
        {
            if (ValidateID(id))
                ID = id;
            else throw new ArgumentException("Invalid Id");

            if (ValidateAuthor(author))
                Author = author;
            else throw new ArgumentException("Invalid Author Input");

            if (ValidateTitle(title))
                Title = title;
            else throw new ArgumentException("Invalid Title Input");

            Availability = true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {

                return false;
            }
            return true;
        }
        public bool ValidateAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {

                return false;
            }
            return true;
        }
        public bool ValidateID(string ID)
        {
            if (!string.IsNullOrWhiteSpace(ID) && (ID.Length == 10 || ID.Length == 13))
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    if (!char.IsDigit(ID[i]))
                    {
                        return false;


                    }

                }
                return true;
            }
            return false;
        }
    
    }
}
