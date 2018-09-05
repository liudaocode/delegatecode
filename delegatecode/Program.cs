using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegatecode
{
    public delegate void GreetingDelegate(string name);
    class Program
    {
        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            // 做某些额外的事情，比如初始化之类，此处略
            MakeGreeting(name);
        }
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
        static void Main(string[] args)
        {
            GreetPeople("liudao", EnglishGreeting);
            GreetPeople("六道", ChineseGreeting);
            Console.ReadKey();
        }
    }
}
