﻿using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class BoomShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boom Shuriken");
            Tooltip.SetDefault("Rapid firing explosives");
        }

        public override void SetDefaults()
        {
            item.width = 11;
            item.height = 11;
            item.damage = 16;
            item.thrown = true;
            item.noMelee = true;
            item.consumable = true;
            item.noUseGraphic = true;
            item.scale = 0.75f;
            item.crit = 5;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.maxStack = 999;
            item.rare = 1;
            item.shoot = mod.ProjectileType("ShurikenProj");
            item.shootSpeed = 11f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shuriken, 20);
            recipe.AddIngredient(ItemID.Dynamite, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
    }
}