using System.Collections.Generic;

namespace NHSE.Core
{
    public static class RecipeList
    {
        public static readonly IReadOnlyDictionary<ushort, ushort> Recipes = new Dictionary<ushort, ushort>
        {
            {0x006, 02596}, // juicy-apple TV
            {0x009, 01263}, // pear wardrobe
            {0x00A, 03068}, // flimsy axe
            {0x00D, 01429}, // campfire
            {0x00E, 01799}, // doghouse
            {0x00F, 01913}, // wooden chair
            {0x010, 00880}, // wooden bucket
            {0x011, 02560}, // wooden chest
            {0x012, 02605}, // wooden simple bed
            {0x013, 03082}, // flimsy shovel
            {0x014, 03083}, // flimsy watering can
            {0x015, 03084}, // flimsy fishing rod
            {0x016, 02376}, // flimsy net
            {0x017, 01559}, // wooden-block bench
            {0x018, 01561}, // wooden-block chest
            {0x01A, 01565}, // wooden-block table
            {0x01D, 02822}, // slingshot
            {0x01E, 01753}, // aroma pot
            {0x020, 00808}, // mush table
            {0x021, 00739}, // tea table
            {0x022, 01430}, // bonfire
            {0x023, 03191}, // ironwood table
            {0x024, 02754}, // simple well
            {0x025, 02559}, // pot
            {0x026, 03206}, // wooden-block toy
            {0x029, 00333}, // birdhouse
            {0x02A, 00331}, // birdbath
            {0x02B, 00088}, // ringtoss
            {0x02C, 00383}, // acoustic guitar
            {0x02D, 00669}, // ukulele
            {0x02E, 00710}, // bamboo bench
            {0x030, 00729}, // garden rock
            {0x031, 00730}, // tall garden rock
            {0x033, 00805}, // mush lamp
            {0x037, 00665}, // wave breaker
            {0x038, 00975}, // fruit basket
            {0x039, 01103}, // rocking chair
            {0x03A, 01157}, // brick oven
            {0x03B, 01170}, // swinging bench
            {0x03C, 01189}, // tire stack
            {0x03D, 01557}, // wooden-block bed
            {0x03E, 01558}, // wooden-block bookshelf
            {0x03F, 01625}, // iron garden bench
            {0x040, 01626}, // iron garden chair
            {0x041, 01627}, // iron garden table
            {0x042, 01823}, // trash bags
            {0x04D, 02319}, // drinking fountain
            {0x04E, 02329}, // tire toy
            {0x04F, 02553}, // iron frame
            {0x050, 02586}, // natural garden chair
            {0x051, 03065}, // gold bars
            {0x052, 03122}, // mini DIY workbench
            {0x053, 03193}, // ironwood chair
            {0x054, 03194}, // ironwood low table
            {0x055, 03195}, // ironwood cart
            {0x056, 03196}, // ironwood dresser
            {0x057, 03200}, // ironwood bed
            {0x059, 03205}, // wooden-block stereo
            {0x05A, 03208}, // wooden-block wall clock
            {0x05B, 03270}, // ironwood kitchenette
            {0x05C, 03271}, // ironwood cupboard
            {0x05E, 03275}, // ironwood clock
            {0x063, 03080}, // brick fence
            {0x064, 03402}, // vertical-board fence
            {0x065, 03403}, // bamboo lattice fence
            {0x066, 00083}, // rocking horse
            {0x067, 00343}, // tiki torch
            {0x068, 03398}, // stone stool
            {0x069, 03397}, // stone table
            {0x06B, 02615}, // ladder
            {0x06E, 04044}, // log extra-long sofa
            {0x06F, 04043}, // log round table
            {0x070, 04042}, // log bench
            {0x071, 04035}, // log garden lounge
            {0x072, 04036}, // log decorative shelves
            {0x073, 04037}, // log wall-mounted clock
            {0x074, 04038}, // log stool
            {0x075, 04039}, // log chair
            {0x076, 04040}, // log dining table
            {0x077, 04041}, // log bed
            {0x078, 04025}, // unglazed dish set
            {0x079, 04027}, // floral swag
            {0x07A, 03559}, // iron wall lamp
            {0x07B, 03562}, // iron wall rack
            {0x07C, 03509}, // garden bench
            {0x07D, 03943}, // ironwood DIY workbench
            {0x07E, 03560}, // iron worktable
            {0x080, 03563}, // iron shelf
            {0x082, 03772}, // golden candlestick
            {0x083, 03810}, // golden dishes
            {0x084, 03774}, // Libra scale
            {0x085, 03473}, // golden seat
            {0x088, 03808}, // mush log
            {0x08A, 03806}, // mush partition
            {0x08B, 03805}, // mush parasol
            {0x08C, 03499}, // frozen arch
            {0x08D, 03501}, // frozen sculpture
            {0x08E, 03503}, // frozen chair
            {0x08F, 03505}, // frozen counter
            {0x091, 03504}, // frozen tree
            {0x092, 03497}, // frozen table
            {0x093, 03498}, // frozen partition
            {0x094, 03500}, // frozen pillar
            {0x095, 03502}, // frozen bed
            {0x097, 03558}, // bamboo wall decoration
            {0x098, 03658}, // bamboo basket
            {0x099, 03554}, // bamboo candleholder
            {0x09A, 03556}, // bamboo stopblock
            {0x09B, 03551}, // bamboo shelf
            {0x09D, 03553}, // bamboo partition
            {0x09E, 03555}, // bamboo doll
            {0x09F, 03557}, // bamboo floor lamp
            {0x0A0, 02558}, // wooden-block chair
            {0x0A1, 04011}, // cherry speakers
            {0x0A2, 04012}, // cherry lamp
            {0x0A3, 03684}, // coconut juice
            {0x0A4, 00080}, // clackercart
            {0x0A5, 01266}, // barrel
            {0x0A6, 03692}, // plain wooden shop sign
            {0x0A7, 03675}, // hay bed
            {0x0A8, 03449}, // wooden stool
            {0x0A9, 03445}, // standard umbrella stand
            {0x0AA, 03438}, // wooden end table
            {0x0AB, 00682}, // boomerang
            {0x0AC, 03436}, // wooden wardrobe
            {0x0AD, 03490}, // wooden waste bin
            {0x0AE, 03683}, // plain sink
            {0x0AF, 03977}, // shell arch
            {0x0B0, 03978}, // shell partition
            {0x0B1, 03979}, // shell stool
            {0x0B2, 03980}, // shell table
            {0x0B4, 03982}, // shell fountain
            {0x0B5, 03983}, // shell bed
            {0x0B6, 03984}, // shell lamp
            {0x0B7, 04703}, // vaulting pole
            {0x0B8, 03976}, // orange wall-mounted clock
            {0x0B9, 03975}, // orange end table
            {0x0BA, 04546}, // pear bed
            {0x0BB, 04127}, // peach chair
            {0x0BC, 04128}, // peach surprise box
            {0x0BD, 04134}, // apple chair
            {0x0BE, 00132}, // succulent plant
            {0x0BF, 04549}, // fish bait
            {0x0C0, 04073}, // classic pitcher
            {0x0C1, 04124}, // wooden fish
            {0x0C2, 04279}, // frozen-treat set
            {0x0C3, 04393}, // old-fashioned washtub
            {0x0C4, 01759}, // stack of books
            {0x0C5, 01861}, // stacked magazines
            {0x0C7, 04104}, // frying pan
            {0x0C8, 05150}, // shell speaker
            {0x0C9, 03439}, // wooden table
            {0x0CA, 04090}, // spooky table
            {0x0CB, 04066}, // illuminated tree
            {0x0CC, 03406}, // beekeeper's hive
            {0x0CD, 04083}, // spooky arch
            {0x0CE, 04084}, // spooky scarecrow
            {0x0CF, 04086}, // spooky tower
            {0x0D0, 04087}, // spooky carriage
            {0x0D1, 04088}, // spooky lantern
            {0x0D2, 04089}, // spooky chair
            {0x0D4, 04092}, // spooky lantern set
            {0x0D5, 03588}, // signpost
            {0x0D6, 03785}, // potted ivy
            {0x0D7, 01058}, // music stand
            {0x0D8, 00865}, // birdcage
            {0x0D9, 00722}, // hearth
            {0x0DA, 05320}, // ocarina
            {0x0DB, 04376}, // shell wreath
            {0x0DC, 04708}, // mush low stool
            {0x0DD, 04726}, // mushroom wreath
            {0x0DE, 04375}, // snowflake wreath
            {0x0DF, 04378}, // fruit wreath
            {0x0E0, 03396}, // natural garden table
            {0x0E1, 04727}, // tree branch wreath
            {0x0E2, 04377}, // ornament wreath
            {0x0E3, 04293}, // cosmos wreath
            {0x0E4, 05436}, // windflower wreath
            {0x0E5, 05437}, // rose wreath
            {0x0E6, 05466}, // pansy wreath
            {0x0E7, 05467}, // mum wreath
            {0x0E8, 05468}, // hyacinth wreath
            {0x0E9, 01447}, // flying saucer
            {0x0EA, 01054}, // moon
            {0x0EB, 01439}, // asteroid
            {0x0EC, 01445}, // astronaut suit
            {0x0ED, 05096}, // hyacinth crown (Red)
            {0x0EE, 05097}, // cool hyacinth crown (Blue)
            {0x0EF, 05098}, // purple hyacinth crown (Purple)
            {0x0F0, 05099}, // windflower crown (Colorful)
            {0x0F1, 05100}, // cool windflower crown (Colorful)
            {0x0F2, 05101}, // purple windflower crown (Purple)
            {0x0F3, 05102}, // tulip crown (Colorful)
            {0x0F4, 05103}, // chic tulip crown (Colorful)
            {0x0F5, 05104}, // dark tulip crown (Dark red)
            {0x0F6, 05105}, // pansy crown (Colorful)
            {0x0F7, 05106}, // cool pansy crown (Colorful)
            {0x0F8, 05107}, // purple pansy crown (Purple)
            {0x0F9, 05108}, // cosmos crown (Colorful)
            {0x0FA, 05109}, // lovely cosmos crown (Colorful)
            {0x0FB, 05110}, // dark cosmos crown (Dark red)
            {0x0FC, 05111}, // rose crown (Colorful)
            {0x0FD, 05112}, // cute rose crown (Colorful)
            {0x0FE, 05113}, // chic rose crown (Purple)
            {0x0FF, 05114}, // lily crown (Colorful)
            {0x100, 05115}, // cute lily crown (Colorful)
            {0x101, 05116}, // dark lily crown (Dark red)
            {0x102, 05117}, // mum crown (Colorful)
            {0x103, 05118}, // chic mum crown (Colorful)
            {0x104, 05119}, // simple mum crown (Green)
            {0x105, 04682}, // leaf (Green)
            {0x106, 03472}, // golden toilet
            {0x107, 01241}, // DIY workbench
            {0x108, 02578}, // pitfall seed
            {0x10A, 05212}, // stone fence
            {0x10B, 04357}, // iron fence
            {0x10C, 04350}, // country fence
            {0x10D, 04349}, // corral fence
            {0x10F, 02100}, // axe
            {0x111, 03966}, // big festive tree
            {0x112, 03991}, // festive tree
            {0x115, 00144}, // manhole cover
            {0x116, 05635}, // tiny library
            {0x117, 05636}, // wooden-plank sign
            {0x118, 02379}, // watering can
            {0x119, 02099}, // shovel
            {0x11A, 02377}, // fishing rod
            {0x11B, 05784}, // net
            {0x11C, 03618}, // cutting board
            {0x11D, 05856}, // stone axe
            {0x11E, 05528}, // starry wall
            {0x120, 05516}, // ice flooring
            {0x121, 05253}, // iceberg flooring
            {0x122, 04905}, // autumn wall
            {0x123, 05230}, // Jingle wall
            {0x124, 05510}, // sci-fi wall
            {0x125, 05505}, // ice wall
            {0x126, 05500}, // starry-sky wall
            {0x127, 05498}, // ski-slope wall
            {0x128, 04865}, // honeycomb wall
            {0x12A, 04820}, // gold-screen wall
            {0x12B, 04894}, // golden wall
            {0x12C, 04853}, // bamboo-grove wall
            {0x12D, 05229}, // garbage-heap wall
            {0x12E, 05662}, // iceberg wall
            {0x12F, 04915}, // orange wall
            {0x130, 04916}, // apple wall
            {0x131, 04917}, // pear wall
            {0x132, 04918}, // peach wall
            {0x133, 04919}, // cherry wall
            {0x134, 05164}, // mush wall
            {0x135, 04858}, // wild-wood wall
            {0x136, 04859}, // wooden-mosaic wall
            {0x137, 04860}, // dark wooden-mosaic wall
            {0x138, 04804}, // brown herringbone wall
            {0x139, 04805}, // chocolate herringbone wall
            {0x13A, 04844}, // stacked-wood wall
            {0x13B, 04840}, // cabin wall
            {0x13C, 04838}, // manga-library wall
            {0x13D, 04837}, // classic-library wall
            {0x13E, 05216}, // stone wall
            {0x13F, 04911}, // wooden-knot wall
            {0x140, 04904}, // modern wood wall
            {0x141, 04947}, // sakura-wood wall
            {0x142, 04833}, // bamboo wall
            {0x143, 04855}, // snowflake wall
            {0x144, 04813}, // rustic-stone wall
            {0x145, 04801}, // steel-frame wall
            {0x146, 05457}, // jungle wall
            {0x167, 00677}, // deer scare
            {0x168, 05670}, // tulip wreath
            {0x169, 05751}, // pretty tulip wreath
            {0x16A, 05771}, // dark tulip wreath
            {0x16C, 05337}, // three-tiered snowperson
            {0x16D, 03561}, // iron hanger stand
            {0x16E, 05956}, // Aquarius urn
            {0x16F, 05954}, // Aries rocking chair
            {0x170, 05955}, // Virgo harp
            {0x172, 05957}, // Capricorn ornament
            {0x173, 05959}, // Cancer table
            {0x174, 00891}, // holiday candle
            {0x175, 01442}, // lunar rover
            {0x176, 03689}, // sauna heater
            {0x177, 06030}, // cherry-blossom bonsai
            {0x178, 05958}, // Sagittarius arrow
            {0x179, 05960}, // Gemini closet
            {0x17A, 03340}, // deer decoration
            {0x17B, 01443}, // satellite
            {0x17C, 05962}, // Scorpio lamp
            {0x17D, 01444}, // space shuttle
            {0x17E, 03344}, // steamer-basket set
            {0x17F, 04309}, // destinations signpost
            {0x180, 05961}, // Taurus bathtub
            {0x181, 05977}, // bamboo-shoot lamp
            {0x182, 01440}, // lunar lander
            {0x183, 05543}, // wooden-block stool
            {0x184, 04067}, // tabletop festive tree
            {0x185, 02326}, // water pump
            {0x186, 01797}, // decoy duck
            {0x187, 03773}, // terrarium
            {0x188, 04074}, // illuminated reindeer
            {0x189, 04075}, // gong
            {0x18A, 03819}, // oil-barrel bathtub
            {0x18B, 04078}, // barbell
            {0x18C, 03775}, // hanging terrarium
            {0x18D, 04093}, // bamboo drum
            {0x18E, 05517}, // pan flute
            {0x18F, 05963}, // Pisces lamp
            {0x190, 04107}, // infused-water dispenser
            {0x191, 04108}, // illuminated present
            {0x192, 05970}, // firewood
            {0x193, 01652}, // matryoshka
            {0x194, 04125}, // wooden bookshelf
            {0x195, 04130}, // coconut wall planter
            {0x196, 04131}, // illuminated snowflakes
            {0x197, 05964}, // Leo sculpture
            {0x198, 03776}, // brick well
            {0x199, 01441}, // rocket
            {0x19A, 01111}, // outdoor bath
            {0x19B, 05975}, // traditional balancing toy
            {0x19C, 05973}, // log stakes
            {0x19D, 01032}, // magazine rack
            {0x19E, 06075}, // tree's bounty mobile
            {0x19F, 06078}, // tree's bounty lamp
            {0x1A0, 06079}, // tree's bounty little tree
            {0x1A1, 06080}, // tree's bounty big tree
            {0x1A2, 06032}, // cherry-blossom-petal pile
            {0x1A3, 06031}, // cherry-blossom branches
            {0x1A4, 05976}, // bamboo sphere
            {0x1A5, 05978}, // bamboo lunch box
            {0x1A6, 06033}, // outdoor picnic set
            {0x1A7, 06081}, // tree's bounty arch
            {0x1A8, 05979}, // bamboo noodle slide
            {0x1AA, 06832}, // cherry-blossom clock
            {0x1AB, 06831}, // blossom-viewing lantern
            {0x1AD, 06826}, // nova light
            {0x1AE, 06827}, // starry garland
            {0x1B0, 06829}, // crescent-moon chair
            {0x1B1, 06818}, // ornament mobile
            {0x1B2, 05676}, // crewed spaceship
            {0x1B3, 05931}, // jail bars
            {0x1B4, 05972}, // wild log bench
            {0x1B5, 03992}, // key holder
            {0x1B6, 05641}, // lily wreath
            {0x1B8, 05765}, // chic windflower wreath
            {0x1B9, 05746}, // cool windflower wreath
            {0x1BA, 05768}, // natural mum wreath
            {0x1BB, 05749}, // fancy mum wreath
            {0x1BC, 05764}, // chic cosmos wreath
            {0x1BD, 05745}, // pretty cosmos wreath
            {0x1BE, 05766}, // dark rose wreath
            {0x1BF, 05772}, // blue rose wreath
            {0x1C0, 05747}, // fancy rose wreath
            {0x1C1, 05820}, // gold rose wreath
            {0x1C2, 05767}, // cool pansy wreath
            {0x1C3, 05748}, // snazzy pansy wreath
            {0x1C4, 05769}, // purple hyacinth wreath
            {0x1C5, 05750}, // cool hyacinth wreath
            {0x1C6, 05770}, // dark lily wreath
            {0x1C7, 05677}, // fancy lily wreath
            {0x1C8, 06840}, // leaf umbrella
            {0x1C9, 03229}, // clothesline
            {0x1CA, 07211}, // bridge construction kit
            {0x1CB, 07377}, // blue rose crown (Blue)
            {0x1CC, 07378}, // gold rose crown (Gold)
            {0x1CD, 05166}, // campsite construction kit
            {0x1CE, 01750}, // document stack
            {0x1CF, 04034}, // scattered papers
            {0x1D0, 05719}, // fossil doorplate
            {0x1D1, 05718}, // timber doorplate
            {0x1D2, 05716}, // paw-print doorplate
            {0x1D3, 04751}, // bone doorplate
            {0x1D4, 04752}, // iron doorplate
            {0x1D5, 05717}, // crest doorplate
            {0x1D6, 05515}, // jungle flooring
            {0x1D7, 05223}, // woodland wall
            {0x1D8, 04999}, // honeycomb flooring
            {0x1D9, 04986}, // money flooring
            {0x1DA, 04797}, // basement flooring
            {0x1DB, 05021}, // golden flooring
            {0x1DC, 04990}, // colored-leaves flooring
            {0x1DD, 05270}, // sci-fi flooring
            {0x1DE, 04968}, // lunar surface
            {0x1DF, 07204}, // cherry-blossom flooring
            {0x1E0, 07205}, // cherry-blossom-trees wall
            {0x1E2, 05269}, // galaxy flooring
            {0x1E3, 04989}, // ski-slope flooring
            {0x1E4, 07187}, // forest wall
            {0x1E5, 04964}, // bamboo flooring
            {0x1E6, 05236}, // garbage-heap flooring
            {0x1E7, 04979}, // backyard lawn
            {0x1E8, 07186}, // forest flooring
            {0x1E9, 04960}, // steel flooring
            {0x1EA, 04008}, // kettle bathtub
            {0x1EB, 07134}, // wooden low table
            {0x1EC, 07133}, // wooden mini table
            {0x1ED, 07132}, // wooden double bed
            {0x1EE, 07142}, // simple DIY workbench
            {0x1EF, 07231}, // tulip surprise box
            {0x1F0, 07160}, // cardboard table
            {0x1F1, 07161}, // cardboard bed
            {0x1F2, 07163}, // cardboard chair
            {0x1F4, 07159}, // cardboard sofa
            {0x1F5, 07230}, // cosmos shower
            {0x1F6, 07137}, // wooden full-length mirror
            {0x1F7, 07233}, // windflower fan
            {0x1F8, 07045}, // recycled-can thumb piano
            {0x1F9, 07232}, // mum cushion
            {0x1FA, 07234}, // hyacinth lamp
            {0x1FB, 07235}, // rose bed
            {0x1FC, 07805}, // butter churn
            {0x1FD, 07788}, // leaf campfire
            {0x1FE, 07867}, // angled signpost
            {0x1FF, 07409}, // cherry-blossom pond stone
            {0x200, 07408}, // maple-leaf pond stone
            {0x201, 07393}, // pond stone
            {0x202, 07253}, // star clock
            {0x203, 07236}, // lily record player
            {0x204, 07237}, // pansy table
            {0x206, 03446}, // western-style stone
            {0x207, 07390}, // leaf stool
            {0x208, 07452}, // raccoon figurine
            {0x209, 07048}, // pile of zen cushions
            {0x20B, 02544}, // star wand
            {0x20C, 05083}, // hyacinth wand
            {0x20D, 05084}, // windflower wand
            {0x20E, 05085}, // tulip wand
            {0x20F, 05091}, // pansy wand
            {0x210, 05092}, // cosmos wand
            {0x211, 05093}, // rose wand
            {0x212, 05094}, // lily wand
            {0x213, 05095}, // mums wand
            {0x214, 07584}, // wand
            {0x215, 07585}, // ice wand
            {0x216, 07586}, // shell wand
            {0x217, 07587}, // tree-branch wand
            {0x218, 07588}, // mushroom wand
            {0x219, 07589}, // cherry-blossom wand
            {0x21A, 07590}, // bamboo wand
            {0x21B, 07591}, // golden wand
            {0x21C, 07592}, // iron wand
            {0x21D, 07169}, // maple-leaf umbrella
            {0x21E, 07327}, // apple rug
            {0x21F, 07328}, // cherry rug
            {0x220, 07330}, // orange rug
            {0x221, 07331}, // peach rug
            {0x222, 07332}, // pear rug
            {0x225, 04352}, // rope fence
            {0x226, 04354}, // imperial fence
            {0x228, 04356}, // straw fence
            {0x229, 04358}, // spiky fence
            {0x22B, 05206}, // iron-and-stone fence
            {0x22C, 05207}, // zen fence
            {0x231, 05213}, // barbed-wire fence
            {0x234, 05268}, // underwater flooring
            {0x235, 05030}, // water flooring
            {0x236, 04590}, // gold armor (Gold)
            {0x237, 02777}, // medicine
            {0x238, 07317}, // zen-style stone
            {0x239, 08825}, // golden casket
            {0x23A, 07795}, // stone lion-dog
            {0x23B, 08419}, // garden wagon
            {0x23C, 08826}, // wooden table mirror
            {0x23D, 09642}, // iron closet
            {0x23E, 07258}, // modeling clay
            {0x23F, 07259}, // palm-tree lamp
            {0x240, 07261}, // trophy case
            {0x241, 01504}, // giant teddy bear
            {0x242, 09814}, // lucky gold cat
            {0x243, 07454}, // wooden toolbox
            {0x244, 07281}, // sleigh
            {0x246, 00530}, // grass standee
            {0x247, 00531}, // hedge standee
            {0x248, 00532}, // mountain standee
            {0x249, 00533}, // tree standee
            {0x24A, 01023}, // pile of leaves
            {0x24B, 04269}, // green-leaf pile
            {0x24C, 04270}, // yellow-leaf pile
            {0x24D, 04271}, // red-leaf pile
            {0x24E, 10742}, // bamboo stool
            {0x24F, 10743}, // bamboo speaker
            {0x250, 03802}, // pine bonsai tree
            {0x251, 03580}, // bonsai shelf
            {0x252, 01509}, // robot hero
            {0x253, 11261}, // golden gears
            {0x254, 03617}, // stall
            {0x256, 07247}, // silo
            {0x257, 08031}, // fountain
            {0x258, 07535}, // kettlebell
            {0x259, 05941}, // golden dung beetle
            {0x25A, 11260}, // golden arowana model
            {0x25B, 04333}, // grass skirt (Brown)
            {0x25C, 05291}, // traditional straw coat (Brown)
            {0x25D, 08907}, // green grass skirt (Green)
            {0x25E, 07254}, // straw umbrella hat (Brown)
            {0x25F, 05143}, // bamboo hat (Beige)
            {0x260, 07527}, // flower stand
            {0x261, 03410}, // small cardboard boxes
            {0x262, 03411}, // medium cardboard boxes
            {0x263, 03412}, // large cardboard boxes
            {0x264, 09838}, // cherry dress (Red)
            {0x265, 09873}, // cherry hat (Red)
            {0x266, 09949}, // cherry umbrella
            {0x267, 09837}, // pear dress (Beige)
            {0x268, 09872}, // pear hat (Green)
            {0x269, 09950}, // pear umbrella
            {0x26A, 09839}, // peach dress (Peach)
            {0x26B, 09874}, // peach hat (Peach)
            {0x26C, 09947}, // peach umbrella
            {0x26D, 09836}, // apple dress (Red)
            {0x26E, 09871}, // apple hat (Red)
            {0x26F, 09948}, // apple umbrella
            {0x270, 05275}, // orange hat (Orange)
            {0x271, 06912}, // orange umbrella
            {0x272, 03288}, // orange dress (Orange)
            {0x273, 07489}, // star pochette (Yellow)
            {0x274, 09862}, // star head (Yellow)
            {0x275, 09945}, // cherry-blossom umbrella
            {0x276, 07490}, // cherry-blossom pochette (Pink)
            {0x277, 07491}, // maple-leaf pochette (Red)
            {0x278, 07492}, // acorn pochette (Brown)
            {0x279, 07493}, // snowflake pochette (White)
            {0x27A, 07494}, // shellfish pochette (White)
            {0x27B, 07291}, // leaf mask (Green)
            {0x27C, 07511}, // knitted-grass backpack (Green)
            {0x27D, 08609}, // snowperson head (White)
            {0x27E, 07498}, // log pack (Brown)
            {0x280, 04588}, // iron armor (Gray)
            {0x281, 05334}, // knight's helmet (Gray)
            {0x282, 05472}, // armor shoes (Gray)
            {0x283, 05524}, // gold-armor shoes (Gold)
            {0x284, 05346}, // gold helmet (Gold)
            {0x285, 07506}, // basket pack (Green)
            {0x286, 12206}, // flat garden rock
            {0x287, 12208}, // mossy garden rock
            {0x288, 07174}, // mush umbrella
            {0x289, 05056}, // sakura-wood flooring
            {0x28A, 12230}, // festive top set
            {0x28B, 11943}, // stone tablet
            {0x28C, 11941}, // stone arch
            {0x28D, 00676}, // tall lantern
            {0x28E, 11942}, // street piano
            {0x28F, 01120}, // scarecrow
            {0x290, 11711}, // simple wooden fence
            {0x291, 11712}, // lattice fence
            {0x292, 08179}, // golden net
            {0x293, 08533}, // golden watering can
            {0x294, 08574}, // golden shovel
            {0x295, 08578}, // golden slingshot
            {0x296, 08660}, // golden rod
            {0x297, 09617}, // golden axe
            {0x298, 12326}, // recycled boots (Brown)
            {0x299, 05508}, // underwater wall
            {0x29A, 05661}, // tropical vista
            {0x29B, 07239}, // starry-sands flooring
            {0x29C, 07362}, // shell rug
            {0x29D, 04970}, // sandy-beach flooring
            {0x29E, 12332}, // natural square table
            {0x29F, 11113}, // light bamboo rug
            {0x2A0, 11114}, // dark bamboo rug
            {0x2A1, 12439}, // earth-egg shell (Red)
            {0x2A2, 12449}, // earth-egg outfit (Red)
            {0x2A3, 12455}, // earth-egg shoes (Red)
            {0x2A4, 12440}, // stone-egg shell (Yellow)
            {0x2A5, 12450}, // stone-egg outfit (Yellow)
            {0x2A6, 12456}, // stone-egg shoes (Yellow)
            {0x2A7, 12441}, // leaf-egg shell (Green)
            {0x2A8, 12451}, // leaf-egg outfit (Green)
            {0x2A9, 12457}, // leaf-egg shoes (Green)
            {0x2AA, 12442}, // wood-egg shell (Orange)
            {0x2AB, 12452}, // wood-egg outfit (Orange)
            {0x2AC, 12458}, // wood-egg shoes (Orange)
            {0x2AD, 12443}, // sky-egg shell (Blue)
            {0x2AE, 12453}, // sky-egg outfit (Blue)
            {0x2AF, 12459}, // sky-egg shoes (Blue)
            {0x2B0, 12444}, // water-egg shell (Purple)
            {0x2B1, 12454}, // water-egg outfit (Purple)
            {0x2B2, 12460}, // water-egg shoes (Purple)
            {0x2B3, 12446}, // egg party hat (Colorful)
            {0x2B4, 12448}, // egg party dress (Colorful)
            {0x2B5, 12445}, // Bunny Day crown (Colorful)
            {0x2B6, 12447}, // Bunny Day bag (Colorful)
            {0x2B7, 12398}, // Bunny Day arch
            {0x2B8, 12412}, // wobbling Zipper toy
            {0x2B9, 12413}, // Bunny Day lamp
            {0x2BA, 12414}, // Bunny Day bed
            {0x2BB, 12415}, // Bunny Day stool
            {0x2BC, 12417}, // Bunny Day glowy garland
            {0x2BD, 12418}, // Bunny Day wall clock
            {0x2BE, 12419}, // Bunny Day merry balloons
            {0x2BF, 12420}, // Bunny Day vanity
            {0x2C0, 12421}, // Bunny Day festive balloons
            {0x2C1, 12436}, // Bunny Day table
            {0x2C2, 12437}, // Bunny Day wardrobe
            {0x2C3, 12517}, // Bunny Day wreath
            {0x2C4, 05231}, // Bunny Day wall
            {0x2C5, 07546}, // Bunny Day rug
            {0x2C6, 12423}, // Bunny Day flooring
            {0x2C7, 12578}, // Bunny Day wand
            {0x2C8, 12630}, // Bunny Day fence
            {0x2C9, 12758}, // hedge
            {0x2CA, 12894}, // wedding fence
            {0x2CB, 12695}, // wedding wand
            {0x2CC, 05607}, // King Tut mask (Gold)
            {0x2CD, 12552}, // mermaid table
            {0x2CE, 12553}, // mermaid shelf
            {0x2CF, 12554}, // mermaid vanity
            {0x2D0, 12555}, // mermaid screen
            {0x2D1, 12556}, // mermaid lamp
            {0x2D2, 12557}, // mermaid wall clock
            {0x2D3, 12558}, // mermaid bed
            {0x2D4, 12559}, // mermaid closet
            {0x2D5, 12560}, // mermaid sofa
            {0x2D6, 12561}, // mermaid dresser
            {0x2D7, 12562}, // mermaid chair
            {0x2D8, 12563}, // mermaid rug
            {0x2D9, 12566}, // mermaid wall
            {0x2DA, 12568}, // mermaid flooring
            {0x2DC, 12951}, // spooky candy set
            {0x2DD, 12949}, // spooky standing lamp
            {0x2DE, 13222}, // spooky garland
            {0x2DF, 13223}, // spooky table setting
            {0x2E0, 13237}, // spooky wand
            {0x2E1, 13275}, // spooky fence
            {0x2E4, 13447}, // Turkey Day garden stand
            {0x2E5, 13448}, // Turkey Day hearth
            {0x2E6, 13449}, // Turkey Day decorations
            {0x2E7, 13450}, // Turkey Day chair
            {0x2E9, 13453}, // Turkey Day table
            {0x2EA, 07544}, // festive rug
            {0x2EB, 13818}, // Turkey Day casserole
            {0x2EC, 13819}, // Turkey Day wheat decor
            {0x2ED, 13820}, // Turkey Day table setting
            {0x2EE, 13244}, // gift pile
            {0x2EF, 13792}, // festive wrapping paper
            {0x2F0, 13603}, // falling-snow wall
            {0x2F3, 03548}, // rainbow feather
            {0x2F5, 12217}, // summer-shell rug
            {0x306, 14239}, // shamrock wand
            {0x308, 14278}, // mermaid fence
        };
    }
}
