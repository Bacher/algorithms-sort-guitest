using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SortAnalyzer
{
    public partial class MainForm : Form
    {
        BackgroundWorker bw;

        delegate void PrintStepDelegate(string resultString);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            BWEventArgs args = (BWEventArgs)e.Argument;
            PrintStepDelegate printDelegate = new PrintStepDelegate(PrintStep);

            int stepIteration = (args.endLength - args.startLength) / args.stepsCount;

            BeginInvoke(printDelegate, "Пакетное тестирование запущено.");

            for (int i = args.startLength, step = 1; step <= args.stepsCount; step++, i += stepIteration)
            {
                BeginInvoke(printDelegate, "==================================================");
                BeginInvoke(printDelegate, string.Format("Начинается тестирование. Шаг: {0}/{1}", step, args.stepsCount));
                BeginInvoke(printDelegate, string.Format("    Размерность массива: {0}", i));
                BeginInvoke(printDelegate, "==================================================");

                startTesting(i, printDelegate);

                BeginInvoke(printDelegate, "Тестирование шага завершено.");

                bw.ReportProgress(step * 100 / args.stepsCount);
            }
        }

        void startTesting(int length, PrintStepDelegate printFunc)
        {
            Random rnd = new Random();

            int[] numbers = new int[length];

            for (int i = 0; i < length; ++i)
            {
                numbers[i] = rnd.Next();
            }

            SortReport quickReport = startSortingProc("Quick-sort.exe", numbers);
            BeginInvoke(printFunc, string.Format("Quick-sort is finished at {0} ms.", quickReport.millisecs));
            SortReport heapReport = startSortingProc("Heap-sort.exe", numbers);
            BeginInvoke(printFunc, string.Format("Heap-sort is finished at {0} ms.", heapReport.millisecs));
        }

        SortReport startSortingProc(string procName, int[] numbers)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo(procName);

            procInfo.RedirectStandardInput = true;
            procInfo.RedirectStandardOutput = true;
            procInfo.UseShellExecute = false;
            procInfo.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = procInfo;
            proc.Start();

            var watch = new Stopwatch();
            watch.Start();

            proc.StandardInput.WriteLine(numbers.Length);
            for (int i = 0; i < numbers.Length; ++i)
            {
                proc.StandardInput.WriteLine(numbers[i]);
            }
           
            string result = proc.StandardOutput.ReadToEnd();

            watch.Stop();

            var report = new SortReport();
            report.output = result;
            report.millisecs = watch.ElapsedMilliseconds;

            return report;
        }

        void PrintStep(string info)
        {
            txtResults.AppendText(string.Format("{0}: {1}\n", DateTime.Now.ToLocalTime().ToLongTimeString(), info));
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                MessageBox.Show("Анализ алгоритмов завершен.");
            }
            progress.Value = 0;            
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void btnStartSort_Click(object sender, EventArgs e)
        {
            // Test functions
            ProcessStartInfo procInfo = new ProcessStartInfo("Quick-sort.exe");

            procInfo.RedirectStandardInput = true;
            procInfo.RedirectStandardOutput = true;
            procInfo.UseShellExecute = false;
            procInfo.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = procInfo;
            proc.Start();

            proc.StandardInput.WriteLine(4);
            proc.StandardInput.WriteLine(4);
            proc.StandardInput.WriteLine(3);
            proc.StandardInput.WriteLine(1);
            proc.StandardInput.WriteLine(8);
            
            string result = proc.StandardOutput.ReadToEnd();

            MessageBox.Show(result);
           
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            txtResults.Clear();

            bw.RunWorkerAsync(new BWEventArgs()
            {
                startLength = int.Parse(txtStart.Text),
                endLength = int.Parse(txtEnd.Text),
                stepsCount = int.Parse(txtCount.Text)
            });
        }

        
    }
}
