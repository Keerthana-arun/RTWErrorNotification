using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWErrorNotification.Models;
using System;
using System.Collections.Generic;

namespace RTWErrorNotification.Data
{
    public static class MockDatabase
    {
        private static List<CandidateViewModel> candidates = new List<CandidateViewModel>
        {
            new CandidateViewModel { Id = 1, Name = "vishnu vardhan", Email = "vishnuvardhan007.d@gmail.com", ErrorMessage = "Document verification failed." },
            new CandidateViewModel { Id = 2, Name = "Vishnu royal", Email = "vishnuroyal007.d@gmail.com", ErrorMessage = "Address verification failed." }
            // Add more mock data as needed
        };

        public static List<CandidateViewModel> GetCandidatesWithErrors()
        {
            // Simulate retrieving candidates with errors from database
            return candidates;
        }
    }
}

