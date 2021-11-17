﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class DSSlider : ModProjectile
    {
        public bool checkpos = false;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongSlider";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Scourge Slider");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 78;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            if (projectile.position.Y < player.Center.Y - 258)
            {
                projectile.velocity.Y *= -1;
            }
            else if (projectile.position.Y > player.Center.Y + 173)
            {
                projectile.velocity.Y *= -1;
            }

            if (!modPlayer.pongactive)
            {
                projectile.active = false;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive)
            {
                Texture2D texture2 = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongSlider");
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[projectile.type] * projectile.frame, texture2.Width, texture2.Height / Main.projFrames[projectile.type]);
                Vector2 position2 = projectile.Center - Main.screenPosition;
                position2.X += drawOffsetX;
                position2.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture2, position2, rectangle2, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
            }
        }
    }
}