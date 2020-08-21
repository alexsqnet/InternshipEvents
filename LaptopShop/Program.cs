using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    delegate void ChangeStatus(string message);

    class Program
    {
        static void Main(string[] args)
        {
            Laptop asus = new Laptop();
            asus.ChangePrice += new ChangeStatus(OnChangePrice);

            //Simulate changing price scenario
            Console.WriteLine("Please insert the new price of the Asus laptop ");
            asus.Price = int.Parse(Console.ReadLine());

            //Delay
            Console.ReadLine();            
        }

        static void OnChangePrice(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Laptop
    {
        int price;

        public event ChangeStatus ChangePrice;

        public int Price
        {
            get { return price; }

            set 
            {
                if (value > 0)
                {
                    price = value;
                }

                ChangePrice?.Invoke($"The price has been changed {this.price}");
            }
        }
    }
}
