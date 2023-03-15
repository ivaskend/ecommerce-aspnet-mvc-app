using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Models;

namespace Vinyls.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //AlbumGenre
                if (!context.AlbumGenres.Any())
                {
                    context.AlbumGenres.AddRange(new List<AlbumGenre>()
                    {
                        new AlbumGenre()
                        {
                            Name = "Рок",
                            Description ="Рок музиката е широк жанр на популарна музика што потекнува како „рокенрол“ во " +
                            "Соединетите Држави кон крајот на 1940-тите и раните 1950-ти," +
                            " развивајќи се во низа различни стилови во средината на 1960-тите и подоцна," +
                            " особено во САД и Обединето Кралство"
                        },
                         new AlbumGenre()
                        {
                            Name = "Џез",
                            Description ="Џезот е музички жанр што потекнува од афро-американските заедници во Њу Орлеанс," +
                            " Луизијана, кон крајот на 19 и почетокот на 20 век, со своите корени во блуз и регтајм. " +
                            "Од 1920-тите години на џезот, тој е препознаен како главна форма " +
                            "на музичко изразување во традиционалната и популарната музика."
                        },
                        new AlbumGenre()
                        {
                            Name = "Поп",
                            Description ="Поп музиката е жанр на популарна музика што потекнува во" +
                            " нејзината модерна форма во средината на 1950-тите во САД и Обединетото Кралство. " +
                            "Термините популарна музика и" +
                            " поп музика често се користат наизменично," +
                            " иако првиот ја опишува целата музика што е популарна и вклучува многу различни стилови"
                        },
                        new AlbumGenre()
                        {
                            Name = "Поп-Рок",
                            Description ="Поп рокот е жанр на фузија со акцент на " +
                            "професионалното пишување и снимање песни, и помалку нагласен став од рок музиката."
                        },
                        new AlbumGenre()
                        {
                            Name = "Алтернативен Рок",
                            Description ="Алтернативниот рок е категорија на рок музика " +
                            "која произлезе од независната музичка сцена од 1970-тите и стана широко популарна во 1990-тите."
                        },


                    });
                    context.SaveChanges();
                }
                //Artists
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName = "Битлси (The Beatles)",
                            Bio = "Англиски рок бенд формиран во Ливерпул во 1960 година, составен од Џон Ленон, Пол Макартни, Џорџ Харисон и Ринго Стар",
                            ProfilePictureURL = "https://yt3.googleusercontent.com/5lOkozHE7R-TL0iHNetrVWai47pG7Oa6bJvW4CiUGCMsRUjqXSUAlJWDgpkjdc12iKm0GwzF0Cw=s900-c-k-c0x00ffffff-no-rj"

                        },
                        new Artist()
                        {
                            FullName = "Квин (Queen)",
                            Bio = "Британски рок бенд формиран во Лондон во 1970 година од Фреди Меркјури, Брајан Меј и Роџер Тејлор, а подоцна се приклучува и Џон Дикон",
                            ProfilePictureURL = "https://i.scdn.co/image/af2b8e57f6d7b5d43a616bd1e27ba552cd8bfd42"
                        },
                        new Artist()
                        {
                            FullName = "Дејвид Боуви (David Bowie)",
                            Bio = "Дејвид Роберт Џонс, професионално познат како Дејвид Боуви, беше англиски пејач-текстописец и актер." +
                            " Водечка фигура во музичката индустрија, тој се смета за еден од највлијателните музичари на 20 век",
                            ProfilePictureURL = "https://i.scdn.co/image/ab6761610000e5ebb78f77c5583ae99472dd4a49"
                        },
                        new Artist()
                        {
                            FullName = "Брајан Адамс (Bryan Adams)",
                            Bio = "Брајан Гај Адамс OC OBC FRPS е канадски музичар, пејач, текстописец, композитор " +
                            "и фотограф. Тој е наведен како еден од најпродаваните музички уметници на сите времиња",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/3/3a/20130710-ByanAdamsLucca-0019_%289273168286%29.jpg"
                        },
                        new Artist()
                        {
                            FullName = "Тото (Toto)",
                            Bio = "Тото е американски рок бенд формиран во 1977 година во Лос Анџелес, Калифорнија. Тото е познат по музичкиот " +
                            "стил кој комбинира елементи на поп, рок, соул, фанк, прогресивен рок, хард рок, R&B, блуз и џез.",
                            ProfilePictureURL = "https://www.mcall.com/wp-content/uploads/migration/2019/10/16/TNCYRJICUZFS3H3MGIGT2ZHH2U.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //RecordLabel
                if (!context.RecordLabels.Any())
                {
                    context.RecordLabels.AddRange(new List<RecordLabel>()
                    {
                        new RecordLabel()
                        {
                            FullName = "Abbey Road Studios",
                            Bio = "Abbey Road Studios - основана е во ноември 1931 година од Грамофон Компани, претходник на музичката компанија ЕМИ",
                            ProfilePictureURL = "https://www.tpvision.com/wp-content/uploads/Abbey-Road-Studios-TPVision.jpg"

                        },
                        new RecordLabel()
                        {
                            FullName = "EMI Records",
                            Bio = "ЕМИ Рекордс е мултинационална издавачка куќа во сопственост на Universal Music Group." +
                            " Првично беше основана како британска водечки издавачка куќа од истоимената музичка компанија во 1972 година," +
                            " а лансирана во јануари 1973 година како наследник на издавачките куќи Колумбија и Парлофон",
                            ProfilePictureURL = "https://i.pinimg.com/474x/76/b0/16/76b01674dbd18f711db61e3422eed154.jpg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Mountain Studios",
                            Bio = "ЕМИ Рекордс е мултинационална издавачка куќа во сопственост на Universal Music Group." +
                            " Првично беше основана како британска водечки издавачка куќа од истоимената музичка компанија во 1972 година," +
                            " а лансирана во јануари 1973 година како наследник на издавачките куќи Колумбија и Парлофон.",
                            ProfilePictureURL = "https://geo-media.beatsource.com/image_size/500x500/2/a/c/2acd6abc-10f2-4087-ae36-ae9df1220b4e.jpg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Def Jam Recordings",
                            Bio = "Def Jam Recordings е американска мултинационална издавачка куќа во сопственост на Universal Music Group. " +
                            "Се наоѓа во Менхетен, Њујорк Сити, специјализирана претежно за хип хоп, современ R&B, соул и поп",
                            ProfilePictureURL = "https://variety.com/wp-content/uploads/2020/02/defjam-og.jpg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Frontiers Music",
                            Bio = "италијанска издавачка куќа, која претежно произведува хард рок. " +
                            "Основана е во 1996 година од Серафино Перуџино и е со седиште во Неапол.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/it/4/45/Frontiers_logo.jpg"
                        }
                    });
                    context.SaveChanges();

                }
                //Vinyls
                if (!context.Vinyls.Any())
                {
                    context.Vinyls.AddRange(new List<Vinyl>()
                    {
                        new Vinyl()
                        {
                            Name = "Let It Be",
                            Description = "Vinyl, LP, Album Box Set, Limited Edition, Book",
                            Price = 1200,
                            ImageURL = "https://i.discogs.com/AJ1Y_8DOL0uyZi_H8VvX9V9G7gfcUGsQ_Bq-Tiddbyc/rs:fit/g:sm/q:90/h:598/w:600/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTEwODgx/MjYtMTY0ODgyMDgw/MC05NTcwLmpwZWc.jpeg",
                            AlbumGenreId = 1,
                            RecordLabelId = 1,
                            AlbumFormat = AlbumFormat.LP
                        },
                        new Vinyl()
                        {
                            Name = "Under Pressure",
                            Description = "Vinyl, 12inches, 45RPM",
                            Price = 1200,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/Queen_%26_David_Bowie_-_Under_Pressure.jpeg/220px-Queen_%26_David_Bowie_-_Under_Pressure.jpeg",
                            AlbumGenreId = 1,
                            RecordLabelId = 3,
                            AlbumFormat = AlbumFormat.Single
                        },
                        new Vinyl()
                        {
                            Name = "Bohemian Rhapsody",
                            Description = "Pop Rock, Arena Rock, Soundtrack, Rock and Roll, Ballad",
                            Price = 1200,
                            ImageURL = "https://i.discogs.com/vaH1Pv5RPfD1dxuaEscxMEV0CECv0yorec3CaNPzp4s/rs:fit/g:sm/q:90/h:600/w:600/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTEyNjg3/Mjg5LTE1NDAwNTk2/NTUtNTA0NS5qcGVn.jpeg",
                            AlbumGenreId = 2,
                            RecordLabelId = 2,
                            AlbumFormat = AlbumFormat.DoubleLP,
                            Details =""
                        },
                        new Vinyl()
                        {
                            Name = "Toto",
                            Description = "Vinyl, LP, Album, Club Edition",
                            Price = 1300,
                            ImageURL = "https://i.discogs.com/PcmEerVO38G060diJ_uLHIG91UavdVD9PK6GpqSEeEA/rs:fit/g:sm/q:90/h:600/w:599/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTI1NjIx/NTgtMTI5MDU1MTI3/NC5qcGVn.jpeg",
                            AlbumGenreId = 4,
                            RecordLabelId = 5,
                            AlbumFormat = AlbumFormat.LP,
                        },
                        new Vinyl()
                        {
                            Name = "Ultimate",
                            Description = "Ultimate - Double vinyl",
                            Price = 1100,
                            ImageURL = "https://m.media-amazon.com/images/I/41lF24SVV+L._SX425_.jpg",
                            AlbumGenreId = 1,
                            RecordLabelId = 4,
                            AlbumFormat = AlbumFormat.DoubleLP,
                        },
                        new Vinyl()
                        {
                            Name = "Hunky Dory (Picture Disc)",
                            Description = "Hunky Dory - четврти студио албум снимен во 1970 од страна на РСА Рекордс...",
                            Price = 1800,
                            ImageURL = "https://cdn.shopify.com/s/files/1/0287/4323/7725/products/4044486-2778087_500x500.jpg?v=1641117670g",
                            AlbumGenreId = 1,
                            RecordLabelId = 4,
                            AlbumFormat = AlbumFormat.LP,
                        }
                    });
                    context.SaveChanges();

                }
                //Artist&Vinyls
                if (!context.Artists_Vinyls.Any())
                {
                    context.Artists_Vinyls.AddRange(new List<Artist_Vinyl>()
                    {
                        new Artist_Vinyl()
                        {
                            ArtistId = 1,
                            VinylId = 1
                        },
                        new Artist_Vinyl()
                        {
                            ArtistId = 2,
                            VinylId = 2
                        },

                         new Artist_Vinyl()
                        {
                            ArtistId = 2,
                            VinylId = 3
                        },

                        new Artist_Vinyl()
                        {
                            ArtistId = 3,
                            VinylId = 2
                        },
                        new Artist_Vinyl()
                        {
                            ArtistId = 3,
                            VinylId = 6
                        },
                        new Artist_Vinyl()
                        {
                            ArtistId = 4,
                            VinylId = 5
                        },


                        new Artist_Vinyl()
                        {
                            ArtistId = 5,
                            VinylId = 4
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
