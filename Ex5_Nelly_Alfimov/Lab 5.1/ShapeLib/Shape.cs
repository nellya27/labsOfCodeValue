using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected ConsoleColor m_Color;
      
        public Shape(ConsoleColor i_Color)
        {
            m_Color = i_Color;
        }

        public  Shape()
        {
            m_Color = ConsoleColor.White;
        }

        public ConsoleColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public virtual void Display()
        {           
          Console.ForegroundColor=Color;
        }

        public abstract double Area { get; }
    }
}
