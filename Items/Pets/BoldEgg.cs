﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class BoldEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eggstone");
            Tooltip.SetDefault("Wait, it's alive?!\n" + "Hatches into a baby Bohldohr");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit41;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.BoldLizard>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<Buffs.Pets.EggBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}