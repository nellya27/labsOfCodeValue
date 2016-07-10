using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;
using System.Collections;


namespace ShapesApp
{
    public class ShapeMenager
    {
        private ArrayList m_ListOfShapes=new ArrayList();
        private IPersist m_Write;
                 
        public void Add(Shape i_NewShape)
        {
            m_ListOfShapes.Add(i_NewShape);
        }

        public void DisplayAll()
        {            
            foreach (Shape shape in m_ListOfShapes)
            {

                shape.Display();
                Console.WriteLine("The Area Of The shape:{0}{1}", shape.Area,System.Environment.NewLine);                   
            }
        }

        public int Count
        {
            get { return m_ListOfShapes.Count; }
        }

        public Shape this[int indexer]
        {
           get {return m_ListOfShapes[indexer] as Shape;}
        }

        public void Save(StringBuilder sb)
        {
           
           for(int i=0;i<m_ListOfShapes.Count;i++)
            {
                if(m_ListOfShapes[i] is Ellipse)
                {
                    m_Write =m_ListOfShapes[i] as Ellipse;
                    m_Write.Write(sb);
                }
                if(m_ListOfShapes[i] is Rectangle)
                {
                    m_Write =m_ListOfShapes[i] as Rectangle;
                    m_Write.Write(sb);
                }
            }
          
        }

    }
    
}
