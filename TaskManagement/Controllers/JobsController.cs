using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TM.Data.Models;
using TM.Services.Interfaces;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            try
            {
                return Ok(await _jobsService.GetJobs());

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(string id)
        {
            try
            {
                var job = await _jobsService.GetJobById(id);

                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }

        [HttpPut]
        public async Task<IActionResult> PutJob(Job job)
        {
            try
            {
                _jobsService.UpdateJob(job);
                await _jobsService.Save();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _jobsService.GetJobById(job.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            try
            {
                await _jobsService.NewJob(job);
            }
            catch (DbUpdateException)
            {
                if (await _jobsService.GetJobById(job.Id)!= null)
                {
                    return Conflict("Job exists");
                }

                return BadRequest();
            }

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(string id)
        {
            try
            {
                var job = await _jobsService.GetJobById(id);
                if (job == null)
                {
                    return NotFound();
                }

                await _jobsService.DeleteJob(id);
                await _jobsService.Save();

                return Ok(job);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
