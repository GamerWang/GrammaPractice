using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammaPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opening part of this test program.
            Console.WriteLine("Hello World");

            // Create 2 Generic classes.
            // MyCollection<string> list2 = new MyCollection<string>("String Param");
            // MyCollection<int> list3 = new MyCollection<int>(1456723);
            // Print out the type of variable to see if the Generic worked.
            // Could see that expression like 'list2.variable' could work.
            // However 'typeof(list2.variable)' does not work.
            // Console.WriteLine("Program Main see list2.variable: {0}", list2.variable + 123);
            // Console.WriteLine("Program Main see list3.variable: {0}", list3.variable + 123);

            // See the default(T) value in list2 and list3.
            // Both print out nothing
            // list2.TryDefault();
            // list3.TryDefault();

            // Create Iterator class.
            // Iterator iterator = new Iterator();
            // Console.WriteLine("Program Main GetEnumerator1 start");
            // foreach (var item in iterator.GetEnumerator1())
            // {
            //     Console.WriteLine("Program Main see item: {0}",item.ToString());
            // }
            // Console.WriteLine("Program Main GetEnumerator2 start");
            // foreach (var item in iterator.GetEnumerator2())
            // {
            //     Console.WriteLine("Program Main see item: {0}", item.ToString());
            // }
            // Console.WriteLine("Program Main GetEnumerator3 start");
            // foreach (var item in iterator.GetEnumerator3())
            // {
            //     Console.WriteLine("Program Main see item: {0}", item.variable);
            // }

            // A code frame for Nullable Type.
            // int? num = null;
            // num = 1;
            // if (num.HasValue == true)
            // {
            //     Console.WriteLine("Program Main Nullable Type: num = {0}", num.Value);
            // }
            // else
            // {
            //     Console.WriteLine("Program Main Nullable Type: num = Null");
            // }
            // var y = num ?? -1;
            // Console.WriteLine("Program Main Nullable Type: y = {0}", y);

            // A code frame for delegate.
            // Delegate delFrame = new Delegate();
            // delFrame.UseDelegate();
            // The code below will not work.
            // delFrame.Del handler = Delegate.DelegateMethod2;
            // The delegate belongs to the class not the instance.
            // Delegate.Del handler = Delegate.DelegateMethod2;
            // handler("Program Main: Hello Delegate");
            // Delegate.Del handler2 = Delegate.DelegateMethod1;
            // handler2("Program Main: Hello Delegate");
            // handler("Program Main: Hello Delegate");
            // handler = Delegate.DelegateMethod1;
            // handler("Program Main: Hello Delegate");
            // Anonymous Method delegate
            // handler = delegate(string message)
            // {
            //     handler2("Program Main: inside Anonymous function");
            //     System.Console.WriteLine(message);
            // };
            // handler("Program Main: Anonymous delegate");
            // Could not create delegate inside a method.
            // The code bellow will not work here.
            // delegate void Del(int x)
            // Use delegate handler as a callback function.
            // delFrame.MethodWithCallback(1, 2, handler);
            // Try delegate operations.
            // Delegate.MethodClass methods = new Delegate.MethodClass();
            // Delegate.Del del1 = methods.Method1;
            // Delegate.Del del2 = methods.Method2;
            // Delegate.Del del3 = Delegate.DelegateMethod1;
            // Try combine delegates.
            // Delegate.Del allMethodsDelegate = del1 + del2;
            // allMethodsDelegate += del3;
            // Try call the combined delegate.
            // allMethodsDelegate("Program Main: combined text");
            // var rawMessage = "Original message";
            // allMethodsDelegate("Program Main: " + rawMessage);
            // Try object params
            // Delegate.MethodClass.Del2 del4 = methods.Method3;
            // Delegate.MethodClass.Del2 del5 = methods.Method4;
            // Delegate.MethodClass.Del2 combinedDelegate = del4 + del5;
            // object o;
            // o = 0;
            // combinedDelegate(o);
            // Try class params
            // Delegate.MethodClass.Del3 del6 = methods.Method5;
            // Delegate.MethodClass.Del3 del7 = methods.Method6;
            // Delegate.MethodClass.Del3 combinedDelegate = del6 + del7 + del6;
            // combinedDelegate -= del7;
            // combinedDelegate += del7;
            // combinedDelegate -= del6;
            // Delegate.MethodClass.ReferenceParam r = new Delegate.MethodClass.ReferenceParam();
            // combinedDelegate(r);
            // Console.WriteLine("Program Main: see invocation list length: {0}", combinedDelegate.GetInvocationList().GetLength(0));

            while (true) ;
        }
    }

    class MyCollection<T>
    {
        public T variable;

        // The Constructor function.
        public MyCollection(T param)
        {
            Add(param);
        }
        public void TryDefault()
        {
            Console.WriteLine("MyCollection see variable: {0}", variable);
            Console.WriteLine("MyCollection see default(T): {0}",default(T));
            Console.WriteLine("MyColleciont see default equals null: {0}", default(T) == null);
            // Could not try equal 0.
            // Console.WriteLine("MyColleciont see default equals 0: {0}", default(T) == 0);
        }
        private void Add(T param)
        {
            variable = param;
            // Expression like this will not work.
            // variable = param + 123;
            // It says operator + could not work with T and int.
            // variable = param + param does not work either.
        }
    }

    class Iterator
    {
        public IEnumerable<int> GetEnumerator1()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }

        public IEnumerable<int> GetEnumerator2()
        {
            var index = 0;
            while (index++ < 10)
                yield return index + 20;
        }

        public IEnumerable<MyCollection<int>> GetEnumerator3()
        {
            var index = 0;
            while (index++ < 10)
            {
                MyCollection<int> Mc = new MyCollection<int>(index + 50);
                yield return Mc;
            }
        }
    }

    class Delegate
    {
        public class MethodClass
        {
            // Simple object parameter delegate.
            public delegate object Del2(object o);

            // Special class parameter delegate.
            public delegate void Del3(ReferenceParam r);

            // Class as the parameter.
            public class ReferenceParam
            {
                public int data = 0;
            }

            public void Method1(string message){
                // Try do some change on message
                // message += " Method1 Modified";
                // message = "New message1";
                Console.WriteLine("{0}, with method1", message);
            }

            public void Method2(string message){
                // message += " Method2 Modified";
                // message = "New message2";
                Console.WriteLine("{0}, with method2", message);
            }

            public object Method3(object o)
            {
                // o = 1;
                Console.WriteLine("{0}, with method3", o);
                return o;
            }

            public object Method4(object o)
            {
                o = 1;
                Console.WriteLine("{0}, with method4", o);
                return o;
            }

            public void Method5(ReferenceParam r)
            {
                r.data += 1;
                Console.WriteLine("{0}, with method5", r.data);
            }

            public void Method6(ReferenceParam r)
            {
                r.data += 2;
                Console.WriteLine("{0}, with method6", r.data);
            }
        }

        public delegate void Del(string message);

        // Create a method for a delegate.
        public static void DelegateMethod1(string message)
        {
            System.Console.WriteLine(message);
        }

        public static void DelegateMethod2(string message)
        {
            System.Console.WriteLine("{0}, but little different", message);
        }

        public void UseDelegate()
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod1;

            // Call the delegate.
            handler("Delegate: Hello Delegate");
        }

        public void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("Delegate: The number is: " + (param1 + param2).ToString());
        }

        // This will work
        delegate void Del2(int x);
        Del2 d = delegate(int k) { };
    }
}
