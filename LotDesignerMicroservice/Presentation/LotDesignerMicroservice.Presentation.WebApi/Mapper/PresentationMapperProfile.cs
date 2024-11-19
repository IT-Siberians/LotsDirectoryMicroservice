using AutoMapper;
using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Seller;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Image;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Seller;

namespace LotDesignerMicroservice.Presentation.WebApi.Mapper
{
    public class PresentationMapperProfile : Profile
    {
        public PresentationMapperProfile()
        {
            CreateMap<CreateSellerRequest, CreateSellerModel>();
            CreateMap<SellerModel, SellerResponse>();

            CreateMap<ImageModel, ImageResponse>();

            CreateMap<CreateLotCardRequest, CreateLotCardModel>();
        }
    }
}