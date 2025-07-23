using System;
using System.Collections.Generic;
using Course.Entities.Enums;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    internal class Order
    {
        // Momento em que o pedido foi realizado
        public DateTime Moment { get; set; }

        // Status atual do pedido (enum: PendingPayment, Processing, etc.)
        public OrderStatus Status { get; set; }

        // Cliente que fez o pedido
        public Client Client { get; set; }

        // Lista de itens do pedido
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Construtor padrão
        public Order()
        {
        }

        // Construtor que recebe os valores para inicializar o pedido
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        // Adiciona um item à lista de itens do pedido
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        // Remove um item da lista de itens do pedido
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        // Calcula o valor total do pedido somando o subtotal de cada item
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.Subtotal(); // subtotal = quantidade * preço
            }
            return sum;
        }

        // Gera um resumo do pedido como string formatada
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"Order status: {Status}");
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine("Order items:");

            // Adiciona cada item da lista ao resumo
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }

            // Formata o total com ponto como separador decimal (padrão dos EUA)
            sb.AppendLine("Total price: " + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
