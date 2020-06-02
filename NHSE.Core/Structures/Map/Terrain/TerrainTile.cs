using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    /// <summary>
    /// Represents a Terraform-able terrain tile.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class TerrainTile
    {
        // tile[2] (u16 model, u16 variation, u16 angle)
        // u16 elevation
        public const int SIZE = 0xE;
        private const string Terrain = nameof(Terrain);
        private const string Road = nameof(Road);
        private const string Details = nameof(Details);

        // Tile
        [Category(Terrain), Description("Terrain model to be loaded for this tile.")]
        public TerrainUnitModel UnitModel { get; set; }

        [Category(Terrain), Description("Variant of the terrain model.")]
        public ushort Variation { get; set; }

        [Category(Terrain), Description("Angle of the terrain model.")]
        public ushort LandMakingAngle { get; set; }

        // Road
        [Category(Road), Description("Road model to be loaded on top of the Terrain model.")]
        public TerrainUnitModel UnitModelRoad { get; set; }

        [Category(Road), Description("Variant of the road model.")]
        public ushort VariationRoad { get; set; }

        [Category(Road), Description("Angle of the road model.")]
        public ushort LandMakingAngleRoad { get; set; }

        // Elevation
        [Category(Details), Description("How high the terrain tile is elevated.")]
        public ushort Elevation { get; set; }

        public static TerrainTile[] GetArray(byte[] data) => data.GetArray<TerrainTile>(SIZE);
        public static byte[] SetArray(IReadOnlyList<TerrainTile> data) => data.SetArray(SIZE);

        public void Clear()
        {
            UnitModel = UnitModelRoad = 0;
            Variation = LandMakingAngle = VariationRoad = LandMakingAngleRoad = Elevation = 0;
        }

        public void CopyFrom(TerrainTile source)
        {
            UnitModel = source.UnitModel;
            Variation = source.Variation;
            LandMakingAngle = source.LandMakingAngle;
            UnitModelRoad = source.UnitModelRoad;
            VariationRoad = source.VariationRoad;
            LandMakingAngleRoad = source.LandMakingAngleRoad;
            Elevation = source.Elevation;
        }

        public void CopyGroundFrom(TerrainTile tile)
        {
            UnitModel = tile.UnitModel;
            Variation = tile.Variation;
            LandMakingAngle = tile.LandMakingAngle;
        }

        public void CopyRoadFrom(TerrainTile tile)
        {
            UnitModelRoad = tile.UnitModelRoad;
            VariationRoad = tile.VariationRoad;
            LandMakingAngleRoad = tile.LandMakingAngleRoad;
        }

        public bool Rotate() => UnitModelRoad != 0 ? RotateRoad() : RotateTerrain();

        private bool RotateTerrain()
        {
            if (UnitModel == TerrainUnitModel.Base)
                return false;
            var rot = LandMakingAngle;
            rot = (ushort)((rot + 1) & 3);
            LandMakingAngle = rot;
            return true;
        }

        private bool RotateRoad()
        {
            var rot = LandMakingAngleRoad;
            rot = (ushort) ((rot + 1) & 3);
            LandMakingAngleRoad = rot;
            return true;
        }
    }
}
