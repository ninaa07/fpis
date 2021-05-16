using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class DrzavaConfiguration : BaseEntityConfiguration<Drzava>
    {
        public override void Configure(EntityTypeBuilder<Drzava> builder)
        {
            base.Configure(builder);
        }
    }
}
