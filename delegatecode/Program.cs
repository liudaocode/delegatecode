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
        public string type = "xiaomi001";
        public string area = "China Huaian";
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs e);//声明委托
        public event BoiledEventHandler Boiled;         //声明事件

        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            //if (Boiled != null)
            //{ // 如果有对象注册
            //    Boiled(this, e);  // 调用所有注册对象的方法
            //}
            Boiled?.Invoke(this, e);
        }
        
        // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;

                if (temperature > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
    }
    // 警报器
    public class Alarm
    {
        // 发出语音警报
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
            Trace.WriteLine(string.Format("Alarm：{0} - {1}: ", heater.area, heater.type)); //访问 sender 中的公共字段
            Trace.WriteLine(string.Format("Alarm：嘀嘀嘀，水已经 {0} 度了。", e.temperature));
        }
    }
    // 显示器
    public class Display
    {
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        { //静态方法
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
            Trace.WriteLine(string.Format("Display：{0} - {1}: ", heater.area, heater.type)); //访问 sender 中的公共字段
            Trace.WriteLine(string.Format("Display：水快开了，当前温度：{0}度。", e.temperature));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heater ht = new Heater();
            Alarm alarm = new Alarm();

            ht.Boiled += alarm.MakeAlert;    //注册方法
            ht.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);//也可以这么注册
            ht.Boiled += (new Alarm()).MakeAlert;   //给匿名对象注册方法
            ht.Boiled += Display.ShowMsg;       //注册静态方法

            ht.BoilWater();   //烧水，会自动调用注册过对象的方法
        }
    }
}
