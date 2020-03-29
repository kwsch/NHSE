using System.Linq;

namespace NHSE.Core
{
    public interface IVillagerOrigin
    {
        byte[] GetTownIdentity();
        byte[] GetPlayerIdentity();
    }

    public static class VillagerOriginExtensions
    {
        public static bool IsOriginatedFrom(this IVillagerOrigin visit, IVillagerOrigin host)
        {
            var hostTown = host.GetTownIdentity();
            var visitTown = visit.GetTownIdentity();
            if (!hostTown.SequenceEqual(visitTown))
                return false;

            var hostPlayer = host.GetTownIdentity();
            var visitPlayer = visit.GetTownIdentity();
            if (!hostPlayer.SequenceEqual(visitPlayer))
                return false;

            return true;
        }

        public static void ChangeOrigins(this IVillagerOrigin visit, IVillagerOrigin host, byte[] visitData)
        {
            var hostTown = host.GetTownIdentity();
            var visitTown = visit.GetTownIdentity();
            visitData.ReplaceOccurrences(visitTown, hostTown);

            var hostPlayer = host.GetTownIdentity();
            var visitPlayer = visit.GetTownIdentity();
            visitData.ReplaceOccurrences(visitPlayer, hostPlayer);
        }
    }
}