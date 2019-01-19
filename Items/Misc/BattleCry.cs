using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class BattleCry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle Cry");
            Tooltip.SetDefault("Increase spawn rates by 10x on use\n" +
                                "Use it again to decrease them");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 5;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            FargoWorld.battleCry = !FargoWorld.battleCry;

            if (FargoWorld.battleCry)
            {
                Main.NewText("Spawn rates increased!", 175, 75);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Horn").WithVolume(1f).WithPitchVariance(.5f), (int)player.position.X, (int)player.position.Y);
            }
            else
            {
                Main.NewText("Spawn rates decreased!", 175, 75);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BattlePotion, 15);
            recipe.AddIngredient(ItemID.WaterCandle, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}