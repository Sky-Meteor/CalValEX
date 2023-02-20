﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AstralGrass : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Astral Grass Seeds");
			Tooltip.SetDefault("Places grass on blighted astral dirt");
		}

		public override void SetDefaults()
		{
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.width = Item.height = 16;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.maxStack = 999;
		}

		public override bool? UseItem(Player player)
		{
			Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
			
			if (tile.HasTile && tile.TileType == ModContent.TileType<Tiles.AstralBlocks.AstralDirtPlaced>() && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY))
			{
				Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<Tiles.AstralBlocks.AstralGrassPlaced>();

				SoundEngine.PlaySound(SoundID.Dig, player.Center);

				return true;
			}

			return false;
		}
    }
}