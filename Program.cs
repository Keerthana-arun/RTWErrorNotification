using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWErrorNotification.Data;
using RTWErrorNotification.Models;
using RTWErrorNotification.Services;
using System;
using System.Collections.Generic;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;


namespace RTWErrorNotification
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create a scheduler instance
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            // Define the job and tie it to the EmailJob class
            IJobDetail job = JobBuilder.Create<EmailJob>()
                .WithIdentity("emailJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 24 hours
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("emailTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(24) // Run once a day
                    .RepeatForever())
                .Build();

            // Schedule the job using the job and trigger
            await scheduler.ScheduleJob(job, trigger);

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();

            // Shutdown the scheduler when the application is closed
            await scheduler.Shutdown();
        }
    }
}