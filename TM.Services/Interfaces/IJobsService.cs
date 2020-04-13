using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Data.Models;

namespace TM.Services.Interfaces
{
    public interface IJobsService
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJobById(string id);
        Task NewJob(Job job);
        void UpdateJob(Job job);
        Task DeleteJob(string id);
        Task Save();
    }
}
