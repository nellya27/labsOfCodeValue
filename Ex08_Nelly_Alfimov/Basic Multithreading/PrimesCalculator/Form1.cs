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

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource sourcceToken;
        private CancellationToken token;
     
        public Form1()
        {
          
            InitializeComponent();           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            sourcceToken = new CancellationTokenSource();
            token = sourcceToken.Token;
            List<int> primes = new List<int>();
            CancelButton.IsAccessible = true;
            Task<List<int>> newTask = Task<List<int>>.Factory.StartNew(() => CalcPrimes(token));
            Task task = newTask.ContinueWith((t) => { var result = t.Result;
                DisplayInListBox(result);
            });
                                                          
        }
        

        public List <int> CalcPrimes(CancellationToken token)
        {
            int startRange =int.Parse(firstNumber.Text.ToString());
            int endRange = int.Parse(secondNumber.Text.ToString());
            List<int> listOfPrimes = new List<int>();
            for (int i = startRange; i < endRange; i++)
            {
                Thread.Sleep(1000);
                
                if (token.IsCancellationRequested)
                {
                    break;
                }
                else
                {
                    FindPrimes(i, listOfPrimes);  
                }
            }
            return listOfPrimes;
        }

        private void DisplayInListBox(List<int> list)
        {
            foreach(int number in list)
            {
                listOfPrimes.Items.Add(number.ToString());
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            if (sourcceToken != null)
            {
                sourcceToken.Cancel();
                sourcceToken.Dispose();
                sourcceToken = null;
            }
        }

        private void FindPrimes(int rangeNumber,List<int> listOfPrimes)
        {
            bool isPrime = true;

            for (int j = 2; j <rangeNumber ; j++)
            {
               
                if (rangeNumber % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                listOfPrimes.Add(rangeNumber);
            }
        }
    }
}
