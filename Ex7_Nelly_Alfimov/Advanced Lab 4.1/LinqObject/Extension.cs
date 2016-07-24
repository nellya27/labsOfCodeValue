using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObject
{
    public static class Extension
    {
        public static void CopyTo(this object source,object dest)
        { 
            var properties = from s in source.GetType().GetProperties()
                             from d in dest.GetType().GetProperties()
                             where s.PropertyType.IsPublic && d.PropertyType.IsPublic
                             && s.CanRead && d.CanWrite &&
                             s.PropertyType == d.PropertyType
                             select new { PropertyS = s, PropertyD = d };

            foreach (var item in properties)
            {
                item.PropertyD.SetValue(dest, item.PropertyS.GetValue(source, new object[] { }), new object[] { });
            }
        }
    }
}
