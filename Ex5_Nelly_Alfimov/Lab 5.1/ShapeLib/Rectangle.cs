using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle:Shape,IPersist,IComparable
    {
      private  double m_Width;
      private  double m_Height;

        public Rectangle(double i_Width,double i_Height,ConsoleColor i_Color):base(i_Color)
        {
            m_Width = i_Width;
            m_Height = i_Height;
        }

        public override double Area
        {
            get
            {
               return m_Width * m_Height;
            }
        }
       
        public override void Display()
        {
            base.Display();

         Console.WriteLine("Rectangle Width:{0} , Rectangle Height: {1}", m_Width, m_Height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Rectangle Width:"+m_Width.ToString());
            sb.AppendLine("Rectangle Height:"+ m_Height.ToString());
        }

        public int CompareTo(object obj)
        {
            int compareRes = 1;
            Rectangle otherRectangle = obj as Rectangle;
            if(this.Area==otherRectangle.Area)
            {
                compareRes = 0;
            }
            else if(this.Area>otherRectangle.Area)
            {
                compareRes = -1;
            }

            return compareRes;

        }
    }
}
