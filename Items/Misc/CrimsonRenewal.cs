﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class CrimsonRenewal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Renewal");
            Tooltip.SetDefault("Crimsons a large radius");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3, 0);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CrimsonNukeProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.RedSolution, 100);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}