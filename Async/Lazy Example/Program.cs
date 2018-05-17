using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lazy_Example
{
    public class Person
    {
        public Person(string name)
        {
            Thread.Sleep(500);
            Name = name;
            Console.WriteLine("Created");
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", Name, Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lazyPerson = new Lazy<Person>(()=>new Person(""));
            Console.WriteLine("Lazy object created");
            Console.WriteLine("has person been created {0}", lazyPerson.IsValueCreated ? "Yes" : "No");
            Console.WriteLine("Setting Name");
            lazyPerson.Value.Name = "Andy";
            Console.WriteLine("Setting Age");
            lazyPerson.Value.Age = 21; // Re-uses same object from first call to Value
            Person andy = lazyPerson.Value;
            Console.WriteLine(andy);


            var lazyPerson2 = new Lazy<Person>(() => new Person("x"), LazyThreadSafetyMode.ExecutionAndPublication);
            Task<Person> p1 = Task.Run(() => lazyPerson2.Value);
            Task<Person> p2 = Task.Run(() => lazyPerson2.Value);

            Console.WriteLine(object.ReferenceEquals(p1.Result, p2.Result));
            Console.ReadLine();
        }
    }
}
