using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Console_app_Library_
{
    internal class Library
    {
        public List<Book> Books;
        public List<Member> Members;

        
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
        public void RemoveMember(Member member)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Name == member.Name && member.BorrowedBooks == 0)
                {
                    Members.Remove(Members[i]);
                    Console.WriteLine($"The Member with the name {member.Name} is removed");
                    return;
                }
                if (member.BorrowedBooks != 0)
                {
                    Console.WriteLine($"The Member with the name {member.Name} cannot be removed because they have borrowed books.");
                }

                Console.WriteLine($"The Member with the name {member.Name} is not found");
            }
        }

     public void DisplayMember()
     {
         if (Member.IDcount == 0)
         {
                Console.WriteLine("No members found.");
                return;
         }
         for (int i = 0; i < Member.IDcount; i++)
         {
               Console.WriteLine($"Member Name:{Members[i].Name} and his Id: {Members[i].Id} NumberofBooksBorrowed: {Members[i].BorrowedBooks}");
         }
     }

public void AddBook(Book book)
{
    for(int i = 0; i < Books.Count; i++)
    {
        if(Books[i].Title == book.Title)
        {
            Console.WriteLine($"The book with the name {book.Title} is already exist");
        }
    }
        Books.Add(book);
}

public void RemoveBook(Book book)
{
    for (int i = 0;i < Books.Count;i++)
    {
        if (Books[i].Title == book.Title)
        {
            Books.Remove(Books[i]);
        }
        Console.WriteLine($"The Book with the name {book.Title} Maybe removed already");
    }
}

public void GetBooks()
{
            if (Book.Count == 0)
            {
                Console.WriteLine("There is No Book at the moment!")
                }
            else
            {
                foreach (Book book in Books)
                {
                    Console.WriteLine($"Name {book.Title}, and the Author is {book.Author} With The ISBN of {book.ID}");
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
