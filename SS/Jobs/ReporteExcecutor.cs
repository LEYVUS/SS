using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Jobs
{
    public class ReporteExcecutor
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<Reporte>().Build();

            ITrigger trigger = TriggerBuilder.Create()
           .WithIdentity("trigger1", "group1")
           .StartNow()
           .WithSimpleSchedule(x => x
               .WithIntervalInHours(24)
               .RepeatForever())
           .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}