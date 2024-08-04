using Microsoft.EntityFrameworkCore;
using WhiskersWondersPets.Models;

namespace WhiskersWondersPets.Data
{
    public class AnimalsDBContext : DbContext
    {

        public AnimalsDBContext(DbContextOptions<AnimalsDBContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData
            (
                new { CategoryId = 1, Name = "Mamal" },
                new { CategoryId = 2, Name = "Reptile" },
                new { CategoryId = 3, Name = "Fish" },
                new { CategoryId = 4, Name = "Amphibians" },
                new { CategoryId = 5, Name = "Invertebrates" },
                new { CategoryId = 6, Name = "Birds" }
            );

            modelBuilder.Entity<Animal>().HasData
            (
                new { AnimalId = 1, Name = "Cat", Age = 12, PictureName = "https://th.bing.com/th/id/OIP.b75wsUso03rbXnv0EQoSXwAAAA?rs=1&pid=ImgDetMain", Description = "The cat, commonly referred to as the domestic cat or house cat, is a small domesticated carnivorous mammal. It is the only domesticated species of the family Felidae. Recent advances in archaeology and genetics have shown that the domestication of the cat occurred in the Near East around 7500 BC. It is commonly kept as a house pet and farm cat, but also ranges freely as a feral cat avoiding human contact. Valued by humans for companionship and its ability to kill vermin, the cat's retractable claws are adapted to killing small prey like mice and rats. It has a strong, flexible body, quick reflexes, and sharp teeth, and its night vision and sense of smell are well developed. It is a social species, but a solitary hunter and a crepuscular predator. Cat communication includes vocalizations like meowing, purring, trilling, hissing, growling, and grunting as well as cat body language. It can hear sounds too faint or too high in frequency for human ears, such as those made by small mammals. It secretes and perceives pheromones.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Dog", Age = 12, PictureName = "https://www.pitpat.com/wp-content/uploads/2020/07/Copy-of-Dog_-rights_CU_outdoors_puppy_stationary_-sitting-_cockapoo-1-1536x1152.jpg", Description = "The dog is a domesticated descendant of the wolf. Also called the domestic dog, it was domesticated from an extinct population of Pleistocene wolves over 14,000 years ago. The dog was the first species to be domesticated by humans. Experts estimate that hunter-gatherers domesticated dogs more than 15,000 years ago, which was before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", CategoryId = 1 },
                new { AnimalId = 3, Name = "Rabbit", Age = 12, PictureName = "https://th.bing.com/th/id/OIP.jaWae7u9oCuRk2DwzUme9gHaE8?rs=1&pid=ImgDetMain", Description = "Rabbits are small mammals in the family Leporidae (which also includes the hares), which is in the order Lagomorpha (which also includes pikas). The European rabbit, Oryctolagus cuniculus is the ancestor of the world's hundreds of breeds[1] of domestic rabbit. Sylvilagus includes 13 wild rabbit species, among them the seven types of cottontail. The European rabbit, which has been introduced on every continent except Antarctica, is familiar throughout the world as a wild prey animal, a domesticated form of livestock and a pet. With its widespread effect on ecologies and cultures, in many areas of the world, the rabbit is a part of daily life – as food, clothing, a companion, and a source of artistic inspiration.", CategoryId = 1 },

                new { AnimalId = 4, Name = "Lizard", Age = 12, PictureName = "https://th.bing.com/th/id/R.1070daa416395639e22125463f9ac987?rik=KB1cuxRgSuKevg&riu=http%3a%2f%2fsciworthy.com%2fwp-content%2fuploads%2f2014%2f10%2fAnole_Lizard_Hilo_Hawaii_edit.jpg&ehk=brpgPNeQO5MTVr82k7ydZnEBUGhNIC0qooBPBVC5q3I%3d&risl=&pid=ImgRaw&r=0", Description = "Lizard is the common name used for all squamate reptiles other than snakes (and to a lesser extent amphisbaenians), encompassing over 7,000 species, ranging across all continents except Antarctica, as well as most oceanic island chains. The grouping is paraphyletic as some lizards are more closely related to snakes than they are to other lizards. Lizards range in size from chameleons and geckos a few centimeters long to the 3-meter-long Komodo dragon.", CategoryId = 2 },

                new { AnimalId = 5, Name = "Fish", Age = 12, PictureName = "https://wallup.net/wp-content/uploads/2018/10/08/954889-fish-fishes-underwater-ocean-sea-sealife-nature.jpg", Description = "A fish (pl.: fish or fishes) is an aquatic, anamniotic, gill-bearing vertebrate animal with swimming fins and a hard skull, but lacking limbs with digits. Fish can be grouped into the more basal jawless fish and the more common jawed fish, the latter including all living cartilaginous and bony fish, as well as the extinct placoderms and acanthodians. Most fish are cold-blooded, their body temperature varying with the surrounding water, though some large active swimmers like white shark and tuna can hold a higher core temperature. Many fish can communicate acoustically with each other, such as during courtship displays.", CategoryId = 3 },

                new { AnimalId = 6, Name = "Frog", Age = 12, PictureName = "https://th.bing.com/th/id/R.6e6e60fd73de36781c00ad05057b70b0?rik=cNReyg5lusO%2bAA&pid=ImgRaw&r=0", Description = "A frog is any member of a diverse and largely carnivorous group of short-bodied, tailless amphibians composing the order Anura. The oldest fossil \"proto-frog\" Triadobatrachus is known from the Early Triassic of Madagascar, but molecular clock dating suggests their split from other amphibians may extend further back to the Permian, 265 million years ago. Frogs are widely distributed, ranging from the tropics to subarctic regions, but the greatest concentration of species diversity is in tropical rainforest. Frogs account for around 88% of extant amphibian species. They are also one of the five most diverse vertebrate orders. Warty frog species tend to be called toads, but the distinction between frogs and toads is informal, not from taxonomy or evolutionary history.\r\n\r\nAn adult frog has a stout body, protruding eyes, anteriorly-attached tongue, limbs folded underneath, and no tail (the tail of tailed frogs is an extension of the male cloaca). Frogs have glandular skin, with secretions ranging from distasteful to toxic. Their skin varies in colour from well-camouflaged dappled brown, grey and green to vivid patterns of bright red or yellow and black to show toxicity and ward off predators. Adult frogs live in fresh water and on dry land; some species are adapted for living underground or in trees.", CategoryId = 4 },

                new { AnimalId = 7, Name = "Earth wroms", Age = 12, PictureName = "https://th.bing.com/th/id/R.f56fb31244629de154c1c8c9c721e4e0?rik=DFdXLlz6ACoaag&pid=ImgRaw&r=0", Description = "An earthworm is a soil-dwelling terrestrial invertebrate that belongs to the phylum Annelida. The term is the common name for the largest members of the class (or subclass, depending on the author) Oligochaeta. In classical systems, they were in the order of Opisthopora since the male pores opened posterior to the female pores, although the internal male segments are anterior to the female. Theoretical cladistic studies have placed them in the suborder Lumbricina of the order Haplotaxida, but this may change. Other slang names for earthworms include \"dew-worm\", \"rainworm\", \"nightcrawler\", and \"angleworm\" (from its use as angling hookbaits). Larger terrestrial earthworms are also called megadriles (which translates to \"big worms\") as opposed to the microdriles (\"small worms\") in the semiaquatic families Tubificidae, Lumbricidae and Enchytraeidae. The megadriles are characterized by a distinct clitellum (more extensive than that of microdriles) and a vascular system with true capillaries.", CategoryId = 5 },

                new { AnimalId = 8, Name = "Parrot", Age = 12, PictureName = "https://img.rawpixel.com/s3fs-private/rawpixel_images/website_content/pd19-3-12957u.jpg?auto=format&bg=transparent&con=3&cs=srgb&dpr=1&fm=jpg&ixlib=php-3.1.0&mark=rawpixel-watermark.png&markalpha=90&markpad=13&markscale=10&markx=25&q=75&usm=15&vib=3&w=1400&s=f61b96ced835e02c10fd45d78f3b7d92", Description = "Parrots, also known as psittacines, are birds with a strong curved beak, upright stance, and clawed feet. They are classified in four families that contain roughly 410 species in 101 genera, found mostly in tropical and subtropical regions. The four families are the Psittaculidae (Old World parrots), Psittacidae (African and New World parrots), Cacatuoidea (cockatoos), and Strigopidae (New Zealand parrots). One-third of all parrot species are threatened by extinction, with a higher aggregate extinction risk (IUCN Red List Index) than any other comparable bird group. Parrots have a generally pantropical distribution with several species inhabiting temperate regions as well. The greatest diversity of parrots is in South America and Australasia.", CategoryId = 6 }
            );

            modelBuilder.Entity<Comment>().HasData
            (
                new { CommentId =  1 , AnimalId = 1, UserComment = "Wow its a cat"},
                new { CommentId = 2, AnimalId = 2, UserComment = "Wow its a dog" },
                new { CommentId = 3, AnimalId = 2, UserComment = "Wow its a cute dog" },
                new { CommentId = 4, AnimalId = 2, UserComment = "So cute" }
            );


        }
    }
}
