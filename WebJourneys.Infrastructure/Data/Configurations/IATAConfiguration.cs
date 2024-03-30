using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Infrastructure.Data.Configurations
{
    public class IATAConfiguration : IEntityTypeConfiguration<IATACode>
    {
        public void Configure(EntityTypeBuilder<IATACode> builder)
        {
            builder.HasKey(i => i.IATA);
        }
    }
}
