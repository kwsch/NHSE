namespace NHSE.Core;

/// <summary>
/// Learned Emotions that can be used from the Reaction Wheel
/// </summary>
public enum Reaction : byte
{
    None = 0,
    Happiness = 1, // Smiling
    Laughter = 2, // Laughing
    Joy = 3, // HappyFlower
    Love = 4, // Love
    Glee = 5, // HappyDance
    UNUSED_6 = 6, // Anger (Unused)
    Aggravation = 7, // Outraged
    UNUSED_8 = 8, // Outrage (Unused)
    Worry = 9, // Worried
    Sighing = 10, // Sighing
    Thought = 11, // Thinking
    Sadness = 12, // SadSpiral
    Distress = 13, // Frantic
    Sorrow = 14, // Crying
    Amazed = 15, // Shocked
    Surprise = 16, // Aha
    UNUSED_17 = 17, // Disbelief (Unused)
    Shocked = 18, // Surprised
    Cold_Chill = 19, // ColdChill
    Fearful = 20, // Shaking
    Agreement = 21, // Nodding
    Inspiration = 22, // IdeaBulb
    Curiosity = 23, // QuestionMark
    Heartbreak = 24, // BrokenHeart
    Sleepy = 25, // Sleepy
    Bashfulness = 26, // Blushing
    Resignation = 27, // OhGeez
    Mischief = 28, // Scheming
    Delight = 29, // Clapping
    Sneezing = 30, // Sneezing
    Encouraging = 31, // Cheering
    Greetings = 32, // Greeting
    Pride = 33, // SmugFace
    UNUSED_34 = 34, // Sweating (Unused)
    Smirking = 35, // Grin
    Sheepishness = 36, // WrySmile
    UNUSED_37 = 37, // Smile (Unused)
    UNUSED_38 = 38, // Sunniness (Unused)
    Shyness = 39, // Hesitate
    Disagreement = 40, // Negative
    Mistaken = 41, // Oops
    Flourish = 42, // Dance
    Daydreaming = 43, // AbsentMindedness
    Showmanship = 44, // Shaki
    Dozing = 45, // Sleep
    UNUSED_46 = 46, // Shrunk Funk Shuffle (Unused)
    Intense = 47, // Silent
    Pleased = 48, // Hello
    UNUSED_49 = 49, // Distress without the hand movements? (Unused)
    UNUSED_50 = 50, // Smiling and rubbing cheek (Unused)
    UNUSED_51 = 51, // Poking hands together (Unused)
    UNUSED_52 = 52, // Intense but frowning (Unused)
    UNUSED_53 = 53, // Amazed with smaller particles (Unused)
    Apologetic = 54, // Apologize
    Confident = 55, // Assent
    UNUSED_56 = 56, // Talking (Unused)
    UNUSED_57 = 57, // Clapping with no expression (Makes you stand up if sitting down) (Unused)
    Bewilderment = 58, // Pardon
    UNUSED_59 = 59, // Greetings with no sound or expression (Unused)

    Scare = 60, // AddPrank 
    Haunt = 61, // AddScaring 
    SitDown = 62, // AddSitDown 
    Yoga = 63, // AddYoga 
    HereYouGo = 64, // AddHereYouGo 
    WorkOut = 65, // AddGymnastics
    TakeAPicture = 66, // AddTakePictures 
    SniffSniff = 67, // AddSmell 
    Tada = 68, // AddPraise 
    WaveGoodbye = 69, // AddWaveHands 
    Excited = 70, // AddExcited 

    Confetti = 71, // (Festivale DLC)
    Viva = 72, // (Festivale DLC)
    LetsGo = 73, // (Festivale DLC)
    FeelinIt = 74, // (Festivale DLC)

    UNUSED_75 = 75, // Gullivar about to come alive (Unused)
    UNUSED_76 = 76, // Intense shake action (Unused)
    UNUSED_77 = 77, // Literally the "roll safe" meme (google it) (Unused)
    UNUSED_78 = 78, // Leave it to me! (Unused)
    UNUSED_79 = 79, // K.K. Slider Sitting (Unused)
    UNUSED_80 = 80, // K.K. nodding while sitting (Unused)
    UNUSED_81 = 81, // K.K. thinking while sitting (Unused)
}