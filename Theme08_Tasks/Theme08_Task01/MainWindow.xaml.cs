using System.Collections.Generic;
using System.Windows;

namespace Theme08_Task01
{
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();

            Products.AddRange(new List<Product>
            {
                new Product
                {
                    Name = "Апельсины",
                    Price = 129.99M,
                    Category = ProductCategory.Food,
                    ImagePath = "/Images/orange.png"
                },
                new Product
                {
                    Name = "Стиральная машина",
                    Price = 65799.99M,
                    Category = ProductCategory.Appliances,
                    ImagePath = "/Images/washing_machine.png"
                },
                new Product
                {
                    Name = "Виноград",
                    Price = 349.49M,
                    Category = ProductCategory.Food,
                    ImagePath = "/Images/grapes.png"
                },
                new Product
                {
                    Name = "Кофе-машина",
                    Price = 17999.00M,
                    Category = ProductCategory.Appliances,
                    ImagePath = "/Images/coffee_machine.png"
                }
            });

            this.DataContext = this;
        }
    }
}