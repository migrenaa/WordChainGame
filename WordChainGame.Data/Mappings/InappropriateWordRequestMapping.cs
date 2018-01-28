using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChainGame.Data.Entities;

namespace WordChainGame.Data.Mappings
{
    public class InappropriateWordRequestMapping : EntityTypeConfiguration<InappropriateWordRequest>
    {
        public InappropriateWordRequestMapping()
        {
            this.ToTable("InappropriateWordRequestMappings");

            this.HasKey(p => p.Id);

            this.Property(p => p.DateCreated)
                .IsRequired();

            this.Property(p => p.IsInappropriate)
                .IsRequired();

            this.HasRequired(p => p.InappropriateWord)
                .WithMany(p => p.InappropriateWordRequests)
                .HasForeignKey(p => p.InappropriateWordId);

        }
    }
}
