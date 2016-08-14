using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    public class Program
    {
        public static void Main()
        {
            ProjectBuilder build = new ProjectBuilder();
            build.SequentialBuild();
        }
    }
}
