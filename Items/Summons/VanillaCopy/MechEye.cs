using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MechEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Kind of Metallic Eye");
            Tooltip.SetDefault("Summons the Twins");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 3;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override string Texture => "Terraria/Item_544";

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalEye);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}