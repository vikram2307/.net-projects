namespace TestProject1
{
    using Library_management;
    namespace LibraryManagementTestCase
    {
        public class Tests
        {
            Librarian library;

            [SetUp]
            public void Setup()
            {
                library = new Librarian();
            }

            [Test]
            public void AddBook()
            {

                Assert.IsTrue(library.addBook());
            }
            [Test]
            public void DeleteBook()
            {

                Assert.IsTrue(library.DeleteBook());
            }
            [Test]
            public void AddStudent()
            {

                Assert.IsTrue(library.AddStudent());
            }
            [Test]
            public void DeleteStudent()
            {

                Assert.IsTrue(library.DeleteStudent());
            }
            [Test]
            public void ViewAllBooks()
            {

                Assert.IsTrue(library.ViewAllBooks());
            }
            [Test]
            public void ViewOnlyIssuedBooks()
            {

                Assert.IsTrue(library.ViewOnlyIssuedBooks());
            }
            [Test]
            public void SearchByBookName()
            {

                Assert.IsTrue(library.SearchByBookName());
            }
            [Test]
            public void IssueBook()
            {

                Assert.IsTrue(library.IssueBook());
            }
            [Test]
            public void ReturnBook()
            {

                Assert.IsTrue(library.ReturnBook());
            }
            [Test]
            public void SearchByAuthorName()
            {

                Assert.IsTrue(library.SearchByAuthorName());
            }
        }
    }
}