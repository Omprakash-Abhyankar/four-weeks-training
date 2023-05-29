
namespace LinqToObjectsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 30, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" }
            };
            //Write queries using LINQ for following operations


            //1. Get all people from USA
            var queryForPeopleInUSA = people.Where(e => e.Country == "USA");

            foreach (var person in queryForPeopleInUSA)
            {
                Console.WriteLine("Name: {0}, Country: {1}", person.Name, person.Country);
            }

            //2. Get all people above 30
            var queryForPeopleAbove30 = people.Where(e => e.Age > 30);

            foreach (var person in queryForPeopleAbove30)
            {
                Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age);
            }

            //3. Sort people by name
            var queryForSortPeopleByName = people.OrderBy(e => e.Name);

            foreach (var person in queryForSortPeopleByName)
            {
                Console.WriteLine("Name: {0}, Country: {1}, Age: {2}", person.Name, person.Country, person.Age);
            }

            //4. Project/Select only Name and Country of all people
            var queryForNameAndCountry = people.Select(p => new { p.Name, p.Country });

            foreach (var person in queryForNameAndCountry)
            {
                Console.WriteLine("Name: {0}, Country: {1}", person.Name, person.Country);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
