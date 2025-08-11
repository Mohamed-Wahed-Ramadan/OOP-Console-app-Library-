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
public int BorrowedBooks;


public Member()
{
    
}


            public Member(string Name)
            {
                if (ValidateName(Name))
                this.Name = Name;
                Id = IDcount++;
                BorrowedBooks = 0;
            }

        public bool ValidateName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Name Is Not Valid");
                return false;
            }
            return true;
        }

     public List<Book> _BorrowedBooks = new List<Book>();

     public void AddBorrowedBook(Book book)
      {
          _BorrowedBooks.Add(book);
          BorrowedBooks = _BorrowedBooks.Count;
      }

      public void RemoveBorrowedBook(string bookId)
      {
          List<Book> newList = new List<Book>();
          for (int i = 0; i < _BorrowedBooks.Count; i++)
          {
              if (_BorrowedBooks[i].ID != bookId)
              {
                  newList.Add(_BorrowedBooks[i]);

              }
          }
          _BorrowedBooks = newList;
          BorrowedBooks = _BorrowedBooks.Count;
      }
    }
}
