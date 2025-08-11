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


        public Book ()
        {
            
        }

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
            // 1. لازم العنوان ما يكونش فاضي أو مسافات بس
            if (string.IsNullOrWhiteSpace(title))
                return false;

            // 2. لازم كل الحروف تكون إما حروف أو مسافات
            foreach (char c in title)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }

            return true; // لو عدت الشروط يبقى صالح
        }

        public bool ValidateAuthor(string author)
        {
            // 1. لازم اسم المؤلف ما يكونش فاضي أو مسافات بس
            if (string.IsNullOrWhiteSpace(author))
                return false;

            // 2. لازم كل الحروف تكون إما حروف أو مسافات
            foreach (char c in author)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }

            return true; // لو عدت الشروط يبقى صالح
        }

        public bool ValidateID(string ID)
        {
            if (!string.IsNullOrWhiteSpace(ID) ) 
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
