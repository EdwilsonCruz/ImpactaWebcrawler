
using ImpactaWebcrawler.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactaWebcrawler.Data
{
    public class RespostaMapping : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("resposta");

            builder.HasKey(r => r.Id);

        }
    }
}
