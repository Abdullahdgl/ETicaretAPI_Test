﻿using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Concretes;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceServices(this IServiceCollection services)
		{

			//services.AddSingleton<IProductService,ProductService>();
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


		}
	}
}
