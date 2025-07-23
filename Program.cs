using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace ComposicaoPedido
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entrada de dados do cliente
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Cria o objeto Client com os dados informados
            Client client = new Client(name, email, birthDate);

            // Entrada de dados do pedido
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            // Cria o objeto Order associando o cliente
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            // Laço para entrada de dados dos itens do pedido
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");

                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                // Cria objetos Product e OrderItem, depois adiciona ao pedido
                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantity, productPrice, product);
                order.AddItem(orderItem);
            }

            // Exibe o resumo do pedido
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}