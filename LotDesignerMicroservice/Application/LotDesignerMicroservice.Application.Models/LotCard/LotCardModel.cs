using LotDesignerMicroservice.Domain.Entities.Enums;

namespace LotDesignerMicroservice.Application.Models.LotCard
{
    public class LotCardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal PriceStep { get; set; }
        public decimal? RepurchasePrice { get; set; }
        public TimeSpan TradeDuration { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public LotCardState State { get; set; }
        public Guid SellerId { get; set; }
        public IEnumerable<Guid> ImagesIds { get; set; } = [];
    }
}