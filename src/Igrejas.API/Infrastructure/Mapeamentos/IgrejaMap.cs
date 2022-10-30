using Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapeamentos
{
    public sealed class IgrejaMap :
        IEntityTypeConfiguration<Igreja>
    {
        public void Configure(EntityTypeBuilder<Igreja> builder)
        {
            builder.ToTable("Igrejas");

            BuildIndexes(builder);

            BuildProperties(builder);

            //BuildRelations(builder);
        }

        private static void BuildIndexes(EntityTypeBuilder<Igreja> builder)
        {
            builder.HasKey(x => x.Id);
        }

        private static void BuildProperties(EntityTypeBuilder<Igreja> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Logo)
                .IsRequired();

            builder.Property(x => x.Imagem)
                .IsRequired();

            builder.Property(x => x.DescricaoHistorica)
                .IsRequired();

            builder.Property(x => x.Telefone1)
                .IsRequired();
        }
    }
}
