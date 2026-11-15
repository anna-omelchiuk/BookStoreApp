using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            if (Database.EnsureCreated())
            {
                SeedData();
            }
        }

        private void SeedData()
        {
            if (Books.Any()) 
                return;

            var initialBooks = new List<Book>
            {
                new Book
                {
                    Title = "Дюна",
                    Author = "Френк Герберт",
                    Genre = "Наукова фантастика",
                    Price = 450,
                    Description = "Епічна сага про пустельну планету Арракіс, політику, екологію та боротьбу за найціннішу речовину у Всесвіті.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780441172719-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780340960196-L.jpg" }
                    },
                    Comments = new List<Comment>
                    {
                        new() { UserName = "Віта", Text = "Неймовірна глибина світу, читається на одному диханні!", CreatedAt = DateTime.Now.AddDays(-2) }
                    }
                },
                new Book
                {
                    Title = "1984",
                    Author = "Джордж Орвелл",
                    Genre = "Наукова фантастика",
                    Price = 280,
                    Description = "Класичний роман-антиутопія про тоталітарне суспільство, контроль думок та боротьбу особистості проти системи.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780451524935-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780141036144-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Фундація",
                    Author = "Айзек Азімов",
                    Genre = "Наукова фантастика",
                    Price = 360,
                    Description = "Математик Гарі Селдон передбачає падіння Галактичної Імперії та створює Фундацію для збереження знань людства.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780553293357-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780008117498-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "451 градус за Фаренгейтом",
                    Author = "Рей Бредбері",
                    Genre = "Наукова фантастика",
                    Price = 295,
                    Description = "Історія пожежника Гая Монтега у світі майбутнього, де всі книги заборонені та підлягають спаленню.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9781451673319-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780006546061-L.jpg" }
                    },
                    Comments = new List<Comment>
                    {
                        new() { UserName = "Назар", Text = "Книга, яка змушує замислитися. Дуже радий, що прочитав її від початку і до кінця", CreatedAt = DateTime.Now.AddDays(-2) }
                    }
                },
                new Book
                {
                    Title = "Нейромант",
                    Author = "Вільям Гібсон",
                    Genre = "Наукова фантастика",
                    Price = 340,
                    Description = "Культовий кіберпанк-роман про хакера Кейса, штучний інтелект та віртуальну реальність матриці.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780441569595-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780575076815-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Марсіянин",
                    Author = "Енді Вейр",
                    Genre = "Наукова фантастика",
                    Price = 390,
                    Description = "Астронавт Марк Вотні опиняється сам на Марсі після піщаної бурі та намагається вижити за допомогою науки й гумору.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780553418026-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780091956141-L.jpg" }
                    }
                },

                new Book
                {
                    Title = "Острів скарбів",
                    Author = "Роберт Луїс Стівенсон",
                    Genre = "Пригодницькі романи",
                    Price = 240,
                    Description = "Захоплива морська подорож юного Джима Гокінса за картою піратських скарбів капітана Флінта.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780141321004-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780486275598-L.jpg" }
                    },
                    Comments = new List<Comment>
                    {
                        new() { UserName = "Роман", Text = "Незабутні пригоди, які я пережив разом із персонажами читаючи книгу. Усім раджу прочести.", CreatedAt = DateTime.Now.AddDays(-2) }
                    }
                },
                new Book
                {
                    Title = "Граф Монте-Крісто",
                    Author = "Александр Дюма",
                    Genre = "Пригодницькі романи",
                    Price = 520,
                    Description = "Історія неправедно ув'язненого Едмона Дантеса, який знаходить незліченні скарби та вершить справедливу помсту.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780140449266-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780553213508-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Двадцять тисяч льє під водою",
                    Author = "Жуль Верн",
                    Genre = "Пригодницькі романи",
                    Price = 310,
                    Description = "Підводна експедиція професора Аронакса на борту загадкового підводного човна «Наутилус» капітана Немо.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780553212525-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9781853260315-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Три мушкетери",
                    Author = "Александр Дюма",
                    Genre = "Пригодницькі романи",
                    Price = 370,
                    Description = "Пригоди молодого гасконця д'Артаньяна та його вірних друзів Атоса, Портоса й Араміса при дворі короля Франції.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780140449273-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780553213379-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Робінзон Крузо",
                    Author = "Данієль Дефо",
                    Genre = "Пригодницькі романи",
                    Price = 250,
                    Description = "Історія виживання моряка, який провів двадцять вісім років на безлюдному острові після корабельної аварії.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780141439822-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780486404271-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Поклик предків",
                    Author = "Джек Лондон",
                    Genre = "Пригодницькі романи",
                    Price = 230,
                    Description = "Драматична історія пса Бака під час золотої лихоманки на Алясці, де виживає лише найсильніший.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780141321059-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780486264721-L.jpg" }
                    }
                },

                new Book
                {
                    Title = "Убивство у «Східному експресі»",
                    Author = "Агата Крісті",
                    Genre = "Детективи",
                    Price = 300,
                    Description = "Знаменитий бельгійський детектив Еркюль Пуаро розслідує загадкове вбивство у поїзді, заблокованому сніговими заметами.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780062693662-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780007119318-L.jpg" }
                    },
                    Comments = new List<Comment>
                    {
                        new() { UserName = "Максим", Text = "Фінал просто непередбачуваний, класика жанру!", CreatedAt = DateTime.Now.AddHours(-5) }
                    }
                },
                new Book
                {
                    Title = "Собака Баскервілів",
                    Author = "Артур Конан Дойл",
                    Genre = "Детективи",
                    Price = 275,
                    Description = "Шерлок Холмс і доктор Ватсон розгадують таємницю родового прокляття та пекельного пса на болотах Девонширу.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780140437867-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780486282145-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "І не лишилось жодного",
                    Author = "Агата Крісті",
                    Genre = "Детективи",
                    Price = 315,
                    Description = "Десять незнайомців запрошені на відокремлений острів, де кожного починає наздоганяти розплата за минуле.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780062073488-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780007136834-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Код да Вінчі",
                    Author = "Ден Браун",
                    Genre = "Детективи",
                    Price = 380,
                    Description = "Професор симвології Роберт Ленгдон розшифровує таємні послання, приховані у творах Леонардо да Вінчі.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780307474278-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780552149518-L.jpg" }
                    }
                },
                new Book
                {
                    Title = "Етюд у багряних тонах",
                    Author = "Артур Конан Дойл",
                    Genre = "Детективи",
                    Price = 260,
                    Description = "Перша справа, у якій знайомляться Шерлок Холмс і доктор Ватсон та розкривають загадкове вбивство в Лондоні.",
                    Images = new List<BookImage>
                    {
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780140439083-L.jpg" },
                        new() { ImageUrl = "https://covers.openlibrary.org/b/isbn/9780486419312-L.jpg" }
                    }
                }
            };

            Books.AddRange(initialBooks);
            SaveChanges();
        }
    }
}
