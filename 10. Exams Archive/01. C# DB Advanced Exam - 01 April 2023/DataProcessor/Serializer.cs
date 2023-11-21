namespace Boardgames.DataProcessor
{
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Newtonsoft.Json;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Data.Models;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardgamesProfile>();
            });

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCreatorDto[]), new XmlRootAttribute("Creators"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            ExportCreatorDto[] creatorDtos = context
                .Creators
                .Where(c => c.Boardgames.Any())
                .ProjectTo<ExportCreatorDto>(config)
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.Name)
                .ToArray();
            xmlSerializer.Serialize(sw, creatorDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context
                .Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .ToArray()
                        .OrderByDescending(bs => bs.Boardgame.Rating)
                        .ThenBy(bs => bs.Boardgame.Name)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}