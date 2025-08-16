using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProductList
{
    public enum ProductCategory
    {
        Food,
        Appliance
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public ProductCategory Category { get; set; }
    }

    public class CategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ProductCategory category)
            {
                return category == ProductCategory.Appliance ? "Appliance" : "Food";
            }
            return "Food";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Пример данных
            Products = new List<Product>
            {
                new Product { Name = "Яблоки", Price = 299.99m, ImagePath = "apple.jpg", Category = ProductCategory.Food },
                new Product { Name = "Холодильник", Price = 59999.99m, ImagePath = "fridge.jpg", Category = ProductCategory.Appliance },
                new Product { Name = "Бананы", Price = 199.49m, ImagePath = "banana.jpg", Category = ProductCategory.Food }
            };

            DataContext = this;
        }
    }
}