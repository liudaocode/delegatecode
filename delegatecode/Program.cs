using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace delegatecode
{
    public delegate void GreetingDelegate(string name);

    public class GreetingManager
    {
        //在类的内部，不管你声明它是public还是protected，它总是private的。在类的外部，注册“+=”和注销“-=”的访问限定符与你在声明事件时使用的访问符相同。
        public event GreetingDelegate delegate1;

        public void GreetPeople(string name)
        {
            if (delegate1 != null)
            {     //如果有方法注册委托变量
                delegate1(name);      //通过委托调用方法
            }
        }
    }

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
            GreetingManager gm = new GreetingManager();
            gm.delegate1 += EnglishGreeting;
            gm.delegate1 += ChineseGreeting;

            gm.GreetPeople("liudao");


            //GreetingDelegate delegate1;
            //delegate1 = EnglishGreeting;
            //delegate1 += ChineseGreeting;
            //GreetPeople("liudao", delegate1);
            //delegate1-=ChineseGreeting;
            //GreetPeople("六道", delegate1);
            //Console.ReadKey();
        }
    }
}
