using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class ThornChakramThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ThornChakram);
			item.shoot = ProjectileID.ThornChakram;
			item.melee = false;
			item.thrown = true;
		}
		
		public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThornChakram);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}