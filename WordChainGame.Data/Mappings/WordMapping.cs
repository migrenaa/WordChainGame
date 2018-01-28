﻿using System.Data.Entity.ModelConfiguration;
using WordChainGame.Data.Entities;

namespace WordChainGame.Data.Mappings
{
    public class WordMapping : EntityTypeConfiguration<Word>
    {
        public WordMapping()
        {
            this.ToTable("Words");

            this.HasKey(p => p.Id);

            this.Property(p => p.WordContent)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.DateCreated)
                .IsRequired();

            this.HasRequired(p => p.Topic)
                .WithMany(p => p.Words)
                .HasForeignKey(p => p.TopicId);

        }
    }
}