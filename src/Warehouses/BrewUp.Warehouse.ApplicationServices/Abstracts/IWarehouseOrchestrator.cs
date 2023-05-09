﻿using BrewUp.Warehouse.ApplicationServices.DTOs;

namespace BrewUp.Warehouse.ApplicationServices.Abstracts;

public interface IWarehouseOrchestrator
{
    Task<BeerAvailabilityDTO> GetBeerAvailabilityAsync(CancellationToken cancellationToken);
}