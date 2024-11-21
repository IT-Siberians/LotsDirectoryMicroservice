using AutoMapper;
using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Seller;
using LotDesignerMicroservice.Domain.Entities.Entities;

namespace LotDesignerMicroservice.Application.Services.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Seller, SellerModel>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.UserName.Value))
                .ReverseMap();

            CreateMap<Image, ImageModel>()
                .ForMember(d => d.Url, o => o.MapFrom(s => s.Url.ToString()));

            CreateMap<LotCard, LotCardModel>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title.Value))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description.Value))
                .ForMember(d => d.StartingPrice, o => o.MapFrom(s => s.StartingPrice.Value))
                .ForMember(d => d.PriceStep, o => o.MapFrom(s => s.PriceStep.Value))
                .ForMember(d => d.RepurchasePrice, o => o.MapFrom((s, d) => s.RepurchasePrice?.Value ?? null))
                .ForMember(d => d.TradeDuration, o => o.MapFrom(s => s.TradeDuration.Value))
                .ForMember(d => d.SellerId, o => o.MapFrom(s => s.Seller.Id));
        }
    }
}