using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //打印到输出窗口
            //重定向到即时窗口https://www.cnblogs.com/xwgli/p/3625925.html
            Trace.WriteLine("Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Trace.WriteLine("早上好, " + name);
        }
        static void Main(string[] args)
        {
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;
            delegate1 += ChineseGreeting;
            GreetPeople("liudao", delegate1);
            delegate1-=ChineseGreeting;
            GreetPeople("六道", delegate1);
            //Console.ReadKey();
        }
    }
}
