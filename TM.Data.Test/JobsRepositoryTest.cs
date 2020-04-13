using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TM.Data.Interfaces;
using TM.Data.Models;
using TM.Data.Repositories;

namespace TM.Data.Test
{
    [TestClass]
    public class JobsRepositoryTest
    {
        private DbContextOptionsBuilder optionsBuilder;
        string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JobMngSystemDb;Integrated Security=True";
        private readonly IJobsRepository _jobsRepository;

        public JobsRepositoryTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _jobsRepository = new JobsRepository(new ApplicationContext((DbContextOptions<ApplicationContext>) optionsBuilder.Options));
        }
        
       
        
        [TestMethod]
        public void GetJobs_Data_NotEmpty()
        {
            var jobs = _jobsRepository.GetJobs().Result;
            Assert.IsTrue(condition: jobs.Any());
        }

        [TestMethod]
        public void GetJobById_Job_Null()
        {
            var job = _jobsRepository.GetJobById("11ab51cc-5e73-4634-ad63-2cf6d88291ea").Result;
            Assert.AreEqual(job,null);
        }
    }
}
