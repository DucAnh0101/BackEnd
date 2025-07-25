using DataAccessLayer.DTOs.request;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalServiecs proposalServiecs;
        public ProposalController(IProposalServiecs _proposalServiecs)
        {
            proposalServiecs = _proposalServiecs;
        }

        [HttpPost("create_proposal")]
        public async Task<IActionResult> CreateProposal([FromBody] ProposalReq req, int id)
        {
            try
            {
                var p = proposalServiecs.CreateProposal(req, id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_proposals/{id}")]
        public async Task<IActionResult> GetProposalById(int id)
        {
            try
            {
                var p = proposalServiecs.GetProposalById(id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_proposalbyuser/{id}")]
        public async Task<IActionResult> GetProposalByUId(int id)
        {
            try
            {
                var p = proposalServiecs.GetProposalByUid(id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_proposal/{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            try
            {
                proposalServiecs.DeleteProposal(id);
                return Ok("Proposal deteled successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update_proposal/{id}")]
        public async Task<IActionResult> UpdatdProposal(ProposalReq req, [FromRoute] int id)
        {
            try
            {
                var p = proposalServiecs.UpdateProposal(req, id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

