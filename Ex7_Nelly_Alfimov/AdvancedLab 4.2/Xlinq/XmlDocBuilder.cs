using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xlinq
{
    public class XmlDocBuilder
    {

        public void GetXmlDoc(XElement element)
        {
            Assembly assembly = Assembly.Load("mscorlib");
            var xmlClassList = new XElement("Classes", from c in assembly.GetTypes()
                                                       where c.IsClass && c.IsPublic
                                                       select new XElement("Type", new XAttribute("FullName", c.FullName),
                                                       new XElement("Properties", from p in c.GetProperties()
                                                                                  select new XElement("Properties", new XAttribute("Name", p.Name), new XAttribute("Type", p.PropertyType))),
                                                        new XElement("Methods", from m in c.GetMethods()
                                                                                where m.IsPublic &&c.IsClass &&m.DeclaringType.ToString()==c.FullName
                                                                                select new XElement("Method", new XAttribute("Name", m.Name), new XAttribute("RetuurnType", m.ReturnType), new XElement("Prameters", from prm in m.GetParameters()
                                                                                                                                                                                                                     select new XElement("Parameters", new XAttribute("Name", prm.Name), new XAttribute("Type", prm.ParameterType)))))));
            element = xmlClassList;
            element.Save("Classes.xml");
        }

      
    }
}
