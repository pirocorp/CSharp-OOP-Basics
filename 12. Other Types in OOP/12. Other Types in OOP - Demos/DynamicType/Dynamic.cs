﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DynamicType
{
    using System.Collections;

    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SayName()
        {
            return "I am " + this.Name;
        }
    }

    class Dynamic
    {
        static void Main(string[] args)
        {
            // using dynamic for classes
            dynamic student = new Student();
            student.Name = "Pesho";
            Console.WriteLine(student.Name);

            // using dynamic without having dynamic all over the place
            var result = Sum<int>(5, 6);
            var decimalResult = Sum<decimal>(15.6M, 16.15M);
            var text = Sum<string>("pesho", "gosho");

            Console.WriteLine(result);
            Console.WriteLine(text);
            Console.WriteLine(decimalResult);

            // using dynamic to compare types
            var comparing = Compare(5, 6);
            // comparing = Compare("pesho", "gosho"); // this causes exception

            // using dynamic expanding object
            dynamic expObj = new ExpandoObject();
            expObj.Result = 5;
            Console.WriteLine("Result: " + expObj.Result);
            expObj.FirstName = "Pesho";
            expObj.LastName = "Goshovski";
            expObj.SayHello = new Func<string>(() =>
            {
                return "I am " + expObj.FirstName + " " + expObj.LastName;
            });

            Console.WriteLine(expObj.SayHello());

            // using ExpandoObject as Dictionary<TPropertyName, TPropertyValue>
            var properties = (IDictionary<string, Object>)expObj;
            properties.Add("Age", 10);
            properties.Add("SayAge", new Func<string>(() =>
            {
                return "My age is " + properties["Age"];
            }));
            Console.WriteLine(expObj.SayAge());

            properties.Add("ChangeAge", new Action<int>((age) =>
            {
                properties["Age"] = age;
            }));
            expObj.ChangeAge(20);
            Console.WriteLine(expObj.SayAge());

            foreach (var pair in properties)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }

            // this will not compile
            //dynamic someObj = new ExpandoObject();
            //someObj.Result = "Pesho";
            //Console.WriteLine(someObj.Result);
        }

        static T Sum<T>(dynamic first, dynamic second)
        {
            return first + second;
        }

        static int Compare(dynamic first, dynamic second)
        {
            if (first == second)
            {
                return 0;
            }
            else
            {
                if (first < second)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
