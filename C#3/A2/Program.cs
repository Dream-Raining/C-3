using System;

namespace EventTest
{



    internal class Program
    {
        class SecondEvent : EventArgs
        {
            public int second;
            public SecondEvent()
            {
                second = 0;
            }
            public override string ToString()
            {
                return second.ToString();
            }
        }

        public delegate void EventEventHandler(object sender, EventArgs e);
        class AlarmClock
        {

            public event EventEventHandler Tick;
            public event EventEventHandler Alarm;
            public int alarmTime;
            public AlarmClock()
            {
                Console.WriteLine("Please enter the end time");
                int time = int.Parse(Console.ReadLine().ToString());
                alarmTime = time;
                while (alarmTime <= 0)
                {
                    Console.WriteLine("Please enter the end time");
                    time = int.Parse(Console.ReadLine().ToString());
                    alarmTime = time;
                }

            }
            public void Working()
            {
                SecondEvent se = new SecondEvent();
                while (se.second < alarmTime)
                {
                    System.Threading.Thread.Sleep(1000);
                    se.second++;
                    Tick(this, se);
                }
                Alarm(this, se);
            }

        }
        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();
            alarmClock.Alarm += AlarmClock_Alarm;
            alarmClock.Tick += AlarmClock_Tick;
            alarmClock.Tick += AlarmClock_Tick1;
            alarmClock.Working();
        }

        private static void AlarmClock_Tick1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("滴答");
        }

        private static void AlarmClock_Tick(object sender, EventArgs e)
        {
            Console.Write(e.ToString());
        }

        private static void AlarmClock_Alarm(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("END");
        }
    }
}