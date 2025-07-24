using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;

namespace Services.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly MyDbContext myDbContext;
        public ProjectServices(MyDbContext _myDbContext)
        {
            myDbContext = _myDbContext;
        }
        public Project CreateProject(ProjectReq req)
        {
            if (req == null) throw new ArgumentNullException("Please enter all informaiton");
            var p = new Project
            {
                Name = req.Name,
                CreatedDate = req.CreatedDate,
                EndDate = req.EndDate,
            };
            myDbContext.Projects.Add(p);
            myDbContext.SaveChanges();
            return myDbContext.Projects.FirstOrDefault(i => i.PrId == p.PrId);
        }

        public void DeleteProject(int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = myDbContext.Projects.FirstOrDefault(i => i.PrId == id);
            if (p == null) throw new Exception($"Can not found the project with id {id}");

            p.IsDelete = true;
            myDbContext.SaveChanges();
        }

        public ProjectRes GetProjectById(int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = myDbContext.Projects
                .Include(a => a.SurveyLines)
                .Where(b => b.PrId == id && !b.IsDelete)
                .Select(c => new ProjectRes
                {
                    PrId = c.PrId,
                    Name = c.Name,
                    CreatedDate = c.CreatedDate,
                    EndDate = c.EndDate,
                    SurveyLines = c.SurveyLines
                        .Where(d => !d.IsDelete)
                        .Select(e => new SurveyLineRes
                        {
                            SlId = e.SlId,
                            Name = e.Name,
                            CreatedDate = e.CreatedDate,
                            CompletionPercentage = e.CompletionPercentage,
                            Status = e.Status
                        }).ToList()
                })
                .FirstOrDefault();
            if (p == null) throw new Exception($"Can not found the project with id {id}");
            return p;
        }

        public List<ProjectRes> GetProjectsByProposalId(int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = myDbContext.Projects
                .Include(a => a.SurveyLines)
                .Where(b => b.ProposalId == id && !b.IsDelete)
                .Select(c => new ProjectRes
                {
                    PrId = c.PrId,
                    Name = c.Name,
                    CreatedDate = c.CreatedDate,
                    EndDate = c.EndDate,
                    SurveyLines = c.SurveyLines
                        .Where(d => !d.IsDelete)
                        .Select(e => new SurveyLineRes
                        {
                            SlId = e.SlId,
                            Name = e.Name,
                            CreatedDate = e.CreatedDate,
                            CompletionPercentage = e.CompletionPercentage,
                            Status = e.Status
                        }).ToList()
                })
                .ToList();
            if (p == null) throw new Exception($"Can not found the project with id {id}");
            return p;
        }

        public List<ProjectRes> SearchProject(string? name, int? status, DateOnly? from, DateOnly? to)
        {
            var query = myDbContext.Projects
                .Include(p => p.SurveyLines)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                string namePattern = $"%{name.Trim().ToLower()}%";
                query = query.Where(pr => EF.Functions.Like(pr.Name.Trim().ToLower(), namePattern));
            }

            if (from.HasValue)
            {
                query = query.Where(pr => pr.CreatedDate >= from.Value);
            }

            if (to.HasValue) query = query.Where(pr => pr.EndDate <= to.Value);

            if (status.HasValue) query = query.Where(pr =>
                    pr.SurveyLines.Any(sl => (int)sl.Status == status));

            var result = query.Select(pr => new ProjectRes
            {
                PrId = pr.PrId,
                Name = pr.Name,
                CreatedDate = pr.CreatedDate,
                EndDate = pr.EndDate,
                SurveyLines = pr.SurveyLines.Select(sl => new SurveyLineRes
                {
                    SlId = sl.SlId,
                    Name = sl.Name,
                    Status = sl.Status,
                    CompletionPercentage = sl.CompletionPercentage,
                    CreatedDate = sl.CreatedDate
                }).ToList()
            }).ToList();

            if (!result.Any())
                throw new Exception("No project found matching the criteria.");

            return result;
        }

        public Project UpdateProject(ProjectReq req, int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var p = myDbContext.Projects.FirstOrDefault(i => i.PrId == id);
            if (p == null) throw new Exception($"Can not found the project with id {id}");

            p.Name = req.Name;
            p.CreatedDate = req.CreatedDate;
            p.EndDate = req.EndDate;

            myDbContext.SaveChanges();
            return myDbContext.Projects.FirstOrDefault(i => i.PrId == p.PrId);
        }
    }
}
