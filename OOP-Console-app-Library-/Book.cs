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
 private bool Availability;
 

 

 public Book(string id, string title, string author)
 {
     if(ValidateID(id))
         ID = id;

     if(ValidateAuthor(author))
        Author = author;

     if (ValidateTitle(title))
        Title = title;
     
 }

 public bool ValidateTitle(string title)
 {
     if(string.IsNullOrWhiteSpace(title))
     {
         Console.WriteLine("Can't Create A Book Without a Title");
         return false;
     }
     return true;
 }
 public bool ValidateAuthor(string author)
 {
     if (string.IsNullOrWhiteSpace(author))
     {
         Console.WriteLine("Can't Create A Book Without a Author");
         return false;
     }
     return true;
 }
 public bool ValidateID(string ID)
 {
     if (string.IsNullOrWhiteSpace(ID) && (ID.Length == 10 || ID.Length == 13))
     {
         for (int i  = 0;  i < ID.Length; i++)
         {
             if (!char.IsDigit(ID[i]))
             {
                 Console.WriteLine("ID has to be only Numbers");
             }
         }
         return true;
     }
     return false;
 }
    }
}
