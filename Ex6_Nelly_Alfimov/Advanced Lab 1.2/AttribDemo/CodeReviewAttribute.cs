using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    using System;
    [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class,Inherited =true,AllowMultiple =true)]
    public class CodeReviewAttribute:Attribute
    {
        string reviewerName;
        string reviewDate;
        bool isApproved;

        public CodeReviewAttribute(string name,string date,bool result)
        {
            reviewerName = name;
            reviewDate = date;
            isApproved = result; 
        }
        public string GetReviewerName
        {
            get { return reviewerName; }
        }
        public string GetReviewDate
        {
            get { return reviewDate; }
        }
        public bool GetApproval
        {
            get { return isApproved; }
        }
    }
}
