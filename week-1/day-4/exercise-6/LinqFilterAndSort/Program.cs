
namespace LinqFilterAndSort
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            // Use LINQ to filter and sort the list
            // Print the filtered and sorted list of people to the console

            // Create a list of Person objects
            List<Person> people = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 17 },
            new Person { FirstName = "Bob", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Alice", LastName = "Jones", Age = 20 },
            new Person { FirstName = "Mike", LastName = "Williams", Age = 18 }
        };

            // Use LINQ to filter the list to only include people who are 18 years old or older
            var filteredPeople = from person in people
                                 where person.Age >= 18
                                 select person;

            // Use LINQ to sort the filtered list by last name, then by first name
            var sortedPeople = from person in filteredPeople
                               orderby person.LastName, person.FirstName
                               select person;

            // Print the filtered and sorted list of people to the console
            foreach (var person in sortedPeople)
            {
                Console.WriteLine("{0} {1} ({2})", person.FirstName, person.LastName, person.Age);
            }
        }
    }
}
