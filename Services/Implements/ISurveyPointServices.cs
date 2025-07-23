using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface ISurveyPointServices
    {
        List<SurveyPointRes> GetSurveyPointBySurveyLineId(int id);
        SurveyPoint CreateSurveyPonit(SurveyPointReq req, int id);
        List<SurveyPointReq> SearchSurveyPointByName(string? name, int id, DateOnly? from, DateOnly? to);
        void DeleteSurveyPoint(int id);
        LocationDesDto CreateLocation(LocationDesDto location, int id);
        void UpdateLocation(LocationDesDto location, int id);
        HydrologyDto CreateHydrology(HydrologyDto hydrology, int id);
        void UpdateHydrology(HydrologyDto hydrology, int id);
        VegetationCoverDto CreateVegetationCover(VegetationCoverDto vegetationCover, int id);
        void UpdateVegetationCover(VegetationCoverDto vegetationCover, int id);
    }
}
