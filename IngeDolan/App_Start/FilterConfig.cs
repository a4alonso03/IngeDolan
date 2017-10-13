using System.Web;
using System.Web.Mvc;
using IngeDolan.App_Start;

namespace IngeDolan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MessagesActionFilter());
        }
    }
}
