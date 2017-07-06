using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Adv_c_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Struct memory");
            Struct1();
            Console.WriteLine("\nStruct value write");
            Struct2();
            Console.WriteLine("\nStruct value read");
            Struct3();
            Console.WriteLine("\nClasses can inheritance");
            Class1();
            Console.WriteLine("\nClasses faster with interface ref");
            Class2();
            Console.WriteLine("\nClasses holds refs, not copy");
            Class3();
            Console.Read();
        }
        static Stopwatch sw = new Stopwatch();

        #region Classes
        static void Class1()
        {
            //private struct MyStruct1
            //private struct MyStruct2 : MyStruct1
            //private class MyClass1
            //private class MyClass2 : MyClass1
        }

        interface MyInterface
        {
            int Do();
        }

        struct MyStruct : MyInterface
        {
            public int Do() => throw new NotImplementedException();
        }

        class MyClass : MyInterface
        {
            public int Do() => throw new NotImplementedException();
        }

        static void Class2()
        {
            var ints = new List<MyStruct>();
            var objs = new List<MyClass>();
            for (int i = 0; i < 70000; i++)
            {
                ints.Add(new MyStruct());
                objs.Add(new MyClass());
            }

            sw.Start();
            for (int i = 0; i < 70000; i++)
            {
                MyInterface a = ints[i];
            }
            sw.Stop();
            Console.WriteLine($"Interface struct write time => {sw.ElapsedTicks}");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < 70000; i++)
            {
                MyInterface a = objs[i];
            }
            sw.Stop();
            Console.WriteLine($"Interface class write time => {sw.ElapsedTicks}");
            sw.Reset();
        }

        struct MyStruct2
        {
            public string s;
        }

        class MyClass2
        {
            public string s;
        }

        static void Class3()
        {
            var ms = new MyStruct2();
            ms.s = "string";
            var mc = new MyClass2();
            mc.s = "string";
            ChangeStructString(ms);
            ChangeClassString(mc);
            Console.WriteLine($"Original string => string");
            Console.WriteLine($"Struct new string => {ms.s}");
            Console.WriteLine($"Class new string => {mc.s}");
        }
        private static void ChangeStructString(MyStruct2 ms)
        {
            ms.s = "new string";
        }
        private static void ChangeClassString(MyClass2 mc)
        {
            mc.s = "new string";
        }
        #endregion Classes

        #region Structs
        static void Struct1()
        {
            var ints = new List<int>();
            var objs = new List<object>();
            long size = 0;
            for (int i = 0; i < 7000000; i++)
            {
                ints.Add(i);
                objs.Add(i);
            }

            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, ints);
                size = stream.Length;
            }
            Console.WriteLine($"Ints memory => {size}");

            size = 0;

            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objs);
                size = stream.Length;
            }
            Console.WriteLine($"Objs memory => {size}");
        }

        static void Struct2()
        {
            var ints = new List<int>();
            var objs = new List<object>();

            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                ints.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"Ints write time => {sw.ElapsedTicks}");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                objs.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"Objs write time => {sw.ElapsedTicks}");
            sw.Reset();
        }

        static void Struct3()
        {
            var ints = new List<int>();
            var objs = new List<object>();
            for (int i = 0; i < 10000000; i++)
            {
                ints.Add(i);
                objs.Add(i);
            }

            sw.Start();
            foreach (var item in ints)
            {
                var temp = item;
            }
            sw.Stop();
            Console.WriteLine($"Ints read time => {sw.ElapsedTicks}");
            sw.Reset();

            sw.Start();
            foreach (var item in objs)
            {
                var temp = item;
            }
            sw.Stop();
            Console.WriteLine($"Objs read time => {sw.ElapsedTicks}");
            sw.Reset();
        }
        #endregion Structs
    }
}
