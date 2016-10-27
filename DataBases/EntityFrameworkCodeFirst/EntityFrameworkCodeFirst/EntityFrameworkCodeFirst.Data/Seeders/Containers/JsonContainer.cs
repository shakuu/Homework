namespace EntityFrameworkCodeFirst.Data.Seeders.Containers
{
    internal class JsonContainer : IJsonContainer
    {
        private readonly string courses =
        #region SeededCourses
            @"[
                {
                    ""Name"": ""lorem lorem, luctus"",
                    ""Description"": ""et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet""
                },
                {
                    ""Name"": ""Morbi accumsan laoreet ipsum. Curabitur"",
                    ""Description"": ""lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque. In ornare sagittis felis. Donec tempor, est ac mattis semper, dui lectus rutrum urna, nec luctus felis purus ac tellus. Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend""
                },
                {
                    ""Name"": ""turpis. Aliquam adipiscing lobortis risus."",
                    ""Description"": ""massa lobortis ultrices. Vivamus rhoncus. Donec est. Nunc ullamcorper, velit in aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla vulputate dui, nec tempus mauris erat eget ipsum. Suspendisse sagittis. Nullam vitae diam. Proin dolor. Nulla semper tellus id nunc interdum feugiat. Sed nec metus facilisis lorem tristique aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet odio. Etiam ligula tortor, dictum eu, placerat eget, venenatis a, magna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam laoreet, libero et tristique pellentesque, tellus sem mollis dui, in sodales elit erat""
                },
                {
                    ""Name"": ""pharetra sed, hendrerit a, arcu. Sed et"",
                    ""Description"": ""dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere at, velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed molestie. Sed id risus quis diam luctus lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie orci tincidunt adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu iaculis enim, sit amet ornare lectus justo eu arcu. Morbi sit amet massa. Quisque porttitor eros nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel arcu eu odio tristique pharetra. Quisque ac libero nec ligula consectetuer rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod urna. Nullam lobortis""
                },
                {
                    ""Name"": ""velit eget laoreet posuere, enim"",
                    ""Description"": ""iaculis quis, pede. Praesent eu dui. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus. Etiam bibendum fermentum metus. Aenean sed pede nec ante blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna nec quam. Curabitur vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu neque pellentesque massa lobortis ultrices. Vivamus rhoncus. Donec est. Nunc ullamcorper, velit in aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla vulputate dui, nec tempus mauris erat eget ipsum.""
                },
                {
                    ""Name"": ""primis in faucibus orci luctus et"",
                    ""Description"": ""ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus. In mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit nonummy. Fusce fermentum fermentum""
                },
                {
                    ""Name"": ""non lorem vitae odio sagittis semper."",
                    ""Description"": ""neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla. Integer vulputate, risus a ultricies adipiscing, enim mi tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper erat, in consectetuer""
                },
                {
                    ""Name"": ""faucibus orci luctus et ultrices posuere cubilia"",
                    ""Description"": ""iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat.""
                },
                {
                    ""Name"": ""Morbi neque tellus, imperdiet"",
                    ""Description"": ""metus. In nec orci. Donec nibh. Quisque nonummy ipsum non arcu. Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae odio sagittis semper. Nam tempor diam dictum sapien. Aenean massa. Integer vitae nibh. Donec est mauris, rhoncus id, mollis nec, cursus a, enim. Suspendisse aliquet, sem ut cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus. In mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed""
                },
                {
                    ""Name"": ""eu, eleifend nec, malesuada"",
                    ""Description"": ""Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas, urna justo faucibus lectus, a sollicitudin orci sem eget massa. Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est. Nunc laoreet lectus quis massa. Mauris vestibulum, neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam vel arcu. Curabitur ut odio vel est tempor bibendum. Donec felis orci, adipiscing non, luctus sit amet, faucibus ut, nulla. Cras eu tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus""
                }
            ]";
        #endregion


        private readonly string names =
        #region SeededNames
            @"[
               	{
               		""FirstName"": ""Madeline"",
               		""LastName"": ""Leach"",
               		""StudentNumber"": 56986
               	},
               	{
               		""FirstName"": ""Garth"",
               		""LastName"": ""Morin"",
               		""StudentNumber"": 47021
               	},
               	{
               		""FirstName"": ""Silas"",
               		""LastName"": ""Moses"",
               		""StudentNumber"": 22247
               	},
               	{
               		""FirstName"": ""Kathleen"",
               		""LastName"": ""Watts"",
               		""StudentNumber"": 95630
               	},
               	{
               		""FirstName"": ""Kellie"",
               		""LastName"": ""Dickson"",
               		""StudentNumber"": 97458
               	},
               	{
               		""FirstName"": ""Ann"",
               		""LastName"": ""Osborne"",
               		""StudentNumber"": 13236
               	},
               	{
               		""FirstName"": ""Tana"",
               		""LastName"": ""Spence"",
               		""StudentNumber"": 42984
               	},
               	{
               		""FirstName"": ""Chadwick"",
               		""LastName"": ""Morse"",
               		""StudentNumber"": 99192
               	},
               	{
               		""FirstName"": ""Glenna"",
               		""LastName"": ""Ferguson"",
               		""StudentNumber"": 68454
               	},
               	{
               		""FirstName"": ""Griffin"",
               		""LastName"": ""Sellers"",
               		""StudentNumber"": 85430
               	},
               	{
               		""FirstName"": ""Tad"",
               		""LastName"": ""Bird"",
               		""StudentNumber"": 18791
               	},
               	{
               		""FirstName"": ""Risa"",
               		""LastName"": ""Wise"",
               		""StudentNumber"": 72897
               	},
               	{
               		""FirstName"": ""Hyacinth"",
               		""LastName"": ""Jordan"",
               		""StudentNumber"": 51587
               	},
               	{
               		""FirstName"": ""Isabella"",
               		""LastName"": ""Morgan"",
               		""StudentNumber"": 75019
               	},
               	{
               		""FirstName"": ""Imelda"",
               		""LastName"": ""Sawyer"",
               		""StudentNumber"": 95582
               	},
               	{
               		""FirstName"": ""Ishmael"",
               		""LastName"": ""Espinoza"",
               		""StudentNumber"": 81034
               	},
               	{
               		""FirstName"": ""Gareth"",
               		""LastName"": ""Cain"",
               		""StudentNumber"": 46163
               	},
               	{
               		""FirstName"": ""Porter"",
               		""LastName"": ""Hudson"",
               		""StudentNumber"": 44396
               	},
               	{
               		""FirstName"": ""Tyler"",
               		""LastName"": ""Pollard"",
               		""StudentNumber"": 21388
               	},
               	{
               		""FirstName"": ""Medge"",
               		""LastName"": ""Dickson"",
               		""StudentNumber"": 86342
               	},
               	{
               		""FirstName"": ""Connor"",
               		""LastName"": ""Jimenez"",
               		""StudentNumber"": 11815
               	},
               	{
               		""FirstName"": ""Rama"",
               		""LastName"": ""Giles"",
               		""StudentNumber"": 96080
               	},
               	{
               		""FirstName"": ""Adrian"",
               		""LastName"": ""Cox"",
               		""StudentNumber"": 42979
               	},
               	{
               		""FirstName"": ""Signe"",
               		""LastName"": ""Kirk"",
               		""StudentNumber"": 54404
               	},
               	{
               		""FirstName"": ""Roanna"",
               		""LastName"": ""Ramirez"",
               		""StudentNumber"": 42432
               	},
               	{
               		""FirstName"": ""Amity"",
               		""LastName"": ""Travis"",
               		""StudentNumber"": 91096
               	},
               	{
               		""FirstName"": ""Peter"",
               		""LastName"": ""Navarro"",
               		""StudentNumber"": 76683
               	},
               	{
               		""FirstName"": ""Macon"",
               		""LastName"": ""Hester"",
               		""StudentNumber"": 16985
               	},
               	{
               		""FirstName"": ""Jasmine"",
               		""LastName"": ""Burt"",
               		""StudentNumber"": 94209
               	},
               	{
               		""FirstName"": ""Ursa"",
               		""LastName"": ""Vargas"",
               		""StudentNumber"": 64159
               	},
               	{
               		""FirstName"": ""Portia"",
               		""LastName"": ""Mathews"",
               		""StudentNumber"": 17323
               	},
               	{
               		""FirstName"": ""Naomi"",
               		""LastName"": ""Lynch"",
               		""StudentNumber"": 95266
               	},
               	{
               		""FirstName"": ""Serina"",
               		""LastName"": ""Lott"",
               		""StudentNumber"": 24541
               	},
               	{
               		""FirstName"": ""Olivia"",
               		""LastName"": ""Cleveland"",
               		""StudentNumber"": 80832
               	},
               	{
               		""FirstName"": ""Jena"",
               		""LastName"": ""Gay"",
               		""StudentNumber"": 97600
               	},
               	{
               		""FirstName"": ""Bernard"",
               		""LastName"": ""Valentine"",
               		""StudentNumber"": 46526
               	},
               	{
               		""FirstName"": ""Bethany"",
               		""LastName"": ""Figueroa"",
               		""StudentNumber"": 52629
               	},
               	{
               		""FirstName"": ""Marshall"",
               		""LastName"": ""Coleman"",
               		""StudentNumber"": 31984
               	},
               	{
               		""FirstName"": ""Kasper"",
               		""LastName"": ""Cain"",
               		""StudentNumber"": 85814
               	},
               	{
               		""FirstName"": ""Violet"",
               		""LastName"": ""Salas"",
               		""StudentNumber"": 32651
               	},
               	{
               		""FirstName"": ""Brooke"",
               		""LastName"": ""Gallagher"",
               		""StudentNumber"": 88942
               	},
               	{
               		""FirstName"": ""Claudia"",
               		""LastName"": ""Chapman"",
               		""StudentNumber"": 30395
               	},
               	{
               		""FirstName"": ""Wayne"",
               		""LastName"": ""Strickland"",
               		""StudentNumber"": 74538
               	},
               	{
               		""FirstName"": ""Judah"",
               		""LastName"": ""Harrison"",
               		""StudentNumber"": 62638
               	},
               	{
               		""FirstName"": ""Emily"",
               		""LastName"": ""Roach"",
               		""StudentNumber"": 49843
               	},
               	{
               		""FirstName"": ""Judah"",
               		""LastName"": ""Burris"",
               		""StudentNumber"": 49492
               	},
               	{
               		""FirstName"": ""Carlos"",
               		""LastName"": ""Martin"",
               		""StudentNumber"": 41245
               	},
               	{
               		""FirstName"": ""Lester"",
               		""LastName"": ""Stark"",
               		""StudentNumber"": 95661
               	},
               	{
               		""FirstName"": ""Lael"",
               		""LastName"": ""Miranda"",
               		""StudentNumber"": 52986
               	},
               	{
               		""FirstName"": ""Breanna"",
               		""LastName"": ""Bradley"",
               		""StudentNumber"": 14507
               	},
               	{
               		""FirstName"": ""Tashya"",
               		""LastName"": ""Kerr"",
               		""StudentNumber"": 55201
               	},
               	{
               		""FirstName"": ""Zephr"",
               		""LastName"": ""Zimmerman"",
               		""StudentNumber"": 79998
               	},
               	{
               		""FirstName"": ""Raven"",
               		""LastName"": ""House"",
               		""StudentNumber"": 39990
               	},
               	{
               		""FirstName"": ""Jameson"",
               		""LastName"": ""Hopper"",
               		""StudentNumber"": 91677
               	},
               	{
               		""FirstName"": ""Nasim"",
               		""LastName"": ""Jensen"",
               		""StudentNumber"": 62924
               	},
               	{
               		""FirstName"": ""Erica"",
               		""LastName"": ""Hurley"",
               		""StudentNumber"": 58346
               	},
               	{
               		""FirstName"": ""Lucy"",
               		""LastName"": ""Santana"",
               		""StudentNumber"": 99641
               	},
               	{
               		""FirstName"": ""Mary"",
               		""LastName"": ""Cote"",
               		""StudentNumber"": 40939
               	},
               	{
               		""FirstName"": ""Libby"",
               		""LastName"": ""Walker"",
               		""StudentNumber"": 71540
               	},
               	{
               		""FirstName"": ""Maia"",
               		""LastName"": ""Cardenas"",
               		""StudentNumber"": 72109
               	},
               	{
               		""FirstName"": ""Harper"",
               		""LastName"": ""Chase"",
               		""StudentNumber"": 76491
               	},
               	{
               		""FirstName"": ""Dustin"",
               		""LastName"": ""Jordan"",
               		""StudentNumber"": 99752
               	},
               	{
               		""FirstName"": ""Illiana"",
               		""LastName"": ""Vaughan"",
               		""StudentNumber"": 83791
               	},
               	{
               		""FirstName"": ""Hedy"",
               		""LastName"": ""Thornton"",
               		""StudentNumber"": 72697
               	},
               	{
               		""FirstName"": ""Odessa"",
               		""LastName"": ""Brooks"",
               		""StudentNumber"": 52208
               	},
               	{
               		""FirstName"": ""Murphy"",
               		""LastName"": ""Alvarez"",
               		""StudentNumber"": 53675
               	},
               	{
               		""FirstName"": ""Keaton"",
               		""LastName"": ""Vasquez"",
               		""StudentNumber"": 11825
               	},
               	{
               		""FirstName"": ""Beverly"",
               		""LastName"": ""Hudson"",
               		""StudentNumber"": 66282
               	},
               	{
               		""FirstName"": ""Jesse"",
               		""LastName"": ""Key"",
               		""StudentNumber"": 52466
               	},
               	{
               		""FirstName"": ""Signe"",
               		""LastName"": ""Head"",
               		""StudentNumber"": 82449
               	},
               	{
               		""FirstName"": ""Elizabeth"",
               		""LastName"": ""Elliott"",
               		""StudentNumber"": 49893
               	},
               	{
               		""FirstName"": ""Raymond"",
               		""LastName"": ""Mccormick"",
               		""StudentNumber"": 87326
               	},
               	{
               		""FirstName"": ""Lucius"",
               		""LastName"": ""Jacobs"",
               		""StudentNumber"": 58122
               	},
               	{
               		""FirstName"": ""Quon"",
               		""LastName"": ""House"",
               		""StudentNumber"": 45804
               	},
               	{
               		""FirstName"": ""Mark"",
               		""LastName"": ""Warren"",
               		""StudentNumber"": 50066
               	},
               	{
               		""FirstName"": ""Sophia"",
               		""LastName"": ""Prince"",
               		""StudentNumber"": 51810
               	},
               	{
               		""FirstName"": ""Baxter"",
               		""LastName"": ""Hickman"",
               		""StudentNumber"": 96627
               	},
               	{
               		""FirstName"": ""Alice"",
               		""LastName"": ""Cummings"",
               		""StudentNumber"": 48676
               	},
               	{
               		""FirstName"": ""Evangeline"",
               		""LastName"": ""Bean"",
               		""StudentNumber"": 18391
               	},
               	{
               		""FirstName"": ""Tiger"",
               		""LastName"": ""Barton"",
               		""StudentNumber"": 59181
               	},
               	{
               		""FirstName"": ""Mara"",
               		""LastName"": ""Lambert"",
               		""StudentNumber"": 93908
               	},
               	{
               		""FirstName"": ""Wanda"",
               		""LastName"": ""Bauer"",
               		""StudentNumber"": 28398
               	},
               	{
               		""FirstName"": ""Alden"",
               		""LastName"": ""Spears"",
               		""StudentNumber"": 96195
               	},
               	{
               		""FirstName"": ""Merritt"",
               		""LastName"": ""Hayden"",
               		""StudentNumber"": 76895
               	},
               	{
               		""FirstName"": ""Tyrone"",
               		""LastName"": ""Frazier"",
               		""StudentNumber"": 10595
               	},
               	{
               		""FirstName"": ""Haviva"",
               		""LastName"": ""Castro"",
               		""StudentNumber"": 51721
               	},
               	{
               		""FirstName"": ""Madeson"",
               		""LastName"": ""Larson"",
               		""StudentNumber"": 90767
               	},
               	{
               		""FirstName"": ""Shoshana"",
               		""LastName"": ""Mendoza"",
               		""StudentNumber"": 74520
               	},
               	{
               		""FirstName"": ""Griffith"",
               		""LastName"": ""Payne"",
               		""StudentNumber"": 44433
               	},
               	{
               		""FirstName"": ""Driscoll"",
               		""LastName"": ""Wilkerson"",
               		""StudentNumber"": 74725
               	},
               	{
               		""FirstName"": ""Indigo"",
               		""LastName"": ""Richmond"",
               		""StudentNumber"": 76480
               	},
               	{
               		""FirstName"": ""Germane"",
               		""LastName"": ""Snyder"",
               		""StudentNumber"": 33662
               	},
               	{
               		""FirstName"": ""Bianca"",
               		""LastName"": ""David"",
               		""StudentNumber"": 23574
               	},
               	{
               		""FirstName"": ""Colleen"",
               		""LastName"": ""Espinoza"",
               		""StudentNumber"": 83394
               	},
               	{
               		""FirstName"": ""Logan"",
               		""LastName"": ""Farrell"",
               		""StudentNumber"": 70184
               	},
               	{
               		""FirstName"": ""Ezekiel"",
               		""LastName"": ""Salinas"",
               		""StudentNumber"": 20848
               	},
               	{
               		""FirstName"": ""Jolene"",
               		""LastName"": ""Koch"",
               		""StudentNumber"": 53051
               	},
               	{
               		""FirstName"": ""Calvin"",
               		""LastName"": ""Horton"",
               		""StudentNumber"": 22659
               	},
               	{
               		""FirstName"": ""Geraldine"",
               		""LastName"": ""Sherman"",
               		""StudentNumber"": 18595
               	},
               	{
               		""FirstName"": ""Jakeem"",
               		""LastName"": ""Little"",
               		""StudentNumber"": 66365
               	}
              ]";
        #endregion

        public string SeededNamesJson { get { return this.names; } }

        public string SeededCoursesJson { get { return this.courses; } }
    }
}
