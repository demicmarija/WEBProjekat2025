using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WEBProjekat2025.Data.Enum;
using WEBProjekat2025.Data.Static;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data
{
    public class AppDbInitializer
    {
        public void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
              
                    var context = serviceScope.ServiceProvider.GetService<appDbContext>();
                    context.Database.EnsureCreated();

                    // 🔹 DISKONT
                    if (!context.Diskont.Any())
                {
                    context.Diskont.AddRange(new List<Diskont>()
                    {
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/3225/3225630.png",
                            Naziv = "Osveženje DOO",
                            Adresa = "Kralja Petra 25, Beograd"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/2738/2738915.png",
                            Naziv = "Zlatna Kap",
                            Adresa = "Cara Dušana 19, Novi Sad"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/7073/7073016.png",
                            Naziv = "Ugao Ukusa",
                            Adresa = "Nemanjina 44, Niš"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/1598/1598445.png",
                            Naziv = "Bokal",
                            Adresa = "Bulevar Oslobođenja 73, Kragujevac"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/992/992700.png",
                            Naziv = "Picorama",
                            Adresa = "Kneza Miloša 12, Subotica"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/2935/2935038.png",
                            Naziv = "Piceland",
                            Adresa = "Trg Republike 8, Zrenjanin"
                        },
                        new Diskont()
                        {
                            LogoURL = "https://cdn-icons-png.flaticon.com/512/3172/3172569.png",
                            Naziv = "Užitak Plus",
                            Adresa = "Glavna 56, Čačak"
                        }
                    });
                    context.SaveChanges();
                }

                // 🔹 AROMA
                if (!context.Aroma.Any())
                {
                    context.Aroma.AddRange(new List<Aroma>()
                    {
                        new Aroma()
                        {
                            SlikaURL = "https://www.kudaveceras.rs/images/news/1585312016-vanilla-1.jpg",
                            Ime = "Vanila",
                            Opis = "Topla, slatka i kremasta nota koja potiče iz hrastovih buradi."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://joyfoodsunshine.com/wp-content/uploads/2022/06/homemade-caramel-recipe-5.jpg",
                            Ime = "Karamela",
                            Opis = "Blaga slatkoća koja podseća na šećer zagrejan do zlatne boje."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://static.vecteezy.com/system/resources/thumbnails/020/921/416/small/steam-and-smoke-isolated-3d-render-png.png",
                            Ime = "Dim",
                            Opis = "Prepoznatljiva nota koja podseća na drvo i vatru, česta u škotskim viskijima."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://perfumersupplyhouse.com/wp-content/uploads/2021/02/pexels-eva-elijas-5940272-scaled-e1612465908497.jpg",
                            Ime = "Hrast",
                            Opis = "Drvena i suva aroma koja dolazi iz odležavanja u buradima."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://us.nuxe.com/cdn/shop/articles/mag-1200x672-what-are-the-virtues-of-honey-and-other-treasures-of-the-hive-1.jpg?v=1751244173&width=2048",
                            Ime = "Med",
                            Opis = "Prirodna slatkoća sa blagim cvetnim tonovima."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOK2YfDH9OubNtYXjHgo3eRE-Pr2cxg1jY2w&s",
                            Ime = "Suvo voće",
                            Opis = "Note suvih smokava, grožđica i urmi koje daju dubinu ukusu."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://www.beyondceliac.org/nitropack_static/xQdsWNGdOKvDiRWJnCFbvkEAiiEngekD/assets/images/optimized/rev-cf08676/www.beyondceliac.org/wp-content/uploads/2022/08/spices_900x600.jpg",
                            Ime = "Začini",
                            Opis = "Arome cimeta, karanfilića i bibera koje doprinose složenosti pića."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://assets.bonappetit.com/photos/57c5d0e36a6acdf3485dfb2b/master/w_3357,h_2238,c_limit/3717295073_f5ae257d71_o.jpg",
                            Ime = "Kafa",
                            Opis = "Gorčasto-pržena aroma karakteristična za tamno pečene note."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://article.images.consumerreports.org/image/upload/t_article_tout/v1696263716/prod/content/dam/CRO-Images-2023/10October/Special-Projects/CR-SP-InlineHero-Heavy-Metals-in-Chocolate-Products-1023",
                            Ime = "Čokolada",
                            Opis = "Glatka i slatko-gorka nota koja se javlja u bogatijim destilatima."
                        },
                        new Aroma()
                        {
                            SlikaURL = "https://www.aromatics.com/cdn/shop/articles/the-power-of-citrus-exploring-the-versatile-uses-of-citrus-essential-oils-394415.jpg?v=1721836156",
                            Ime = "Citrus",
                            Opis = "Sveža nota limuna i narandžine kore koja osvežava aromu pića."
                        }
                    });
                    context.SaveChanges();
                }

                // 🔹 PROIZVODJAC
                if (!context.Proizvodjac.Any())
                {
                    context.Proizvodjac.AddRange(new List<Proizvodjac>()
                    {
                        new Proizvodjac()
                        {
                            LogoURL = "https://www.hatchwise.com/wp-content/uploads/2022/04/pasted-image-0.png",
                            Ime = "Jack Daniel's",
                            Opis = "Američki proizvođač viskija iz Tennessee-a."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQoySPdxbSS0Q1cuRCQy0JKayz2f7PgUVY5Q&s",
                            Ime = "Heineken",
                            Opis = "Holandska pivara osnovana 1864. godine."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIzNId5-0lNUVarWW_-q7DD0wPOkdyL5p71g&s",
                            Ime = "Coca-Cola",
                            Opis = "Američki proizvođač bezalkoholnih pića."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://lobbymap.org/site//data/001/735/1735834.png",
                            Ime = "PepsiCo",
                            Opis = "Globalna kompanija za pića i grickalice."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://1000logos.net/wp-content/uploads/2020/01/Smirnoff-Logo-1978.png",
                            Ime = "Smirnoff",
                            Opis = "Ruski brend votke, sada u vlasništvu Diageo."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://www.unahealydesign.com/wp-content/uploads/2013/03/guinness-logo.jpg",
                            Ime = "Guinness",
                            Opis = "Irski proizvođač tamnog piva poznatog širom sveta."
                        },
                        new Proizvodjac()
                        {
                            LogoURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdieZDsjxiI3EikXt843Z6JbcvzQVg_FvCfQ&s",
                            Ime = "Red Bull",
                            Opis = "Austrijski proizvođač energetskih pića."
                        }
                    });
                    context.SaveChanges();
                }

                // 🔹 PICE
                if (!context.Pice.Any())
                {
                    context.Pice.AddRange(new List<Pice>()
                    {
                        new Pice()
                        {
                            SlikaURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkSDUxHmBLgzoJcPmDQkl9TleOplGt3AyMvA&s",
                            Ime = "Jack Daniel's Old No. 7",
                            Opis = "Klasični Tennessee viski.",
                            Cena = 4200,
                            Proizvedeno = new DateTime(2024, 11, 15),
                            KategorijaPica = KategorijaPica.Alkoholno,
                            ProizvodjacId = 1,
                            DiskontId = 1
                        },
                        new Pice()
                        {
                            SlikaURL = "https://online.idea.rs/images/products/460/460103401_1l.jpg?1756296910",
                            Ime = "Heineken Pivo",
                            Opis = "Osvežavajuće lager pivo.",
                            Cena = 180,
                            Proizvedeno = new DateTime(2025, 3, 1),
                            KategorijaPica = KategorijaPica.Alkoholno,
                            ProizvodjacId = 2,
                            DiskontId = 2
                        },
                        new Pice()
                        {
                            SlikaURL = "https://api.cenoteka.rs/uploads/cache/product_4x3/uploads/2024/02/fanta-pomorandza-limenka-330ml-65d761c103f22.png",
                            Ime = "Fanta Narandža",
                            Opis = "Gazirano bezalkoholno piće.",
                            Cena = 130,
                            Proizvedeno = new DateTime(2025, 6, 20),
                            KategorijaPica = KategorijaPica.Bezalkoholno,
                            ProizvodjacId = 3,
                            DiskontId = 3
                        },
                        new Pice()
                        {
                            SlikaURL = "https://static.maxi.rs/medias/sys_master/h63/h8d/8968363442206.jpg",
                            Ime = "Smirnoff Vodka",
                            Opis = "Čista votka iz Rusije.",
                            Cena = 2500,
                            Proizvedeno = new DateTime(2025, 2, 10),
                            KategorijaPica = KategorijaPica.Alkoholno,
                            ProizvodjacId = 5,
                            DiskontId = 4
                        },
                        new Pice()
                        {
                            SlikaURL = "https://www.coca-cola.com/content/dam/onexp/us/en/brands/coca-cola-original/coke-de-mexico.png",
                            Ime = "Coca-Cola Classic",
                            Opis = "Osvežavajuće gazirano piće.",
                            Cena = 120,
                            Proizvedeno = new DateTime(2025, 4, 5),
                            KategorijaPica = KategorijaPica.Bezalkoholno,
                            ProizvodjacId = 3,
                            DiskontId = 5
                        },
                        new Pice()
                        {
                            SlikaURL = "https://icdn.bottlenose.wine/images/full/651152.jpg?min-w=200&min-h=200&fit=crop",
                            Ime = "Guinness Stout",
                            Opis = "Tamno pivo bogatog ukusa.",
                            Cena = 260,
                            Proizvedeno = new DateTime(2025, 1, 15),
                            KategorijaPica = KategorijaPica.Alkoholno,
                            ProizvodjacId = 6,
                            DiskontId = 6
                        },
                        new Pice()
                        {
                            SlikaURL = "https://online.idea.rs/images/products/306/306039040_1l.jpg?1725020108",
                            Ime = "Red Bull Energy Drink",
                            Opis = "Energetsko piće za osveženje i energiju.",
                            Cena = 180,
                            Proizvedeno = new DateTime(2025, 7, 1),
                            KategorijaPica = KategorijaPica.Bezalkoholno,
                            ProizvodjacId = 7,
                            DiskontId = 7
                        }
                    });
                    context.SaveChanges();
                }

                // 🔹 AROME_PICE
                if (!context.Arome_Pice.Any())
                {
                    context.Arome_Pice.AddRange(new List<Arome_Pice>()
                    {
                        new Arome_Pice() { AromaId = 1, PiceId = 3 },
                        new Arome_Pice() { AromaId = 2, PiceId = 5 },
                        new Arome_Pice() { AromaId = 3, PiceId = 1 },
                        new Arome_Pice() { AromaId = 4, PiceId = 2 },
                        new Arome_Pice() { AromaId = 5, PiceId = 7 },
                        new Arome_Pice() { AromaId = 6, PiceId = 4 },
                        new Arome_Pice() { AromaId = 7, PiceId = 6 }
                    });
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@WEBProjekat2025.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@WEBProjekat2025.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
