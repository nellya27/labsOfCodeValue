using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape,IPersist,IComparable
    {
       protected const double k_PI = 3.147;
       protected double m_AxisA;
       protected double m_AxisB;
       
       public Ellipse(double i_AxisA,double i_AxisB,ConsoleColor i_Color):base(i_Color)
        {
            m_AxisA = i_AxisA;
            m_AxisB = i_AxisB;
        } 

        public override double Area
        {
            get
            {
                return m_AxisB * m_AxisA * k_PI;
            }
        }

        public int CompareTo(object obj)
        {
            int compareRes = 1;
            Ellipse otherRectangle = obj as Ellipse;
            if (this.Area == otherRectangle.Area)
            {
                compareRes = 0;
            }
            else if (this.Area > otherRectangle.Area)
            {
                compareRes = -1;
            }

            return compareRes;
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("Ellipse A semimajor:{0} Ellipse B semimajor: {1}", m_AxisA, m_AxisB);

        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Ellipse Width:"+m_AxisA.ToString());
            sb.AppendLine("Ellipse Height:"+m_AxisB.ToString());
        }
    }
}
