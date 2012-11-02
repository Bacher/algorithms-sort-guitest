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

namespace SortAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartSort_Click(object sender, EventArgs e)
        {
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
    }
}
