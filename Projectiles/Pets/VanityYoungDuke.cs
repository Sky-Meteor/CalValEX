﻿using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityYoungDuke : ModFlyingPet
    {
        public override string Texture => "CalamityMod/Projectiles/Summon/YoungDuke";

        public override bool ShouldFlyRotate => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Young Duke");
            Main.projFrames[Projectile.type] = 16;
        }

        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(108f * -Main.player[Projectile.owner].direction, -50f);

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                Projectile.timeLeft = 0;
            if (!modPlayer.vanityyound)
                Projectile.timeLeft = 0;
            if (modPlayer.vanityyound)
                Projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 6)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 6)
                Projectile.frame = 0;
            Projectile.rotation = 0;
        }
    }
}