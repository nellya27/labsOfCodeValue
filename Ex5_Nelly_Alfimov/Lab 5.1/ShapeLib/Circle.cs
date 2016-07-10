using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        private double m_Radius;
               
        public Circle(double i_Radius,ConsoleColor i_Color):base(i_Radius,i_Radius,i_Color)
        {
            m_Radius = i_Radius;
        }
        
        public override double Area
        {
            get
            {
                return base.Area;
            }
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("Circle Radius:{0}", m_Radius);
        }
    }
}
