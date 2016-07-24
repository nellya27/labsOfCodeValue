using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xlinq
{
    public class Program
    {
        public static void Main()
        {

            XmlDocBuilder xmlDoc = new XmlDocBuilder();
            XElement newElement = new XElement("Classes");
            xmlDoc.GetXmlDoc(newElement);
          
            QueryBuilder linqQuery = new QueryBuilder();
            linqQuery.GetTypeWithNoProperty();
            linqQuery.GetTotalMethodAmount();
            linqQuery.GetPropertyStatistics();
            linqQuery.GetMostCommonParameterType();
            linqQuery.SortTypeByMethodNumber();
            linqQuery.GroupByMethodNumber();

        }
    }
}
