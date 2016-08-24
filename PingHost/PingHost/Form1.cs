using System;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PingHost
{
    public partial class Form_Ping : Form
    {
        private BackgroundWorker m_BackgroundWorker = new BackgroundWorker();

        public Form_Ping()
        {
            InitializeComponent();

            m_BackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            m_BackgroundWorker.DoWork += M_BackgroundWorker_DoWork;
            m_BackgroundWorker.ProgressChanged += M_BackgroundWorker_ProgressChanged;
            m_BackgroundWorker.RunWorkerCompleted += M_BackgroundWorker_RunWorkerCompleted;

            progressBar.Hide();
        }

        private void M_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            label_Status.Text = "status";
            progressBar.Hide();// .Enabled = false;
            button_Ping.Enabled = true;
            button_Stop.Enabled = false;
            textBox_IP.Enabled = true;
        }

        private void M_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                var status = (IPStatus)e.UserState;
                label_Status.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss:fff} {1}", DateTime.Now, status);
            }
        }

        private void M_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bg = sender as BackgroundWorker;
            var host = e.Argument.ToString();
            var path = Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".log");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                try
                {
                    sw.WriteLine("{0:yyyy-MM-dd HH:mm:ss:fff} Ping {1}: Start", DateTime.Now, host);

                    var d = DateTime.MinValue;
                    double i = 0.0;
                    double max = 100.0;
                    while (!e.Cancel)
                    {
                        var dt = DateTime.Now.AddSeconds(-3);
                        if (dt.CompareTo(d) > 0)
                        {
                            d = DateTime.Now;
                            var ret = Ping(host);
                            e.Result = ret;
                            sw.WriteLine("{0:yyyy-MM-dd HH:mm:ss:fff} Ping {1}: {2}", DateTime.Now, host, ret);
                            sw.Flush();

                            var p = (int)((i / max) * 100);
                            bg.ReportProgress(p, ret);

                            i++;
                            if (i > 100)
                            {
                                i = 0;
                            }
                        }

                        if (bg.CancellationPending)
                        {
                            e.Cancel = true;
                        }

                        Thread.Sleep(50);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sw.WriteLine("{0:yyyy-MM-dd HH:mm:ss:fff} Ping {1}: Finish", DateTime.Now, host);
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private IPStatus Ping(string hostName, int timeout = 5000)
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    PingOptions option = new PingOptions(126, true);
                    var buffer = Encoding.ASCII.GetBytes("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    PingReply reply = ping.Send(hostName, timeout, buffer, option);
                    return reply.Status;
                }
                catch (Exception)
                {
                    return IPStatus.Unknown;
                }
            }
        }


        private void button_Ping_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_IP.Text))
            {
                return;
            }

            if (!m_BackgroundWorker.IsBusy)
            {
                var ip = textBox_IP.Text.Trim();
                m_BackgroundWorker.RunWorkerAsync(ip);
                progressBar.Show();//.Enabled = true;
                button_Ping.Enabled = false;
                button_Stop.Enabled = true;
                textBox_IP.Enabled = false;
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (m_BackgroundWorker.IsBusy)
            {
                m_BackgroundWorker.CancelAsync();
            }
        }

        private void Form_Ping_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_BackgroundWorker.IsBusy)
            {
                m_BackgroundWorker.CancelAsync();
                while (m_BackgroundWorker.IsBusy)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
            }
        }
    }
}
