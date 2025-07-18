using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;

namespace Services.Services
{
    public class SurveyPointServices : ISurveyPointServices
    {
        private readonly MyDbContext myDbContext;
        public SurveyPointServices(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public SurveyPoint CreateSurveyPonit(SurveyPointReq req)
        {
            if (req == null) throw new Exception("Please enter all information needed!");
            try
            {
                var surveyp = new SurveyPoint
                {
                    SurveyName = req.SurveyName,
                    Latitude = req.Latitude,
                    Longitude = req.Longitude,
                    Altitude = req.Altitude,
                    Address = req.Address,
                    SurveyorId = req.SurveyorId,
                    IsActive = req.IsActive,
                };
                myDbContext.SurveyPoints.Add(surveyp);
                myDbContext.SaveChanges();

                return surveyp;
            }
            catch (Exception ex)
            {
                throw new Exception("Some things when wrong");
            }
        }

        public void DeleteSurveyPoint(int id)
        {
            var sp = myDbContext.SurveyPoints
                .FirstOrDefault(p => p.Id == id);
            if (sp == null) throw new Exception("No surveypoint was found!");

            sp.IsActive = false;
            myDbContext.SaveChanges();
        }

        public List<SurveyPointRes> GetSurveyPointByUId(int id)
        {
            var u = myDbContext.SurveyPoints
                .Include(s => s.Hydrology)
                .Include(s => s.LocationDescription)
                .Include(s => s.VegetationCover)
                .Where(s => s.SurveyorId == id && s.IsActive)
                .Select(sp => new SurveyPointRes
                {
                    Id = sp.Id,
                    SurveyName = sp.SurveyName,
                    Latitude = sp.Latitude,
                    Longitude = sp.Longitude,
                    Altitude = sp.Altitude,
                    Address = sp.Address
                }).ToList();

            if (!u.Any()) throw new Exception("No surveypoint was found!");
            return u;
            throw new Exception("Some things when wrong");
        }
    }
}
