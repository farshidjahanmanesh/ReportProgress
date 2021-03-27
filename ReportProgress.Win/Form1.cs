using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgress.Win
{
    public partial class Form1 : Form
    {
        public async Task DoTask()
        {
            //Action<int> progress = i =>
            //{
            //    Action act = () => label1.Text = Convert.ToString(i);
            //    Invoke(act);
            //};
            var progress = new Progress<int>(i => label1.Text = Convert.ToString(i));
            progress.ProgressChanged += Progress_ProgressChanged;
            await ReportSomeWork(progress);
        }

        private void Progress_ProgressChanged(object sender, int e)
        {

        }

        private Task ReportSomeWork(IProgress<int> onProgressPercentChanged)
        {
            return Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (i % 10 == 0)
                            onProgressPercentChanged.Report(i / 10);
                        Thread.Sleep(30);
                        //some code
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoTask();

        }
    }
}
