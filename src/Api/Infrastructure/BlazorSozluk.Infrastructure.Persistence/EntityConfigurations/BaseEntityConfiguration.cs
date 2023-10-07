using BlazorSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.EntityConfigurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        //Id değeri bir keydir anlamında kullanılır
        builder.HasKey(x => x.Id);

        //Save metodunu çalığrmadan add metodu çağırıldığında generet edilsin 
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreateDate).ValueGeneratedOnAdd();
    }
}
