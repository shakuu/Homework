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
                ""FirstName"": ""Emery"",
                ""LastName"": ""Jacobson"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Carlos"",
                ""LastName"": ""Lopez"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Cheyenne"",
                ""LastName"": ""Herring"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Phoebe"",
                ""LastName"": ""Wolf"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Solomon"",
                ""LastName"": ""Mullins"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Rama"",
                ""LastName"": ""Williamson"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Kylan"",
                ""LastName"": ""Bauer"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Shad"",
                ""LastName"": ""Becker"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Thomas"",
                ""LastName"": ""Wilcox"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Rafael"",
                ""LastName"": ""Mckinney"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Sigourney"",
                ""LastName"": ""Trevino"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Summer"",
                ""LastName"": ""King"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Baxter"",
                ""LastName"": ""Joyner"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Alika"",
                ""LastName"": ""Beasley"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Nerea"",
                ""LastName"": ""Macdonald"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Leroy"",
                ""LastName"": ""Haynes"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Raya"",
                ""LastName"": ""Jensen"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Charlotte"",
                ""LastName"": ""Tran"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Lareina"",
                ""LastName"": ""Bridges"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Melodie"",
                ""LastName"": ""Hicks"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Aspen"",
                ""LastName"": ""Kirk"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Carter"",
                ""LastName"": ""Grant"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Kessie"",
                ""LastName"": ""Hurst"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Chloe"",
                ""LastName"": ""Britt"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Tana"",
                ""LastName"": ""Mckay"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Alyssa"",
                ""LastName"": ""Schmidt"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Linda"",
                ""LastName"": ""Schwartz"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Allegra"",
                ""LastName"": ""Dodson"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Laura"",
                ""LastName"": ""Jimenez"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Dawn"",
                ""LastName"": ""Short"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Brady"",
                ""LastName"": ""Holcomb"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Sasha"",
                ""LastName"": ""Chambers"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Hadassah"",
                ""LastName"": ""Mcintyre"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Lamar"",
                ""LastName"": ""Hawkins"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Mason"",
                ""LastName"": ""Prince"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Murphy"",
                ""LastName"": ""Thompson"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Bruce"",
                ""LastName"": ""Franklin"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Sopoline"",
                ""LastName"": ""Callahan"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Xyla"",
                ""LastName"": ""Charles"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Elijah"",
                ""LastName"": ""Christian"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Bryar"",
                ""LastName"": ""Boyer"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Quon"",
                ""LastName"": ""Smith"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Flavia"",
                ""LastName"": ""Arnold"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Clarke"",
                ""LastName"": ""Warner"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Alfreda"",
                ""LastName"": ""Bell"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Owen"",
                ""LastName"": ""Cummings"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Eve"",
                ""LastName"": ""Perkins"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""John"",
                ""LastName"": ""Shepard"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Stella"",
                ""LastName"": ""Carrillo"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Gray"",
                ""LastName"": ""Mcleod"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Odette"",
                ""LastName"": ""Moss"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Lee"",
                ""LastName"": ""Giles"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Ryder"",
                ""LastName"": ""Shepard"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Roth"",
                ""LastName"": ""Frost"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Sheila"",
                ""LastName"": ""Brennan"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Shelley"",
                ""LastName"": ""Sheppard"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Adrian"",
                ""LastName"": ""Brooks"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Amos"",
                ""LastName"": ""Burnett"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Lacey"",
                ""LastName"": ""Nieves"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Fleur"",
                ""LastName"": ""Tucker"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Luke"",
                ""LastName"": ""Newman"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Damon"",
                ""LastName"": ""Velazquez"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Preston"",
                ""LastName"": ""Joyner"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Frances"",
                ""LastName"": ""Bradshaw"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Emma"",
                ""LastName"": ""Bennett"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Travis"",
                ""LastName"": ""Cohen"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Melyssa"",
                ""LastName"": ""Herrera"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""McKenzie"",
                ""LastName"": ""Newton"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Clio"",
                ""LastName"": ""Cote"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Hunter"",
                ""LastName"": ""Sims"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Denton"",
                ""LastName"": ""Michael"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Guy"",
                ""LastName"": ""Lott"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Guy"",
                ""LastName"": ""Stuart"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Demetria"",
                ""LastName"": ""Padilla"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Graiden"",
                ""LastName"": ""Combs"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Sybil"",
                ""LastName"": ""Thompson"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Fulton"",
                ""LastName"": ""Jennings"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Stuart"",
                ""LastName"": ""Grant"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Meghan"",
                ""LastName"": ""Daugherty"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Melyssa"",
                ""LastName"": ""Meyer"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Hasad"",
                ""LastName"": ""Villarreal"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Phillip"",
                ""LastName"": ""Head"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Germane"",
                ""LastName"": ""Carrillo"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Fuller"",
                ""LastName"": ""Livingston"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Kylie"",
                ""LastName"": ""Kim"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Marshall"",
                ""LastName"": ""Vang"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Ella"",
                ""LastName"": ""Kirby"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Gwendolyn"",
                ""LastName"": ""Frederick"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""David"",
                ""LastName"": ""Walter"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Grady"",
                ""LastName"": ""Conway"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Steven"",
                ""LastName"": ""Serrano"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Carl"",
                ""LastName"": ""Daniels"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Iris"",
                ""LastName"": ""Booth"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Octavius"",
                ""LastName"": ""Elliott"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Baxter"",
                ""LastName"": ""Le"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Renee"",
                ""LastName"": ""Mason"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Hedda"",
                ""LastName"": ""Abbott"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Orlando"",
                ""LastName"": ""Hudson"",
                ""GenderType"": 1
            },
            {
                ""FirstName"": ""Jameson"",
                ""LastName"": ""Finley"",
                ""GenderType"": 2
            },
            {
                ""FirstName"": ""Marny"",
                ""LastName"": ""Hayden"",
                ""GenderType"": 2
            }
        ]";
        #endregion

        public string SeededNamesJson { get { return this.names; } }

        public string SeededCoursesJson { get { return this.courses; } }
    }
}
