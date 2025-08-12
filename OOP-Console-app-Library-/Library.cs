using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Console_app_Library_
{
    internal class Library
    {
        public List<Book> Books;
        public List<Member> Members;


        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }


        public void AddMember(Member Member)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Name == Member.Name)
                {
                    Console.WriteLine($"The Member with the name {Member.Name} is already exist");
                    return;
                }
            }
            Members.Add(Member);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public Member FindMemberById(int memberId)
        {
            foreach (Member member in Members)
            {
                if (member.Id == memberId)
                {
                    return member; // لو لقيت العضو، برجّع الأوبجكت
                }
            }
            Console.WriteLine($"member with ID '{memberId}' was not found.");

            return null; // لو مش لقيت، برجع null
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void RemoveMember(Member member)
        {
          if (member.BorrowedBooks == 0)
            {
                Members.Remove(member);
                Console.WriteLine($"The Member with the name {member.Name} is removed");
            }
            else
            {
                Console.WriteLine($"The Member with the name {member.Name} cannot be removed because they have borrowed books.");
            }
        }

////////////////////////////////////////////////////////////////////
        public void editMember(Member member)
        {
          if (member.BorrowedBooks == 0)
            {
                Members.Remove(member);
            }
            else
            {
                Console.WriteLine($"The Member with the name {member.Name} cannot be removed because they have borrowed books.");
            }

        }
    public void DisplayMember()
 {
     if (Members.Count == 0)
     {
         Console.WriteLine("No members found.");
         return;
     }
     for (int i = 0; i < Members.Count; i++)
     {
         Console.WriteLine($"Member Name:{Members[i].Name} and his Id: {Members[i].Id} NumberofBooksBorrowed: {Members[i].BorrowedBooks}");
     }
 }

        public bool AddBook(Book book)
        {
            for(int i = 0; i < Books.Count; i++)
            {
                if(Books[i].ID == book.ID)
                {
                    Console.WriteLine($"The book with the id {book.ID} is already exist");
                    return false; // الكتاب ما اتضافش
                }
                if (Books[i].Title == book.Title)
                {
                    Console.WriteLine($"The book with the name {book.Title} is already exist");
                    return false; // الكتاب ما اتضافش
                }
            }
                Books.Add(book);
                 return true; // الكتاب اتضاف

        }

        ////////////////////////////////////////////////////////////////////////////////////
        public Book FindBookById(string bookId)  ///////////////// de function 34an ageb al book w amsa7o b3dha 
        {
            foreach (Book book in Books)
            {
                if (book.ID == bookId)
                {
                    return book; // لو لقيت الكتاب برجّع الأوبجكت نفسه
                }
            }
            Console.WriteLine($"Book with ID '{bookId}' was not found.");
            return null; // لو مش لقيت الكتاب برجع null
        }
        /////////////////////////////////////////////////////////////////////////////////
           
        public void RemoveBook(Book book)
        {
            if (!book.Availability)
            {
                Console.WriteLine("Can't Remove a book while it's borrowed");
            }
            else
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].Title == book.Title)
                    {
                        Books.RemoveAt(i);
                        return;
                    }
                }
                Console.WriteLine($"The Book with the name {book.Title} Maybe removed already");
            }
        }

        public void GetBooks()
        {
            if(Books.Count == 0)
            {
                Console.WriteLine("No Books to be Printed!");
                    return;
                }
            else{
                    foreach (Book book in Books)
                    {
                        Console.WriteLine($"Name {book.Title}, and the Author is {book.Author} With The ISBN of {book.ID}, Availability: {(book.Availability ? "Yes" : "No")}");
                    }
                }
        }

         public void Display_available_borrowed_books()
         {
             if (Books.Count == 0)
             {
                 Console.WriteLine("There aren't found any book to display");
                 return;
             }
             int c = 0;
             if(Books.Count > 0)
             {
                 Console.WriteLine("all available book");
                 foreach (Book book in Books)
                 {
                     if (book.Availability)
                     {
                         Console.WriteLine($"Name {book.Title}, With The ISBN of {book.ID} is available");
                         c++;
                     }
                 }
             }
    
             if(c < Books.Count)
             {
                 Console.WriteLine("all borrowed book");
                 foreach (Book book in Books)
                 {
                     if (!book.Availability)
                     {
                         Console.WriteLine($"Name {book.Title}, With The ISBN of {book.ID} is borrowed");
                     }
                 }
             }
         }
         public void BorrowBook()
         {
             Display_available_borrowed_books();

             Console.Write("Enter Book ID: ");
             string b_id = Console.ReadLine();

             Console.Write("Enter Member ID: ");
             int m_id;
             if (!int.TryParse(Console.ReadLine(), out m_id))
             {
                 Console.WriteLine("Member ID must be a valid number.");
                 return;
             }

             /////////////////// Find the book//////////////
             Book foundBook = null;
             for (int i = 0; i < Books.Count; i++)
             {
                 if (Books[i].ID == b_id)
                 {
                     foundBook = Books[i];
                     break;
                 }
             }

             if (foundBook == null)
             {
                 Console.WriteLine("Book not found.");
                 return;
             }

             if (!foundBook.Availability)
             {
                 Console.WriteLine("Book is already borrowed.");
                 return;
             }

             // Find the member
             Member foundMember = null;
             for (int i = 0; i < Members.Count; i++)
             {
                 if (Members[i].Id == m_id)
                 {
                     foundMember = Members[i];
                     break;
                 }
             }

             if (foundMember == null)
             {
                 Console.WriteLine("Member not found.");
                 return;
             }

             // Borrow the book
             foundBook.Availability = false;
             foundMember.AddBorrowedBook(foundBook);
             Console.WriteLine("Book borrowed successfully.");
         }


         public void ReturnBook()
         {
             Display_available_borrowed_books();

             Console.Write("Enter Book ID: ");
             string b_id = Console.ReadLine();

             Console.Write("Enter Member ID: ");
             int m_id;
             if (!int.TryParse(Console.ReadLine(), out m_id))
             {
                 Console.WriteLine("Member ID must be a valid number.");
                 return;
             }

             // Find the book
             Book foundBook = null;
             for (int i = 0; i < Books.Count; i++)
             {
                 if (Books[i].ID == b_id)
                 {
                     foundBook = Books[i];
                     break;
                 }
             }

             if (foundBook == null)
             {
                 Console.WriteLine("Book not found.");
                 return;
             }

             if (foundBook.Availability)
             {
                 Console.WriteLine("Book is not borrowed.");
                 return;
             }

             // Find the member
             Member foundMember = null;
             for (int i = 0; i < Members.Count; i++)
             {
                 if (Members[i].Id == m_id)
                 {
                     foundMember = Members[i];
                     break;
                 }
             }

             if (foundMember == null)
             {
                 Console.WriteLine("Member not found.");
                 return;
             }

             // Return the book
             foundBook.Availability = true;
             foundMember.RemoveBorrowedBook(b_id);
             Console.WriteLine("Book returned successfully.");
         }
            }
}
