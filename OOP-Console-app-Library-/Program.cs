// See https://aka.ms/new-console-template for more information


string[] menuOptions = {
            "Add Book",
            "Remove Book",
            "Add Member",
            "Remove Member",
            "Borrow Book",
            "Return Book",
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
                Console.WriteLine($"Book '{addTitle}' added successfully.");
                break;

            case 1: // Remove Book
                Console.Write("Enter Book ID: ");
                string removeBookId = Console.ReadLine();
                Console.Write("Enter Title: ");
                string removeTitle = Console.ReadLine();
                Console.Write("Enter Author: ");
                string removeAuthor = Console.ReadLine();
                Console.WriteLine($"Book '{removeTitle}' removed successfully.");
                break;

            case 2: // Add Member
                Console.Write("Enter Member ID: ");
                string addMemberId = Console.ReadLine();
                Console.Write("Enter Name: ");
                string addMemberName = Console.ReadLine();
                Console.WriteLine($"Member '{addMemberName}' added successfully.");
                break;

            case 3: // Remove Member
                Console.Write("Enter Member ID: ");
                string removeMemberId = Console.ReadLine();
                Console.WriteLine($"Member 'Alice Smith' removed successfully.");
                break;

            case 4: // Borrow Book
                Console.Write("Enter Book ID: ");
                string borrowBookId = Console.ReadLine();
                Console.Write("Enter Member ID: ");
                string borrowMemberId = Console.ReadLine();
                Console.WriteLine("Book is not available.");
                break;

            case 5: // Return Book
                Console.Write("Enter Book ID: ");
                string returnBookId = Console.ReadLine();
                Console.Write("Enter Member ID: ");
                string returnMemberId = Console.ReadLine();
                Console.WriteLine("Alice Smith returned 'The Great Gatsby'.");
                break;

            case 6: // List Books
                Console.WriteLine("Books in Library:");
                Console.WriteLine("ID: 1, Title: The Great Gatsby, Author: F. Scott Fitzgerald, Available: True");
                Console.WriteLine("ID: 2, Title: 1984, Author: George Orwell, Available: True");
                break;

            case 7: // List Members
                Console.WriteLine("Library Members:");
                break;

            case 8: // Exit
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









