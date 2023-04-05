using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management
{
    public class LibraryApi
    {
        int OriginalCopies, contact;
        String BookName, AuthorName, StudentName, dob, issueDate;
        string ConnectionString = "data source=DESKTOP-AI3GDBR;Initial catalog=Library_management;Integrated Security=true;";


        //Librarian Console
        public void addBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter book name:");
            BookName = Console.ReadLine();
            Console.WriteLine("Enter book author name:");
            AuthorName = Console.ReadLine();
            Console.WriteLine("Enter number of copies:");
            OriginalCopies = Convert.ToInt32(Console.ReadLine());
            string query = "insert into book(BookName,AuthorName,OriginalCopies,RemainingCopies) values('" + BookName + "','" + AuthorName + "'," + OriginalCopies + "," + OriginalCopies + ")";

            SqlCommand command = new SqlCommand(query, Connect);

            command.ExecuteNonQuery();
            Console.WriteLine("\nBook added successfully!");
        }

        public void deleteBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter book name:");
            BookName = Console.ReadLine();
            Console.WriteLine("Enter book author name:");
            AuthorName = Console.ReadLine();
            Console.WriteLine("Enter number of copies:");
            OriginalCopies = Convert.ToInt32(Console.ReadLine());
            SqlCommand command = new SqlCommand("delete from book where BookName = '" + BookName + "'", Connect);

            command.ExecuteNonQuery();
            Console.WriteLine("\nBook deleted successfully!");
        }

        public void addStudent()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter student name:");
            StudentName = Console.ReadLine();
            
            string query = "insert into student(StudentName,BookName) values('" + StudentName + "',null)";

            SqlCommand command = new SqlCommand(query, Connect);

            command.ExecuteNonQuery();
            Console.WriteLine("\nStudent added successfully!");
        }

        public void deleteStudent()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter student name:");
            StudentName = Console.ReadLine();
            SqlCommand command = new SqlCommand("delete from student where StudentName = '" + StudentName + "'", Connect);

            command.ExecuteNonQuery();
            Console.WriteLine("\nStudent deleted successfully!");
        }

        public void dispAllBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            SqlCommand command = new SqlCommand("select * from book", Connect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine("Book Name: " + reader["BookName"].ToString());
                Console.WriteLine("Author Name: " + reader["AuthorName"].ToString());
                Console.WriteLine("Number of copie: " + Convert.ToInt32(reader["OriginalCopies"].ToString()));
            }
            Console.WriteLine("\nDisplyaed all books successfully!");
        }

        public void dispIssuedBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            SqlCommand command = new SqlCommand("select distinct BookName from combo", Connect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Book Name: " + reader["BookName"].ToString());
            }
            Console.WriteLine("\nDisplayed only issued books successfully!");
        }

        //Student console
        public void searchBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter book name:");
            BookName = Console.ReadLine();
            SqlCommand command = new SqlCommand("select * from book where BookName='" + BookName + "'", Connect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine("Book Name: " + reader["BookName"].ToString());
                Console.WriteLine("Author Name: " + reader["AuthorName"].ToString());
                Console.WriteLine("Available Copies: " + Convert.ToInt32(reader["RemainingCopies"].ToString()));
            }
            reader.Close();
            SqlCommand command1 = new SqlCommand("select  COUNT(*) from combo where BookName='" + BookName + "'", Connect);
            Int32 count = Convert.ToInt32(command1.ExecuteScalar());

            Console.WriteLine("Copies issued out:" + count);
        }
        public void searchAuthor()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter book author name:");
            AuthorName = Console.ReadLine();
            SqlCommand command = new SqlCommand("select * from book where AuthorName='" + AuthorName + "'", Connect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                BookName = reader["BookName"].ToString();
                Console.WriteLine();
                Console.WriteLine("Book Name: " + reader["BookName"].ToString());
                Console.WriteLine("Author Name: " + reader["AuthorName"].ToString());
                Console.WriteLine("Available Copies: " + Convert.ToInt32(reader["RemainingCopies"].ToString()));
            }
            reader.Close();
            SqlCommand command1 = new SqlCommand("select  RemainingCopies,OriginalCopies from book where AuthorName='" + AuthorName + "'", Connect);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                Console.WriteLine("Copies issued out:" + (Convert.ToInt32(reader1["OriginalCopies"]) - Convert.ToInt32(reader1["RemainingCopies"])));
            }
        }


        //Front Desk Console
        public void issueBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter student name:");
            StudentName = Console.ReadLine();
            Console.WriteLine("Enter book name:");
            BookName = Console.ReadLine();
            Console.WriteLine("Enter issue date: ");
            issueDate = Console.ReadLine();
            Console.WriteLine("Enter number of copies:");
            OriginalCopies = Convert.ToInt32(Console.ReadLine());
            string query = "insert into combo values('" + StudentName + "','" + BookName + "','" + issueDate + "'," + OriginalCopies + ")";

            SqlCommand command = new SqlCommand(query, Connect);

            command.ExecuteNonQuery();

            string query1 = "update book set RemainingCopies =(RemainingCopies -" + OriginalCopies + ") where BookName='" + BookName + "' ";

            SqlCommand command1 = new SqlCommand(query1, Connect);

            command1.ExecuteNonQuery();

            string query2 = "update student set BookName='" + BookName + "' where StudentName='" + StudentName + "' ";

            SqlCommand command2 = new SqlCommand(query2, Connect);

            command2.ExecuteNonQuery();
        }

        public void returnBook()
        {
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
            Console.WriteLine("Enter student name:");
            StudentName = Console.ReadLine();
            Console.WriteLine("Enter book name:");
            BookName = Console.ReadLine();
            Console.WriteLine("Enter return date: ");
            issueDate = Console.ReadLine();
            Console.WriteLine("Enter number of copies:");
            OriginalCopies = Convert.ToInt32(Console.ReadLine());
            string query = "insert into combo values('" + StudentName + "','" + BookName + "','" + issueDate + "'," + OriginalCopies + ")";

            SqlCommand command = new SqlCommand(query, Connect);

            command.ExecuteNonQuery();
            string query1 = "update book set RemainingCopies =(RemainingCopies +" + OriginalCopies + ") where BookName='" + BookName + "' ";

            SqlCommand command1 = new SqlCommand(query1, Connect);

            command1.ExecuteNonQuery();

            string query2 = "update student set BookName=null where StudentName='" + StudentName + "' ";

            SqlCommand command2 = new SqlCommand(query2, Connect);

            command2.ExecuteNonQuery();
        }
    }
}
