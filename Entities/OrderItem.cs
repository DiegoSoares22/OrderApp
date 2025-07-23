using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Course.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product Product { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }
        public double Subtotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return $"{Product.Name}, ${Price.ToString("F2")}, Quantity: {Quantity}, Subtotal: ${Subtotal().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
