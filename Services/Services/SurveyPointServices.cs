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

        public HydrologyDto CreateHydrology(HydrologyDto hydrology, int id)
        {
            if (hydrology == null) throw new ArgumentNullException("Please fill all needed informaton");
            var ehydro = myDbContext.Hydrologies.FirstOrDefault(h => h.SurveyPointId == id);
            if (ehydro != null) throw new Exception("Hydro already exist in this database");
            try
            {
                var hydro = new Hydrology
                {
                    SurveyPointId = id,
                    WaterPresence = hydrology.WaterPresence,
                    WaterLevel = hydrology.WaterLevel,
                    WaterFlow = hydrology.WaterFlow,
                    DistanceToWaterSource = hydrology.DistanceToWaterSource,
                    WaterSourceFeatures = hydrology.WaterSourceFeatures,
                    SurfaceWaterType = hydrology.SurfaceWaterType,
                    SurfaceWaterLevel = hydrology.SurfaceWaterLevel,

                };

                myDbContext.Hydrologies.Add(hydro);
                myDbContext.SaveChanges();
                return hydrology;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not create hydrology");
            }
        }

        public LocationDesDto CreateLocation(LocationDesDto location, int id)
        {
            if (location == null) throw new ArgumentNullException("Please fill all needed informaton");
            var ehydro = myDbContext.LocationDescriptions.FirstOrDefault(h => h.SurveyPointId == id);
            if (ehydro != null) throw new Exception("Location descruption already exist in this database");
            try
            {
                var locationadd = new LocationDescription
                {
                    SurveyPointId = id,
                    SurveyPointType = location.SurveyPointType,
                    PopulationDensity = location.PopulationDensity,
                    Description = location.Description,
                    Infrastructure = location.Infrastructure,
                    Residents = location.Residents,
                };

                myDbContext.LocationDescriptions.Add(locationadd);
                myDbContext.SaveChanges();
                return location;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not create location description");
            }
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
                    IsActive = req.IsActive,
                };

                myDbContext.SurveyPoints.Add(surveyp);
                myDbContext.SaveChanges();

                return surveyp;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not create survey location");
            }
        }

        public VegetationCoverDto CreateVegetationCover(VegetationCoverDto vegetationCover, int id)
        {
            if (vegetationCover == null) throw new ArgumentNullException("Please fill all needed informaton");
            var ehydro = myDbContext.VegetationCovers.FirstOrDefault(h => h.SurveyPointId == id);
            if (ehydro != null) throw new Exception("Vegetation already exist in this database");
            try
            {
                var veget = new VegetationCover
                {
                    SurveyPointId = id,
                    GrassPercentage = vegetationCover.GrassPercentage,
                    SoilPercentage = vegetationCover.SoilPercentage,
                    ForestPercentage = vegetationCover.ForestPercentage,
                    CropPercentage = vegetationCover.CropPercentage,
                    Other = vegetationCover.Other,
                    NaturalForestPercentage = vegetationCover.NaturalForestPercentage,
                    FlowerPercentage = vegetationCover.FlowerPercentage,
                };

                myDbContext.VegetationCovers.Add(veget);
                myDbContext.SaveChanges();

                return vegetationCover;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not create vegetation cover details");
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
            var surveyPoints = myDbContext.SurveyPoints
                .Include(s => s.Hydrology)
                .Include(s => s.LocationDescription)
                .Include(s => s.VegetationCover)
                .Where(s => s.Id == id && s.IsActive == true)
                .Select(sp => new SurveyPointRes
                {
                    Id = sp.Id,
                    SurveyName = sp.SurveyName,
                    Latitude = sp.Latitude,
                    Longitude = sp.Longitude,
                    Altitude = sp.Altitude,
                    Address = sp.Address,

                    LocationDesDto = sp.LocationDescription == null ? null : new LocationDesDto
                    {
                        SurveyPointType = sp.LocationDescription.SurveyPointType,
                        PopulationDensity = sp.LocationDescription.PopulationDensity,
                        Description = sp.LocationDescription.Description,
                        Infrastructure = sp.LocationDescription.Infrastructure,
                        Residents = sp.LocationDescription.Residents,
                    },

                    VegetationCoverDto = sp.VegetationCover == null ? null : new VegetationCoverDto
                    {
                        GrassPercentage = sp.VegetationCover.GrassPercentage,
                        SoilPercentage = sp.VegetationCover.SoilPercentage,
                        ForestPercentage = sp.VegetationCover.ForestPercentage,
                        CropPercentage = sp.VegetationCover.CropPercentage,
                        Other = sp.VegetationCover.Other,
                        NaturalForestPercentage = sp.VegetationCover.NaturalForestPercentage,
                        FlowerPercentage = sp.VegetationCover.FlowerPercentage,
                    },

                    HydrologyDto = sp.Hydrology == null ? null : new HydrologyDto
                    {
                        WaterPresence = sp.Hydrology.WaterPresence,
                        WaterLevel = sp.Hydrology.WaterLevel,
                        WaterFlow = sp.Hydrology.WaterFlow,
                        DistanceToWaterSource = sp.Hydrology.DistanceToWaterSource,
                        WaterSourceFeatures = sp.Hydrology.WaterSourceFeatures,
                        SurfaceWaterType = sp.Hydrology.SurfaceWaterType,
                        SurfaceWaterLevel = sp.Hydrology.SurfaceWaterLevel,
                        SurfaceWaterFlow = sp.Hydrology.SurfaceWaterFlow,
                        SurfaceWaterDistance = sp.Hydrology.SurfaceWaterDistance,
                        SurfaceWaterFeatures = sp.Hydrology.SurfaceWaterFeatures,
                    }
                }).ToList();

            if (surveyPoints == null || !surveyPoints.Any())
                throw new Exception("No survey point was found!");

            return surveyPoints;
        }

        public void UpdateHydrology(HydrologyDto hydrology, int id)
        {
            try
            {
                var uhydro = myDbContext.Hydrologies.FirstOrDefault(h => h.SurveyPointId == id);
                if (uhydro == null) throw new Exception("Can not find the hydro in this survey point");

                uhydro.WaterPresence = hydrology.WaterPresence;
                uhydro.WaterLevel = hydrology.WaterLevel;
                uhydro.WaterFlow = hydrology.WaterFlow;
                uhydro.DistanceToWaterSource = hydrology.DistanceToWaterSource;
                uhydro.WaterSourceFeatures = hydrology.WaterSourceFeatures;
                uhydro.SurfaceWaterType = hydrology.SurfaceWaterType;
                uhydro.SurfaceWaterLevel = hydrology.SurfaceWaterLevel;
                uhydro.SurfaceWaterFlow = hydrology.SurfaceWaterFlow;
                uhydro.SurfaceWaterDistance = hydrology.SurfaceWaterDistance;
                uhydro.SurfaceWaterFeatures = hydrology.SurfaceWaterFeatures;

                myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not update hydrology");
            }
        }

        public void UpdateLocation(LocationDesDto location, int id)
        {
            try
            {
                var ulocation = myDbContext.LocationDescriptions.FirstOrDefault(h => h.SurveyPointId == id);
                if (ulocation == null) throw new Exception("Can not find the location in this survey");

                ulocation.SurveyPointType = location.SurveyPointType;
                ulocation.PopulationDensity = location.PopulationDensity;
                ulocation.Description = location.Description;
                ulocation.Infrastructure = location.Infrastructure;
                ulocation.Residents = location.Residents;

                myDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Can not update location");
            }
        }

        public void UpdateVegetationCover(VegetationCoverDto vegetationCover, int id)
        {
            try
            {
                var uveget = myDbContext.VegetationCovers.FirstOrDefault(h => h.SurveyPointId == id);
                if (uveget == null) throw new Exception("Can not find the location in this survey");

                uveget.GrassPercentage = vegetationCover.GrassPercentage;
                uveget.SoilPercentage = vegetationCover.SoilPercentage;
                uveget.ForestPercentage = vegetationCover.ForestPercentage;
                uveget.CropPercentage = vegetationCover.CropPercentage;
                uveget.Other = vegetationCover.Other;
                uveget.NaturalForestPercentage = vegetationCover.NaturalForestPercentage;
                uveget.ForestPercentage = vegetationCover.ForestPercentage;

                myDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Can not update vegetation cover");
            }
        }
    }
}
