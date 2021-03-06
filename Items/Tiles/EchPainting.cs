using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class EchPainting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ech Painting");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.createTile = mod.TileType("EchPaintingSheet");
        }
    }
}