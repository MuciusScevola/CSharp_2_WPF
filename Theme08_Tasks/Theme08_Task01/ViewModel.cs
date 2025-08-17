using System.Collections.ObjectModel;
using WpfProductListApp.Models;

namespace WpfProductListApp.ViewModels
{
    public class MainViewModel
    {
        // ObservableCollection автоматически уведомляет интерфейс об изменениях (добавление/удаление элементов)
        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            // Инициализация и заполнение списка товаров
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Name = "Яблоки",
                    Price = 299.99m,
                    Category = ProductCategory.Food,
                    // Путь к ресурсу изображения
                    ImagePath = "/Images/apple.png"
                },
                new Product
                {
                    Name = "Холодильник",
                    Price = 59999.99m,
                    Category = ProductCategory.Appliances,
                    ImagePath = "/Images/fridge.png"
                },
                new Product
                {
                    Name = "Бананы",
                    Price = 199.49m,
                    Category = ProductCategory.Food,
                    ImagePath = "/Images/bananas.png"
                }
            };
        }
    }
}