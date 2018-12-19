
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using ASFW;
using Engine;


namespace Engine
{
	sealed class C_Pets
	{
		
#region Globals etc
		
		internal static PetRec[] Pet;
		
		internal const byte PetbarTop = 2;
		internal const byte PetbarLeft = 2;
		internal const byte PetbarOffsetX = 4;
		internal const byte MaxPetbar = 8;
		internal const int PetHpBarWidth = 129;
		internal const int PetMpBarWidth = 129;
		
		internal static int PetSkillBuffer;
		internal static int PetSkillBufferTimer;
		internal static int[] PetSkillCd;
		
		internal static bool ShowPetStats;

		internal static bool isMounted;
		
		//Pet Constants
		internal const byte PetBehaviourFollow = 0; //The pet will attack all npcs around
		
		internal const byte PetBehaviourGoto = 1; //If attacked, the pet will fight back
		internal const byte PetAttackBehaviourAttackonsight = 2; //The pet will attack all npcs around
		internal const byte PetAttackBehaviourGuard = 3; //If attacked, the pet will fight back
		internal const byte PetAttackBehaviourDonothing = 4; //The pet will not attack even if attacked
		
		public struct PetRec
		{
			public int Num;
			public string Name;
			public int Sprite;
			
			public int Range;
			
			public int Level;

            public byte IsMount;
            public byte IsFlying;

            public int MaxLevel;
			public int ExpGain;
			public int LevelPnts;
			
			public byte StatType; //1 for set stats, 2 for relation to owner's stats
			public byte LevelingType; //0 for leveling on own, 1 for not leveling
			
			public byte[] Stat;
			
			public int[] Skill;
			
			public byte Evolvable;
			public int EvolveLevel;
			public int EvolveNum;
		}
		
		public struct PlayerPetRec
		{
			public int Num;
			public int Health;
			public int Mana;
			public int Level;
			public bool isMounted;
			public byte[] Stat;
			public int[] Skill;
			public int Points;
			public int X;
			public int Y;
			public int Dir;
			public int MaxHp;
			public int MaxMp;
			public byte Alive;
			public int AttackBehaviour;
			public int Exp;
			public int Tnl;
			
			//Client Use Only
			public int XOffset;
			
			public int YOffset;
			public byte Moving;
			public byte Attacking;
			public int AttackTimer;
			public byte Steps;
			public int Damage;
		}
		
#endregion
		
#region Database
		
		public static void ClearPet(int index)
		{
			
			Pet[index].Name = "";
			
			Pet[index].Stat = new byte[(int) Enums.StatType.Count];
			Pet[index].Skill = new int[5];
		}
		
		public static void ClearPets()
		{
			int i = 0;
			
			Pet = new C_Pets.PetRec[Constants.MAX_PETS + 1];
			PetSkillCd = new int[5];
			
			for (i = 1; i <= Constants.MAX_PETS; i++)
			{
				ClearPet(i);
			}
			
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendPetBehaviour(int index)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSetBehaviour);
			
			buffer.WriteInt32(index);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendTrainPetStat(byte statNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPetUseStatPoint);
			
