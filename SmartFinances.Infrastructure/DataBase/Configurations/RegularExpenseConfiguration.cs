﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class RegularExpenseConfiguration : IEntityTypeConfiguration<RegularExpense>
    {
        public void Configure(EntityTypeBuilder<RegularExpense> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.Type)
                   .IsRequired();

            builder.HasOne(r => r.Account)
                   .WithMany(a => a.RegularExpenses)
                   .HasForeignKey(r => r.AccountId);
        }
    }
}