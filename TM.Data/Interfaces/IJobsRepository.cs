using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Models;
using TM.Data.Repositories;

namespace TM.Data.Interfaces
{
    public interface IJobsRepository
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJobById(string id);
        Task NewJob(Job job);
        void UpdateJob(Job job);
        Task DeleteJob(string id);
        Task Save();
    }
}
