using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BabyHage : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hage");
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.ignoreWater = true;
            facingLeft = false; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = false; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = true; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
            Projectile.Opacity = 0;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1000f; //teleport distance
            distance[1] = 300f; //faster speed distance
            speed = 2.5f;
            inertia = 10f;
            animationSpeed = 1; //how fast the animation should play
            spinRotationSpeedMult = 0f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 30f * -Main.player[Projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -80f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "CalValEX/Projectiles/Pets/BabyHage_Glowmask";
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.hage = false;
            if (modPlayer.hage)
                Projectile.timeLeft = 2;

            /* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
             * for custom behaviour, you can check if the projectile is walking or not via Projectile.localAI[1]
             * you should make new custom behaviour with numbers higher than 0, or less than 0
             * the next few lines is an example on how to implement this
             *
             * switch ((int)Projectile.localAI[1])
             * {
             *     case -1:
             *         break;
             *     case 1:
             *         break;
             * }
             *
             * 0 is already in use.
             * 0 = flying
             *
             * you can still use this, changing thing inside (however it's not recomended unless you want to add custom behaviour to this)
             */
        }
    }
}