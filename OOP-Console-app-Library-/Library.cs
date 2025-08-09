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



public void AddBook(Book book)
{
    for(int i = 0; i < Books.Count; i++)
    {
        if(Books[i].Title == book.Title)
        {
            Console.WriteLine($"The book with the name {book.Title} is already exist");
        }
        Books.Add(book);
    }
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
    if(Book.Count == 0)
    {
        Console.WriteLine("There is No Book at the moment!")
        }
    else{
            foreach (Book book in Books)
            {
                Console.WriteLine($"Name {book.Title}, and the Author is {book.Author} With The ISBN of {book.ID}");
            }
        }
}
    }
}
