using AutoMapper;
using DiaryTech.Domain.Dto.Report;
using DiaryTech.Domain.Entity;

namespace DiaryTech.Application.Mapping;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
    }
}