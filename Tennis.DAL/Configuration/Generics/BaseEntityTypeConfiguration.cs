using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DAL.Configuration
{
    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : class
    {
        public string TableName { get; set; }

        public BaseEntityTypeConfiguration(string prefix = "", string suffix = "")
        {
            string name = typeof(TBase).Name;
            string tmp = prefix;

            foreach (var item in name)
            {
                if (char.IsUpper(item))
                {
                    tmp += $"_{item}".ToLower();
                }
                else
                {
                    tmp += item;
                }
            }


            TableName = tmp + suffix;
        }

        public virtual void Configure(EntityTypeBuilder<TBase> e)
        {
            e.ToTable(TableName);
        }
    }
}
