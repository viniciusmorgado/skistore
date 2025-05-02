using SkiStore.Core.Aggregates.Order;
using SkiStore.Core.Base.Specs;

namespace SkiStore.Core.Specs;

public class OrderSpec : BaseSpec<Order>
{
    public OrderSpec(string email) : base(x => x.BuyerEmail == email)
    {
        
    }

    public OrderSpec(string email, int id) : base(x => x.BuyerEmail == email && x.Id == id)
    {
        
    }
}