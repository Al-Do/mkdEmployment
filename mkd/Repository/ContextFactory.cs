using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Repository
{
    public class ContextFactory
    {
        public static string dbContextKey = "MKDContext";
        public static ApplicationContext GetDBContext()
        {

            if (HttpContext.Current.Items[dbContextKey] != null)
            {
                return (ApplicationContext)HttpContext.Current.Items[dbContextKey];
            }
            var context = new ApplicationContext();
            HttpContext.Current.Items[dbContextKey] = context;

            return context;
        }
    }
}
