using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("Breeds");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(b => b.Attributes, attributesBuilder =>
            {
                attributesBuilder.Property(a => a.BreedName)
                                 .IsRequired()
                                 .HasMaxLength(100);

                attributesBuilder.Property(a => a.BreedDescription)
                                 .HasMaxLength(500);

                attributesBuilder.Property(a => a.Hypoallergenic)
                                 .IsRequired();

                attributesBuilder.OwnsOne(a => a.LifeRange, lifeRangeBuilder =>
                {
                    lifeRangeBuilder.Property(v => v.Min).HasColumnName("LifeRangeMin");
                    lifeRangeBuilder.Property(v => v.Max).HasColumnName("LifeRangeMax");
                });

                attributesBuilder.OwnsOne(a => a.MaleWeightRange, maleWeightRangeBuilder =>
                {
                    maleWeightRangeBuilder.Property(v => v.Min).HasColumnName("MaleWeightRangeMin");
                    maleWeightRangeBuilder.Property(v => v.Max).HasColumnName("MaleWeightRangeMax");
                });

                attributesBuilder.OwnsOne(a => a.FemaleWeightRange, femaleWeightRangeBuilder =>
                {
                    femaleWeightRangeBuilder.Property(v => v.Min).HasColumnName("FemaleWeightRangeMin");
                    femaleWeightRangeBuilder.Property(v => v.Max).HasColumnName("FemaleWeightRangeMax");
                });
            });
        }
    }
}
