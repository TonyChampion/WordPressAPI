using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI.Models;
using XmlRpcPortable.Converter;

namespace WordPressAPI.Helpers
{
    public class WordPressPostHelper
    {
        public static WordPressField GetField(string propertyName)
        {
            var postTypeInfo = typeof(WordPressPost).GetTypeInfo();
            var prop = postTypeInfo.GetDeclaredProperty(propertyName);

            if(prop != null)
            {
               var attr = prop.GetCustomAttribute<XmlRpcNameAttribute>();

               if(attr != null)
                {
                    return new WordPressField() { Field = propertyName, Mapping = attr.Name };
                }
            }

            return null;
        }
    }
}
