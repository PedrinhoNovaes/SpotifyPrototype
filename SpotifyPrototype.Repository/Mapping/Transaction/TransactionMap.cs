using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyPrototype.Domain.Transaction.Aggregates;

namespace SpotifyPrototype.Repository.Mapping.Transaction
{
    public class TransactionMap : IEntityTypeConfiguration<SpotifyPrototype.Domain.Transaction.Aggregates.Transaction>
    {
        public void Configure(EntityTypeBuilder<SpotifyPrototype.Domain.Transaction.Aggregates.Transaction> builder)
        {
            builder.ToTable(nameof(SpotifyPrototype.Domain.Transaction.Aggregates.Transaction)); 

            builder.HasKey(t => t.Id); 

            builder.Property(t => t.Amount)
                .IsRequired(); 

            builder.Property(t => t.MerchantId)
                .IsRequired(); 
            builder.Property(t => t.Description)
                .IsRequired(); 

            builder.Property(t => t.Status)
                .IsRequired(); 

            
        }
    }
}
