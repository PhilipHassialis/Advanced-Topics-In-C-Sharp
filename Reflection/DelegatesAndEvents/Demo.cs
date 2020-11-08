using System;

namespace DelegatesAndEvents
{
    class Demo
    {

        public event EventHandler<int> MyEvent;

        public void Handler(object sender, int arg)
        {
            Console.WriteLine($"I just got {arg}");
        }

        static void Main(string[] args)
        {
            var demo = new Demo();
            var eventInfo = typeof(Demo).GetEvent("MyEvent");
            var handlerMethod = demo.GetType().GetMethod("Handler");

            var handler = Delegate.CreateDelegate(
                eventInfo.EventHandlerType,
                null,
                handlerMethod);

            eventInfo.AddEventHandler(demo, handler);

            demo.MyEvent?.Invoke(null, 312);

        }
    }
}
