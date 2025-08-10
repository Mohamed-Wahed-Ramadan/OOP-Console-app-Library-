using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Console_app_Library_
{
     internal class Member
 {
     public int Id;
     public static int IDcount = 0;
     public string Name;
     //public List<string> Names;
     //Names.remove(Name[i]);
     public int _borrowedBooks;

             public Member()
             {
       
             }
     public Member(string name)
     {
         if (string.IsNullOrWhiteSpace(name))
         {
             Console.WriteLine("Name cannot be empty.");
         }
         else
         {
             Name = name;
         }
         Id = IDcount++;
         _borrowedBooks = 0;
     }
          
        public void AddBorrowedBook(Book book)
        {
            Book[] newArray = new Book[_borrowedBooks.Length + 1];
            for (int i = 0; i < _borrowedBooks.Length; i++)
            {
                newArray[i] = _borrowedBooks[i];
            }
            newArray[newArray.Length - 1] = book;
            _borrowedBooks = newArray;
        }

        public void RemoveBorrowedBook(string bookId)
        {
            int count = 0;
            for (int i = 0; i < _borrowedBooks.Length; i++)
            {
                if (_borrowedBooks[i].ID != bookId)
                {
                    count++;
                }
            }

            Book[] newArray = new Book[count];
            int index = 0;
            for (int i = 0; i < _borrowedBooks.Length; i++)
            {
                if (_borrowedBooks[i].ID != bookId)
                {
                    newArray[index] = _borrowedBooks[i];
                    index++;
                }
            }
            _borrowedBooks = newArray;
        }
 }
}
