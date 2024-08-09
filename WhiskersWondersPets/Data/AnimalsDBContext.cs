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
                new { AnimalId = 1, Name = "Cat", Age = 12, PictureName = "images/Cat.jpg", Description = "The cat, commonly referred to as the domestic cat or house cat, is a small domesticated carnivorous mammal. It is the only domesticated species of the family Felidae. Recent advances in archaeology and genetics have shown that the domestication of the cat occurred in the Near East around 7500 BC. It is commonly kept as a house pet and farm cat, but also ranges freely as a feral cat avoiding human contact. Valued by humans for companionship and its ability to kill vermin, the cat's retractable claws are adapted to killing small prey like mice and rats. It has a strong, flexible body, quick reflexes, and sharp teeth, and its night vision and sense of smell are well developed. It is a social species, but a solitary hunter and a crepuscular predator. Cat communication includes vocalizations like meowing, purring, trilling, hissing, growling, and grunting as well as cat body language. It can hear sounds too faint or too high in frequency for human ears, such as those made by small mammals. It secretes and perceives pheromones.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Dog", Age = 12, PictureName = "images/Dog.jpg", Description = "The dog is a domesticated descendant of the wolf. Also called the domestic dog, it was domesticated from an extinct population of Pleistocene wolves over 14,000 years ago. The dog was the first species to be domesticated by humans. Experts estimate that hunter-gatherers domesticated dogs more than 15,000 years ago, which was before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", CategoryId = 1 },
                new { AnimalId = 3, Name = "Rabbit", Age = 12, PictureName = "images/Rabbit.jpg", Description = "Rabbits are small mammals in the family Leporidae (which also includes the hares), which is in the order Lagomorpha (which also includes pikas). The European rabbit, Oryctolagus cuniculus is the ancestor of the world's hundreds of breeds[1] of domestic rabbit. Sylvilagus includes 13 wild rabbit species, among them the seven types of cottontail. The European rabbit, which has been introduced on every continent except Antarctica, is familiar throughout the world as a wild prey animal, a domesticated form of livestock and a pet. With its widespread effect on ecologies and cultures, in many areas of the world, the rabbit is a part of daily life – as food, clothing, a companion, and a source of artistic inspiration.", CategoryId = 1 },

                new { AnimalId = 4, Name = "Lizard", Age = 12, PictureName = "images/Lizard.jpg", Description = "Lizard is the common name used for all squamate reptiles other than snakes (and to a lesser extent amphisbaenians), encompassing over 7,000 species, ranging across all continents except Antarctica, as well as most oceanic island chains. The grouping is paraphyletic as some lizards are more closely related to snakes than they are to other lizards. Lizards range in size from chameleons and geckos a few centimeters long to the 3-meter-long Komodo dragon.", CategoryId = 2 },

                new { AnimalId = 5, Name = "Fish", Age = 12, PictureName = "images/Fish.jpg", Description = "A fish (pl.: fish or fishes) is an aquatic, anamniotic, gill-bearing vertebrate animal with swimming fins and a hard skull, but lacking limbs with digits. Fish can be grouped into the more basal jawless fish and the more common jawed fish, the latter including all living cartilaginous and bony fish, as well as the extinct placoderms and acanthodians. Most fish are cold-blooded, their body temperature varying with the surrounding water, though some large active swimmers like white shark and tuna can hold a higher core temperature. Many fish can communicate acoustically with each other, such as during courtship displays.", CategoryId = 3 },

                new { AnimalId = 6, Name = "Frog", Age = 12, PictureName = "images/Frog.jpg", Description = "A frog is any member of a diverse and largely carnivorous group of short-bodied, tailless amphibians composing the order Anura. The oldest fossil \"proto-frog\" Triadobatrachus is known from the Early Triassic of Madagascar, but molecular clock dating suggests their split from other amphibians may extend further back to the Permian, 265 million years ago. Frogs are widely distributed, ranging from the tropics to subarctic regions, but the greatest concentration of species diversity is in tropical rainforest. Frogs account for around 88% of extant amphibian species. They are also one of the five most diverse vertebrate orders. Warty frog species tend to be called toads, but the distinction between frogs and toads is informal, not from taxonomy or evolutionary history.\r\n\r\nAn adult frog has a stout body, protruding eyes, anteriorly-attached tongue, limbs folded underneath, and no tail (the tail of tailed frogs is an extension of the male cloaca). Frogs have glandular skin, with secretions ranging from distasteful to toxic. Their skin varies in colour from well-camouflaged dappled brown, grey and green to vivid patterns of bright red or yellow and black to show toxicity and ward off predators. Adult frogs live in fresh water and on dry land; some species are adapted for living underground or in trees.", CategoryId = 4 },

                new { AnimalId = 7, Name = "Earth wroms", Age = 12, PictureName = "images/Worms.jpg", Description = "An earthworm is a soil-dwelling terrestrial invertebrate that belongs to the phylum Annelida. The term is the common name for the largest members of the class (or subclass, depending on the author) Oligochaeta. In classical systems, they were in the order of Opisthopora since the male pores opened posterior to the female pores, although the internal male segments are anterior to the female. Theoretical cladistic studies have placed them in the suborder Lumbricina of the order Haplotaxida, but this may change. Other slang names for earthworms include \"dew-worm\", \"rainworm\", \"nightcrawler\", and \"angleworm\" (from its use as angling hookbaits). Larger terrestrial earthworms are also called megadriles (which translates to \"big worms\") as opposed to the microdriles (\"small worms\") in the semiaquatic families Tubificidae, Lumbricidae and Enchytraeidae. The megadriles are characterized by a distinct clitellum (more extensive than that of microdriles) and a vascular system with true capillaries.", CategoryId = 5 },

                new { AnimalId = 8, Name = "Parrot", Age = 12, PictureName = "images/Parrot.jpg", Description = "Parrots, also known as psittacines, are birds with a strong curved beak, upright stance, and clawed feet. They are classified in four families that contain roughly 410 species in 101 genera, found mostly in tropical and subtropical regions. The four families are the Psittaculidae (Old World parrots), Psittacidae (African and New World parrots), Cacatuoidea (cockatoos), and Strigopidae (New Zealand parrots). One-third of all parrot species are threatened by extinction, with a higher aggregate extinction risk (IUCN Red List Index) than any other comparable bird group. Parrots have a generally pantropical distribution with several species inhabiting temperate regions as well. The greatest diversity of parrots is in South America and Australasia.", CategoryId = 6 },
                new { AnimalId = 9, Name = "HedgeHog", Age = 6, PictureName = "images/Hedgehog.jpg", Description = "A hedgehog is a spiny mammal of the subfamily Erinaceinae, in the eulipotyphlan family Erinaceidae. There are seventeen species of hedgehog in five genera found throughout parts of Europe, Asia, and Africa, and in New Zealand by introduction. There are no hedgehogs native to Australia and no living species native to the Americas. However, the extinct genus Amphechinus was once present in North America.\r\n\r\nHedgehogs share distant ancestry with shrews, with gymnures possibly being the intermediate link, and they have changed little over the last fifteen million years. Like many of the first mammals, they have adapted to a nocturnal way of life. Their spiny protection resembles that of porcupines, which are rodents, and echidnas, a type of monotreme.", CategoryId = 1 }
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
