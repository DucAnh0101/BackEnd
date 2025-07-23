using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface IProjectServices
    {
        void DeleteProject(int id);
        List<ProjectRes> GetProjectsByProposalId(int id);
        ProjectRes GetProjectById(int id);
        Project CreateProject(ProjectReq req);
        Project UpdateProject(ProjectReq req, int id);
        List<ProjectRes> SearchProject(string? name, int? status, DateOnly? from, DateOnly? to);

    }
}
