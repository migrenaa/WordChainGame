﻿using System.Data.Entity.ModelConfiguration;
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
            
            this.HasRequired(p => p.InappropriateWord)
                .WithMany(p => p.InappropriateWordRequests)
                .HasForeignKey(p => p.InappropriateWordId);

            this.HasRequired(p => p.Requester)
                .WithMany(p => p.InappropriateWordRequests)
                .HasForeignKey(p => p.RequesterId);
            
        }
    }
}
