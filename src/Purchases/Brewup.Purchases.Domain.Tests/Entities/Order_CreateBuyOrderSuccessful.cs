﻿using Brewup.Purchases.Domain.CommandHandlers;
using Brewup.Purchases.Messages.Commands;
using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace Brewup.Purchases.Domain.Tests.Entities;

public class Order_CreateBuyOrderSuccessful : CommandSpecification<CreateBuyOrder>
{
	private readonly BuyOrderId _buyOrderId;
	private readonly SupplierId _supplierId;

	private readonly DateTime _date;

	private readonly IEnumerable<OrderLine> _lines;
	//private IList<OrderLine> _lines;

	public Order_CreateBuyOrderSuccessful()
	{
		_buyOrderId = new BuyOrderId(Guid.NewGuid());
		_supplierId = new SupplierId(Guid.NewGuid());
		_date = DateTime.Today;

		_lines = Enumerable.Empty<OrderLine>();
		_lines = _lines.Concat(new List<OrderLine>
		{
			new()
			{
				ProductId = new ProductId(Guid.NewGuid()),
				Title = "Product 1",
				Quantity = new Quantity {UnitOfMeasure = "N.", Value = 1},
				Price = new Price {Currency = "EUR", Value = 1}
			},
			new()
			{
				ProductId = new ProductId(Guid.NewGuid()),
				Title = "Product 2",
				Quantity = new Quantity {UnitOfMeasure = "N.", Value = 2},
				Price = new Price {Currency = "EUR", Value = 2}
			}
		});
	}

	protected override IEnumerable<DomainEvent> Given()
	{
		yield break;
	}

	protected override CreateBuyOrder When()
	{
		return new CreateBuyOrder(_buyOrderId, _supplierId, _date, _lines);
	}

	protected override ICommandHandlerAsync<CreateBuyOrder> OnHandler()
	{
		return new CreateBuyOrderHandlerAsync(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new BuyOrderCreated(_buyOrderId, _supplierId, _date, _lines);
	}
}