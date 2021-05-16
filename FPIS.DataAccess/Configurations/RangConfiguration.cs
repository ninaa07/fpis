using FPIS.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class RangConfiguration : BaseEntityConfiguration<Rang>
    {
        public override void Configure(EntityTypeBuilder<Rang> builder)
        {
            base.Configure(builder);
        }
    }
}
