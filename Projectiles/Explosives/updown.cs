using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class updown : ModProjectile
    {
        private int ye;

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
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = 0; y <= (325 * radius); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(ye + position.Y / 16.0f);
                    int ydow = (int)(y + position.Y / 16.0f);

                    if ((x * y) <= radius)   //rectangle
                    {
                        WorldGen.KillTile(xPosition, yPosition);  //tile destroy
                        WorldGen.KillTile(xPosition, ydow);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);
                    }
                    ye = y * -1;
                }
            }
        }
    }
}