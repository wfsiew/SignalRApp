using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRApp.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class AuthAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        private bool IsAdmin(HttpSessionStateBase se)
        {
            return se["adminid"] != null;
        }
    }
}