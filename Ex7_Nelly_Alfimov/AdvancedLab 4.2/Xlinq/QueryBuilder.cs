using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xlinq
{
    public class QueryBuilder
    {

        public void GetTypeWithNoProperty()
        {
          XElement element = XElement.Load("Classes.xml");
          var query = ( from t in element.Descendants("Type")
                       where t.Element("Properties").IsEmpty
                               orderby (string)t.Attribute("FullName")
                               select new { Name = t.Attribute("FullName").Value }).ToList();

            foreach(var item in query)
            {
                Console.WriteLine("Classes Name:{0}",item.Name);
            }
            Console.WriteLine("number of classes with no properties :{0}",query.Count);
        }

        public void GetPropertyStatistics()
        {

            XElement element = XElement.Load("Classes.xml");

            var query = (from p in element.Descendants("Properties")
                         select (p)).Count();
            Console.WriteLine(query);
        }


        public void GetTotalMethodAmount()
        {
            XElement element = XElement.Load("Classes.xml");
            var query = (from m in element.Descendants("Method")
                         select m).Count();

            Console.WriteLine(query);
                     

        }

        public void GetMostCommonParameterType()
        {
            XElement element = XElement.Load("Classes.xml");
            var query =( from t in element.Descendants("Parameters")
                        let type=t.Attribute("Type").Value
                        group t by type
                        into typeGroup
                        orderby typeGroup.Count() descending
                        select new { key = typeGroup.Key, Value = typeGroup }).First();
                                          
            Console.WriteLine(query.key);                      
        }

        public void SortTypeByMethodNumber()
        {

            XElement element = XElement.Load("Classes.xml");

            var query = (from t in element.Descendants("Type")
                        let methodNumber =(from g in t.Descendants("Method")
                                           select(g)).Count()
                        let propertyNumber=(from a in t.Descendants("Properties")
                                          select(a)).Count()
                        orderby methodNumber descending
                        select new {methodCount=methodNumber,propertyCount=propertyNumber,name=t.Attribute("FullName").Value }).Distinct();
          
            query.ToList();
            var newXmlDoc = new XElement("Type", from d in query
                                                 select new XElement("Type", new XAttribute("FullName", d.name), new XAttribute("NumberOfMethos", d.methodCount), new XAttribute("NumberOfProperties", d.propertyCount)));
                                             
            XElement doc = newXmlDoc;
            doc.Save("newDocument.xml");
        }

        public void GroupByMethodNumber()
        {

            XElement element = XElement.Load("Classes.xml");
            var query =(from t in element.Descendants("Type")
                        let name=t.Attribute("FullName").Value
                        orderby name ascending
                        let methodNumber = (from g in t.Descendants("Method")
                                             select (g)).Count()

                        group t by methodNumber into newGroup
                        orderby newGroup.Key descending                       
                        select new { Key =newGroup.Key,Value=newGroup }).Distinct();


            foreach (var item in query)
            {
                Console.WriteLine(item.Key);

                foreach (var d in item.Value)
                {
                    Console.WriteLine(d.LastAttribute);
                }
            }
      

        }
        
    }
}
