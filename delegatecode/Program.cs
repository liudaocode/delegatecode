using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace delegatecode
{
    public class Heater
    {
        private int temperature; // 水温
        public delegate void BoilHandler(int param);//声明委托
        public event BoilHandler BoilEvent;         //声明事件
        // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;

                if (temperature > 95)
                {
                    //if (BoilEvent != null)        //如果有对象注册
                    //{
                    //    BoilEvent(temperature);   //调用所有注册对象的方法
                    //}
                    BoilEvent?.Invoke(temperature);
                }
            }
        }
    }
    // 警报器
    public class Alarm
    {
        // 发出语音警报
        public void MakeAlert(int param)
        {
            Trace.WriteLine(string.Format("Alarm：嘀嘀嘀，水已经 {0} 度了：", param));
        }
    }
    // 显示器
    public class Display
    {
        public static void ShowMsg(int param)
        { //静态方法
            Trace.WriteLine(string.Format("Display：水快开了，当前温度：{0}度。", param));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heater ht = new Heater();
            Alarm alarm = new Alarm();

            ht.BoilEvent += alarm.MakeAlert;    //注册方法
            ht.BoilEvent += (new Alarm()).MakeAlert;   //给匿名对象注册方法
            ht.BoilEvent += Display.ShowMsg;       //注册静态方法

            ht.BoilWater();   //烧水，会自动调用注册过对象的方法
        }
    }
}
