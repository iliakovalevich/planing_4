using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Planning
{
    class Task
    {
        private bool IsStarted { get; set; } = false;
        public int process { get; set; }
        public bool pause { get; set; } = false;

        public Task(int process)
        {
            this.process = process;
        }
        public void Start()
        {
            IsStarted = true;
            pause = false;
            Processing();
        }
        public void Pause()
        {
            pause = true;
        }
        private void Processing()
        {
            for (; !pause && process != 0; process--)
            {
                Thread.Sleep(10);
            }
        }
    }
}
