using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Planning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Task> tasks = new List<Task>();
        Thread thread;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "Start":
                    {
                        thread = new Thread(Go1);
                        thread.Start();
                        timer2.Enabled = true;
                        button1.Text = "Stop";
                        break;
                    }
                case "Stop":
                    {
                        timer2.Enabled = false;
                        tasks[0].Pause();
                        button1.Text = "Start";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (button2.Text)
            {
                case "Start":
                    {
                        thread = new Thread(Go1);
                        thread.Start();
                        button2.Text = "Stop";
                        break;
                    }
                case "Stop":
                    {
                        tasks[0].Pause();
                        button2.Text = "Start";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void Go1()
        {
            do
            {
                tasks[0].Start();
                if (tasks[0].process == 0)
                    tasks.RemoveAt(0);
            }
            while (tasks.Count != 0 && !tasks[0].pause);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tasks.Add(new Task(int.Parse(textBox1.Text)));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var task in tasks)
            {
                listBox1.Items.Add(task.process);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tasks[0].Pause();
            thread.Join();
            tasks.Add(tasks[0]);
            tasks.RemoveAt(0);
            thread = new Thread(Go1);
            thread.Start();
        }
    }
}