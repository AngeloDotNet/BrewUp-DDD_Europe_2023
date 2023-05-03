﻿using Brewup.Purchases.ApplicationService.BindingModels;
using Brewup.Purchases.Infrastructure;
using Brewup.Purchases.Infrastructure.MongoDb;
using Muflone.Eventstore;

namespace Brewup.Purchases.Rest.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 99;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddMongoDb(builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>()!);
		builder.Services.AddMufloneEventStore(builder.Configuration["EventStore:ConnectionString"]!);
		builder.Services.AddRabbitMq(builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>()!);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		return endpoints;
	}
}