using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;
using LotDesignerMicroservice.Domain.ValueObjects.NumericObjects;
using LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Configurations
{
    public class EfLotCardConfiguration : IEntityTypeConfiguration<LotCard>
    {
        public void Configure(EntityTypeBuilder<LotCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDateTime)
                .IsRequired()
                .HasConversion(
                    creationDateTime => DateTime.SpecifyKind(creationDateTime, DateTimeKind.Utc),
                    value => DateTime.SpecifyKind(value, DateTimeKind.Utc)
                );

            builder.Property(x => x.LastModifiedDateTime)
                .IsRequired(false)
                .HasConversion(
                    lastModifiedDateTime => DateTime.SpecifyKind(lastModifiedDateTime!.Value, DateTimeKind.Utc),
                    value => DateTime.SpecifyKind(value, DateTimeKind.Utc)
                );

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion(
                    title => title.Value,
                    value => new Title(value)
                );

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(20000)
                .HasConversion(
                    description => description.Value,
                    value => new Text(value)
                );

            builder.Property(x => x.StartingPrice)
                .IsRequired()
                .HasConversion(
                    startingPrice => startingPrice.Value,
                    value => new Price(value)
                );

            builder.Property(x => x.PriceStep)
                .IsRequired()
                .HasConversion(
                    priceStep => priceStep.Value,
                    value => new Price(value)
                );

            builder.Property(x => x.RepurchasePrice)
                .IsRequired(false)
                .HasConversion(
                    repurchasePrice => repurchasePrice!.Value,
                    value => new Price(value)
                );

            builder.Property(x => x.TradeDuration)
                .IsRequired()
                .HasConversion<long>(
                    tradeDuration => tradeDuration.Value.Ticks,
                    value => new TradeDuration(new TimeSpan(value))
                );

            builder.Property(x => x.State)
                .IsRequired();


            builder.HasOne(x => x.Seller)
                .WithMany("_lotCards")
                .IsRequired();

            builder.HasMany(x => x.Images).WithOne(i => i.LotCard);
        }
    }
}