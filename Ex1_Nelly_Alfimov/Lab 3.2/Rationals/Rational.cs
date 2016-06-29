using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;




namespace Rationals
{
    public struct Rational
    {
        private int Numerator;
        private int Denominator;

        public Rational(int i_Numerator,int i_Denominator)//Constractor that get two values
        {
            Numerator = i_Numerator;
            Denominator = i_Denominator;
        }

        public Rational(int i_Numerator)//constractor that gets one value of numinator the denominator as default 1 
        {
            Numerator = i_Numerator;
            Denominator = 1;
        }

        public int GetNumerator
        {
            get { return Numerator; }
        }

        public double GetAsDouble
        {
            get { return (double)Numerator / (double)Denominator; }

        }

        public int GetDenumenator
        {
            get { return Denominator; }
        }

        public Rational Add(Rational i_NewRat)
        {
   
            int newDenumenator = 0;
            int newNuminator = 0;
            
            if (i_NewRat.GetDenumenator==this.Denominator)
            {
                newNuminator = this.Numerator + i_NewRat.GetNumerator;
                newDenumenator =this.Denominator;         
            }
            else
            {
                newDenumenator = i_NewRat.GetDenumenator *this.Denominator;
                newNuminator = (this.Denominator * i_NewRat.GetNumerator) + (i_NewRat.GetDenumenator * this.Numerator);
            }

            return new Rational(newNuminator, newDenumenator);

        }

        public Rational Mul(Rational i_NewRat)//multiplies two rational objects
        {
            int newNuminator = i_NewRat.GetNumerator *this.Numerator;
            int newDenuminator =i_NewRat.Denominator*this.Denominator;
            return new Rational(newNuminator, newDenuminator);             
        }

        public void Reduce()//simplify the number
        {
            int gcdResult =(int)BigInteger.GreatestCommonDivisor(this.Numerator,this.Denominator);
            this.Numerator=this.Numerator/gcdResult;
            this.Denominator = this.Denominator / gcdResult;
        }

        public override string ToString()//overriding Tostring 
        {
            string rationalNum = string.Empty;
            if(Denominator==1)
            {
                rationalNum = string.Format("The rational number is: {0}", Numerator);
            }
            else
            {
                rationalNum = string.Format("The rational number is {0}/{1}", Numerator, Denominator);
            }
            return rationalNum;
        }

        public override bool Equals(object other)//overriding Equals
        {
            if (other is Rational)
            {
                Rational newRational = (Rational)other;
                return this.Denominator == newRational.GetDenumenator && this.Numerator == newRational.GetNumerator;
            }
            else
                return false;
                       
        }

    }
}

