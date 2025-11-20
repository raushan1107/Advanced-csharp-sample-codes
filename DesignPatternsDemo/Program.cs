using System;
using System.Collections.Generic;

namespace DesignPatternsTeachingApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== DESIGN PATTERNS TEACHING APP ==========");
                Console.WriteLine("1. Singleton");
                Console.WriteLine("2. Factory");
                Console.WriteLine("3. Builder");
                Console.WriteLine("4. Adapter");
                Console.WriteLine("5. Decorator");
                Console.WriteLine("6. Observer");
                Console.WriteLine("7. Command");
                Console.WriteLine("8. Strategy");
                Console.WriteLine("9. Exit");
                Console.WriteLine("11. Summary of All Patterns");
                Console.Write("Choose option: ");

                string input = Console.ReadLine();
                Console.WriteLine("\n--------------------------------------\n");

                switch (input)
                {
                    case "1": SingletonDemo.Run(); break;
                    case "2": FactoryDemo.Run(); break;
                    case "3": BuilderDemo.Run(); break;
                    case "4": AdapterDemo.Run(); break;
                    case "5": DecoratorDemo.Run(); break;
                    case "6": ObserverDemo.Run(); break;
                    case "7": CommandDemo.Run(); break;
                    case "8": StrategyDemo.Run(); break;
                    case "9": return;
                    case "11": SummaryDemo.Run(); break;

                    default: Console.WriteLine("Invalid option."); break;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }

    // ================================================================
    // 1. SINGLETON PATTERN
    // ================================================================

    /*
     THEORY:
     --------
     Singleton ensures that ONLY ONE object of a class exists 
     for the entire lifetime of the application.

     REAL-LIFE EXAMPLE:
     ------------------
     Only ONE Prime Minister in a country.
     You can “access” but cannot “create another”.

     WHY USED:
     ---------
     - Logging service
     - Configuration manager
     - Database connection manager
     
     HOW IT WORKS:
     -------------
     - Private constructor → no outside creation
     - Static instance → only one object
     - Public getter → controlled access
    */

    public sealed class AppLogger
    {
        private static readonly AppLogger _instance = new AppLogger();
        public static AppLogger Instance => _instance;

        private AppLogger() { } // cannot instantiate from outside

        public void Log(string msg)
        {
            Console.WriteLine("LOG: " + msg);
        }
    }

    public static class SingletonDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- SINGLETON PATTERN DEMO -----\n");

            var a = AppLogger.Instance;
            var b = AppLogger.Instance;

            Console.WriteLine("Both instances same? → " + (a == b));
            a.Log("Singleton pattern executed.");
        }
    }

    // ================================================================
    // 2. FACTORY PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Factory is used to create objects WITHOUT exposing the creation logic.

     ANALOGY:
     --------
     In Pizza Hut, you just say “Veg Pizza”. 
     You don’t care HOW it's made. Kitchen handles creation process.

     WHY USED:
     ---------
     - To avoid "new" keyword everywhere
     - Centralizes object creation
     - Makes adding new types easy

     EXPLANATION:
     ------------
     Factory returns object based on parameter (email, sms, whatsapp...)
    */

    public interface IMessage
    {
        void Send(string msg);
    }

    public class EmailMessage : IMessage
    {
        public void Send(string msg) => Console.WriteLine("Email → " + msg);
    }

    public class SmsMessage : IMessage
    {
        public void Send(string msg) => Console.WriteLine("SMS → " + msg);
    }

    public class MessageFactory
    {
        public IMessage GetMessageChannel(string type)
        {
            return type.ToLower() switch
            {
                "email" => new EmailMessage(),
                "sms" => new SmsMessage(),
                _ => throw new Exception("Invalid message type")
            };
        }
    }

    public static class FactoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- FACTORY PATTERN DEMO -----\n");

            var factory = new MessageFactory();
            var channel = factory.GetMessageChannel("sms");
            channel.Send("Hello from Factory Pattern!");
        }
    }

    // ================================================================
    // 3. BUILDER PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Builder constructs complex objects step-by-step.

     ANALOGY:
     --------
     Making a burger: add cheese, add mayo, extra patty… 
     You “build” the burger in steps.

     WHY USED:
     ---------
     - Avoids telescopic constructors
     - Build object flexibly

     CODE EXPLANATION:
     -----------------
     UserBuilder builds User object in steps and produces final object.
    */

    public class User
    {
        public string Name;
        public int Age;
        public string City;

        public override string ToString() => $"{Name}, {Age}, {City}";
    }

    public class UserBuilder
    {
        private User u = new User();

        public UserBuilder SetName(string name) { u.Name = name; return this; }
        public UserBuilder SetAge(int age) { u.Age = age; return this; }
        public UserBuilder SetCity(string city) { u.City = city; return this; }

        public User Build() => u;
    }

    public static class BuilderDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- BUILDER PATTERN DEMO -----\n");

            var user = new UserBuilder()
                        .SetName("Raushan")
                        .SetAge(25)
                        .SetCity("Delhi")
                        .Build();

            Console.WriteLine("User created → " + user);
        }
    }

    // ================================================================
    // 4. ADAPTER PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Adapter converts one interface to another.

     ANALOGY:
     --------
     HDMI to VGA converter → laptop to old projector.

     WHY USED:
     ---------
     - To connect old system with new system
     - To reuse existing code

     CODE EXPLANATION:
     -----------------
     OldSystemPrinter has PrintOld()
     New system expects Print()
     Adapter maps Print() → PrintOld()
    */

    public class OldPrinter
    {
        public void PrintOld(string msg) => Console.WriteLine("Old Printer → " + msg);
    }

    public interface INewPrinter
    {
        void Print(string msg);
    }

    public class PrinterAdapter : INewPrinter
    {
        private OldPrinter _old;
        public PrinterAdapter(OldPrinter old) { _old = old; }

        public void Print(string msg) => _old.PrintOld(msg);
    }

    public static class AdapterDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- ADAPTER PATTERN DEMO -----\n");

            INewPrinter printer = new PrinterAdapter(new OldPrinter());
            printer.Print("Using new system with old printer.");
        }
    }

    // ================================================================
    // 5. DECORATOR PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Decorator adds new features without modifying original class.

     ANALOGY:
     --------
     Coffee: 
     Basic Coffee → ₹50  
     Add Milk → +₹10  
     Add Chocolate → +₹20

     WHY USED:
     ---------
     - Extend object behavior dynamically
     - Avoid subclass explosion

     CODE EXPLANATION:
     -----------------
     MilkDecorator wraps BasicCoffee and adds extra cost + description.
    */

    public interface ICoffee
    {
        string GetDescription();
        int GetCost();
    }

    public class BasicCoffee : ICoffee
    {
        public string GetDescription() => "Basic Coffee";
        public int GetCost() => 50;
    }

    public class MilkDecorator : ICoffee
    {
        private ICoffee _coffee;
        public MilkDecorator(ICoffee coffee) => _coffee = coffee;

        public string GetDescription() => _coffee.GetDescription() + ", Milk";
        public int GetCost() => _coffee.GetCost() + 10;
    }

    public static class DecoratorDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- DECORATOR PATTERN DEMO -----\n");

            ICoffee coffee = new BasicCoffee();
            coffee = new MilkDecorator(coffee);

            Console.WriteLine("Order → " + coffee.GetDescription());
            Console.WriteLine("Cost → ₹" + coffee.GetCost());
        }
    }

    // ================================================================
    // 6. OBSERVER PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Observer allows automatic notification to many subscribers 
     when one object changes.

     ANALOGY:
     --------
     YouTube subscriptions → new video → get notification.

     WHY USED:
     ---------
     - Event-driven programming
     - Pub/Sub systems

     CODE EXPLANATION:
     -----------------
     Channel uploads video → Notifies subscribers automatically.
    */

    public class YoutubeChannel
    {
        public event Action<string> VideoUploaded;

        public void Upload(string title)
        {
            Console.WriteLine("Channel uploaded: " + title);
            VideoUploaded?.Invoke(title);
        }
    }

    public class Subscriber
    {
        public void Notify(string video) =>
            Console.WriteLine("Subscriber Notified → New Video: " + video);
    }

    public static class ObserverDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- OBSERVER PATTERN DEMO -----\n");

            var channel = new YoutubeChannel();
            var user = new Subscriber();

            channel.VideoUploaded += user.Notify;

            channel.Upload("C# Observer Pattern Explained!");
        }
    }

    // ================================================================
    // 7. COMMAND PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Command encapsulates a request as an object.

     ANALOGY:
     --------
     TV Remote:
     - Press ON → Command object
     - Press OFF → Command object

     WHY USED:
     ---------
     - Undo/Redo systems
     - Macro recording
     - Task queues

     CODE EXPLANATION:
     -----------------
     RemoteControl executes command without knowing how it works.
    */

    public interface ICommand
    {
        void Execute();
    }

    public class TurnOnTV : ICommand
    {
        public void Execute() => Console.WriteLine("TV is ON");
    }

    public class TurnOffTV : ICommand
    {
        public void Execute() => Console.WriteLine("TV is OFF");
    }

    public class RemoteControl
    {
        public void Press(ICommand cmd) => cmd.Execute();
    }

    public static class CommandDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- COMMAND PATTERN DEMO -----\n");

            var remote = new RemoteControl();
            remote.Press(new TurnOnTV());
            remote.Press(new TurnOffTV());
        }
    }

    // ================================================================
    // 8. STRATEGY PATTERN
    // ================================================================

    /*
     THEORY:
     -------
     Strategy allows selecting algorithm/behavior at runtime.

     ANALOGY:
     --------
     Payment methods:
     - UPI
     - Credit card
     - Net banking

     WHY USED:
     ---------
     - To change behavior dynamically
     - Avoid big if-else logic

     CODE EXPLANATION:
     -----------------
     Checkout class accepts any payment strategy.
    */

    public interface IPayment
    {
        void Pay(int amount);
    }

    public class UpiPayment : IPayment
    {
        public void Pay(int amount) =>
            Console.WriteLine($"Paid ₹{amount} via UPI");
    }

    public class CardPayment : IPayment
    {
        public void Pay(int amount) =>
            Console.WriteLine($"Paid ₹{amount} via Credit Card");
    }

    public class Checkout
    {
        private IPayment _strategy;
        public Checkout(IPayment strategy) => _strategy = strategy;

        public void Process(int amt) => _strategy.Pay(amt);
    }

    public static class StrategyDemo
    {
        public static void Run()
        {
            Console.WriteLine("----- STRATEGY PATTERN DEMO -----\n");

            var checkout = new Checkout(new CardPayment());
            checkout.Process(1000);
        }
    }
    // ================================================================
    // 11. SUMMARY OF ALL PATTERNS (ADDED BY REQUEST)
    // ================================================================

    public static class SummaryDemo
    {
        public static void Run()
        {
            Console.WriteLine("========== DESIGN PATTERNS SUMMARY ==========\n");

            Console.WriteLine("CREATIONAL PATTERNS\n");

            Console.WriteLine("1️⃣ Singleton");
            Console.WriteLine("When to use: Only one instance should exist (Logging, Config, Cache).");
            Console.WriteLine("Essence: Control object creation so only ONE object lives.\n");

            Console.WriteLine("2️⃣ Factory");
            Console.WriteLine("When to use: You want to centralize object creation, hide 'new',");
            Console.WriteLine("             and return different types based on input.");
            Console.WriteLine("Essence: Client asks WHAT they want; Factory knows HOW to create.\n");

            Console.WriteLine("3️⃣ Builder");
            Console.WriteLine("When to use: Object has many optional parameters (User, Pizza, HTTP Request).");
            Console.WriteLine("Essence: Build object step-by-step cleanly.\n");

            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("STRUCTURAL PATTERNS\n");

            Console.WriteLine("4️⃣ Adapter");
            Console.WriteLine("When to use: Old system needs to work with new system.");
            Console.WriteLine("Essence: Converts one interface into another.\n");

            Console.WriteLine("5️⃣ Decorator");
            Console.WriteLine("When to use: Add features dynamically without modifying the base class.");
            Console.WriteLine("Essence: Wrap object to extend behavior at runtime.\n");

            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("BEHAVIORAL PATTERNS\n");

            Console.WriteLine("6️⃣ Observer");
            Console.WriteLine("When to use: One event → many subscribers (Notifications, Event handling).");
            Console.WriteLine("Essence: Publisher notifies subscribers automatically.\n");

            Console.WriteLine("7️⃣ Command");
            Console.WriteLine("When to use: Need Undo/Redo, queue commands, or decouple UI from logic.");
            Console.WriteLine("Essence: Convert actions into objects.\n");

            Console.WriteLine("8️⃣ Strategy");
            Console.WriteLine("When to use: Multiple ways to perform the same task (Payments, Sorting).");
            Console.WriteLine("Essence: Swap algorithms/behaviors at runtime.\n");

            Console.WriteLine("==============================================\n");

            Console.WriteLine("🔥 THE ESSENCE OF DESIGN PATTERNS 🔥");
            Console.WriteLine("▶ They reduce complexity.");
            Console.WriteLine("▶ They make code flexible and maintainable.");
            Console.WriteLine("▶ They decouple systems and promote clean architecture.");
            Console.WriteLine("▶ They avoid rewriting same logic again and again.");
            Console.WriteLine("▶ They help teams communicate using common vocabulary.");
            Console.WriteLine("   (\"Use Strategy here\", \"Add a Decorator\", \"Make this Observable\")\n");

            Console.WriteLine("==============================================\n");

            Console.WriteLine("⭐ SUMMARY IN ONE LINE EACH ⭐\n");
            Console.WriteLine("Singleton → One object, global access.");
            Console.WriteLine("Factory → Create objects without exposing logic.");
            Console.WriteLine("Builder → Build objects step-by-step.");
            Console.WriteLine("Adapter → Make incompatible systems work together.");
            Console.WriteLine("Decorator → Add features dynamically.");
            Console.WriteLine("Observer → Notify all subscribers on event.");
            Console.WriteLine("Command → Encapsulate an action as object.");
            Console.WriteLine("Strategy → Switch algorithm at runtime.\n");

            Console.WriteLine("==============================================");
            Console.WriteLine("This summary helps students recall patterns instantly.");
        }
    }

}
