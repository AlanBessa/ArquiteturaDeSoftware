using MWS.Domain.Entidades;
using MWS.SharedKernel.Validation;
using System.Linq;

namespace MWS.Domain.Scopes
{
    public static class OrderScopes
    {
        public static bool PlaceOrderScopeIsValid(this Order order)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertIsGreaterThan(order.OrderItems.Count(), 0, "Nenhum produto foi adicionado ao pedido")
            );
        }
    }
}