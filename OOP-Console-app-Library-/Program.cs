// See https://aka.ms/new-console-template for more information


using OOP_Console_app_Library_;

Library library1 = new Library();


string[] menuOptions = {
            "Add Book",
            "Remove Book",
            "Add Member",
            "Remove Member",
            "Borrow Book",
            "Return Book",
            "Edit Book",
            "Edit Member",
            "List Books",
            "List Members",
            "Exit"
        };

int selectedIndex = 0;         // mot8ayar 34an n7faz feh al mkan 
ConsoleKeyInfo keyInfo;        //hn5azen al qema bra3et al zorar 

do
{
    // مسح الشاشة
    Console.Clear();

    // عرض المنيو
    Console.WriteLine("Library Management System");
    Console.WriteLine("========================");
    Console.WriteLine();

    for (int i = 0; i < menuOptions.Length; i++)
    {
        if (i == selectedIndex)
        {
            // العنصر المحدد
            // hn8ayar al alwan 34an ykon bayen b 3enak 
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"> {menuOptions[i]} <");
            Console.ResetColor(); // hyraga3 al lon 
        }
        else
        {
            // العناصر العادية
            Console.WriteLine($"  {menuOptions[i]}");
        }
    }

    Console.WriteLine();

    // قراءة المفتاح المضغوط
    keyInfo = Console.ReadKey(true);       //الوسيط true معناه لا تطبع المفتاح على الشاشة (intercept) — القراءة تكون بدون ظهور الحرف.  // hy2ra al dost 3ala eh 

    // التحكم في التنقل
    if (keyInfo.Key == ConsoleKey.UpArrow)
    {
        selectedIndex--;
        if (selectedIndex < 0)
            selectedIndex = menuOptions.Length - 1;   // 34an ylef w ygy ta7t -1 34an bnbda2 b 0
    }
    else if (keyInfo.Key == ConsoleKey.DownArrow)
    {
        selectedIndex++;
        if (selectedIndex >= menuOptions.Length)
            selectedIndex = 0;
    }
    else if (keyInfo.Key == ConsoleKey.Enter)
    {
        Console.Clear();

        switch (selectedIndex)
        {
            case 0: // Add Book
                Console.Write("Enter Book ID: ");
                string addBookId = Console.ReadLine();
                Console.Write("Enter Title: ");
                string addTitle = Console.ReadLine();
                Console.Write("Enter Author: ");
                string addAuthor = Console.ReadLine();

                Book tempbook = new Book();
                bool isValid = true;

                if (!tempbook.ValidateID(addBookId))
                {
                    Console.WriteLine("Invalid ID");
                    isValid = false;
                }
                if (!tempbook.ValidateTitle(addTitle))
                {
                    Console.WriteLine("Invalid Title");
                    isValid = false;
                }
                if (!tempbook.ValidateAuthor(addAuthor))
                {
                    Console.WriteLine("Invalid Author");
                    isValid = false;
                }

                if (isValid)
                {
                    Book newBook = new Book(addBookId, addTitle, addAuthor);
                    if (library1.AddBook(newBook)) // لو رجعت true
                    {
                        Console.WriteLine($"Book '{addTitle}' added successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid book details. Please try again.");
                }
                break;

            case 1: // Remove Book

                 library1.Display_available_borrowed_books();
                Console.WriteLine("==============================================================================");     
                                
                Console.Write("Enter Book ID: ");
                string removeBookId = Console.ReadLine();
                Book bookToRemove = library1.FindBookById(removeBookId);   // hena hb3at al id 34an ageb al book  w ab3ato ll remove function

                if (bookToRemove != null)
                {
                    library1.RemoveBook(bookToRemove);
                    Console.WriteLine($"Book ID {bookToRemove.ID}.....Book title {bookToRemove.Title } removed successfully.");
                }
                break;

            case 2: // Add Member
             
                Console.Write("Enter Name: ");
                string addMemberName = Console.ReadLine();

                Member tempmember = new Member();
                bool isMemberValid = true;

                
                if (tempmember.ValidateName(addMemberName))
                {
                    isMemberValid = true;
                    Member newMember = new Member(addMemberName);
                    library1.AddMember(newMember);
                    Console.WriteLine($"Member '{addMemberName}' added successfully.");

                }
                else
                {
                    Console.WriteLine("Invalid Name");
                    isMemberValid = false;
                }
                break;

            case 3: // Remove Member
                library1.DisplayMember();
                Console.WriteLine("==============================================================================");
                                
                Console.Write("Enter Member ID: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int removeMemberId))
                {
                    Member membertoremove = library1.FindMemberById(removeMemberId);
                    if (membertoremove != null)
                    {
                        library1.RemoveMember(membertoremove);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please enter a numeric value.");
                }
            
               break;

            case 4: // Borrow Book

                library1.BorrowBook();
                break;

            case 5: // Return Book

                library1.ReturnBook();
                break;

           
            case 6:       //      "Edit Book",

                Console.WriteLine("edit book ");
                Console.WriteLine("===================================================");
                library1.Display_available_borrowed_books();
                Console.WriteLine("===================================================");
                Console.WriteLine("enter Id of book you want to edit  ");
                string editbook = Console.ReadLine();
                Book bookedit = library1.FindBookById(editbook);   // hena hb3at al id 34an ageb al book  w ab3ato ll remove function

                if (bookedit != null)
                {
                    Console.Write("Enter Book ID: ");
                    string editbookid = Console.ReadLine();
                    Console.Write("Enter Title: ");
                    string editbooktitle = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string editbookauthor = Console.ReadLine();

                    Book tempbookedit = new Book();
                    bool eidtisValid = true;

                    if (!tempbookedit.ValidateID(editbookid))
                    {
                        Console.WriteLine("Invalid ID");
                        eidtisValid = false;
                    }
                    if (!tempbookedit.ValidateTitle(editbooktitle))
                    {
                        Console.WriteLine("Invalid Title");
                        eidtisValid = false;
                    }
                    if (!tempbookedit.ValidateAuthor(editbookauthor))
                    {
                        Console.WriteLine("Invalid Author");
                        eidtisValid = false;
                    }

                    if (eidtisValid)
                    {
                        Book newBook = new Book(editbookid, editbooktitle, editbookauthor);
                        if (library1.AddBook(newBook)) // لو رجعت true
                        {
                            library1.RemoveBook(bookedit);
                            Console.WriteLine($"Book '{editbooktitle}' edited successfully.");
                            Console.WriteLine("==================");
                            Console.WriteLine("books after updated");
                            library1.Display_available_borrowed_books();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid book details. Please try again.");
                    }
                }


                break;
            case 7:          //     "Edit member",
                Console.WriteLine("edit member");
                Console.WriteLine("==================================================");
                library1.DisplayMember();
                Console.WriteLine("==================================================");
                Console.WriteLine("enter member id you want to edit ");
                string editmember = Console.ReadLine();

                if (int.TryParse(editmember, out int editMemberId))
                {
                    Member membertoedit = library1.FindMemberById(editMemberId);
                    if (membertoedit != null)
                    {
                        library1.editMember(membertoedit);
                        Console.Write("Enter new Name: ");
                        string editMemberName = Console.ReadLine();

                        Member tempmemberedit = new Member();
                        bool isMembereditValid = true;


                        if (tempmemberedit.ValidateName(editMemberName))
                        {
                            isMembereditValid = true;
                            Member newMemberedit = new Member(editMemberName);
                            library1.AddMember(newMemberedit);
                            Console.WriteLine($"Member '{editMemberName}' edit successfully.");

                        }
                        else
                        {
                            Console.WriteLine("Invalid Name");
                            isMemberValid = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please enter a numeric value.");
                }

                

                break;

            case 8: // List Books
                Console.WriteLine("Books in Library:");
                
                library1.Display_available_borrowed_books();
                break;

            case 9: // List Members
                Console.WriteLine("Library Members:");

                library1.DisplayMember();
                break;

            case 10: // Exit
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

} while (keyInfo.Key != ConsoleKey.Escape);

Console.WriteLine("Goodbye!");









