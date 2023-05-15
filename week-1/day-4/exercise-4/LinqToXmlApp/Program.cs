using System.Xml.Linq;

namespace LinqToXmlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assume there is an XML document with the following structure:
            // <Books>
            //     <Book>
            //         <Title>Book Title 1</Title>
            //         <Author>Author 1</Author>
            //         <Genre>Genre 1</Genre>
            //     </Book>
            //     ...
            // </Books>
            // Write above book structure as a c# string
            string xmlString = @"<Books>
                                    <Book>
                                        <Title>Book Title 1</Title>
                                        <Author>Author 1</Author>
                                        <Genre>Genre 1</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 2</Title>
                                        <Author>Author 2</Author>
                                        <Genre>Genre 2</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 3</Title>
                                        <Author>Author 3</Author>
                                        <Genre>Genre 3</Genre>
                                    </Book>
                                </Books>";

            // Create an XDocument object from the XML string

            // Write the title of all books to the console

            // Write the title of all books with genre "Genre 1" to the console


            XDocument doc = XDocument.Parse(xmlString);

            // Iterate over all <book> elements and write their titles to the console
            foreach (XElement bookElement in doc.Descendants("Book"))
            {
                string title = bookElement.Element("Title").Value;
                Console.WriteLine(title);
            }

            // Use LINQ to filter <book> elements by genre
            IEnumerable<XElement> books = doc.Descendants("Book")
                .Where(b => (string)b.Element("Genre") == "Genre 1");

            // Iterate over filtered <book> elements and write their titles to the console
            foreach (XElement bookElement in books)
            {
                string title = bookElement.Element("Title").Value;
                Console.WriteLine(title);
            }

        }
    }
}