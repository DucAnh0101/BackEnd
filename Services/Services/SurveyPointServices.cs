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
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            if (hydrology == null) throw new ArgumentNullException("Please fill all needed informaton");
            var ehydro = myDbContext.Hydrologies.FirstOrDefault(h => h.SurveyPointId == id);
            if (ehydro != null) throw new Exception("Hydro already exist in this database");
            try
            {
                var hydro = new Hydrology
                {
                    SurveyPointId = id,
                    WaterPresence = hydrology.WaterPresence,
                    WaterLevel = hydrology.WaterPresence ? hydrology.WaterLevel : null,
                    WaterFlow = hydrology.WaterPresence ? hydrology.WaterFlow : null,
                    DistanceToWaterSource = hydrology.WaterPresence ? hydrology.DistanceToWaterSource : null,
                    WaterSourceFeatures = hydrology.WaterPresence ? hydrology.WaterSourceFeatures : null,
                    SurfaceWaterType = hydrology.SurfaceWaterType,
                    SurfaceWaterLevel = hydrology.SurfaceWaterLevel,
                    SurfaceWaterFlow = hydrology.SurfaceWaterFlow,
                    SurfaceWaterDistance = hydrology.SurfaceWaterDistance,
                    SurfaceWaterFeatures = hydrology.SurfaceWaterFeatures,

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
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
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

        public SurveyPoint CreateSurveyPonit(SurveyPointReq req, int id)
        {
            if (req == null) throw new Exception("Please enter all information needed!");
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            try
            {
                var surveyp = new SurveyPoint
                {
                    SurveyName = req.SurveyName,
                    Latitude = req.Latitude,
                    Longitude = req.Longitude,
                    Altitude = req.Altitude,
                    Address = req.Address,
                    IsDelete = false,
                    SurveyLineId = id
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
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
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
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var sp = myDbContext.SurveyPoints
                .FirstOrDefault(p => p.SpId == id);
            if (sp == null) throw new Exception("No surveypoint was found!");

            sp.IsDelete = true;
            myDbContext.SaveChanges();
        }

        public List<SurveyPointRes> GetSurveyPointBySurveyLineId(int id)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");
            var surveyPoints = myDbContext.SurveyPoints
                .Include(s => s.Hydrology)
                .Include(s => s.LocationDescription)
                .Include(s => s.VegetationCover)
                .Where(s => s.SurveyLineId == id && s.IsDelete == false)
                .Select(sp => new SurveyPointRes
                {
                    Id = sp.SpId,
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

        public List<SurReq> SearchSurveyPointByName(string? name, int id, DateOnly? from, DateOnly? to)
        {
            if (id <= 0) throw new Exception("Please enter an id greater than 0");

            var query = myDbContext.SurveyPoints
                .Where(sp => sp.SurveyLineId == id && !sp.IsDelete);
            if (!string.IsNullOrWhiteSpace(name))
            {
                string namePattern = $"%{name.Trim().ToLower()}%";
                query = query.Where(sp => EF.Functions.Like(sp.SurveyName.Trim().ToLower(), namePattern));
            }

            if (from.HasValue)
            {
                query = query.Where(sp => sp.CreatedDate >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(sp => sp.CreatedDate <= to.Value);
            }

            var result = query.Select(sp => new SurReq
            {
                SurveyName = sp.SurveyName,
                Address = sp.Address,
                Latitude = sp.Latitude,
                Longitude = sp.Longitude,
                Altitude = sp.Altitude,
                CreatedDate = sp.CreatedDate,
            }).ToList();

            return result;
        }

        public void UpdateHydrology(HydrologyDto hydrology, int id)
        {
            try
            {
                if (id <= 0) throw new Exception("Please enter an id greater than 0");
                var uhydro = myDbContext.Hydrologies.FirstOrDefault(h => h.SurveyPointId == id);
                if (uhydro == null)
                {
                    throw new Exception("Cannot find the hydrology record for this survey point");
                }

                uhydro.WaterPresence = hydrology.WaterPresence;
                uhydro.WaterLevel = hydrology.WaterPresence ? hydrology.WaterLevel : null;
                uhydro.WaterFlow = hydrology.WaterPresence ? hydrology.WaterFlow : null;
                uhydro.DistanceToWaterSource = hydrology.WaterPresence ? hydrology.DistanceToWaterSource : null;
                uhydro.WaterSourceFeatures = hydrology.WaterPresence ? hydrology.WaterSourceFeatures : null;
                uhydro.SurfaceWaterType = hydrology.SurfaceWaterType;
                uhydro.SurfaceWaterLevel = hydrology.SurfaceWaterLevel;
                uhydro.SurfaceWaterFlow = hydrology.SurfaceWaterFlow;
                uhydro.SurfaceWaterDistance = hydrology.SurfaceWaterDistance;
                uhydro.SurfaceWaterFeatures = hydrology.SurfaceWaterFeatures;

                myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot update hydrology: {ex.Message}", ex);
            }
        }

        public void UpdateLocation(LocationDesDto location, int id)
        {
            try
            {
                if (id <= 0) throw new Exception("Please enter an id greater than 0");
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
                if (id <= 0) throw new Exception("Please enter an id greater than 0");
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
