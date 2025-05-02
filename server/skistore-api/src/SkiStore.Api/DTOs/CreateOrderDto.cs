using System.ComponentModel.DataAnnotations;
using SkiStore.Core.Aggregates.Order;

namespace SkiStore.Api.DTOs;

public class CreateOrderDto
{
    [Required]
    public string CartId { get; set; }
    [Required]
    public int DeliveryMethodId { get; set; }
    [Required]
    public ShippingAddress ShippingAddress { get; set; }
    [Required]
    public PaymentSummary PaymentSummary { get; set; }
}
