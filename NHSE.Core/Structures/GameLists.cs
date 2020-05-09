using System.Collections.Generic;

namespace NHSE.Core
{
    public static class GameLists
    {
        public static readonly IReadOnlyList<ushort> Fruits = new ushort[]
        {
            2213, // apple
            2287, // Cherry
            2214, // Orange
            2286, // Peach
            2285, // Pear
        };

        public static readonly IReadOnlyList<ushort> Bugs = new ushort[]
        {
            00582, // brown cicada
            00583, // tiger butterfly
            00584, // Rajah Brooke's birdwing
            00585, // red dragonfly
            00586, // Queen Alexandra's birdwing
            00587, // pondskater
            00588, // ant
            00590, // pill bug
            00591, // wharf roach
            00592, // moth
            00594, // diving beetle
            00595, // darner dragonfly
            00596, // goliath beetle
            00597, // fly
            00598, // orchid mantis
            00599, // tiger beetle
            00600, // horned hercules
            00601, // evening cicada
            00602, // cyclommatus stag
            00603, // firefly
            00604, // dung beetle
            00605, // rice grasshopper
            00606, // mosquito
            00607, // mantis
            00608, // stinkbug
            00609, // citrus long-horned beetle
            00610, // peacock butterfly
            00611, // snail
            00612, // horned dynastid
            00613, // grasshopper
            00614, // earth-boring dung beetle
            00615, // horned atlas
            00616, // walking leaf
            00617, // cricket
            00618, // giant cicada
            00619, // spider
            00620, // agrias butterfly
            00621, // robust cicada
            00622, // bagworm
            00623, // honeybee
            00624, // miyama stag
            00625, // yellow butterfly
            00626, // common butterfly
            00627, // emperor butterfly
            00628, // centipede
            00630, // walking stick
            00631, // rainbow stag
            00632, // saw stag
            00633, // flea
            00634, // mole cricket
            00635, // banded dragonfly
            00636, // monarch butterfly
            00637, // giant stag
            00638, // golden stag
            00639, // scarab beetle
            00640, // scorpion
            00641, // cicada shell
            00642, // bell cricket
            00643, // wasp
            00644, // long locust
            00645, // jewel beetle
            00646, // tarantula
            00647, // ladybug
            00648, // migratory locust
            00649, // walker cicada
            00650, // violin beetle
            00651, // hermit crab
            00652, // Atlas moth
            00653, // horned elephant
            03477, // common bluebottle
            03478, // paper kite butterfly
            03479, // great purple emperor
            03480, // drone beetle
            03482, // giraffe stag
            03483, // man-faced stink bug
            03484, // Madagascan sunset moth
            03485, // blue weevil beetle
            03487, // rosalia batesi beetle
            03539, // snowflake
            03540, // large snowflake
            04702, // Wisp spirit piece
            05157, // giant water bug
            05339, // damselfly
            05859, // cherry-blossom petal
            07374, // maple leaf
        };

        public static readonly IReadOnlyList<ushort> Fish = new ushort[]
        {
            00328, // crucian carp
            00329, // goldfish
            02215, // bitterling
            02216, // pale chub
            02217, // dace
            02219, // carp
            02220, // koi
            02221, // pop-eyed goldfish
            02222, // killifish
            02223, // crawfish
            02224, // soft-shelled turtle
            02225, // tadpole
            02226, // frog
            02227, // freshwater goby
            02228, // loach
            02229, // catfish
            02231, // giant snakehead
            02232, // bluegill
            02233, // yellow perch
            02234, // black bass
            02235, // pike
            02236, // pond smelt
            02237, // sweetfish
            02238, // cherry salmon
            02239, // char
            02241, // stringfish
            02242, // salmon
            02243, // king salmon
            02244, // mitten crab
            02245, // guppy
            02246, // nibble fish
            02247, // angelfish
            02248, // neon tetra
            02249, // piranha
            02250, // arowana
            02251, // dorado
            02252, // gar
            02253, // arapaima
            02254, // saddled bichir
            02255, // sea butterfly
            02256, // sea horse
            02257, // clown fish
            02258, // surgeonfish
            02259, // butterfly fish
            02260, // Napoleonfish
            02261, // zebra turkeyfish
            02262, // blowfish
            02263, // puffer fish
            02264, // horse mackerel
            02265, // barred knifejaw
            02266, // sea bass
            02267, // red snapper
            02268, // dab
            02269, // olive flounder
            02270, // squid
            02271, // moray eel
            02272, // ribbon eel
            02273, // football fish
            02274, // tuna
            02275, // blue marlin
            02276, // giant trevally
            02277, // ray
            02278, // ocean sunfish
            02279, // hammerhead shark
            02280, // great white shark
            02281, // saw shark
            02282, // whale shark
            02283, // oarfish
            02284, // coelacanth
            02502, // stone
            03466, // empty can
            03469, // boot
            03470, // old tire
            04189, // sturgeon
            04190, // tilapia
            04191, // betta
            04192, // snapping turtle
            04193, // golden trout
            04194, // rainbowfish
            04201, // anchovy
            04202, // mahi-mahi
            04203, // suckerfish
            04204, // barreleye
            05254, // ranchu goldfish
            12514, // water egg
        };

