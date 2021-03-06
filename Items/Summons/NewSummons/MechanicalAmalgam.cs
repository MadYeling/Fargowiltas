using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class MechanicalAmalgam : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Amalgam");
            Tooltip.SetDefault("Summons all 3 Mechanical bosses");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 4;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}