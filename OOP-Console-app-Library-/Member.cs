using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Console_app_Library_
{
    internal class Member
    {
         private int Id;
 private static int IDcount = 0;
 private string Name;
 //public List<string> Names;
 //Names.remove(Name[i]);

 private Book[] _borrowedBooks;

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

 public void removeMember(Member _Member)
 {
     for (int i = 0; i < IDcount; i++)
     {
         if (_borrowedBooks == 0 && _Member.Id == Id)
         {
             Console.WriteLine("Member found."); 
         }
         else
         {
             Console.WriteLine("Cannot remove member with borrowed books.");
         }
     }

 }
 public void DisplayMember()
 {
     for (int i = 0; i < IDcount; i++)
     {
         Console.WriteLine($"Member Name:{Name} and his Id: {Id}");
     }
 }
    }
}
