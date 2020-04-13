using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TM.Data.Helper;
using TM.Data.Interfaces;
using TM.Data.Models;

namespace TM.Data.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ApplicationContext _dbContext;

        public JobsRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _dbContext.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobById(string id)
        {
            var job = await _dbContext.Jobs.FindAsync(id);
            return job;
        }

        public async Task NewJob(Job job)
        {
            job.Id = Guid.NewGuid().ToString();
            job.CreatedDate = DateTimeHelper.DateTimeNow();//DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            await _dbContext.Jobs.AddAsync(job);
            await Save();
        }

        public void UpdateJob(Job job)
        {
            _dbContext.Entry(job).State = EntityState.Modified;
        }

        public async Task DeleteJob(string id)
        {
            var job = await _dbContext.Jobs.FindAsync(id);
            if (job != null) _dbContext.Jobs.Remove(job);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
