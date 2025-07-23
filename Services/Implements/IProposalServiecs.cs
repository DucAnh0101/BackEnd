using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface IProposalServiecs
    {
        List<ProposalRes> GetProposalByUid(int id);
        void DeleteProposal(int id);
        Proposal UpdateProposal(ProposalReq proposal, int id);
        ProposalRes GetProposalById(int id);
        Proposal CreateProposal(ProposalReq proposal, int id);
    }
}
