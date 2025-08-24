using System.Collections.Generic;
using System.Windows;

namespace Theme08_Task01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Product> products = new List<Product>
            {
                new Product
                {
                    Name = "Апельсины",
                    Price = 299.99M,
                    Category = ProductCategory.Food, 
                    Image = "/Images/orange.png"
                },
                new Product
                {
                    Name = "Стиральная машина",
                    Price = 59999.99M,
                    Category = ProductCategory.Appliances,
                    Image = "/Images/washing_machine.png"
                },
                new Product
                {
                    Name = "Виноград",
                    Price = 199.49M,
                    Category = ProductCategory.Food,
                    Image = "/Images/grapes.png"
                },
                new Product
                {
                    Name = "Кофе-машина",
                    Price = 199.49M,
                    Category = ProductCategory.Appliances,
                    Image = "/Images/coffee_machine.png"
                }
            };

            ProductsListBox.ItemsSource = products;
        }
    }
}