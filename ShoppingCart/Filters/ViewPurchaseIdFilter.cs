using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Web.Routing;

namespace ShoppingCart.Filters
{
    public class ViewPurchaseIdFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            string sessionId = HttpContext.Current.Request["sessionId"];
            string authorizedSessionId = (string)HttpContext.Current.Session["sessionId"];

            if (sessionId != authorizedSessionId )
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Main " }
                    }
                );
            }
        }
    }
        
}
