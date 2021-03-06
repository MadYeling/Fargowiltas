using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class dia : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instavator");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;   //This defines the hitbox width
            projectile.height = 36;    //This defines the hitbox height
            projectile.aiStyle = 16;  //explosive ai

            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 4;     //size
            int ye = 0;
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = 0; y <= (325 * radius); y++)
                {
                    int xdiaPosition = (int)(y + x + position.X / 16.0f);
                    int ydiaPosition = (int)(y + position.Y / 16.0f);
                    int ydiadow = (int)(ye - x + position.X / 16.0f);
                    int yodiadow = (int)(ye + position.Y / 16.0f);
                    int xadiaPosition = (int)(ye - x + position.X / 16.0f);
                    int yadiaPosition = (int)(y + position.Y / 16.00f);
                    int yadiadow = (int)(y + x + position.X / 16.0f);
                    int yoadiadow = (int)(ye + position.Y / 16.0f);

                    if ((x * y) <= radius)   //rectangle
                    {
                        WorldGen.KillTile(xdiaPosition, ydiaPosition);  //tile destroy
                        WorldGen.KillTile(ydiadow, yodiadow);  //tile destroy
                        WorldGen.KillTile(xadiaPosition, yadiaPosition);  //tile destroy
                        WorldGen.KillTile(yadiadow, yoadiadow);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);
                    }
                    ye = y * -1;
                }
            }
        }
    }
}