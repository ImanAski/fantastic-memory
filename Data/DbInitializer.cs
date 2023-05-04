

namespace Miro.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MiroDbContext context)
        {
            if (context.Product.Any())
            {
                return;
            }

            Product product1 = new Product
            {
                Name = "محصول ۱",
                Description = "اینین محصول است",
                Price = 110000,
                InStock = true
            };

            Product product2 = new Product
            {
                Name = "محصول ۲",
                Description = "اینین محصول دوم است",
                Price = 20000,
                InStock = false
            };

            Product product3 = new Product
            {
                Name = "محصول ۳",
                Description = "اینین محصول سوم است",
                Price = 3000,
                InStock = true
            };

            Product product4 = new Product
            {
                Name = "محصول ۴",
                Description = "اینین محصول چهارم است",
                Price = 44000,
                InStock = false
            };

            Product product5 = new Product
            {
                Name = "محصول ۵",
                Description = "اینین محصول پنجم است",
                Price = 5000,
                InStock = true
            };

            Product product6 = new Product
            {
                Name = "محصول ۶",
                Description = "اینین محصول ششم است",
                Price = 6000,
                InStock = false
            };

            Product product7 = new Product
            {
                Name = "محصول ۷",
                Description = "اینین محصول هفتم است",
                Price = 7000,
                InStock = true
            };

            Product product8 = new Product
            {
                Name = "محصول ۸",
                Description = "اینین محصول هشتم است",
                Price = 8000,
                InStock = false
            };

            Product product9 = new Product
            {
                Name = "محصول ۹",
                Description = "اینین محصول نهم است",
                Price = 9000,
                InStock = true
            };

            Product product10 = new Product
            {
                Name = "محصول ۱۰",
                Description = "اینین محصول دهم است",
                Price = 10000,
                InStock = false
            };

            var products = new Product[]
            {
                product1,
                product2,
                product3,
                product4,
                product5,
                product6,
                product7,
                product8,
                product9,
                product10
                
            };
            context.AddRange(products);
            context.SaveChanges();

        }
    }
}