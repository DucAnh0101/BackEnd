using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;

namespace Services.Services
{
    public class SurveyLineServices : ISurveyLineServices
    {
        private readonly MyDbContext myDbContext;
        public SurveyLineServices(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public SurveyLine CreateSurveyLine(SurveyLineReq req, int id)
        {
            if (req == null) throw new ArgumentNullException("Please fill all information needed!");
            if (id <= 0) throw new ArgumentOutOfRangeException("id");
            var s = new SurveyLine
            {
                Name = req.Name,
                Status = req.Status,
                CompletionPercentage = req.CompletionPercentage,
                IsDelete = req.IsDelete,
                CreatedDate = req.CreatedDate,
                ProjectId = id
            };

            myDbContext.SurveyLines.Add(s);
            myDbContext.SaveChanges();
            return myDbContext.SurveyLines
                .FirstOrDefault(a => a.SlId == s.SlId);
        }

        public void DeleteSurveyLine(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("id");
            var s = myDbContext.SurveyLines
                .FirstOrDefault(a => a.SlId == id);

            s.IsDelete = true;
            myDbContext.SaveChanges();
        }

        public SurveyLineRes GetSurveyLineResById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            var s = myDbContext.SurveyLines
                .Include(a => a.SurveyPoints)
                .Where(a => a.SlId == id)
                .Select(sl => new SurveyLineRes
                {
                    SlId = sl.SlId,
                    Name = sl.Name,
                    Status = sl.Status,
                    CompletionPercentage = sl.CompletionPercentage,
                    IsDelete = sl.IsDelete,
                    CreatedDate = sl.CreatedDate,
                    SurveyPoints = sl.SurveyPoints
                        .Where(sp => !sp.IsDelete)
                        .Select(sp => new SurveyPointReturn
                        {
                            Id = sp.SpId,
                            SurveyName = sp.SurveyName,
                            Latitude = sp.Latitude,
                            Longitude = sp.Longitude,
                            Altitude = sp.Altitude,
                            Address = sp.Address
                        }).ToList()
                })
                .FirstOrDefault();

            if (s == null)
                throw new Exception("SurveyLine not found.");

            return s;
        }

        public List<SurveyLineRes> GetSurveyLineResByPrjId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            var s = myDbContext.SurveyLines
                .Include(a => a.SurveyPoints)
                .Where(a => a.ProjectId == id)
                .Select(sl => new SurveyLineRes
                {
                    SlId = sl.SlId,
                    Name = sl.Name,
                    Status = sl.Status,
                    CompletionPercentage = sl.CompletionPercentage,
                    IsDelete = sl.IsDelete,
                    CreatedDate = sl.CreatedDate,
                    SurveyPoints = sl.SurveyPoints
                        .Where(sp => !sp.IsDelete)
                        .Select(sp => new SurveyPointReturn
                        {
                            Id = sp.SpId,
                            SurveyName = sp.SurveyName,
                            Latitude = sp.Latitude,
                            Longitude = sp.Longitude,
                            Altitude = sp.Altitude,
                            Address = sp.Address
                        }).ToList()
                })
                .ToList();

            if (!s.Any())
                throw new Exception("No surveyLines found.");

            return s;
        }

        public SurveyLine UpdateSurveyLine(SurveyLineReq req, int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            var s = myDbContext.SurveyLines.FirstOrDefault(a => a.SlId == id);

            if (s == null) throw new Exception($"No survey line found with id {id}");

            s.Name = req.Name;
            s.Status = req.Status;
            s.CompletionPercentage = req.CompletionPercentage;
            s.IsDelete = req.IsDelete;
            s.CreatedDate = req.CreatedDate;

            myDbContext.SaveChanges();

            return s;
        }
    }
}