        public static readonly IReadOnlyList<ushort> Fossils = new ushort[]
        {00169, // ankylo skull
            00170, // ankylo torso
            00171, // ankylo tail
            00177, // archelon skull
            00178, // archelon tail
            00180, // megacero skull
            00181, // megacero torso
            00182, // megacero tail
            00184, // dimetrodon skull
            00185, // dimetrodon torso
            00188, // iguanodon skull
            00189, // iguanodon torso
            00190, // iguanodon tail
            00192, // ophthalmo skull
            00193, // ophthalmo torso
            00195, // mammoth skull
            00196, // mammoth torso
            00198, // pachy skull
            00199, // pachy tail
            00202, // parasaur skull
            00203, // parasaur torso
            00204, // parasaur tail
            00206, // ptera body
            00207, // right ptera wing
            00208, // left ptera wing
            00210, // deinony torso
            00211, // deinony tail
            00213, // sabertooth skull
            00214, // sabertooth tail
            00216, // diplo skull
            00217, // diplo neck
            00218, // diplo chest
            00219, // diplo pelvis
            00220, // diplo tail
            00222, // spino skull
            00223, // spino torso
            00224, // spino tail
            00226, // stego skull
            00227, // stego torso
            00228, // stego tail
            00234, // plesio skull
            00235, // plesio body
            00236, // plesio tail
            00238, // T. rex skull
            00239, // T. rex torso
            00240, // T. rex tail
            00242, // tricera skull
            00243, // tricera torso
            00244, // tricera tail
            00294, // amber
            00295, // ammonite
            00296, // coprolite
            00298, // archaeopteryx
            00300, // dinosaur track
            00301, // australopith
            00302, // shark-tooth pattern
            00303, // trilobite
            04651, // anomalocaris
            04658, // right megalo side
            04659, // left megalo side
            04660, // dunkleosteus
            04662, // myllokunmingia
            04663, // eusthenopteron
            04664, // acanthostega
            04665, // juramaia
            04688, // brachio skull
            04689, // brachio chest
            04690, // brachio pelvis
            04691, // brachio tail
            04697, // quetzal torso
            04698, // right quetzal wing
            04699, // left quetzal wing
            07251, // diplo tail tip
        };

        public static readonly IReadOnlyList<ushort> Art = new ushort[]
        {
            00002, // scenic painting 
            00005, // graceful painting (forgery) 
            00006, // graceful painting 
            00009, // quaint painting (forgery) 
            00010, // quaint painting 
            00013, // basic painting (forgery) 
            00014, // basic painting 
            00017, // famous painting (forgery) 
            00018, // famous painting 
            00020, // perfect painting 
            00023, // serene painting (forgery) 
            00024, // serene painting 
            00027, // wistful painting (forgery) 
            00028, // wistful painting 
            00031, // moving painting (forgery) 
            00032, // moving painting 
            00034, // warm painting 
            00038, // dynamic painting 
            00041, // jolly painting (forgery) 
            00042, // jolly painting 
            00044, // common painting 
            00046, // proper painting 
            00048, // nice painting 
            00050, // flowery painting 
            00052, // moody painting 
            00055, // amazing painting (forgery) 
            00056, // amazing painting 
            00065, // scary painting (forgery) 
            00066, // scary painting 
            00068, // worthy painting 
            00071, // solemn painting (forgery) 
            00072, // solemn painting 
            00075, // wild painting right half (forgery) 
            00076, // wild painting right half 
            00078, // calm painting 
            01331, // motherly statue 
            01332, // motherly statue (forgery) 
            01333, // gallant statue 
            01334, // gallant statue (forgery) 
            01335, // robust statue 
            01336, // robust statue (forgery) 
            01337, // ancient statue 
            01338, // ancient statue (forgery) 
            01339, // great statue 
            01341, // beautiful statue 
            01342, // beautiful statue (forgery) 
            01343, // mystic statue 
            01344, // mystic statue (forgery) 
            01345, // valiant statue 
            01346, // valiant statue (forgery) 
            12533, // rock-head statue  
            12534, // rock-head statue  (forgery) 
            12535, // informative statue 
            12536, // informative statue (forgery) 
            12537, // tremendous statue 
            12538, // tremendous statue (forgery) 
            12539, // warrior statue 
            12540, // warrior statue (forgery) 
            12541, // familiar statue 
            12570, // wild painting left half 
            12571, // wild painting left half (forgery) 
            12618, // twinkling painting 
            12619, // academic painting 
            12620, // academic painting (forgery) 
            12621, // sinking painting 
            12622, // detailed painting 
            12623, // detailed painting (forgery) 
            12624, // glowing painting 
            12625, // mysterious painting 
            12629, // scenic painting (forgery) 
        };

        public static readonly HashSet<ushort> Shells = new HashSet<ushort>
        {
            1374, // sea snail
            1375, // venus comb
            1376, // conch
            // 2 unused 1377, 1378
            1379, // sand dollar
            1380, // coral
            1381, // giant clam
            1382, // cowrie

            5982, // summer shell
        };

        public static readonly HashSet<ushort> Terraforming = new HashSet<ushort>
        {
            3075, // path construction permit
            3247, // waterscaping permit
            8773, // stone path permit
            8774, // brick path permit
            8775, // dark dirt path permit
            8776, // arched tile path permit
            8777, // sand path permit
            8778, // terra-cotta tile permit
            8779, // wooden path permit
            8780, // waterscaping permit
            8781, // cliff construction permit
            9771, // custom design path permit
        };

        public static readonly HashSet<ushort> NoCheckReceived = new HashSet<ushort>(Terraforming)
        {
            Item.DIYRecipe,

            9046, // Vaulting Pole Recipe
            9047, // Flimsy Shovel Recipe
            9048, // Flimsy Watering Can Recipe
            9049, // Top 8 Pop Hairstyles
            9050, // Top 8 Cool Hairstyles
            9051, // Top 8 Stylish Hair Colors

            9221, // Pretty Good Tools Recipes

            10309, // Slingshot Recipe

            11140, // Ultimate Pocket Stuffing

            12294, // Flimsy Axe Recipe

            12327, // Ladder Recipe
        };
    }
}
