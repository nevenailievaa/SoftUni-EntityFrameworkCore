namespace Boardgames
{
    using System.Data;
    using AutoMapper;
    using Boardgames.Data.Models;
    using Boardgames.DataProcessor.ExportDto;

    public class BoardgamesProfile : Profile
    {
        public BoardgamesProfile()
        {
            CreateMap<Boardgame, ExportCreatorBoardgameDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.YearPublished, opt =>
                    opt.MapFrom(s => s.YearPublished));
            CreateMap<Creator, ExportCreatorDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(s => s.FirstName + " " + s.LastName))
                .ForMember(dest => dest.BoardgamesCount, opt =>
                    opt.MapFrom(s => s.Boardgames.Count))
                .ForMember(dest => dest.Boardgames, opt =>
                    opt.MapFrom(s => s.Boardgames
                                        .ToArray()
                                        .OrderBy(b => b.Name)));
        }
    }
}