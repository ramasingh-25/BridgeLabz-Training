//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection
//{
//    internal class CustomLoggingProxy
//    {
       

//// 1️⃣ Interface
//public interface IGreeting
//    {
//        void SayHello(string name);
//    }

//    // 2️⃣ Real implementation
//    public class Greeting : IGreeting
//    {
//        public void SayHello(string name)
//        {
//            Console.WriteLine("Hello, " + name);
//        }
//    }

//    // 3️⃣ Logging Proxy using Reflection
//    public class LoggingProxy<T> : DispatchProxy
//    {
//        private T _target;

//        public void SetTarget(T target)
//        {
//            _target = target;
//        }

//        protected override object Invoke(MethodInfo targetMethod, object[] args)
//        {
//            // Log before execution
//            Console.WriteLine($"Calling method: {targetMethod.Name}");

//            // Invoke actual method
//            return targetMethod.Invoke(_target, args);
//        }
//    }

//    // 4️⃣ Program
//    class Program
//    {
//        static void Main()
//        {
//            // Create real object
//            IGreeting greeting = new Greeting();

//            // Create proxy
//            IGreeting proxy =
//                DispatchProxy.Create<IGreeting, LoggingProxy<IGreeting>>();

//            // Attach real object to proxy
//            ((LoggingProxy<IGreeting>)proxy).SetTarget(greeting);

//            // Call method via proxy
//            proxy.SayHello("Rama");
//        }
//    }

//}
//}
