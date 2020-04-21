using System.Linq;

namespace NHSE.Core
{
    public interface IVillagerOrigin
    {
        string PlayerName { get; }
        string TownName { get; }
        byte[] GetTownIdentity();
        byte[] GetPlayerIdentity();
    }

    public static class VillagerOriginExtensions
    {
        public static bool IsOriginatedFrom(this IVillagerOrigin visit, IVillagerOrigin host)
        {
            return visit.IsSameTown(host) && visit.IsSamePlayer(host);
        }

        public static bool IsSameTown(this IVillagerOrigin visit, IVillagerOrigin host)
        {
            var hostTown = host.GetTownIdentity();
            var visitTown = visit.GetTownIdentity();
            return hostTown.SequenceEqual(visitTown);
        }

        public static bool IsSamePlayer(this IVillagerOrigin visit, IVillagerOrigin host)
        {
            var hostPlayer = host.GetPlayerIdentity();
            var visitPlayer = visit.GetPlayerIdentity();
            return hostPlayer.SequenceEqual(visitPlayer);
        }

        public static void ChangeOrigins(this IVillagerOrigin visit, IVillagerOrigin host, byte[] visitData)
        {
            visit.ChangeToHostTown(host, visitData);
            visit.ChangeToHostPlayer(host, visitData);
        }

        private static void ChangeToHostTown(this IVillagerOrigin visit, IVillagerOrigin host, byte[] visitData)
        {
            var hostTown = host.GetTownIdentity();
            var visitTown = visit.GetTownIdentity();
            if (hostTown.SequenceEqual(visitTown))
                return;
            visitData.ReplaceOccurrences(visitTown, hostTown);
        }

        private static void ChangeToHostPlayer(this IVillagerOrigin visit, IVillagerOrigin host, byte[] visitData)
        {
            var hostPlayer = host.GetPlayerIdentity();
            var visitPlayer = visit.GetPlayerIdentity();
            if (hostPlayer.SequenceEqual(visitPlayer))
                return;
            visitData.ReplaceOccurrences(visitPlayer, hostPlayer);
        }
    }
}