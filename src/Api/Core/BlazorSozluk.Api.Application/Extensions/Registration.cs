using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        //Çalışan assemblylerini bulma (çalışan class librariyleride içerisinde barındırı)
        var assm = Assembly.GetExecutingAssembly();


        //bunun altında çalışan dienelleri tarıyarak ugun olan handlelirları kendisine ekleyecek
        services.AddMediatR(assm);
        services.AddAutoMapper(assm);
        services.AddValidatorsFromAssembly(assm);

        return services;
    }
}
