using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
           
        public Form1()
        {
          
            InitializeComponent();           
        }

        private async void calcButton_Click(object sender, EventArgs e)
        {
            int start = int.Parse(firstNumber.Text.ToString());
            int end = int.Parse(secondNumber.Text.ToString());
            CancellationTokenSource sourceToken = new CancellationTokenSource();
            CancellationToken token =sourceToken.Token;
            sourceToken.CancelAfter(5000);
            Task<int> taskResult = CountPrimesAsync(start,end,token);
            int result = await taskResult;
            formLabel.Text = result.ToString();
            WriteResultToFile();
            DisposeCancellationToken(sourceToken);                                                        
        }

        private void DisposeCancellationToken(CancellationTokenSource source)
        {
            if (source != null)
            {
                source.Dispose();
                source = null;
            }
        }

        private void WriteResultToFile()
        {
            string path = "c:\\Temp\\" + outputFile.Text.ToString() + ".txt";
            StreamWriter newFile = File.AppendText(path);
            newFile.Write(formLabel.Text.ToString());
            newFile.Close();
        }
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            
        }

        private async static Task<int> CountPrimesAsync(int firstNumber, int endNumber,CancellationToken token)
        {
            return await Task.Factory.StartNew(() =>
            {
             

                int numOfPrimes = 0;
                for (int i = firstNumber; i < endNumber; i++)
                {
                                   
                    if(token.IsCancellationRequested)
                    {
                        break;
                    }

                    bool isPrime = true;
                    for (int j = 2; j < i; j++)
                    {

                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        numOfPrimes++;
                    }
                }
                return numOfPrimes;
            });
        }
       
    }
}
