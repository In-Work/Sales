using Sales.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Sales.EF
{
    // Класс контекста данных
    public class dbContext : DbContext
    {
        static dbContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public dbContext() : base("name=dbContext") { }
        // Сущности
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<BidProduct> BidProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        // Обработчик создания модели
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Связи
            // Role
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
            // User
            modelBuilder.Entity<User>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Transfers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            // Partner
            modelBuilder.Entity<Partner>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Partner)
                .WillCascadeOnDelete(false);
            // Direction
            modelBuilder.Entity<Direction>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Direction)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Direction>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Direction)
                .WillCascadeOnDelete(false);
            // Store
            modelBuilder.Entity<Store>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Store>()
                .HasMany(e => e.TransfersAt)
                .WithRequired(e => e.StoreAt)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Store>()
                .HasMany(e => e.TransfersTo)
                .WithRequired(e => e.StoreTo)
                .WillCascadeOnDelete(false);
            // Bid
            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidProducts)
                .WithRequired(e => e.Bid)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Bid>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Bid)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Bid>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Bid)
                .WillCascadeOnDelete(true);
            // Product
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.BidProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Transfers)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
            // Measure
            modelBuilder.Entity<Measure>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Measure)
                .WillCascadeOnDelete(false);
            // Category
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);
            // Размерность дробей
            modelBuilder.Entity<Transfer>()
                .Property(e => e.Quantity)
                .HasPrecision(15, 3);
            modelBuilder.Entity<Order>()
                .Property(e => e.Quantity)
                .HasPrecision(15, 3);
            modelBuilder.Entity<BidProduct>()
                .Property(e => e.Quantity)
                .HasPrecision(15, 3);
            modelBuilder.Entity<BidProduct>()
                .Property(e => e.Price)
                .HasPrecision(15, 2);
            modelBuilder.Entity<Price>()
                .Property(e => e.Value)
                .HasPrecision(15, 2);
            modelBuilder.Entity<Payment>()
                .Property(e => e.Summa)
                .HasPrecision(15, 2);
            //
            base.OnModelCreating(modelBuilder);
        }
        // Отмена внесенных изменений в контекст данных
        public void UndoChanges()
        {
            foreach (DbEntityEntry entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
    // Класс инициализации базы данных
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<dbContext>
    {
        protected override void Seed(dbContext context)
        {
            // Начальные данные
            // Роли
            Role roleAdmin = new Role() { Id = 1, Name = "Администратор" };
            Role roleManager = new Role() { Id = 2, Name = "Менеджер" };
            Role roleSaler = new Role() { Id = 3, Name = "Продавец" };
            context.Roles.Add(roleAdmin);
            context.Roles.Add(roleManager);
            context.Roles.Add(roleSaler);
            // Пользователи
            string password = Infrastructure.Auth.GetMD5("1");
            User userAdmin = new User() { Name = "Летов И.Ф.", Password = password, Role = roleAdmin, Enabled = true };
            User userManager = new User() { Name = "Манагер О.М.", Password = password, Role = roleManager, Enabled = true };
            User userSaler = new User() { Name = "Рябинов К.В.", Password = password, Role = roleSaler, Enabled = true };
            context.Users.Add(userAdmin);
            context.Users.Add(userManager);
            context.Users.Add(userSaler);
            // Приход / Расход
            Direction dirIn = new Direction() { Id = 1, Name = "Закупки", BidName = "Заказ поставщику", OrderName = "Поступление товаров", PaymentName = "Оплата поставщику" };
            Direction dirOut = new Direction() { Id = 2, Name = "Продажи", BidName = "Заказ покупателя", OrderName = "Реализация товаров", PaymentName = "Оплата от покупателя" };
            context.Directions.Add(dirIn);
            context.Directions.Add(dirOut);
            // Склады
            Store storeOpt = new Store() { Name = "Оптовый склад", Description = "Основной склад, мелкооптовая торговля" };
            Store storeRoznica = new Store() { Name = "Розничный магазин", Description = "Магазин для розничных покупателей" };
            context.Stores.Add(storeOpt);
            context.Stores.Add(storeRoznica);
            // Единицы измерения
            Measure measureSt = new Measure() { Name = "шт" };
            Measure measureKg = new Measure() { Name = "кг" };
            Measure measureG = new Measure() { Name = "г" };
            context.Measures.Add(measureSt);
            context.Measures.Add(measureKg);
            context.Measures.Add(measureG);
            // Категории
            Category catTan = new Category() { Name = "ТЭНы электрические", Parent = null };
            Category catSpiral = new Category() { Name = "Спиральные нагреватели", Parent = null };
            Category catGibkie = new Category() { Name = "Гибкие ТЭНы)", ParentId = null };
            context.Categories.Add(catTan);
            context.Categories.Add(catSpiral);
            context.Categories.Add(catGibkie);
            Category catTanAir = new Category() { Name = "ТЭНы воздушные", Parent = catTan };
            Category catTanWater = new Category() { Name = "ТЭНы для воды", Parent = catTan };
            Category catSpiralRH17 = new Category() { Name = "RH17 (Прямоуг. сечение 1.8x3.2 мм)", Parent = catSpiral };
            Category catSpiralRH32 = new Category() { Name = "RH32 (Квадр. сечение 3.2x3.2 мм)", Parent = catSpiral };
            context.Categories.Add(catTanAir);
            context.Categories.Add(catTanWater);
            context.Categories.Add(catSpiralRH17);
            context.Categories.Add(catSpiralRH32);
            // Товары
            Product productTanAir54A13 = new Product() { Name = "ТЭН-54A13/2.5Op230", Description = "Мощность 2.5 кВт", Parent = catTanAir, Measure = measureSt };
            Product productTanAir107A13 = new Product() { Name = "ТЭН-107A13/1.5T230", Description = "Мощность 1.5 кВт", Parent = catTanAir, Measure = measureSt };
            Product productTanAir169D13 = new Product() { Name = "ТЭН-169D13/2.0T230", Description = "Мощность 2.0 кВт", Parent = catTanAir, Measure = measureSt };
            Product productTanAir154 = new Product() { Name = "ТЭН-154-9-8.5/1.4T230", Description = "Мощность 1.4 кВт", Parent = catTanAir, Measure = measureSt };
            Product productTanWater84A8 = new Product() { Name = "ТЭН-84A8/2.0J230", Description = "Мощность 2.0 кВт", Parent = catTanWater, Measure = measureSt };
            Product productTanWater125A8 = new Product() { Name = "ТЭН-125A8/2.4J230", Description = "Мощность 2.4 кВт", Parent = catTanWater, Measure = measureSt };
            Product productTanWater79C13 = new Product() { Name = "ТЭН-79C13/3.15P230", Description = "Мощность 3.15 кВт", Parent = catTanWater, Measure = measureSt };
            Product productTanWater100A13 = new Product() { Name = "ТЭН-100A13/3.5P230", Description = "Мощность 3.5 кВт", Parent = catTanWater, Measure = measureSt };
            Product productTanSpiralRH17175 = new Product() { Name = "RH17175", Description = "Мощность 175 Вт, зона нагрева 210 мм, длина 260 мм", Parent = catSpiralRH17, Measure = measureSt };
            Product productTanSpiralRH17200 = new Product() { Name = "RH17200", Description = "Мощность 200 Вт, зона нагрева 260 мм, длина 310 мм", Parent = catSpiralRH17, Measure = measureSt };
            Product productTanSpiralRH32175 = new Product() { Name = "RH32175", Description = "Мощность 175 Вт, зона нагрева развертки 200 мм, длина развертки 250 мм", Parent = catSpiralRH32, Measure = measureSt };
            Product productTanSpiralRH32200 = new Product() { Name = "RH32200", Description = "Мощность 200 Вт, зона нагрева развертки 250 мм, длина развертки 315 мм", Parent = catSpiralRH32, Measure = measureSt };
            Product productTanGibKv6 = new Product() { Name = "ЭНГкв 6.0*300;0.45*220;1", Description = "Квадр. сеч. 6.0x6.0, длина 300 мм, мощность 0.45 кВт, 220 В", Parent = catGibkie, Measure = measureSt };
            Product productTanGibKr85 = new Product() { Name = "ЭНГкр 8.5*350;0.52*220;1", Description = "Кругл. сеч. d 8.5, длина 350 мм, мощность 0.52 кВт, 220 В", Parent = catGibkie, Measure = measureSt };
            context.Products.Add(productTanAir54A13);
            context.Products.Add(productTanAir107A13);
            context.Products.Add(productTanAir169D13);
            context.Products.Add(productTanAir154);
            context.Products.Add(productTanWater84A8);
            context.Products.Add(productTanWater125A8);
            context.Products.Add(productTanWater79C13);
            context.Products.Add(productTanWater100A13);
            context.Products.Add(productTanSpiralRH17175);
            context.Products.Add(productTanSpiralRH17200);
            context.Products.Add(productTanSpiralRH32175);
            context.Products.Add(productTanSpiralRH32200);
            context.Products.Add(productTanGibKv6);
            context.Products.Add(productTanGibKr85);
            // Цены
            DateTime date20200101 = new DateTime(2020, 1, 1);
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanAir54A13, Value = 1.2M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanAir107A13, Value = 1.4M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanAir169D13, Value = 1.9M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanAir154, Value = 2.15M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanWater84A8, Value = 3.2M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanWater125A8, Value = 3.8M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanWater79C13, Value = 5.4M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanWater100A13, Value = 4.15M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanSpiralRH17175, Value = 1.2M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanSpiralRH17200, Value = 1.4M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanSpiralRH32175, Value = 1.7M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanSpiralRH32200, Value = 1.8M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanGibKv6, Value = 3.2M, User = userAdmin });
            context.Prices.Add(new Price() { Date = date20200101, Product = productTanGibKr85, Value = 3.5M, User = userAdmin });
            DateTime date20200701 = new DateTime(2020, 7, 1);
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanAir54A13, Value = 1.32M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanAir107A13, Value = 1.54M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanAir169D13, Value = 2.09M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanAir154, Value = 2.37M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanWater84A8, Value = 3.52M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanWater125A8, Value = 4.18M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanWater79C13, Value = 5.94M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanWater100A13, Value = 4.57M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanSpiralRH17175, Value = 1.32M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanSpiralRH17200, Value = 1.54M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanSpiralRH32175, Value = 1.87M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanSpiralRH32200, Value = 1.98M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanGibKv6, Value = 3.52M, User = userManager });
            context.Prices.Add(new Price() { Date = date20200701, Product = productTanGibKr85, Value = 3.85M, User = userManager });
            // Закупки
            // Поставщики
            Partner partnerZakup1 = new Partner() { Name = "ООО Фабрика тепла", UNP = "999888777", Address = "г. Минск, ул. Улица, 45", Phone = "+375 29 999 99 99", IsSupplier = true, IsPurchaser = false };
            Partner partnerZakup2 = new Partner() { Name = "ОАО Завод отопительного оборудования", UNP = "999888888", Address = "г. Гродно, ул. Ленина, 23", Phone = "+375 29 999 88 99", IsSupplier = true, IsPurchaser = false };
            context.Partners.Add(partnerZakup1);
            context.Partners.Add(partnerZakup2);
            // Заказ на закупку с постоплатой
            Bid bidZakup1 = new Bid()
            {
                Date = new DateTime(2020, 6, 24),
                Direction = dirIn,
                Partner = partnerZakup2,
                Store = storeOpt,
                DeliveryTime = 5,
                PaymentTime = 5,
                User = userManager
            };
            context.Bids.Add(bidZakup1);
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanAir54A13, Quantity = 20, Price = 0.72M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanAir107A13, Quantity = 20, Price = 0.84M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanAir169D13, Quantity = 20, Price = 1.14M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanAir154, Quantity = 20, Price = 1.29M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanWater84A8, Quantity = 20, Price = 1.92M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanWater125A8, Quantity = 20, Price = 2.28M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanWater79C13, Quantity = 20, Price = 3.24M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup1, Product = productTanWater100A13, Quantity = 20, Price = 2.49M });
            // Поступление по заказу с постоплатой
            DateTime date20200627 = new DateTime(2020, 6, 27);
            context.Orders.Add(new Order() { Date = date20200627, Bid = bidZakup1, Product = productTanAir54A13, Quantity = 10, User = userManager });
            context.Orders.Add(new Order() { Date = date20200627, Bid = bidZakup1, Product = productTanAir107A13, Quantity = 20, User = userManager });
            context.Orders.Add(new Order() { Date = date20200627, Bid = bidZakup1, Product = productTanAir169D13, Quantity = 20, User = userManager });
            context.Orders.Add(new Order() { Date = date20200627, Bid = bidZakup1, Product = productTanAir154, Quantity = 20, User = userManager });
            DateTime date20200628 = new DateTime(2020, 6, 28);
            context.Orders.Add(new Order() { Date = date20200628, Bid = bidZakup1, Product = productTanAir54A13, Quantity = 10, User = userManager });
            context.Orders.Add(new Order() { Date = date20200628, Bid = bidZakup1, Product = productTanWater84A8, Quantity = 20, User = userManager });
            context.Orders.Add(new Order() { Date = date20200628, Bid = bidZakup1, Product = productTanWater125A8, Quantity = 20, User = userManager });
            context.Orders.Add(new Order() { Date = date20200628, Bid = bidZakup1, Product = productTanWater79C13, Quantity = 20, User = userManager });
            context.Orders.Add(new Order() { Date = date20200628, Bid = bidZakup1, Product = productTanWater100A13, Quantity = 20, User = userManager });
            // Оплата заказа
            context.Payments.Add(new Payment() { Date = new DateTime(2020, 7, 3), Direction = dirIn, Bid = bidZakup1, Summa = 278.4M, User = userManager });
            // Заказ на закупку с предполатой
            Bid bidZakup2 = new Bid()
            {
                Date = new DateTime(2020, 6, 25),
                Direction = dirIn,
                Partner = partnerZakup1,
                Store = storeOpt,
                DeliveryTime = 30,
                PaymentTime = 0,
                User = userManager
            };
            context.Bids.Add(bidZakup2);
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup2, Product = productTanSpiralRH32175, Quantity = 30, Price = 1.02M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup2, Product = productTanSpiralRH32200, Quantity = 30, Price = 1.08M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup2, Product = productTanGibKv6, Quantity = 10, Price = 1.92M });
            context.BidProducts.Add(new BidProduct() { Bid = bidZakup2, Product = productTanGibKr85, Quantity = 10, Price = 2.1M });
            // Предоплата заказа
            context.Payments.Add(new Payment() { Date = new DateTime(2020, 6, 26), Direction = dirIn, Bid = bidZakup2, Summa = 103.2M, User = userManager });
            // Поступление по заказу с предоплатой
            DateTime date20200629 = new DateTime(2020, 6, 29);
            context.Orders.Add(new Order() { Date = date20200629, Bid = bidZakup2, Product = productTanSpiralRH32175, Quantity = 10, User = userManager });
            context.Orders.Add(new Order() { Date = date20200629, Bid = bidZakup2, Product = productTanSpiralRH32200, Quantity = 10, User = userManager });
            context.Orders.Add(new Order() { Date = date20200629, Bid = bidZakup2, Product = productTanGibKv6, Quantity = 10, User = userManager });
            context.Orders.Add(new Order() { Date = date20200629, Bid = bidZakup2, Product = productTanGibKr85, Quantity = 10, User = userManager });
            // Перемещение со склада на склад магазина
            DateTime date20200630 = new DateTime(2020, 6, 30);
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanAir54A13, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanAir107A13, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanAir169D13, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanAir154, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanWater84A8, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanWater125A8, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanWater79C13, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanWater100A13, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanSpiralRH32175, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanSpiralRH32200, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanGibKv6, Quantity = 5, User = userManager });
            context.Transfers.Add(new Transfer() { Date = date20200630, StoreAt = storeOpt, StoreTo = storeRoznica, Product = productTanGibKr85, Quantity = 5, User = userManager });
            // Продажи
            // Покупатели
            Partner partnerRealRoznica = new Partner() { Name = "Розничный покупатель", UNP = "000000000", Address = "", Phone = "", IsSupplier = false, IsPurchaser = true };
            Partner partnerReal2 = new Partner() { Name = "ООО Холод", UNP = "111111111", Address = "г. Минск, ул. Улица, д. 99", Phone = "+375 29 456 54 54", IsSupplier = false, IsPurchaser = true };
            context.Partners.Add(partnerRealRoznica);
            context.Partners.Add(partnerReal2);
            // Заказ с предоплатой на оптовом складе
            Bid bidReal1 = new Bid()
            {
                Date = new DateTime(2020, 7, 3),
                Direction = dirOut,
                Partner = partnerReal2,
                Store = storeOpt,
                DeliveryTime = 3,
                PaymentTime = 0,
                User = userManager
            };
            context.Bids.Add(bidReal1);
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanAir169D13, Quantity = 5, Price = 2.09M });
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanAir154, Quantity = 5, Price = 2.37M });
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanWater84A8, Quantity = 5, Price = 3.52M });
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanWater125A8, Quantity = 5, Price = 4.18M });
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanSpiralRH32175, Quantity = 5, Price = 1.87M });
            context.BidProducts.Add(new BidProduct() { Bid = bidReal1, Product = productTanSpiralRH32200, Quantity = 5, Price = 1.98M });
            // Предоплата заказа
            context.Payments.Add(new Payment() { Date = new DateTime(2020, 7, 4), Direction = dirOut, Bid = bidReal1, Summa = 80.05M, User = userManager });
            // Поставка по заказу с предоплатой
            DateTime date20200707 = new DateTime(2020, 7, 7);
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanAir169D13, Quantity = 5, User = userManager });
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanAir154, Quantity = 5, User = userManager });
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanWater84A8, Quantity = 5, User = userManager });
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanWater125A8, Quantity = 5, User = userManager });
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanSpiralRH32175, Quantity = 5, User = userManager });
            context.Orders.Add(new Order() { Date = date20200707, Bid = bidReal1, Product = productTanSpiralRH32200, Quantity = 5, User = userManager });
            // Заказ в розничном магазине
            DateTime date20200705 = new DateTime(2020, 7, 5);
            Bid bidReal2 = new Bid()
            {
                Date = date20200705,
                Direction = dirOut,
                Partner = partnerRealRoznica,
                Store = storeRoznica,
                DeliveryTime = 0,
                PaymentTime = 0,
                User = userSaler
            };
            context.Bids.Add(bidReal2);
            context.BidProducts.Add(new BidProduct() { Bid = bidReal2, Product = productTanAir54A13, Quantity = 2, Price = 1.32M });
            // Предоплата заказа в розничном магазине
            context.Payments.Add(new Payment() { Date = date20200705, Direction = dirOut, Bid = bidReal2, Summa = 2.64M, User = userSaler });
            // Поставка по заказу в розничном магазине
            context.Orders.Add(new Order() { Date = date20200705, Bid = bidReal2, Product = productTanAir54A13, Quantity = 2, User = userSaler });
            // Сохранение изменений
            context.SaveChanges();
            //
            base.Seed(context);
        }
    }
}
