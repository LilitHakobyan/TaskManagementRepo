using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Interfaces;
using TM.Data.Models;
using TM.Data.Repositories;
using TM.Services.Interfaces;

namespace TM.Services.Implementations
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepository _jobRepositoryRepository;

        public JobsService()
        {
            _jobRepositoryRepository = new JobsRepository(new ApplicationContext());
        }

        public JobsService(IJobsRepository jobRepositoryRepository)
        {
            _jobRepositoryRepository = jobRepositoryRepository;
        }
        public async Task DeleteJob(string id)
        {
           await _jobRepositoryRepository.DeleteJob(id);
        }

        public async Task<Job> GetJobById(string id)
        {
           return await _jobRepositoryRepository.GetJobById(id);
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
         return await _jobRepositoryRepository.GetJobs();
        }

        public async Task NewJob(Job job)
        {
           await _jobRepositoryRepository.NewJob(job);
        }

        public async Task Save()
        {
           await _jobRepositoryRepository.Save();
        }

        public void UpdateJob(Job job)
        {
            _jobRepositoryRepository.UpdateJob(job);
        }
    }
}
