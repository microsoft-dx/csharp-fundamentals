using System;

namespace AdvancedGenericsInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository<Product>();

            repo.Add(new Product()
            {
                Id = 1,
                Name = "Onion",
                Category = "Food",
                Price = 46
            });

            repo.Add(new Product()
            {
                Id = 2,
                Name = "Carrot",
                Category = "Food",
                Price = 23
            });

            foreach (var p in repo.GetAll())
            {
                p.Print();
            }
        }
    }
}
