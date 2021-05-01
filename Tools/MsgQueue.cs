using System.Collections.Generic;
using System.Timers;

namespace Tools
{
    class MsgQueue<T> where T : class
    {
        public bool IsLocked { get; private set; }
        public int Timeout { get; }
        private Queue<T> Messages { get; }

        private Timer timer;

        public MsgQueue(int timeout)
        {
            IsLocked = false;
            Messages = new Queue<T>();
            Timeout = timeout;

            timer = new Timer(timeout)
            {
                AutoReset = false,
                Enabled = false,
            };
            timer.Elapsed += (s, e) =>
            {
                IsLocked = false;
            };
        }

        public void Enqueue(T message)
        {
            Messages.Enqueue(message);
        }

        public T Dequeue()
        {
            if (!IsLocked)
            {
                IsLocked = true;
                timer.Start();
                return Messages.Dequeue();
            }
            return null;
        }
    }
}
