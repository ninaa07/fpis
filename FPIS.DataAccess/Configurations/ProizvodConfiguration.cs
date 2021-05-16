using FPIS.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.DataAccess.Configurations
{
    public class ProizvodConfiguration : BaseEntityConfiguration<Proizvod>
    {
        public override void Configure(EntityTypeBuilder<Proizvod> builder)
        {
            base.Configure(builder);
        }
    }
}
