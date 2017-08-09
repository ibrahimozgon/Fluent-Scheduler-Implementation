using System;
using System.Diagnostics;
using FluentScheduler;

namespace FluentSchedulerImpl
{
    public class MyFluentSchedulerRegistry : Registry
    {
        public MyFluentSchedulerRegistry()
        {
            Schedule<EmailNotificationJob>()
                .NonReentrant()
                .ToRunNow()
                .AndEvery(10)
                .Seconds();
        }
    }
}