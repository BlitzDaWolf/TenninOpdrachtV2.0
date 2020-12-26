using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis.DAL.Models.Inteface;

namespace Tennis.DAL.Configuration
{
    public abstract class BaseDeleteEntityTypeConfiguration<TBase> : BaseEntityTypeConfiguration<TBase> where TBase : IIsDeleted
    {
        public BaseDeleteEntityTypeConfiguration(string prefix = "", string suffix = "") : base(prefix, suffix) { }

        public override void Configure(EntityTypeBuilder<TBase> e)
        {
            e.HasQueryFilter(p => !p.IsDeleted);
            e.Property(c => c.IsDeleted).HasDefaultValue(false);
            base.Configure(e);
        }
    }
}
