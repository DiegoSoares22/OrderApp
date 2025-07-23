namespace Course.Entities.Enums
{
    // Enum para representar os status do pedido
    internal enum OrderStatus
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }
}