			buffer.WriteInt32(statNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendRequestPets()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestPets);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendUsePetSkill(int skill)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPetSkill);
			buffer.WriteInt32(skill);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
			PetSkillBuffer = skill;
			PetSkillBufferTimer = C_General.GetTickCount();
		}
		
		public static void SendSummonPet()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSummonPet);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}

        public static void SendPetMount()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((System.Int32)Packets.ClientPackets.CPetMount);
            
            if (isMounted == false)
            {
                //Mount
                buffer.WriteInt32(1);
            }
            else
            {
                //Unmount
                buffer.WriteInt32(0);
            }

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();

        }

        public static void SendReleasePet()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CReleasePet);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_UpdatePlayerPet(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			
			//pet
			C_Types.Player[n].Pet.Num = buffer.ReadInt32();
			C_Types.Player[n].Pet.Health = buffer.ReadInt32();
			C_Types.Player[n].Pet.Mana = buffer.ReadInt32();
			C_Types.Player[n].Pet.Level = buffer.ReadInt32();
			C_Types.Player[n].Pet.isMounted = Convert.ToBoolean(buffer.ReadInt32());
			isMounted = C_Types.Player[n].Pet.isMounted;
			
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				C_Types.Player[n].Pet.Stat[i] = (byte)buffer.ReadInt32();
			}
			
			for (i = 1; i <= 4; i++)
			{
				C_Types.Player[n].Pet.Skill[i] = buffer.ReadInt32();
			}
			
			C_Types.Player[n].Pet.X = buffer.ReadInt32();
			C_Types.Player[n].Pet.Y = buffer.ReadInt32();
			C_Types.Player[n].Pet.Dir = buffer.ReadInt32();
			
			C_Types.Player[n].Pet.MaxHp = buffer.ReadInt32();
			C_Types.Player[n].Pet.MaxMp = buffer.ReadInt32();
			
			C_Types.Player[n].Pet.Alive = (byte) (buffer.ReadInt32());
			
			C_Types.Player[n].Pet.AttackBehaviour = buffer.ReadInt32();
			C_Types.Player[n].Pet.Points = buffer.ReadInt32();
			C_Types.Player[n].Pet.Exp = buffer.ReadInt32();
			C_Types.Player[n].Pet.Tnl = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		internal static void Packet_UpdatePet(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			
			ref var with_1 = ref Pet[n];
			with_1.Num = buffer.ReadInt32();
			with_1.Name = buffer.ReadString();
			with_1.Sprite = buffer.ReadInt32();
			with_1.Range = buffer.ReadInt32();
			with_1.Level = buffer.ReadInt32();
			with_1.IsMount = (byte)buffer.ReadInt32();
			with_1.IsFlying = (byte)buffer.ReadInt32();
			with_1.MaxLevel = buffer.ReadInt32();
			with_1.ExpGain = buffer.ReadInt32();
			with_1.LevelPnts = buffer.ReadInt32();
			with_1.StatType = (byte) (buffer.ReadInt32());
			with_1.LevelingType = (byte) (buffer.ReadInt32());
			
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				with_1.Stat[i] = (byte) (buffer.ReadInt32());
			}
			
			for (i = 1; i <= 4; i++)
			{
				with_1.Skill[i] = buffer.ReadInt32();
			}
			
			with_1.Evolvable = (byte) (buffer.ReadInt32());
			with_1.EvolveLevel = buffer.ReadInt32();
			with_1.EvolveNum = buffer.ReadInt32();
			
			buffer.Dispose();
			
		}
		
		internal static void Packet_PetMove(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int dir = 0;
			int movement = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			movement = buffer.ReadInt32();
			
			ref var with_1 = ref C_Types.Player[i].Pet;
			with_1.X = x;
			with_1.Y = y;
			with_1.Dir = dir;
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = (byte)movement;
			
			if (with_1.Dir == (byte)Enums.DirectionType.Up)
			{
				with_1.YOffset = C_Constants.PicY;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Down)
			{
				with_1.YOffset = C_Constants.PicY * -1;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Left)
			{
				with_1.XOffset = C_Constants.PicX;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Right)
			{
				with_1.XOffset = C_Constants.PicX * -1;
			}
			
			buffer.Dispose();
		}
		
		internal static void Packet_PetDir(ref byte[] data)
		{
			int i = 0;
			int dir = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			
			C_Types.Player[i].Pet.Dir = dir;
			
			buffer.Dispose();
		}
		
		internal static void Packet_PetVital(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			if (buffer.ReadInt32() == 1)
			{
				C_Types.Player[i].Pet.MaxHp = buffer.ReadInt32();
				C_Types.Player[i].Pet.Health = buffer.ReadInt32();
			}
			else
			{
				C_Types.Player[i].Pet.MaxMp = buffer.ReadInt32();
				C_Types.Player[i].Pet.Mana = buffer.ReadInt32();
			}
			
			buffer.Dispose();
			
		}
		
		internal static void Packet_ClearPetSkillBuffer(ref byte[] data)
		{
			PetSkillBuffer = 0;
			PetSkillBufferTimer = 0;
		}
		
		internal static void Packet_PetAttack(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			// Set pet to attacking
			C_Types.Player[i].Pet.Attacking = (byte) 1;
			C_Types.Player[i].Pet.AttackTimer = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		internal static void Packet_PetXY(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			C_Types.Player[i].Pet.X = buffer.ReadInt32();
			C_Types.Player[i].Pet.Y = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		internal static void Packet_PetExperience(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Types.Player[C_Variables.Myindex].Pet.Exp = buffer.ReadInt32();
			C_Types.Player[C_Variables.Myindex].Pet.Tnl = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
#endregion
		
#region Movement
		
		public static void ProcessPetMovement(int index)
		{
			
			// Check if pet is walking, and if so process moving them over
			
			if (C_Types.Player[index].Pet.Moving == (byte)Enums.MovementType.Walking)
			{
				
				switch (C_Types.Player[index].Pet.Dir)
				{
					case (int) Enums.DirectionType.Up:
						C_Types.Player[index].Pet.YOffset = System.Convert.ToInt32(C_Types.Player[index].Pet.YOffset - (((double) C_Variables.ElapsedTime / 1000) * (C_Constants.WalkSpeed * C_Constants.SizeX)));
						if (C_Types.Player[index].Pet.YOffset < 0)
						{
							C_Types.Player[index].Pet.YOffset = 0;
						}
						break;
						
					case (int) Enums.DirectionType.Down:
						C_Types.Player[index].Pet.YOffset = System.Convert.ToInt32(C_Types.Player[index].Pet.YOffset + (((double) C_Variables.ElapsedTime / 1000) * (C_Constants.WalkSpeed * C_Constants.SizeX)));
						if (C_Types.Player[index].Pet.YOffset > 0)
						{
							C_Types.Player[index].Pet.YOffset = 0;
						}
						break;
						
					case (int) Enums.DirectionType.Left:
						C_Types.Player[index].Pet.XOffset = System.Convert.ToInt32(C_Types.Player[index].Pet.XOffset - (((double) C_Variables.ElapsedTime / 1000) * (C_Constants.WalkSpeed * C_Constants.SizeX)));
						if (C_Types.Player[index].Pet.XOffset < 0)
						{
							C_Types.Player[index].Pet.XOffset = 0;
						}
						break;
						
					case (int) Enums.DirectionType.Right:
						C_Types.Player[index].Pet.XOffset = System.Convert.ToInt32(C_Types.Player[index].Pet.XOffset + (((double) C_Variables.ElapsedTime / 1000) * (C_Constants.WalkSpeed * C_Constants.SizeX)));
						if (C_Types.Player[index].Pet.XOffset > 0)
						{
							C_Types.Player[index].Pet.XOffset = 0;
						}
						break;
						
				}

				// Check if completed walking over to the next tile
				if (C_Types.Player[index].Pet.Moving > 0)
				{
					if (C_Types.Player[index].Pet.Dir == (int) Enums.DirectionType.Right || C_Types.Player[index].Pet.Dir == (int) Enums.DirectionType.Down)
					{
						if ((C_Types.Player[index].Pet.XOffset >= 0) && (C_Types.Player[index].Pet.YOffset >= 0))
						{
							C_Types.Player[index].Pet.Moving = (byte) 0;
							if (C_Types.Player[index].Pet.Steps == 1)
							{
								C_Types.Player[index].Pet.Steps = (byte) 2;
							}
							else
							{
								C_Types.Player[index].Pet.Steps = (byte) 1;
							}
						}
					}
					else
					{
						if ((C_Types.Player[index].Pet.XOffset <= 0) && (C_Types.Player[index].Pet.YOffset <= 0))
						{
							C_Types.Player[index].Pet.Moving = (byte) 0;
							if (C_Types.Player[index].Pet.Steps == 1)
							{
								C_Types.Player[index].Pet.Steps = (byte) 2;
							}
							else
							{
								C_Types.Player[index].Pet.Steps = (byte) 1;
							}
						}
					}
				}

			}
            if (isMounted)
            {
                C_Types.Player[index].Pet.YOffset = (C_Types.Player[index].Pet.YOffset - 1);
            }

        }
		
		internal static void PetMove(int x, int y)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPetMove);
			
			buffer.WriteInt32(x);
			buffer.WriteInt32(y);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Drawing
		
		internal static void DrawPet(int index)
		{
			byte anim = 0;
			int x = 0;
			int y = 0;
			int sprite = 0;
			int spriteleft = 0;
			Rectangle srcrec = new Rectangle();
			int attackspeed = 0;
			
			sprite = Pet[C_Types.Player[index].Pet.Num].Sprite;
			
			if (sprite < 1 || sprite > C_Graphics.NumCharacters)
			{
				return;
			}
			
			attackspeed = 1000;
			
			// Reset frame
			if (C_Types.Player[index].Pet.Steps == 3)
			{
				anim = (byte) 0;
			}
			else if (C_Types.Player[index].Pet.Steps == 1)
			{
				anim = (byte) 2;
			}
			else if (C_Types.Player[index].Pet.Steps == 2)
			{
				anim = (byte) 3;
			}
			
			// Check for attacking animation
			if (C_Types.Player[index].Pet.AttackTimer + ((double) attackspeed / 2) > C_General.GetTickCount())
			{
				if (C_Types.Player[index].Pet.Attacking == 1)
				{
					anim = (byte) 3;
				}
			}
			else
			{
				// If not attacking, walk normally
				switch (C_Types.Player[index].Pet.Dir)
				{
					case (int) Enums.DirectionType.Up:
						if (C_Types.Player[index].Pet.YOffset > 8)
						{
							anim = C_Types.Player[index].Pet.Steps;
						}
						break;
					case (int) Enums.DirectionType.Down:
						if (C_Types.Player[index].Pet.YOffset < -8)
						{
							anim = C_Types.Player[index].Pet.Steps;
						}
						break;
					case (int) Enums.DirectionType.Left:
						if (C_Types.Player[index].Pet.XOffset > 8)
						{
							anim = C_Types.Player[index].Pet.Steps;
						}
						break;
					case (int) Enums.DirectionType.Right:
						if (C_Types.Player[index].Pet.XOffset < -8)
						{
							anim = C_Types.Player[index].Pet.Steps;
						}
						break;
				}
			}
			
			// Check to see if we want to stop making him attack
			ref var with_1 = ref C_Types.Player[index].Pet;
			if (System.Convert.ToInt32(with_1.AttackTimer + attackspeed) < C_General.GetTickCount())
			{
				with_1.Attacking = 0;
				with_1.AttackTimer = 0;
			}
			
			// Set the left
			switch (C_Types.Player[index].Pet.Dir)
			{
				case (int) Enums.DirectionType.Up:
					spriteleft = 3;
					break;
				case (int) Enums.DirectionType.Right:
					spriteleft = 2;
					break;
				case (int) Enums.DirectionType.Down:
					spriteleft = 0;
					break;
				case (int) Enums.DirectionType.Left:
					spriteleft = 1;
					break;
			}
			
			srcrec = new Rectangle(System.Convert.ToInt32((anim) * ((double) C_Graphics.CharacterGfxInfo[sprite].Width / 4)), System.Convert.ToInt32(spriteleft * ((double) C_Graphics.CharacterGfxInfo[sprite].Height / 4)), System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[sprite].Width / 4), System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[sprite].Height / 4));
			
			// Calculate the X
			x = System.Convert.ToInt32(C_Types.Player[index].Pet.X * C_Constants.PicX + C_Types.Player[index].Pet.XOffset - (((double) C_Graphics.CharacterGfxInfo[sprite].Width / 4 - 32) / 2));
			
			// Is the player's height more than 32..
			if (((double) C_Graphics.CharacterGfxInfo[sprite].Height / 4) > 32)
			{
				// Create a 32 pixel offset for larger sprites
				y = System.Convert.ToInt32(C_Types.Player[index].Pet.Y * C_Constants.PicY + C_Types.Player[index].Pet.YOffset - (((double) C_Graphics.CharacterGfxInfo[sprite].Width / 4) - 32));
			}
			else
			{
				// Proceed as normal
				y = C_Types.Player[index].Pet.Y * C_Constants.PicY + C_Types.Player[index].Pet.YOffset;
			}
			
			// render the actual sprite
			C_Graphics.DrawCharacter(sprite, x, y, srcrec);
			
		}
		
		internal static void DrawPlayerPetName(int index)
		{
			int textX = 0;
			int textY = 0;
			SFML.Graphics.Color color = new SFML.Graphics.Color();
			SFML.Graphics.Color backcolor = new SFML.Graphics.Color();
			string name = "";
			
			// Check access level
			if (C_Player.GetPlayerPk(index) == 0)
			{
				
				switch (C_Player.GetPlayerAccess(index))
				{
					case 0:
						color = SFML.Graphics.Color.Red;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case 1:
						color = SFML.Graphics.Color.Black;
						backcolor = SFML.Graphics.Color.White;
						break;
					case 2:
						color = SFML.Graphics.Color.Cyan;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case 3:
						color = SFML.Graphics.Color.Green;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case 4:
						color = SFML.Graphics.Color.Yellow;
						backcolor = SFML.Graphics.Color.Black;
						break;
				}
			}
			else
			{
				color = SFML.Graphics.Color.Red;
			}
			
			name = C_Player.GetPlayerName(index).Trim() + "'s " + Microsoft.VisualBasic.Strings.Trim(Pet[C_Types.Player[index].Pet.Num].Name);
			// calc pos
			textX = System.Convert.ToInt32(C_Graphics.ConvertMapX(C_Types.Player[index].Pet.X * C_Constants.PicX) + C_Types.Player[index].Pet.XOffset + (C_Constants.PicX / 2) - (double) C_Text.GetTextWidth(name) / 2);
			if (Pet[C_Types.Player[index].Pet.Num].Sprite < 1 || Pet[C_Types.Player[index].Pet.Num].Sprite > C_Graphics.NumCharacters)
			{
				textY = C_Graphics.ConvertMapY(C_Types.Player[index].Pet.Y * C_Constants.PicY) + C_Types.Player[index].Pet.YOffset - 16;
			}
			else
			{
				// Determine location for text
				textY = System.Convert.ToInt32(C_Graphics.ConvertMapY(C_Types.Player[index].Pet.Y * C_Constants.PicY) + C_Types.Player[index].Pet.YOffset - ((double) C_Graphics.CharacterGfxInfo[Pet[C_Types.Player[index].Pet.Num].Sprite].Height / 4) + 16);
			}
			
			// Draw name
			C_Text.DrawText(textX, textY, name.Trim(), color, backcolor, C_Graphics.GameWindow);
			
		}
		
		public static void DrawPetBar()
		{
			int skillnum = 0;
			int skillpic = 0;
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			
			if (!HasPet(C_Variables.Myindex))
			{
				return;
			}
			
			if (!PetAlive(C_Variables.Myindex))
			{
				C_Graphics.RenderSprite(C_Graphics.PetBarSprite, C_Graphics.GameWindow, C_UpdateUI.PetbarX, C_UpdateUI.PetbarY, 0, 0, 32, C_Graphics.PetbarGfxInfo.Height);
			}
			else
			{
				C_Graphics.RenderSprite(C_Graphics.PetBarSprite, C_Graphics.GameWindow, C_UpdateUI.PetbarX, C_UpdateUI.PetbarY, 0, 0, C_Graphics.PetbarGfxInfo.Width, C_Graphics.PetbarGfxInfo.Height);
				
				for (var i = 1; i <= 4; i++)
				{
					skillnum = System.Convert.ToInt32(C_Types.Player[C_Variables.Myindex].Pet.Skill[(int) i]);
					
					if (skillnum > 0)
					{
						skillpic = Types.Skill[skillnum].Icon;
						
						if (C_Graphics.SkillIconsGfxInfo[skillpic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(skillpic, (byte) 9);
						}
						
						//seeying we still use it, lets update timer
						ref var with_1 = ref C_Graphics.SkillIconsGfxInfo[skillpic];
						with_1.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = 32;
						rec.X = 0;
						rec.Width = 32;
						
						if (!(PetSkillCd[(int) i] == 0))
						{
							rec.X = 32;
							rec.Width = 32;
						}
						
						recPos.Y = C_UpdateUI.PetbarY + PetbarTop;
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.PetbarX + PetbarLeft + ((PetbarOffsetX - 2) + 32) * ((i - 1) + 3);
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.SkillIconsSprite[skillpic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
					}
				}
			}
			
		}
		
		public static void DrawPetStats()
		{
			int sprite = 0;
			Rectangle rec = new Rectangle();
			
			if (!HasPet(C_Variables.Myindex))
			{
				return;
			}
			
			if (!ShowPetStats)
			{
				return;
			}
			
			//draw panel
			C_Graphics.RenderSprite(C_Graphics.PetStatsSprite, C_Graphics.GameWindow, C_UpdateUI.PetStatX, C_UpdateUI.PetStatY, 0, 0, C_Graphics.PetStatsGfxInfo.Width, C_Graphics.PetStatsGfxInfo.Height);
			
			//lets get player sprite to render
			sprite = Pet[C_Types.Player[C_Variables.Myindex].Pet.Num].Sprite;
			
			rec.Y = 0;
			rec.Height = System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[sprite].Height / 4);
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[sprite].Width / 4);
			
			string petname = Microsoft.VisualBasic.Strings.Trim(Pet[C_Types.Player[C_Variables.Myindex].Pet.Num].Name);
			
			C_Text.DrawText(C_UpdateUI.PetStatX + 70, C_UpdateUI.PetStatY + 10, petname + " Lvl: " + System.Convert.ToString(C_Types.Player[C_Variables.Myindex].Pet.Level), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			
			C_Graphics.RenderSprite(C_Graphics.CharacterSprite[sprite], C_Graphics.GameWindow, C_UpdateUI.PetStatX + 10, System.Convert.ToInt32(C_UpdateUI.PetStatY + 10 + ((double) C_Graphics.PetStatsGfxInfo.Height / 4) - ((double) rec.Height / 2)), rec.X, rec.Y, rec.Width, rec.Height);
			
			//stats
			C_Text.DrawText(C_UpdateUI.PetStatX + 65, C_UpdateUI.PetStatY + 50, "Strength: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Strength], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			C_Text.DrawText(C_UpdateUI.PetStatX + 65, C_UpdateUI.PetStatY + 65, "Endurance: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Endurance], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			C_Text.DrawText(C_UpdateUI.PetStatX + 65, C_UpdateUI.PetStatY + 80, "Vitality: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Vitality], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			
			C_Text.DrawText(C_UpdateUI.PetStatX + 165, C_UpdateUI.PetStatY + 50, "Luck: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Luck], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			C_Text.DrawText(C_UpdateUI.PetStatX + 165, C_UpdateUI.PetStatY + 65, "Intelligence: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Intelligence], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			C_Text.DrawText(C_UpdateUI.PetStatX + 165, C_UpdateUI.PetStatY + 80, "Spirit: " + C_Types.Player[C_Variables.Myindex].Pet.Stat[(byte)Enums.StatType.Spirit], SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			
			C_Text.DrawText(C_UpdateUI.PetStatX + 65, C_UpdateUI.PetStatY + 95, "Experience: " + System.Convert.ToString(C_Types.Player[C_Variables.Myindex].Pet.Exp) + "/" + System.Convert.ToString(C_Types.Player[C_Variables.Myindex].Pet.Tnl), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
		}
		
#endregion
		
#region Misc
		
		internal static bool PetAlive(int index)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (C_Types.Player[index].Pet.Alive == 1)
			{
				return true;
			}
			
			return returnValue;
		}
		
		internal static bool HasPet(int index)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (C_Types.Player[index].Pet.Num > 0)
			{
				return true;
			}
			return returnValue;
		}
		
		internal static int IsPetBarSlot(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= MaxPetbar; i++)
			{
				
				tempRec.Top = C_UpdateUI.PetbarY + PetbarTop;
				tempRec.Bottom = tempRec.Top + C_Constants.PicY;
				tempRec.Left = C_UpdateUI.PetbarX + PetbarLeft + ((PetbarOffsetX + 32) * ((i - 1) % MaxPetbar));
				tempRec.Right = tempRec.Left + C_Constants.PicX;
				
				if (x >= tempRec.Left && x <= tempRec.Right)
				{
					if (y >= tempRec.Top && y <= tempRec.Bottom)
					{
						return i;
						
					}
				}
			}
			
			return returnValue;
		}
		
#endregion
		
	}
}
