using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface ISurveyLineServices
    {
        SurveyLine CreateSurveyLine(SurveyLineReq req, int id);
        SurveyLine UpdateSurveyLine(SurveyLineReq req, int id);
        void DeleteSurveyLine(int id);
        SurveyLineRes GetSurveyLineResById(int id);
        List<SurveyLineRes> GetSurveyLineResByPrjId(int id);
    }
}
