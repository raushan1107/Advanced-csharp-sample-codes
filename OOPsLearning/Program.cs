using System.Threading.Channels;

namespace OOPsLearning
{
    class Human
    {
        private int age;

        public string Name { get; set; } // auto property

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid age!");
                    return;
                }
                age = value;
            }
        }

        public int YearOfBirth => DateTime.Now.Year - age;
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            HumanDetails();
        }
        static void HumanDetails()
        {
            Human p = new Human();

            p.Name = "Ritu";
            p.Age = 25;

            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age);
            Console.WriteLine(p.YearOfBirth);
        }
    }

    //Person p9 = new Person { Name = "Raushan", Age = 30 };

    //// Let's explore OOPs concepts in C#
    //Console.WriteLine("OOPs Learning in C#");
    //Dog dog = new Dog();
    //dog.Speak(); // Inherited method
    //dog.Bark();  // Dog's own method

    //Cat cat = new Cat();
    //cat.Speak(); // Inherited method
    //cat.Meow();  // Cat's own method

    //// Demonstrating polymorphism
    //Animal myAnimal = new Dog();
    //myAnimal.Eat(); // Calls Dog's overridden Eat method
    //myAnimal = new Cat();
    //myAnimal.Eat(); // Calls Cat's overridden Eat method


    //// What are the four main principles of OOPs?
    //// 1. Encapsulation: Bundling data and methods that operate on the data within a single unit (class).
    //// 2. Inheritance: Mechanism by which one class can inherit properties and methods from another class.
    //// 3. Polymorphism: Ability of different classes to be treated as instances of the same class through a common interface, typically via method overriding or overloading.
    //// 4. Abstraction: Hiding complex implementation details and showing only the essential features of the object.

    //// Let's demonstrate encapsulation with a simple class
    //Person person = new Person ("T", 11);
    ////Person p = new Person()
    ////person.Name = "Alice";
    ////person.Age = 30;
    //Console.WriteLine($"Person Name: {person.Name}, Age: {person.Age}");

    //// Trying to set a negative age
    //person.Age = -5; // This should trigger the validation message

    //// Let's demonstrate abstraction here:
    //// In C#, abstraction is often implemented using abstract classes or interfaces.

    //Shape circle = new Circle(5);
    //Console.WriteLine($"Area of the circle with radius 5: {circle.Area()}");
    public class Animal
    {
        public void Speak()
        {
            Console.WriteLine("The animal makes a sound.");
        }
        // virtual method example
        public virtual void Eat()
        {
            Console.WriteLine("The Animal is eating.");
        }
    }

    public class Dog : Animal
    {
        public void Speak()
        {
            Console.WriteLine("The dog makes a sound.");
        }
        public void Bark()
        {
            Console.WriteLine("The dog barks.");
        }
        // virtual method example
        public override void Eat()
        {
            Console.WriteLine("The Dog is eating dog food.");
        }

    }

    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("The cat meows.");
        }
        // virtual method example
        public override void Eat()
        {
            Console.WriteLine("The Cat is eating cat food.");
        }
    }

    public class Person
    {
        // Encapsulated fields
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Person()
        {
            Console.WriteLine("Con without parameter");
        }
        //public string message {  get; set; }

        //public Person(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //}

        // Public properties to access the fields
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Age cannot be negative.");
                }
            }
        }
    }

    // Let's demonstrate abstraction with an abstract class
    public abstract class Shape
    {
        // Abstract method (does not have a body)
        public abstract double Area();
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        // Implementing the abstract method
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }
}
