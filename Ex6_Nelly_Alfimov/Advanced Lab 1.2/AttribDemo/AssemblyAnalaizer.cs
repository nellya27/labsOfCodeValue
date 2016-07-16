using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class AssemblyAnalaizer
    {
        public bool AnalaizeAssembly(Assembly assemblyType)
        {
            bool isApproved = true;

            foreach(Type item in assemblyType.GetTypes())
            {

                object[] attributeList =item.GetCustomAttributes(typeof(CodeReviewAttribute), true);
                if (attributeList.Length>0)
                {

                    foreach (CodeReviewAttribute att in attributeList)
                    {
                        if (att.GetApproval)
                        {
                            isApproved = false;
                        }

                        Console.WriteLine("Reveiw writer:{0},Review date:{1},the Review apprved:{2}", att.GetReviewerName, att.GetReviewDate, att.GetApproval);
                    }
                }              
            }

            return isApproved;
        }
    }
    
}
