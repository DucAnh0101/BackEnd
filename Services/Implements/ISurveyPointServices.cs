using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface ISurveyPointServices
    {
        List<SurveyPointRes> GetSurveyPointByUId(int id);
        SurveyPoint CreateSurveyPonit(SurveyPointReq req);
        void DeleteSurveyPoint(int id);
    }
}
