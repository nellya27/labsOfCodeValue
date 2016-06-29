using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    public class Program
    {
        public static void Main()
        {
            ShapeMenager newShapes = new ShapeMenager();
            StringBuilder sbResult = new StringBuilder();
            newShapes.Add(new Ellipse(2, 3, ConsoleColor.Blue));
            newShapes.Add(new Rectangle(4, 5, ConsoleColor.DarkBlue));
            newShapes.Add(new Circle(5,ConsoleColor.DarkGreen));
            newShapes.DisplayAll();
            newShapes.Save(sbResult);
            Console.WriteLine(sbResult.ToString());
            Console.WriteLine("The number of shapes in shape maneger {0}",newShapes.Count);
            Console.WriteLine("The shape in 1 index is:{0}", newShapes[1]);

            Rectangle firstRect = new Rectangle(4, 5, ConsoleColor.Cyan);
            Rectangle secondRect = new Rectangle(3, 4, ConsoleColor.DarkMagenta);
            firstRect.Display();
            int compareResult = firstRect.CompareTo(secondRect);

            if(compareResult==0)
            {
                Console.WriteLine("The Areas Are Equal");
            }
            else if(compareResult==1)
            {
                Console.WriteLine("First rectangle area is bigger then the second");

            }
            else
            {
                Console.WriteLine("Second rectangle area is bigger then the first");
            }
                    
         
            }
        }
    }

