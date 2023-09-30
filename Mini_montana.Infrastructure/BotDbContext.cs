using Microsoft.EntityFrameworkCore;
using Mini_montana.Domain.Entities;
using Mini_montana.Domain.ModelObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Infrastructure
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasMany(c => c.Countries)
                .WithMany()
                .UsingEntity(j => j.ToTable("CurrencyCountry"));


            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Испания" },
                new Country { Id = 2, Name = "Франция" },
                new Country { Id = 3, Name = "ОАЭ" },
                new Country { Id = 4, Name = "Мексика" });


            modelBuilder.Entity<Currency>().HasData(
               new Currency
               {
                   Id = 1,
                   Label = "Битко́йн",
                   ShortLabel = "BTC",
                   Description = "Битко́йн, или битко́ин — пиринговая платёжная система, использующая одноимённую единицу для учёта операций. Для обеспечения функционирования и защиты системы используются криптографические методы, но при этом вся информация о транзакциях между адресами системы доступна в открытом виде.",
                   WalletNumber = "1N4Qbzg6LSXUXyXu2MDuGfzxwMA7do8AyL",
                   ImageUrl = "https://res.cloudinary.com/dftzmlrzu/image/upload/v1696065159/mini_montana/yshuc6ksbzuiilezbmj4.jpg"
               },
               new Currency
               {
                   Id = 2,
                   Label = "До́ллар Соединённых Штатов Америки Tether",
                   ShortLabel = "USDT",
                   Description = "Tether (USDT) — самый известный и популярный в мире стейблкоин. Курс Tether привязан к доллару США в пропорции 1:1. Ценность USDT обеспечивает эмитент — компания Tether Limited, у которой есть резервы для обеспечения каждого стейблкоина.",
                   WalletNumber = "1N4Qbzg6LSXUXyXu2MDuGfzxwMA7do8AyL",
                   ImageUrl = "https://res.cloudinary.com/dftzmlrzu/image/upload/v1696065218/mini_montana/pxmgbyvvqd7xj0yokrqf.jpg"
               },
               new Currency
               {
                   Id = 3,
                   Label = "До́ллар Соединённых Штатов Америки",
                   ShortLabel = "USD",
                   Description = "До́ллар Соединённых Штатов Америки — денежная единица США, одна из основных резервных валют мира. 1 доллар = 100 центов. Символьное обозначение в англоязычных текстах: $; в США для замены слова «доллар» знак используется в препозиции, то есть перед числом. Буквенный код валюты: USD.\r\n    </span>",
                   WalletNumber = "1N4Qbzg6LSXUXyXu2MDuGfzxwMA7do8AyL",
                   ImageUrl = "https://res.cloudinary.com/dftzmlrzu/image/upload/v1696065254/mini_montana/avfk1lnnuuvgkbijio3n.jpg"
               },
               new Currency
               {
                   Id = 4,
                   Label = "Евро",
                   ShortLabel = "EURO",
                   Description = "Е́вро — официальная валюта 20 стран «еврозоны». Кроме того, евро используется в Черногории и Косове. Евро также является национальной валютой ещё 4 государств и 8 особых территорий ЕС.",
                   WalletNumber = "1N4Qbzg6LSXUXyXu2MDuGfzxwMA7do8AyL",
                   ImageUrl = "https://res.cloudinary.com/dftzmlrzu/image/upload/v1696065281/mini_montana/iqjjqv8yuok4aledlvwm.jpg"
               },
               new Currency
               {
                   Id = 5,
                   Label = "Российский рубль",
                   ShortLabel = "RUB",
                   Description = "Рубль — денежная единица Российской Федерации. На территории Российской Федерации использование других валют резидентами, с некоторыми исключениями, наказывается штрафом в размере от трёх четвертей до одного размера транзакции.",
                   WalletNumber = "1N4Qbzg6LSXUXyXu2MDuGfzxwMA7do8AyL",
                   ImageUrl = "https://res.cloudinary.com/dftzmlrzu/image/upload/v1696065309/mini_montana/kqb6uzrszgqawj0bmtey.jpg"
               }

            );

        }

        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
