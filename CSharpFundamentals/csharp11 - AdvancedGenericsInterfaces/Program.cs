using System;

namespace AdvancedGenericsInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var productsRepository = new Repository<Product>();

            productsRepository.Add(new Product()
            {
                Id = 1,
                Name = "Onion",
                Category = "Food",
                Price = 46
            });

            productsRepository.Add(new Product()
            {
                Id = 2,
                Name = "Carrot",
                Category = "Food",
                Price = 23
            });

            foreach (var p in productsRepository.GetAll())
            {
                p.Print();
            }
        }
    }
}
