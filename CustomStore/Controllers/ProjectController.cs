using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices projectServices;
        public ProjectController(IProjectServices projectServices)
        {
            this.projectServices = projectServices;
        }

        [HttpPost("create_project")]
        public async Task<IActionResult> CreateProject(ProjectReq req)
        {
            try
            {
                projectServices.CreateProject(req);
                return Ok("Create project successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update_project/{id}")]
        public async Task<IActionResult> UpdateProject(ProjectReq req, [FromRoute] int id)
        {
            try
            {
                projectServices.CreateProject(req);
                return Ok("Create project successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_project/{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            try
            {
                projectServices.DeleteProject(id);
                return Ok("Project deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbyprojectid/{id}")]
        public async Task<IActionResult> GetProjectById([FromRoute] int id)
        {
            try
            {
                var p = projectServices.GetProjectById(id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_projectsbyid/{id}")]
        public async Task<IActionResult> GetProjectByProposalId([FromRoute] int id)
        {
            try
            {
                var p = projectServices.GetProjectsByProposalId(id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? name, int? status, DateOnly? from, DateOnly? to, int id)
        {
            try
            {
                var p = projectServices.SearchProject(name, status, from, to, id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
