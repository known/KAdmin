﻿using System;

namespace Known.WebApi
{
    /// <summary>
    /// 应用程序全局类。
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register();

            var context = Known.Context.Create();
            Core.Initializer.Initialize(context);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            if (ex != null)
            {
                Mail.Send("Web程序发生异常", ex);
            }
        }
    }
}