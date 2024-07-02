using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using RTWErrorNotification.Data;
using RTWErrorNotification.Models;
using RTWErrorNotification.Services;


namespace RTWErrorNotification
{
    public class EmailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            List<CandidateViewModel> candidatesWithErrors = MockDatabase.GetCandidatesWithErrors();
            SendEmail.SendErrorMail(candidatesWithErrors);
            return Task.CompletedTask;
        }
    }
}
