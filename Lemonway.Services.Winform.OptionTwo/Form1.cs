using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Lemonway.Services.Winform.OptionTwo.WebServiceFibonacci;
using System.Threading.Tasks;
using log4net;

namespace BackgroundWorkerSample
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The backgroundworker object on which the time consuming operation shall be executed
        /// </summary>
        BackgroundWorker m_oWorker;

        /// <summary>
        /// The result of calculation
        /// </summary>
        double resultOfCalculation;

        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// On completed do the appropriate task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                lblStatus.Text = "Task Completed...";
                textBox1.Text = resultOfCalculation.ToString();
            }
            btnStartAsyncOperation.Enabled = true;
            this.ControlBox = true;
        }

        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "WinForm is busy......" + progressBar1.Value.ToString() + "%";
        }

        /// <summary>
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            resultOfCalculation = GetFibonacciAsync(10).Result;

            //time consuming operation
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                m_oWorker.ReportProgress(i);
            }

            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }

        /// <summary>
        /// Handle the Start Compute Fibonacci Button Click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            btnStartAsyncOperation.Enabled = false;
            textBox1.Text = "";
            this.ControlBox = false;
            //Start the async operation here
            m_oWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handle the button Cancel Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {
                //Stop/Cancel the async operation here
                m_oWorker.CancelAsync();
            }
        }

        /// <summary>
        /// This method is used to call the fibonacci service asynchronously
        /// </summary>
        /// <param name="n">The integer parameter</param>
        /// <returns>Double</returns>
        private async Task<double> GetFibonacciAsync(int n)
        {
            try
            {
                log.Info("We are trying to call fibo");

                WebServiceFibonacci webServiceFibonacci = new WebServiceFibonacci();

                var result = Task.Run(() => webServiceFibonacci.Fibonacci(n));

                return await result;
            }
            catch (Exception ex)
            {
                log.Info("An exception is occured while trying to connect to fibonacci service" + ex.Message);
                throw;
            }
        }
    }
}
