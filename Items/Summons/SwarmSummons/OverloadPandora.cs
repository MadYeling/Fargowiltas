﻿using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadPandora : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pandora's Tesseract");
            Tooltip.SetDefault("The ultimate swarm");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 11;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.swarmActive && !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.swarmActive = true;
            Fargowiltas.swarmTotal = 500;
            Fargowiltas.swarmKills = 0;
            Fargowiltas.swarmSpawned = 40;

            for (int i = 0; i < Fargowiltas.swarmSpawned; i++)
            {
                int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), FargoGlobalNPC.bosses[Main.rand.Next(FargoGlobalNPC.bosses.Length)]);
                Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().pandoraActive = true;
            }

            Main.NewText("hleh!", 175, 75, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OverloadSlimeCrown");
            recipe.AddIngredient(null, "OverloadEye");
            recipe.AddIngredient(null, "OverloadWorm");
            recipe.AddIngredient(null, "OverloadBrain");
            recipe.AddIngredient(null, "OverloadBee");
            recipe.AddIngredient(null, "OverloadSkele");
            recipe.AddIngredient(null, "OverloadDestroyer");
            recipe.AddIngredient(null, "OverloadTwins");
            recipe.AddIngredient(null, "OverloadPrime");
            recipe.AddIngredient(null, "OverloadPlant");
            recipe.AddIngredient(null, "OverloadGolem");
            recipe.AddIngredient(null, "OverloadFish");
            recipe.AddIngredient(null, "OverloadMoon");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}