namespace NHSE.Core
{
    public class HorizonSave
    {
        public readonly MainSave Main;
        public readonly Player[] Players;
        public override string ToString() => $"{Players[0].Personal.TownName} - {Players[0]}";

        public HorizonSave(string folder)
        {
            Main = new MainSave(folder);
            Players = Player.ReadMany(folder);
        }

        public void Save(uint seed)
        {
            Main.Hash();
            Main.Save(seed);
            foreach (var player in Players)
            {
                player.Hash();
                player.Save(seed);
            }
        }
    }
}
