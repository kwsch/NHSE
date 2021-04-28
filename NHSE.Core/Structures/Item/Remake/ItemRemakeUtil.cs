using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Fetches the customization definition index for a given item (metadata).
    /// </summary>
    public static class ItemRemakeUtil
    {
        public static short GetRemakeIndex(ushort id) => List.TryGetValue(id, out var value) ? value : (short)-1;

        public static Dictionary<short, ushort> GetInvertedDictionary()
        {
            var dict = new Dictionary<short, ushort>();
            foreach (var kvp in List)
            {
                if (!dict.ContainsKey(kvp.Value))
                    dict.Add(kvp.Value, kvp.Key);
            }
            return dict;
        }

        private static readonly IReadOnlyDictionary<ushort, short> List = new Dictionary<ushort, short>
        {
            {00080, 0102}, // clackercart
            {00083, 0129}, // rocking horse
            {00085, 0197}, // train set
            {00086, 0086}, // elephant slide
            {00088, 0119}, // ringtoss
            {00131, 0879}, // lucky cat
            {00144, 0156}, // manhole cover
            {00146, 0172}, // cone
            {00287, 0818}, // exercise bike
            {00290, 0771}, // treadmill
            {00330, 0171}, // barbecue
            {00331, 0399}, // birdbath
            {00333, 0232}, // birdhouse
            {00335, 0758}, // Mr. Flamingo
            {00336, 0759}, // Mrs. Flamingo
            {00338, 0258}, // lawn mower
            {00383, 0310}, // acoustic guitar
            {00530, 0178}, // grass standee
            {00531, 0176}, // hedge standee
            {00532, 0179}, // mountain standee
            {00533, 0177}, // tree standee
            {00546, 0806}, // stadiometer
            {00664, 0182}, // beach chair
            {00667, 0899}, // shaved-ice maker
            {00669, 0456}, // ukulele
            {00676, 0887}, // tall lantern
            {00677, 0651}, // deer scare
            {00682, 0373}, // boomerang
            {00683, 0734}, // bottled ship
            {00685, 0719}, // Dala horse
            {00688, 0803}, // pagoda
            {00690, 0709}, // hula doll
            {00704, 0796}, // tapestry
            {00710, 0216}, // bamboo bench
            {00716, 0360}, // screen
            {00725, 0312}, // paper lantern
            {00739, 0224}, // tea table
            {00742, 0221}, // fireplace
            {00787, 0127}, // tape deck
            {00796, 0374}, // retro stereo
            {00805, 0383}, // mush lamp
            {00808, 0340}, // mush table
            {00832, 0354}, // modern office chair
            {00833, 0085}, // upright locker
            {00839, 0281}, // safe
            {00840, 0355}, // office desk
            {00849, 0402}, // amp
            {00863, 0641}, // billiard table
            {00865, 0190}, // birdcage
            {00870, 0476}, // book stands
            {00889, 0463}, // camp stove
            {00891, 0368}, // holiday candle
            {00896, 0279}, // cat tower
            {00907, 0228}, // vacuum cleaner
            {00908, 0229}, // upright vacuum
            {00915, 0396}, // cuckoo clock
            {00918, 0242}, // coffee cup
            {00928, 0317}, // pot rack
            {00929, 0316}, // air conditioner
            {00941, 0410}, // DJ's turntable
            {00950, 0742}, // effects rack
            {00954, 0572}, // espresso maker
            {00955, 0359}, // exit sign
            {00957, 0277}, // ventilation fan
            {00971, 0886}, // snack machine
            {00987, 0743}, // harp
            {00997, 0267}, // incense burner
            {00998, 0309}, // kitchen island
            {01029, 0183}, // low screen
            {01032, 0152}, // magazine rack
            {01042, 0166}, // metronome
            {01043, 0199}, // microwave
            {01050, 0157}, // mixer
            {01058, 0140}, // music stand
            {01081, 0328}, // upright piano
            {01082, 0184}, // picnic basket
            {01087, 0768}, // pinball machine
            {01092, 0148}, // popcorn machine
            {01103, 0117}, // rocking chair
            {01111, 0726}, // outdoor bath
            {01112, 0125}, // colorful wheel
            {01117, 0231}, // sand castle
            {01125, 0559}, // revolving spice rack
            {01127, 0733}, // old sewing machine
            {01128, 0158}, // sewing machine
            {01143, 0236}, // smoker
            {01157, 0407}, // brick oven
            {01161, 0526}, // cream and sugar
            {01170, 0142}, // swinging bench
            {01171, 0408}, // synthesizer
            {01177, 0772}, // foosball table
            {01185, 0200}, // phone box
            {01189, 0370}, // tire stack
            {01199, 0255}, // tricycle
            {01211, 0794}, // typewriter
            {01221, 0409}, // video camera
            {01227, 0194}, // deluxe washer
            {01229, 0227}, // bathroom sink
            {01232, 0793}, // water cooler
            {01234, 0273}, // portable toilet
            {01241, 0253}, // DIY workbench
            {01243, 0810}, // flashy-flower sign
            {01263, 0325}, // pear wardrobe
            {01288, 0072}, // fan palm
            {01308, 0274}, // school chair
            {01319, 0240}, // microscope
            {01328, 0275}, // school desk
            {01330, 0608}, // basic teacher's desk
            {01348, 0174}, // hamster cage
            {01411, 0223}, // globe
            {01412, 0807}, // TV camera
            {01432, 0124}, // lantern
            {01434, 0263}, // sleeping bag
            {01449, 0747}, // cello
            {01495, 0268}, // dolly
            {01499, 0285}, // Papa bear
            {01500, 0287}, // Mama bear
            {01501, 0286}, // Baby bear
            {01504, 0869}, // giant teddy bear
            {01507, 0575}, // teacup ride
            {01509, 0574}, // robot hero
            {01557, 0084}, // wooden-block bed
            {01558, 0105}, // wooden-block bookshelf
            {01559, 0106}, // wooden-block bench
            {01561, 0107}, // wooden-block chest
            {01565, 0108}, // wooden-block table
            {01567, 0090}, // oil barrel
            {01598, 0175}, // exercise ball
            {01606, 0490}, // serving cart
            {01620, 0180}, // hammock
            {01621, 0185}, // lawn chair
            {01624, 0189}, // garden gnome
            {01625, 0305}, // iron garden bench
            {01626, 0303}, // iron garden chair
            {01627, 0304}, // iron garden table
            {01628, 0269}, // garden lantern
            {01631, 0314}, // garden faucet
            {01632, 0250}, // golf bag
            {01644, 0096}, // rock guitar
            {01645, 0682}, // electric guitar
            {01652, 0381}, // matryoshka
            {01708, 0218}, // cassette player
            {01744, 0544}, // wall clock
            {01750, 0710}, // document stack
            {01753, 0311}, // aroma pot
            {01757, 0193}, // claw-foot tub
            {01759, 0357}, // stack of books
            {01778, 0130}, // clothesline pole
            {01779, 0342}, // table with cloth
            {01783, 0249}, // corkboard
            {01792, 0284}, // cushion
            {01797, 0202}, // decoy duck
            {01799, 0313}, // doghouse
            {01802, 0259}, // drink machine
            {01803, 0089}, // drum set
            {01804, 0724}, // electric bass
            {01816, 0731}, // changing room
            {01823, 0248}, // trash bags
            {01829, 0494}, // cypress plant
            {01836, 0272}, // humidifier
            {01838, 0501}, // ironing set
            {01840, 0532}, // whirlpool bath
            {01845, 0239}, // simple kettle
            {01849, 0246}, // kotatsu
            {01850, 0083}, // laptop
            {01851, 0087}, // rocket lamp
            {01852, 0145}, // box sofa
            {01853, 0146}, // box corner sofa
            {01861, 0353}, // stacked magazines
            {01866, 0167}, // menu chalkboard
            {01868, 0266}, // desk mirror
            {01870, 0153}, // mug
            {01875, 0103}, // grand piano
            {01881, 0149}, // plastic canister
            {01888, 0098}, // rice cooker
            {01889, 0132}, // ring
            {01892, 0230}, // hourglass
            {01899, 0257}, // autograph cards
            {01913, 0135}, // wooden chair
            {01929, 0099}, // toilet
            {02010, 0143}, // ball
            {02012, 0244}, // chalkboard
            {02013, 0406}, // lecture-hall bench
            {02014, 0404}, // lecture-hall desk
            {02020, 0358}, // director's chair
            {02099, 0827}, // shovel
            {02319, 0805}, // drinking fountain
            {02326, 0599}, // water pump
            {02329, 0206}, // tire toy
            {02333, 0736}, // solar panel
            {02335, 0201}, // lighthouse
            {02352, 0875}, // parabolic antenna
            {02377, 0826}, // fishing rod
            {02379, 0653}, // watering can
            {02553, 0196}, // iron frame
            {02554, 0138}, // double sofa
            {02558, 0109}, // wooden-block chair
            {02559, 0867}, // pot
            {02560, 0095}, // wooden chest
            {02561, 0882}, // floor lamp
            {02562, 0864}, // candle
            {02586, 0431}, // natural garden chair
            {02596, 0625}, // juicy-apple TV
            {02605, 0076}, // wooden simple bed
            {02614, 0151}, // mountain bike
            {02713, 0121}, // refrigerator
            {02731, 0078}, // digital alarm clock
            {02736, 0123}, // retro fan
            {02740, 0115}, // automatic washer
            {02770, 0222}, // chessboard
            {02771, 0155}, // round space heater
            {02772, 0604}, // fancy violin
            {02776, 0220}, // tankless toilet
            {02822, 0856}, // slingshot
            {03064, 0282}, // cooler box
            {03078, 0097}, // tourist telescope
            {03122, 0161}, // mini DIY workbench
            {03191, 0298}, // ironwood table
            {03193, 0296}, // ironwood chair
            {03194, 0301}, // ironwood low table
            {03195, 0302}, // ironwood cart
            {03196, 0297}, // ironwood dresser
            {03200, 0299}, // ironwood bed
            {03205, 0111}, // wooden-block stereo
            {03206, 0112}, // wooden-block toy
            {03208, 0113}, // wooden-block wall clock
            {03229, 0131}, // clothesline
            {03230, 0139}, // futon
            {03251, 0629}, // gas range
            {03252, 0101}, // LCD TV (50 in.)
            {03270, 0293}, // ironwood kitchenette
            {03271, 0292}, // ironwood cupboard
            {03275, 0294}, // ironwood clock
            {03282, 0147}, // pop-up toaster
            {03305, 0154}, // baby chair
            {03307, 0205}, // digital scale
            {03333, 0100}, // LCD TV (20 in.)
            {03340, 0256}, // deer decoration
            {03345, 0851}, // lifeguard chair
            {03346, 0173}, // public bench
            {03348, 0186}, // plastic pool
            {03396, 0441}, // natural garden table
            {03400, 0610}, // dish-drying rack
            {03406, 0524}, // beekeeper's hive
            {03407, 0192}, // katana
            {03416, 0204}, // soft-serve lamp
            {03428, 0104}, // wall-mounted TV (50 in.)
            {03430, 0605}, // playground gym
            {03431, 0403}, // wall fan
            {03436, 0168}, // wooden wardrobe
            {03438, 0169}, // wooden end table
            {03439, 0128}, // wooden table
            {03442, 0252}, // sturdy sewing box
            {03443, 0203}, // sewing project
            {03444, 0234}, // wheelchair
            {03445, 0271}, // standard umbrella stand
            {03446, 0126}, // western-style stone
            {03449, 0134}, // wooden stool
            {03467, 0226}, // tea set
            {03468, 0181}, // beach towel
            {03471, 0609}, // light switch
            {03490, 0114}, // wooden waste bin
            {03497, 0347}, // frozen table
            {03498, 0346}, // frozen partition
            {03499, 0343}, // frozen arch
            {03500, 0345}, // frozen pillar
            {03501, 0352}, // frozen sculpture
            {03502, 0344}, // frozen bed
            {03503, 0351}, // frozen chair
            {03504, 0348}, // frozen tree
            {03505, 0350}, // frozen counter
            {03509, 0300}, // garden bench
            {03551, 0211}, // bamboo shelf
            {03553, 0213}, // bamboo partition
            {03554, 0209}, // bamboo candleholder
            {03556, 0210}, // bamboo stopblock
            {03557, 0215}, // bamboo floor lamp
            {03558, 0208}, // bamboo wall decoration
            {03559, 0291}, // iron wall lamp
            {03560, 0308}, // iron worktable
            {03561, 0307}, // iron hanger stand
            {03562, 0290}, // iron wall rack
            {03563, 0306}, // iron shelf
            {03581, 0188}, // fish-drying rack
            {03582, 0150}, // book
            {03583, 0207}, // fishing-boat flag
            {03584, 0270}, // study poster
            {03586, 0254}, // magazine
            {03587, 0362}, // fishing-rod stand
            {03588, 0160}, // signpost
            {03590, 0195}, // desktop computer
            {03591, 0363}, // birthday candles
            {03592, 0364}, // birthday cake
            {03593, 0365}, // birthday table
            {03594, 0366}, // birthday sign
            {03595, 0241}, // park clock
            {03596, 0367}, // pool
            {03616, 0318}, // system kitchen
            {03617, 0324}, // stall
            {03618, 0321}, // cutting board
            {03619, 0529}, // soup kettle
            {03621, 0323}, // loft bed with desk
            {03622, 0322}, // floor seat
            {03623, 0320}, // toy box
            {03624, 0398}, // cute bed
            {03658, 0326}, // bamboo basket
            {03672, 0327}, // cardboard box
            {03675, 0329}, // hay bed
            {03681, 0397}, // piano bench
            {03683, 0400}, // plain sink
            {03692, 0356}, // plain wooden shop sign
            {03697, 0334}, // portable radio
            {03699, 0335}, // fish print
            {03701, 0337}, // study desk
            {03702, 0336}, // study chair
            {03773, 0375}, // terrarium
            {03775, 0376}, // hanging terrarium
            {03776, 0377}, // brick well
            {03783, 0380}, // den desk
            {03784, 0379}, // den chair
            {03785, 0378}, // potted ivy
            {03805, 0389}, // mush parasol
            {03806, 0387}, // mush partition
            {03808, 0385}, // mush log
            {03816, 0391}, // streetlamp
            {03818, 0392}, // pennant
            {03819, 0393}, // oil-barrel bathtub
            {03820, 0394}, // fan
            {03821, 0395}, // air circulator
            {03822, 0405}, // pro tape recorder
            {03943, 0432}, // ironwood DIY workbench
            {03946, 0433}, // outdoor table
            {03947, 0434}, // outdoor bench
            {03948, 0446}, // accessories stand
            {03949, 0493}, // anthurium plant
            {03950, 0478}, // antique chair
            {03951, 0479}, // antique console table
            {03952, 0480}, // antique table
            {03953, 0481}, // antique phone
            {03954, 0482}, // antique clock
            {03955, 0483}, // antique vanity
            {03956, 0484}, // antique bureau
            {03957, 0485}, // antique bed
            {03958, 0486}, // antique mini table
            {03959, 0487}, // antique wardrobe
            {03960, 0492}, // handy water cooler
            {03961, 0455}, // fortune-telling set
            {03962, 0472}, // inflatable sofa
            {03965, 0444}, // painting set
            {03966, 0452}, // big festive tree
            {03967, 0461}, // broom and dustpan
            {03970, 0564}, // imperial decorative shelves
            {03971, 0565}, // imperial partition
            {03972, 0566}, // imperial chest
            {03973, 0567}, // imperial bed
            {03974, 0568}, // imperial low table
            {03975, 0618}, // orange end table
            {03976, 0617}, // orange wall-mounted clock
            {03977, 0577}, // shell arch
            {03978, 0578}, // shell partition
            {03979, 0579}, // shell stool
            {03980, 0580}, // shell table
            {03982, 0582}, // shell fountain
            {03983, 0583}, // shell bed
            {03984, 0584}, // shell lamp
            {03986, 0602}, // wall-mounted TV (20 in.)
            {03987, 0435}, // wall-mounted phone
            {03991, 0451}, // festive tree
            {03992, 0460}, // key holder
            {03993, 0454}, // analog kitchen scale
            {03995, 0422}, // cute DIY table
            {03996, 0423}, // cute wall-mounted clock
            {03997, 0424}, // cute wardrobe
            {03998, 0425}, // cute sofa
            {03999, 0426}, // cute chair
            {04000, 0427}, // cute tea table
            {04001, 0428}, // cute vanity
            {04002, 0429}, // cute floor lamp
            {04003, 0430}, // cute music player
            {04006, 0457}, // climbing wall
            {04009, 0436}, // cordless phone
            {04011, 0619}, // cherry speakers
            {04012, 0620}, // cherry lamp
            {04013, 0467}, // punching bag
            {04014, 0465}, // folding floor lamp
            {04015, 0613}, // shower booth
            {04017, 0512}, // shower set
            {04019, 0558}, // stand mixer
            {04023, 0525}, // pants press
            {04025, 0448}, // unglazed dish set
            {04027, 0440}, // floral swag
            {04029, 0489}, // rotary phone
            {04030, 0445}, // bathroom towel rack
            {04033, 0627}, // traditional tea set
            {04034, 0442}, // scattered papers
            {04035, 0546}, // log garden lounge
            {04036, 0547}, // log decorative shelves
            {04037, 0548}, // log wall-mounted clock
            {04038, 0549}, // log stool
            {04039, 0550}, // log chair
            {04040, 0551}, // log dining table
            {04041, 0552}, // log bed
            {04042, 0553}, // log bench
            {04043, 0554}, // log round table
            {04044, 0555}, // log extra-long sofa
            {04045, 0503}, // rattan waste bin
            {04046, 0505}, // rattan end table
            {04047, 0506}, // rattan stool
            {04048, 0508}, // rattan towel basket
            {04049, 0504}, // rattan wardrobe
            {04050, 0509}, // rattan table lamp
            {04051, 0510}, // rattan vanity
            {04052, 0470}, // rattan bed
            {04053, 0507}, // rattan armchair
            {04054, 0511}, // rattan low table
            {04066, 0415}, // illuminated tree
            {04067, 0453}, // tabletop festive tree
            {04068, 0420}, // table setting
            {04069, 0585}, // table lamp
            {04070, 0626}, // street organ
            {04071, 0616}, // electronics kit
            {04072, 0603}, // toilet-cleaning set
            {04073, 0475}, // classic pitcher
            {04074, 0416}, // illuminated reindeer
            {04075, 0469}, // gong
            {04076, 0462}, // nail-art set
            {04077, 0596}, // party garland
            {04078, 0500}, // barbell
            {04080, 0499}, // long bathtub
            {04081, 0468}, // camping cot
            {04083, 1155}, // spooky arch
            {04084, 1156}, // spooky scarecrow
            {04086, 1157}, // spooky tower
            {04087, 1190}, // spooky carriage
            {04088, 1191}, // spooky lantern
            {04089, 1192}, // spooky chair
            {04090, 1193}, // spooky table
            {04092, 1194}, // spooky lantern set
            {04093, 0612}, // bamboo drum
            {04094, 0474}, // floating-biotope planter
            {04099, 0419}, // formal paper
            {04101, 0437}, // fax machine
            {04102, 0576}, // poolside bed
            {04104, 0513}, // frying pan
            {04108, 0417}, // illuminated present
            {04109, 0561}, // double-door refrigerator
            {04110, 0556}, // essay set
            {04111, 0488}, // old-fashioned alarm clock
            {04113, 0471}, // hose reel
            {04114, 0562}, // tissue box
            {04116, 0414}, // whiteboard
            {04118, 0655}, // magnetic knife rack
            {04119, 0458}, // macrame tapestry
            {04122, 0601}, // cartoonist's set
            {04124, 0644}, // wooden fish
            {04125, 0531}, // wooden bookshelf
            {04127, 0622}, // peach chair
            {04128, 0623}, // peach surprise box
            {04129, 0497}, // monstera
            {04131, 0418}, // illuminated snowflakes
            {04132, 0498}, // yucca
            {04133, 0545}, // double-sided wall clock
            {04134, 0624}, // apple chair
            {04135, 0443}, // freezer
            {04137, 0515}, // diner chair
            {04138, 0516}, // diner counter chair
            {04139, 0517}, // diner counter table
            {04140, 0518}, // retro gas pump
            {04141, 0519}, // diner sofa
            {04142, 0520}, // diner dining table
            {04143, 0521}, // diner neon sign
            {04144, 0522}, // diner neon clock
            {04226, 0630}, // basketball hoop
            {04230, 0421}, // glass holder with candle
            {04279, 0438}, // frozen-treat set
            {04308, 0611}, // unfinished puzzle
            {04309, 0708}, // destinations signpost
            {04338, 0466}, // portable record player
            {04377, 0850}, // ornament wreath
            {04379, 0477}, // springy ride-on
            {04392, 0491}, // magic kit
            {04412, 0502}, // cotton-candy stall
            {04441, 0523}, // diner mini table
            {04445, 0528}, // vintage TV tray
            {04546, 0530}, // pear bed
            {04572, 0543}, // shaded floor lamp
            {04687, 0563}, // toolbox
            {04708, 0569}, // mush low stool
            {04719, 0571}, // celebratory candles
            {04722, 0573}, // monster statue
            {04738, 0845}, // skull doorplate
            {04751, 0842}, // bone doorplate
            {04752, 0849}, // iron doorplate
            {04753, 0593}, // throwback wrestling figure
            {04754, 0586}, // throwback gothic mirror
            {04756, 0589}, // throwback wall clock
            {04757, 0588}, // throwback skull radio
            {04758, 0591}, // throwback mitt chair
            {04759, 0587}, // throwback race-car bed
            {04760, 0594}, // throwback hat table
            {04761, 0595}, // throwback rocket
            {04762, 0592}, // throwback container
            {04764, 0848}, // fish doorplate
            {05150, 0598}, // shell speaker
            {05165, 0600}, // wall-mounted candle
            {05309, 0843}, // heart doorplate
            {05310, 0841}, // spider doorplate
            {05337, 0606}, // three-tiered snowperson
            {05338, 0607}, // simple panel
            {05397, 0784}, // 
            {05543, 0628}, // wooden-block stool
            {05635, 0643}, // tiny library
            {05636, 0642}, // wooden-plank sign
            {05716, 0844}, // paw-print doorplate
            {05717, 0846}, // crest doorplate
            {05718, 0840}, // timber doorplate
            {05719, 0847}, // fossil doorplate
            {05784, 0825}, // net
            {05931, 0647}, // jail bars
            {05972, 0791}, // wild log bench
            {05973, 0790}, // log stakes
            {05976, 0648}, // bamboo sphere
            {05978, 0650}, // bamboo lunch box
            {06075, 0700}, // tree's bounty mobile
            {06078, 0701}, // tree's bounty lamp
            {06079, 0698}, // tree's bounty little tree
            {06080, 0697}, // tree's bounty big tree
            {06081, 0699}, // tree's bounty arch
            {06426, 0652}, // Cyrano's photo
            {06427, 0652}, // Curt's photo
            {06428, 0652}, // Zell's photo
            {06429, 0652}, // Bruce's photo
            {06430, 0652}, // Deirdre's photo
            {06431, 0652}, // Lopez's photo
            {06432, 0652}, // Fuchsia's photo
            {06433, 0652}, // Beau's photo
            {06434, 0652}, // Diana's photo
            {06435, 0652}, // Erik's photo
            {06436, 0652}, // Goldie's photo
            {06437, 0652}, // Butch's photo
            {06438, 0652}, // Chow's photo
            {06439, 0652}, // Lucky's photo
            {06440, 0652}, // Biskit's photo
            {06441, 0652}, // Bones's photo
            {06442, 0652}, // Portia's photo
            {06443, 0652}, // Walker's photo
            {06444, 0652}, // Daisy's photo
            {06445, 0652}, // Cookie's photo
            {06446, 0652}, // Maddie's photo
            {06447, 0652}, // Bea's photo
            {06448, 0652}, // Mac's photo
            {06449, 0652}, // Nate's photo
            {06450, 0652}, // Marcel's photo
            {06451, 0652}, // Benjamin's photo
            {06452, 0652}, // Cherry's photo
            {06453, 0652}, // Shep's photo
            {06454, 0652}, // Bill's photo
            {06455, 0652}, // Joey's photo
            {06456, 0652}, // Pate's photo
            {06457, 0652}, // Maelle's photo
            {06458, 0652}, // Deena's photo
            {06459, 0652}, // Pompom's photo
            {06460, 0652}, // Groucho's photo
            {06461, 0652}, // Mallary's photo
            {06462, 0652}, // Freckles's photo
            {06463, 0652}, // Derwin's photo
            {06464, 0652}, // Drake's photo
            {06465, 0652}, // Scoot's photo
            {06466, 0652}, // Weber's photo
            {06467, 0652}, // Miranda's photo
            {06468, 0652}, // Ketchup's photo
            {06469, 0652}, // Gloria's photo
            {06470, 0652}, // Molly's photo
            {06471, 0652}, // Tutu's photo
            {06472, 0652}, // Quillson's photo
            {06473, 0652}, // Opal's photo
            {06474, 0652}, // Dizzy's photo
            {06475, 0652}, // Big Top's photo
            {06476, 0652}, // Eloise's photo
            {06477, 0652}, // Margie's photo
            {06478, 0652}, // Paolo's photo
            {06479, 0652}, // Axel's photo
            {06480, 0652}, // Ellie's photo
            {06481, 0652}, // Tucker's photo
            {06482, 0652}, // Ursala's photo
            {06483, 0652}, // Tia's photo
            {06484, 0652}, // Lily's photo
            {06485, 0652}, // Ribbot's photo
            {06486, 0652}, // Frobert's photo
            {06487, 0652}, // Camofrog's photo
            {06488, 0652}, // Drift's photo
            {06489, 0652}, // Wart Jr.'s photo
            {06490, 0652}, // Puddles's photo
            {06491, 0652}, // Jeremiah's photo
            {06492, 0652}, // Tad's photo
            {06493, 0652}, // Grizzly's photo
            {06494, 0652}, // Cousteau's photo
            {06495, 0652}, // Huck's photo
            {06496, 0652}, // Prince's photo
            {06497, 0652}, // Jambette's photo
            {06498, 0652}, // Raddle's photo
            {06499, 0652}, // Gigi's photo
            {06500, 0652}, // Croque's photo
            {06501, 0652}, // Diva's photo
            {06502, 0652}, // Henry's photo
            {06503, 0652}, // Chevre's photo
            {06504, 0652}, // Paula's photo
            {06505, 0652}, // Nan's photo
            {06506, 0652}, // Billy's photo
            {06507, 0652}, // Gruff's photo
            {06508, 0652}, // Velma's photo
            {06509, 0652}, // Kidd's photo
            {06510, 0652}, // Pashmina's photo
            {06511, 0652}, // Cesar's photo
            {06512, 0652}, // Peewee's photo
            {06513, 0652}, // Boone's photo
            {06514, 0652}, // Louie's photo
            {06515, 0652}, // Ike's photo
            {06516, 0652}, // Boyd's photo
            {06517, 0652}, // Violet's photo
            {06518, 0652}, // Al's photo
            {06519, 0652}, // Rocket's photo
            {06520, 0652}, // Hans's photo
            {06521, 0652}, // Hamlet's photo
            {06522, 0652}, // Apple's photo
            {06523, 0652}, // Graham's photo
            {06524, 0652}, // Rodney's photo
            {06525, 0652}, // Soleil's photo
            {06526, 0652}, // Charlise's photo
            {06527, 0652}, // Clay's photo
            {06528, 0652}, // Flurry's photo
            {06529, 0652}, // Hamphrey's photo
            {06530, 0652}, // Rocco's photo
            {06531, 0652}, // Bubbles's photo
            {06532, 0652}, // Bertha's photo
            {06533, 0652}, // Biff's photo
            {06534, 0652}, // Bitty's photo
            {06535, 0652}, // Harry's photo
            {06536, 0652}, // Hippeux's photo
            {06537, 0652}, // Antonio's photo
            {06538, 0652}, // Beardo's photo
            {06539, 0652}, // Buck's photo
            {06540, 0652}, // Victoria's photo
            {06541, 0652}, // Savannah's photo
            {06542, 0652}, // Elmer's photo
            {06543, 0652}, // Roscoe's photo
            {06544, 0652}, // Winnie's photo
            {06545, 0652}, // Ed's photo
            {06546, 0652}, // Cleo's photo
            {06547, 0652}, // Peaches's photo
            {06548, 0652}, // Annalise's photo
            {06549, 0652}, // Klaus's photo
            {06550, 0652}, // Clyde's photo
            {06551, 0652}, // Colton's photo
            {06552, 0652}, // Papi's photo
            {06553, 0652}, // Julian's photo
            {06554, 0652}, // Yuka's photo
            {06555, 0652}, // Alice's photo
            {06556, 0652}, // Melba's photo
            {06557, 0652}, // Sydney's photo
            {06558, 0652}, // Gonzo's photo
            {06559, 0652}, // Ozzie's photo
            {06560, 0652}, // Jay's photo
            {06561, 0652}, // Canberra's photo
            {06562, 0652}, // Lyman's photo
            {06563, 0652}, // Eugene's photo
            {06564, 0652}, // Kitt's photo
            {06565, 0652}, // Mathilda's photo
            {06566, 0652}, // Carrie's photo
            {06567, 0652}, // Astrid's photo
            {06568, 0652}, // Sylvia's photo
            {06569, 0652}, // Walt's photo
            {06570, 0652}, // Rooney's photo
            {06571, 0652}, // Robin's photo
            {06572, 0652}, // Marcie's photo
            {06573, 0652}, // Bud's photo
            {06574, 0652}, // Elvis's photo
            {06575, 0652}, // Rex's photo
            {06576, 0652}, // Leopold's photo
            {06577, 0652}, // Mott's photo
            {06578, 0652}, // Rory's photo
            {06579, 0652}, // Lionel's photo
            {06580, 0652}, // Nana's photo
            {06581, 0652}, // Simon's photo
            {06582, 0652}, // Anchovy's photo
            {06583, 0652}, // Tammi's photo
            {06584, 0652}, // Monty's photo
            {06585, 0652}, // Elise's photo
            {06586, 0652}, // Flip's photo
            {06587, 0652}, // Shari's photo
            {06588, 0652}, // Deli's photo
            {06589, 0652}, // Dora's photo
            {06590, 0652}, // Limberg's photo
            {06591, 0652}, // Bella's photo
            {06592, 0652}, // Bree's photo
            {06593, 0652}, // Twiggy's photo
            {06594, 0652}, // Samson's photo
            {06595, 0652}, // Rod's photo
            {06596, 0652}, // Candi's photo
            {06597, 0652}, // Rizzo's photo
            {06598, 0652}, // Anicotti's photo
            {06599, 0652}, // Broccolo's photo
            {06600, 0652}, // Moose's photo
            {06601, 0652}, // Bettina's photo
            {06602, 0652}, // Greta's photo
            {06603, 0652}, // Penelope's photo
            {06604, 0652}, // Jitters's photo
            {06605, 0652}, // Chadder's photo
            {06606, 0652}, // Octavian's photo
            {06607, 0652}, // Marina's photo
            {06608, 0652}, // Zucker's photo
            {06609, 0652}, // Queenie's photo
            {06610, 0652}, // Gladys's photo
            {06611, 0652}, // Sandy's photo
            {06612, 0652}, // Sprocket's photo
            {06613, 0652}, // Julia's photo
            {06614, 0652}, // Cranston's photo
            {06615, 0652}, // Piper's photo
            {06616, 0652}, // Phil's photo
            {06617, 0652}, // Blanche's photo
            {06618, 0652}, // Flora's photo
            {06619, 0652}, // Phoebe's photo
            {06620, 0652}, // Apollo's photo
            {06621, 0652}, // Amelia's photo
            {06622, 0652}, // Pierce's photo
            {06623, 0652}, // Buzz's photo
            {06624, 0652}, // Avery's photo
            {06625, 0652}, // Frank's photo
            {06626, 0652}, // Admiral's photo
            {06627, 0652}, // Sterling's photo
            {06628, 0652}, // Keaton's photo
            {06629, 0652}, // Celia's photo
            {06630, 0652}, // Aurora's photo
            {06631, 0652}, // Roald's photo
            {06632, 0652}, // Cube's photo
            {06633, 0652}, // Hopper's photo
            {06634, 0652}, // Friga's photo
            {06635, 0652}, // Gwen's photo
            {06636, 0652}, // Puck's photo
            {06637, 0652}, // Midge's photo
            {06638, 0652}, // Wade's photo
            {06639, 0652}, // Boomer's photo
            {06640, 0652}, // Iggly's photo
            {06641, 0652}, // Tex's photo
            {06642, 0652}, // Flo's photo
            {06643, 0652}, // Sprinkle's photo
            {06644, 0652}, // Curly's photo
            {06645, 0652}, // Truffles's photo
            {06646, 0652}, // Rasher's photo
            {06647, 0652}, // Hugh's photo
            {06648, 0652}, // Pango's photo
            {06649, 0652}, // Jacob's photo
            {06650, 0652}, // Lucy's photo
            {06651, 0652}, // Spork's photo
            {06652, 0652}, // Cobb's photo
            {06653, 0652}, // Boris's photo
            {06654, 0652}, // Maggie's photo
            {06655, 0652}, // Peggy's photo
            {06656, 0652}, // Gala's photo
            {06657, 0652}, // Chops's photo
            {06658, 0652}, // Kevin's photo
            {06659, 0652}, // Pancetti's photo
            {06660, 0652}, // Lucha's photo
            {06661, 0652}, // Agnes's photo
            {06662, 0652}, // Bunnie's photo
            {06663, 0652}, // Dotty's photo
            {06664, 0652}, // Coco's photo
            {06665, 0652}, // Snake's photo
            {06666, 0652}, // Gaston's photo
            {06667, 0652}, // Gabi's photo
            {06668, 0652}, // Pippy's photo
            {06669, 0652}, // Tiffany's photo
            {06670, 0652}, // Genji's photo
            {06671, 0652}, // Jacques's photo
            {06672, 0652}, // Ruby's photo
            {06673, 0652}, // Doc's photo
            {06674, 0652}, // Claude's photo
            {06675, 0652}, // Francine's photo
            {06676, 0652}, // Chrissy's photo
            {06677, 0652}, // Hopkins's photo
            {06678, 0652}, // O'Hare's photo
            {06679, 0652}, // Carmen's photo
            {06680, 0652}, // Bonbon's photo
            {06681, 0652}, // Cole's photo
            {06682, 0652}, // Peck's photo
            {06683, 0652}, // Mira's photo
            {06684, 0652}, // Tank's photo
            {06685, 0652}, // Rhonda's photo
            {06686, 0652}, // Spike's photo
            {06687, 0652}, // Hornsby's photo
            {06688, 0652}, // Merengue's photo
            {06689, 0652}, // Renée's photo
            {06690, 0652}, // Vesta's photo
            {06691, 0652}, // Baabara's photo
            {06692, 0652}, // Eunice's photo
            {06693, 0652}, // Sparro's photo
            {06694, 0652}, // Stella's photo
            {06695, 0652}, // Cashmere's photo
            {06696, 0652}, // Willow's photo
            {06697, 0652}, // Curlos's photo
            {06698, 0652}, // Wendy's photo
            {06699, 0652}, // Timbra's photo
            {06700, 0652}, // Frita's photo
            {06701, 0652}, // Muffy's photo
            {06702, 0652}, // Pietro's photo
            {06703, 0652}, // Peanut's photo
            {06704, 0652}, // Angus's photo
            {06705, 0652}, // Blaire's photo
            {06706, 0652}, // Filbert's photo
            {06707, 0652}, // Pecan's photo
            {06708, 0652}, // Nibbles's photo
            {06709, 0652}, // Agent S's photo
            {06710, 0652}, // Caroline's photo
            {06711, 0652}, // Sally's photo
            {06712, 0652}, // Static's photo
            {06713, 0652}, // Mint's photo
            {06714, 0652}, // Ricky's photo
            {06715, 0652}, // Rodeo's photo
            {06716, 0652}, // Cally's photo
            {06717, 0652}, // Tasha's photo
            {06718, 0652}, // Sylvana's photo
            {06719, 0652}, // Poppy's photo
            {06720, 0652}, // Sheldon's photo
            {06721, 0652}, // Marshal's photo
            {06722, 0652}, // Hazel's photo
            {06723, 0652}, // Rolf's photo
            {06724, 0652}, // Rowan's photo
            {06725, 0652}, // Tybalt's photo
            {06726, 0652}, // Stu's photo
            {06727, 0652}, // Bangle's photo
            {06728, 0652}, // Leonardo's photo
            {06729, 0652}, // Claudia's photo
            {06730, 0652}, // Bianca's photo
            {06731, 0652}, // Chief's photo
            {06732, 0652}, // Lobo's photo
            {06733, 0652}, // Wolfgang's photo
            {06734, 0652}, // Whitney's photo
            {06735, 0652}, // Dobie's photo
            {06736, 0652}, // Freya's photo
            {06737, 0652}, // T-Bone's photo
            {06738, 0652}, // Fang's photo
            {06739, 0652}, // Vivian's photo
            {06740, 0652}, // Skye's photo
            {06741, 0652}, // Kyle's photo
            {06742, 0652}, // Coach's photo
            {06743, 0652}, // Anabelle's photo
            {06744, 0652}, // Vic's photo
            {06745, 0652}, // Bob's photo
            {06746, 0652}, // Mitzi's photo
            {06747, 0652}, // Rosie's photo
            {06748, 0652}, // Olivia's photo
            {06749, 0652}, // Kiki's photo
            {06750, 0652}, // Tangy's photo
            {06751, 0652}, // Punchy's photo
            {06752, 0652}, // Purrl's photo
            {06753, 0652}, // Moe's photo
            {06754, 0652}, // Snooty's photo
            {06755, 0652}, // Kabuki's photo
            {06756, 0652}, // Kid Cat's photo
            {06757, 0652}, // Monique's photo
            {06758, 0652}, // Tabby's photo
            {06759, 0652}, // Stinky's photo
            {06760, 0652}, // Kitty's photo
            {06761, 0652}, // Tom's photo
            {06762, 0652}, // Merry's photo
            {06763, 0652}, // Felicity's photo
            {06764, 0652}, // Lolly's photo
            {06765, 0652}, // Annalisa's photo
            {06766, 0652}, // Ankha's photo
            {06767, 0652}, // Rudy's photo
            {06768, 0652}, // Katt's photo
            {06769, 0652}, // Bluebear's photo
            {06770, 0652}, // Maple's photo
            {06771, 0652}, // Poncho's photo
            {06772, 0652}, // Pudge's photo
            {06773, 0652}, // Kody's photo
            {06774, 0652}, // Stitches's photo
            {06775, 0652}, // Vladimir's photo
            {06776, 0652}, // Olaf's photo
            {06777, 0652}, // Murphy's photo
            {06778, 0652}, // Olive's photo
            {06779, 0652}, // Cheri's photo
            {06780, 0652}, // June's photo
            {06781, 0652}, // Pekoe's photo
            {06782, 0652}, // Chester's photo
            {06783, 0652}, // Barold's photo
            {06784, 0652}, // Tammy's photo
            {06785, 0652}, // Goose's photo
            {06786, 0652}, // Benedict's photo
            {06787, 0652}, // Teddy's photo
            {06788, 0652}, // Egbert's photo
            {06789, 0652}, // Ava's photo
            {06790, 0652}, // Becky's photo
            {06791, 0652}, // Plucky's photo
            {06792, 0652}, // Knox's photo
            {06793, 0652}, // Broffina's photo
            {06794, 0652}, // Ken's photo
            {06795, 0652}, // Patty's photo
            {06796, 0652}, // Tipper's photo
            {06797, 0652}, // Norma's photo
            {06798, 0652}, // Pinky's photo
            {06799, 0652}, // Naomi's photo
            {06800, 0652}, // Alfonso's photo
            {06801, 0652}, // Alli's photo
            {06802, 0652}, // Boots's photo
            {06803, 0652}, // Del's photo
            {06804, 0652}, // Sly's photo
            {06805, 0652}, // Gayle's photo
            {06806, 0652}, // Drago's photo
            {06807, 0652}, // Fauna's photo
            {06808, 0652}, // Bam's photo
            {06818, 0800}, // ornament mobile
            {06826, 0654}, // nova light
            {06827, 0725}, // starry garland
            {06829, 0757}, // crescent-moon chair
            {06831, 0657}, // blossom-viewing lantern
            {06832, 0656}, // cherry-blossom clock
            {06992, 0652}, // Reneigh's photo
            {06993, 0652}, // Judy's photo
            {06994, 0652}, // Audie's photo
            {06995, 0652}, // Megan's photo
            {06996, 0652}, // Raymond's photo
            {06997, 0652}, // Cyd's photo
            {07045, 0748}, // recycled-can thumb piano
            {07047, 0659}, // zen cushion
            {07048, 0658}, // pile of zen cushions
            {07132, 0664}, // wooden double bed
            {07133, 0661}, // wooden mini table
            {07134, 0662}, // wooden low table
            {07135, 0674}, // floor light
            {07136, 0675}, // cat grass
            {07137, 0663}, // wooden full-length mirror
            {07138, 0666}, // Mom's tea cozy
            {07139, 0673}, // Mom's art
            {07140, 0665}, // Mom's tissue box
            {07141, 0667}, // Mom's pen stand
            {07143, 0671}, // Mom's candle set
            {07144, 0670}, // Mom's cushion
            {07145, 0668}, // Mom's embroidery
            {07146, 0672}, // Mom's homemade cake
            {07147, 0669}, // Mom's plushie
            {07148, 0676}, // life ring
            {07150, 0750}, // blue corner
            {07151, 0876}, // red corner
            {07152, 0877}, // neutral corner
            {07153, 0744}, // cypress bathtub
            {07159, 0813}, // cardboard sofa
            {07160, 0814}, // cardboard table
            {07161, 0815}, // cardboard bed
            {07163, 0816}, // cardboard chair
            {07189, 0680}, // studio spotlight
            {07190, 0681}, // studio wall spotlight
            {07212, 0652}, // Sherb's photo
            {07213, 0652}, // Dom's photo
            {07229, 0684}, // handcart
            {07230, 0692}, // cosmos shower
            {07231, 0691}, // tulip surprise box
            {07232, 0690}, // mum cushion
            {07233, 0689}, // windflower fan
            {07234, 0688}, // hyacinth lamp
            {07235, 0687}, // rose bed
            {07236, 0686}, // lily record player
            {07237, 0685}, // pansy table
            {07238, 0735}, // anchor statue
            {07247, 0694}, // silo
            {07253, 0696}, // star clock
            {07257, 0702}, // pedal board
            {07258, 0703}, // modeling clay
            {07259, 0896}, // palm-tree lamp
            {07260, 0705}, // floor sign
            {07264, 0707}, // champion's pennant
            {07280, 0713}, // gears
            {07281, 0714}, // sleigh
            {07282, 0715}, // hanging scroll
            {07284, 0711}, // nutcracker
            {07317, 0717}, // zen-style stone
            {07379, 0728}, // wind turbine
            {07390, 0782}, // leaf stool
            {07391, 0721}, // tatami bed
            {07392, 0722}, // candy machine
            {07393, 0727}, // pond stone
            {07453, 0767}, // aluminum briefcase
            {07454, 0766}, // wooden toolbox
            {07525, 0773}, // tool shelf
            {07526, 0817}, // outdoor generator
            {07527, 0808}, // flower stand
            {07528, 0809}, // tool cart
            {07529, 0799}, // folding chair
            {07531, 0745}, // ironing board
            {07535, 0746}, // kettlebell
            {07588, 0885}, // mushroom wand
            {07599, 0752}, // board game
            {07653, 0755}, // speed bag
            {07654, 0756}, // electric kick scooter
            {07681, 0762}, // loom
            {07682, 0763}, // kimono stand
            {07788, 0819}, // leaf campfire
            {07789, 0811}, // drying rack
            {07795, 0838}, // stone lion-dog
            {07796, 0774}, // imperial dining table
            {07797, 0775}, // imperial dining chair
            {07800, 0777}, // protein shaker bottle
            {07801, 0778}, // pet food bowl
            {07802, 0779}, // pet bed
            {07803, 0776}, // kitty litter box
            {07804, 0780}, // knife block
            {07805, 0873}, // butter churn
            {07845, 0785}, // pull-up-bar stand
            {07865, 0787}, // elaborate kimono stand
            {07867, 0789}, // angled signpost
            {07868, 0824}, // surfboard
            {08031, 0874}, // fountain
            {08096, 0812}, // record box
            {08176, 0829}, // star net
            {08177, 0828}, // colorful net
            {08178, 0801}, // outdoorsy net
            {08297, 0837}, // stovetop espresso maker
            {08298, 0804}, // bunk bed
            {08415, 0830}, // imperial dining lantern
            {08417, 0823}, // wall-mounted tool board
            {08418, 0822}, // fragrance diffuser
            {08419, 0821}, // garden wagon
            {08471, 0836}, // fish fishing rod
            {08472, 0835}, // colorful fishing rod
            {08473, 0833}, // outdoorsy fishing rod
            {08534, 0860}, // colorful watering can
            {08535, 0878}, // elephant watering can
            {08536, 0861}, // outdoorsy watering can
            {08575, 0863}, // outdoorsy shovel
            {08576, 0870}, // printed-design shovel
            {08577, 0862}, // colorful shovel
            {08579, 0857}, // outdoorsy slingshot
            {08580, 0858}, // colorful slingshot
            {08760, 0831}, // customizable phone case kit
            {08826, 0832}, // wooden table mirror
            {09502, 0852}, // clothes closet
            {09565, 0853}, // mobile
            {09568, 0854}, // construction sign
            {09584, 0859}, // beach ball
            {09619, 0868}, // utility pole
            {09642, 0866}, // iron closet
            {09766, 0871}, // mini fridge
            {09767, 0872}, // garbage bin
            {10244, 0880}, // fragrance sticks
            {10742, 0883}, // bamboo stool
            {10743, 0884}, // bamboo speaker
            {11115, 0652}, // Rilla's photo
            {11116, 0652}, // Marty's photo
            {11117, 0652}, // Étoile's photo
            {11118, 0652}, // Chai's photo
            {11119, 0652}, // Chelsea's photo
            {11120, 0652}, // Toby's photo
            {11941, 0889}, // stone arch
            {11942, 0897}, // street piano
            {11943, 0890}, // stone tablet
            {12140, 0891}, // DAL model plane
            {12207, 0895}, // arcade seat
            {12332, 0901}, // natural square table
            {12372, 0921}, // Pocket modern camper
            {12373, 0920}, // Pocket vintage camper
            {12401, 0923}, // wedding bench
            {12402, 0922}, // wedding arch
            {12403, 0926}, // wedding cake
            {12404, 0932}, // wedding head table
            {12405, 0928}, // wedding chair
            {12406, 0929}, // wedding table
            {12407, 0931}, // wedding decoration
            {12408, 0925}, // wedding candle set
            {12409, 0930}, // wedding pipe organ
            {12410, 0924}, // wedding welcome board
            {12411, 0927}, // wedding flower stand
            {12543, 0934}, // Nintendo Switch
            {12741, 1012}, // world map
            {12949, 1168}, // spooky standing lamp
            {12951, 1195}, // spooky candy set
            {13222, 1153}, // spooky garland
            {13223, 1154}, // spooky table setting
            {13242, 1211}, // RC helicopter
            {13243, 1198}, // puppy plushie
            {13244, 1209}, // gift pile
            {13245, 1207}, // Yule log
            {13246, 1204}, // pop-up book
            {13247, 1208}, // tin robot
            {13249, 1201}, // kids' tent
            {13250, 1210}, // mini circuit
            {13251, 1200}, // dinosaur toy
            {13252, 1205}, // dollhouse
            {13352, 1157}, // spooky tower
            {13447, 1295}, // Turkey Day garden stand
            {13448, 1296}, // Turkey Day hearth
            {13449, 1293}, // Turkey Day decorations
            {13450, 1292}, // Turkey Day chair
            {13453, 1297}, // Turkey Day table
            {13488, 1516}, // chocolate heart
            {13767, 1495}, // Festivale garland
            {13770, 1500}, // Festivale parasol
            {13772, 1501}, // Festivale balloon lamp
            {13773, 1504}, // Festivale stall
            {13774, 1498}, // Festivale drum
            {13775, 1497}, // Festivale stage
            {13776, 1496}, // Festivale confetti machine
            {13777, 1505}, // Festivale lamp
            {13778, 1506}, // Festivale flag
            {13818, 1509}, // Turkey Day casserole
            {13819, 1510}, // Turkey Day wheat decor
            {13820, 1508}, // Turkey Day table setting
            {13829, 1511}, // Shell
            {13831, 1522}, // large Mushroom Platform
            {13832, 1523}, // small Mushroom Platform
            {13862, 0652}, // Jingle's photo
            {13927, 1521}, // Nintendo Switch Lite
            {13930, 1524}, // set of stockings
            {14029, 1546}, // heart-shaped bouquet
            {14254, 0652}, // Tom Nook's photo
            {14255, 0652}, // Timmy and Tommy's photo
            {14256, 0652}, // Isabelle's photo
            {14340, 1615}, // whoopee cushion
            {14472, 0652}, // Rover's photo
            {14475, 1642}, // nuptial doorplate
            {14476, 1640}, // nuptial bell
            {14477, 1641}, // nuptial ring pillow
        };
    }
}
