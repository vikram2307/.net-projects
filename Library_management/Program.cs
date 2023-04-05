using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management
{
    internal class Program
    {
        LibraryApi library = new LibraryApi();
        public void LibraryApiMenu()
        {
            
            Console.WriteLine("Librarian Console\n\nWelcome Librarian!");
            int choice;
            do
            {
                Console.WriteLine("\nWhat do you want to do?\n1.Add book\n2.Delete book\n3.Add Student\n4.Delete Student\n5.View all books\n6.View only issued books\n7.Exit\n\nEnter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        library.addBook();
                        break;

                    case 2:
                        library.deleteBook();
                        break;

                    case 3:
                        library.addStudent();
                        break;

                    case 4:
                        library.deleteStudent();
                        break;

                    case 5:
                        library.dispAllBook();
                        break;

                    case 6:
                        library.dispIssuedBook();
                        break;

                    case 7:
                        Program program = new Program();
                        break;
                }
            } while (choice != 8);
        }

        public void studentMenu()
        {
            Console.WriteLine("Student Console\n\nWelcome Student!");
            int choice;
            do
            {
                Console.WriteLine("\nWhat do you want to do?\n1.Search by book name\n2.Search by book author name\n3.Exit\n\nEnter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        library.searchBook();
                        break;
                    case 2:
                        library.searchAuthor();
                        break;
                    case 3:
                        Program program = new Program();
                        break;
                }
            } while (choice != 4);
        }

        public void FrontdeskMenu()
        {
            Console.WriteLine("Front Desk Console\n\nWelcome Front Desk!");
            int choice;
            do
            {
                Console.WriteLine("\nWhat do you want to do?\n1.Issue book to student\n2.Return book\n3.Exit\n\nEnter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        library.issueBook();
                        break;
                    case 2:
                        library.returnBook();
                        break;
                    case 3:
                        Program program = new Program();
                        break;
                }
            } while (choice != 4);
        }

        public Program() {
            Console.WriteLine("Welcome Page\n\nWelcome to the Read & Feel library!");
            int choice;
            do
            {
                Console.WriteLine("\nWho you are?\n1.Librarian\n2.Student\n3.Front Desk\n4.Exit\n\nEnter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        LibraryApiMenu();
                        break;
                    case 2:
                        studentMenu();
                        break;
                    case 3:
                        FrontdeskMenu();
                        break;
                }
            } while (choice != 4);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
             new Program();
        }
    }
}
