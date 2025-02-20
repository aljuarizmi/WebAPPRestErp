using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class DapperExtensions
    {
        public static ExpandoObject Merge(this ExpandoObject obj, dynamic source)
        {
            var dict = (IDictionary<string, object>)obj;
            foreach (var prop in (IDictionary<string, object>)source)
            {
                dict[prop.Key] = prop.Value;
            }
            return obj;
        }
    }
}
