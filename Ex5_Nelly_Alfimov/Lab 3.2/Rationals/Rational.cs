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

        public static Rational operator *(Rational rational1,Rational rational2)//multiplies two rational objects
        {           
            return new Rational(rational1.GetNumerator*rational2.GetNumerator,rational1.GetDenumenator*rational2.GetDenumenator);             
        }

        public static Rational operator -(Rational rational1,Rational rational2)
        {
            
            if(rational1.GetDenumenator==rational2.GetDenumenator)
            {
                return new Rational(rational1.GetNumerator - rational2.GetNumerator, rational1.GetDenumenator);
            }
            else
            {
                return new Rational(rational1.GetNumerator * rational2.GetDenumenator - rational2.GetNumerator * rational1.GetDenumenator,rational1.GetDenumenator*rational2.GetDenumenator);
            }         
        }

        public static Rational operator+(Rational rational1,Rational rational2)
        {
            if(rational1.GetDenumenator==rational2.GetDenumenator)
            {
                return new Rational(rational1.GetNumerator + rational2.GetNumerator, rational2.GetDenumenator);
            }
            else
            {
                return new Rational(rational1.GetNumerator * rational2.GetDenumenator + rational2.GetNumerator * rational1.GetDenumenator, rational1.GetDenumenator * rational2.GetDenumenator);
            }
        }

        public static Rational operator /(Rational rational1,Rational rational2)
        {
                      
            return new Rational(rational1.Numerator * rational2.GetDenumenator, rational1.GetDenumenator * rational2.GetNumerator);
        }

        public void Reduce()//simplify the number
        {

            int gcdResult =(int)BigInteger.GreatestCommonDivisor(this.Numerator,this.Denominator);
            this.Numerator=this.Numerator/gcdResult;
            this.Denominator = this.Denominator/gcdResult;
        }

        public override string ToString()//overriding Tostring 
        {
            string rationalNum = string.Empty;
            
            if(Denominator==1)
            {
                rationalNum = string.Format("The rational number is: {0}", Numerator);
            }
            else if(Numerator<-1)
            {
                rationalNum = string.Format("The rational number is -{0}/{1}", Numerator, Denominator);
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
                this.Reduce();
                newRational.Reduce();
                return this.Denominator == newRational.GetDenumenator && this.Numerator == newRational.GetNumerator;
            }
            else
                return false;
                       
        }

        public override int GetHashCode()
        {
           return Numerator.GetHashCode() * GetDenumenator.GetHashCode();
        }

    }
}

