using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;

namespace Services.Services
{
    public class ProposalServiecs : IProposalServiecs
    {
        private readonly MyDbContext dbContext;
        public ProposalServiecs(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Proposal CreateProposal(ProposalReq proposal, int id)
        {
            if (proposal == null) throw new Exception("Please enter all informaiton needed");
            var addP = new Proposal
            {
                Name = proposal.Name,
                CreatedDate = proposal.CreatedDate,
                EndDate = proposal.EndDate,
                IsDelete = false,
                UserId = id
            };

            dbContext.Proposals.Add(addP);
            dbContext.SaveChanges();

            return dbContext.Proposals.FirstOrDefault(p => p.PId == addP.PId);
        }

        public void DeleteProposal(int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = dbContext.Proposals
                .FirstOrDefault(i => i.PId == id);
            if (p == null) throw new Exception($"Cam not foud proposal with id {id}");

            p.IsDelete = true;
            dbContext.SaveChanges();
        }

        public ProposalRes GetProposalById(int id)
        {
            if (id <= 0) throw new Exception("Please enter a valid id of the proposal");

            var proposal = dbContext.Proposals
                .Include(p => p.Projects)
                .Where(p => p.PId == id && !p.IsDelete)
                .Select(p => new ProposalRes
                {
                    PId = p.PId,
                    Name = p.Name,
                    CreatedDate = p.CreatedDate,
                    EndDate = p.EndDate,
                    ProjectRes = p.Projects
                        .Where(pr => !pr.IsDelete)
                        .Select(pr => new ProjectRes
                        {
                            PrId = pr.PrId,
                            Name = pr.Name,
                            CreatedDate = pr.CreatedDate,
                            EndDate = pr.EndDate
                        }).ToList()
                })
                .FirstOrDefault();

            if (proposal == null)
            {
                throw new Exception($"No proposal found with id {id}");
            }

            return proposal;
        }


        public List<ProposalRes> GetProposalByUid(int id)
        {
            if (id <= 0) throw new Exception("Please enter a valid id of the proposal");
            var proposal = dbContext.Proposals
               .Include(p => p.Projects)
               .Where(p => p.UserId == id && !p.IsDelete)
               .Select(p => new ProposalRes
               {
                   PId = p.PId,
                   Name = p.Name,
                   CreatedDate = p.CreatedDate,
                   EndDate = p.EndDate,
                   ProjectRes = p.Projects
                       .Where(pr => !pr.IsDelete)
                       .Select(pr => new ProjectRes
                       {
                           PrId = pr.PrId,
                           Name = pr.Name,
                           CreatedDate = pr.CreatedDate,
                           EndDate = pr.EndDate
                       }).ToList()
               })
               .ToList();
            if (proposal.Count() <= 0)
            {
                throw new Exception($"No proposal found with id {id}");
            }
            return proposal;
        }

        public Proposal UpdateProposal(ProposalReq proposal, int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = dbContext.Proposals.FirstOrDefault(o => o.PId == id && !o.IsDelete);
            if (p == null) throw new Exception($"No proposal found with id {id}");

            p.Name = proposal.Name;
            p.CreatedDate = proposal.CreatedDate;
            p.EndDate = proposal.EndDate;

            dbContext.SaveChanges();
            return dbContext.Proposals.FirstOrDefault(o => o.PId == id);
        }
    }
}
