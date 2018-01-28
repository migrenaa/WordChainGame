using System.Data.Entity.ModelConfiguration;
using WordChainGame.Data.Entities;

namespace WordChainGame.Data.Mappings
{
    public class GameMapping : EntityTypeConfiguration<Game>
    {
        public GameMapping()
        {
            this.ToTable("Games");

            this.HasKey(p => p.Id);

            this.Property(p => p.DateCreated)
                .IsRequired();

            this.HasMany(p => p.Topics)
                .WithRequired(p => p.Game)
                .HasForeignKey(p => p.GameId);

        }
    }
}
