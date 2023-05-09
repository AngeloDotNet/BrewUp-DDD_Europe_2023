﻿namespace BrewUp.Wharehouses.Rest.Modules;

public class WharehouseModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var mapGroup = endpoints.MapGroup("/api/v1/")
            .WithTags("Warehouses");
        
        mapGroup.MapGet("/", () => Results.Ok())
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetAvailability");
        
        return endpoints;
    }
}