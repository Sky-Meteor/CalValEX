﻿using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets.Elementals
{
    public class rarebrimlingbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rare Brimling");
            Description.SetDefault("She can't protect you, but she's doing her best.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.rarebrimling>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.rarebrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}