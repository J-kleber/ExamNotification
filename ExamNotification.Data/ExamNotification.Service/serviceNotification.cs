using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Model;
using System.Timers;

namespace ExamNotification.Service
{
    public partial class serviceNotification : ServiceBase
    {
        public serviceNotification()
        {
            InitializeComponent();
        }
        private System.Timers.Timer timer2;

        protected override void OnStart(string[] args)
        {
            this.timer2 = new System.Timers.Timer(30000D);  // 30000 milliseconds = 30 seconds
            this.timer2.AutoReset = true;
            this.timer2.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer2.Start();
            //timer.Enabled = true;
        }

        protected override void OnStop()
        {
            //timer.Enabled = false;
            this.timer2.Stop();
            this.timer2 = null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SendNotification oSend = new SendNotification();
            oSend.Send();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Main2(); // my separate static method for do work
        }


        private static void Main2()
        {
            SendNotification oSend = new SendNotification();
            oSend.Send();
            System.ServiceProcess.ServiceBase.Run(new serviceNotification());
        }





    }
}
