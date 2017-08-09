using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FluentScheduler;

namespace FluentSchedulerImpl
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            JobManager.Initialize(new MyFluentSchedulerRegistry());
            JobManager.Start();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            JobManager.Stop();
            //JobManager.StopAndBlock();

        }
    }
}