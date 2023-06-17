using AutoMapper;
using Course.Services.Catalog.Dtos;

namespace Course.Services.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
                CreateMap<Models.Course,CourseDto>().ReverseMap();
                CreateMap<Models.Feature,FeatureDto>().ReverseMap();
                CreateMap<Models.Category,CategoryDto>().ReverseMap();

            CreateMap<Models.Course, CourseCreatedDto>().ReverseMap();
            CreateMap<Models.Course, CourseUpdatedDto>().ReverseMap();
        }
    }
}
