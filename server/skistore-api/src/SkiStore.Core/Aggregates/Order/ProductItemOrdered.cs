﻿namespace SkiStore.Core.Aggregates.Order;

public class ProductItemOrdered
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string PictureUrl { get; set; }

}
