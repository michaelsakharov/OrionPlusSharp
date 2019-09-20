
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using ASFW;
using Engine;


namespace Engine
{
	sealed class C_Player
	{
		
		public static bool IsPlaying(int index)
		{
			
			// if the player doesn't exist, the name will equal 0
			if (GetPlayerName(index).Length > 0)
			{
				return true;
			}
            return false;
		}
		
		public static string GetPlayerName(int index)
		{
			string returnValue = "";
			returnValue = "";
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return Microsoft.VisualBasic.Strings.Trim(C_Types.Player[index].Name);
		}
		
		public static void CheckAttack()
		{
			int attackspeed = 0;
			int x = 0;
			int y = 0;
			ByteStream buffer = new ByteStream(4);
			
			if (C_UpdateUI.VbKeyControl)
			{
				if (C_EventSystem.InEvent == true)
				{
					return;
				}
				if (C_Variables.SkillBuffer > 0)
				{
					return; // currently casting a skill, can't attack
				}
				if (C_Variables.StunDuration > 0)
				{
					return; // stunned, can't attack
				}
				
				// speed from weapon
				if (GetPlayerEquipment(C_Variables.Myindex, Enums.EquipmentType.Weapon) > 0)
				{
					attackspeed = Types.Item[GetPlayerEquipment(C_Variables.Myindex, Enums.EquipmentType.Weapon)].Speed * 1000;
				}
				else
				{
					attackspeed = 1000;
				}
				
				if (C_Types.Player[C_Variables.Myindex].AttackTimer + attackspeed < C_General.GetTickCount())
				{
					if (C_Types.Player[C_Variables.Myindex].Attacking == 0)
					{
						
						ref var with_1 = ref C_Types.Player[C_Variables.Myindex];
						with_1.Attacking = (byte) 1;
						with_1.AttackTimer = C_General.GetTickCount();
						
						C_NetworkSend.SendAttack();
					}
				}
				
				if (C_Types.Player[C_Variables.Myindex].Dir == (byte)Enums.DirectionType.Up)
				{
					x = GetPlayerX(C_Variables.Myindex);
					y = GetPlayerY(C_Variables.Myindex) - 1;
				}
				else if (C_Types.Player[C_Variables.Myindex].Dir == (byte)Enums.DirectionType.Down)
				{
					x = GetPlayerX(C_Variables.Myindex);
					y = GetPlayerY(C_Variables.Myindex) + 1;
				}
				else if (C_Types.Player[C_Variables.Myindex].Dir == (byte)Enums.DirectionType.Left)
				{
					x = GetPlayerX(C_Variables.Myindex) - 1;
					y = GetPlayerY(C_Variables.Myindex);
				}
				else if (C_Types.Player[C_Variables.Myindex].Dir == (byte)Enums.DirectionType.Right)
				{
					x = GetPlayerX(C_Variables.Myindex) + 1;
					y = GetPlayerY(C_Variables.Myindex);
				}
				
				if (C_General.GetTickCount() > C_Types.Player[C_Variables.Myindex].EventTimer)
				{
					for (var i = 1; i <= C_Maps.Map.CurrentEvents; i++)
					{
						if (C_Maps.Map.MapEvents[(int) i].Visible == 1)
						{
							if (C_Maps.Map.MapEvents[(int) i].X == x && C_Maps.Map.MapEvents[(int) i].Y == y)
							{
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEvent);
								buffer.WriteInt32(System.Convert.ToInt32(i));
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_Types.Player[C_Variables.Myindex].EventTimer = C_General.GetTickCount() + 200;
							}
						}
					}
				}
			}
			
		}
		
		public static void CheckMovement()
		{
			
			if (IsTryingToMove() && CanMove())
			{
				// Check if player has the shift key down for running
				if (C_UpdateUI.VbKeyShift)
				{
					C_Types.Player[C_Variables.Myindex].Moving = (byte)Enums.MovementType.Running;
				}
				else
				{
					C_Types.Player[C_Variables.Myindex].Moving = (byte)Enums.MovementType.Walking;
				}
				
				if (C_Maps.Map.Tile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].Type == (byte)Enums.TileType.Door)
				{
					C_Maps.TempTile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].DoorFrame = 1;
					C_Maps.TempTile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].DoorAnimate = 1; // 0 = nothing| 1 = opening | 2 = closing
                    C_Maps.TempTile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].DoorTimer = C_General.GetTickCount();
				}
				
				switch (GetPlayerDir(C_Variables.Myindex))
				{
					case (int) Enums.DirectionType.Up:
						C_NetworkSend.SendPlayerMove();
						C_Types.Player[C_Variables.Myindex].YOffset = C_Constants.PicY;
						SetPlayerY(C_Variables.Myindex, GetPlayerY(C_Variables.Myindex) - 1);
						break;
					case (int) Enums.DirectionType.Down:
						C_NetworkSend.SendPlayerMove();
						C_Types.Player[C_Variables.Myindex].YOffset = C_Constants.PicY * -1;
						SetPlayerY(C_Variables.Myindex, GetPlayerY(C_Variables.Myindex) + 1);
						break;
					case (int) Enums.DirectionType.Left:
						C_NetworkSend.SendPlayerMove();
						C_Types.Player[C_Variables.Myindex].XOffset = C_Constants.PicX;
						SetPlayerX(C_Variables.Myindex, GetPlayerX(C_Variables.Myindex) - 1);
						break;
					case (int) Enums.DirectionType.Right:
						C_NetworkSend.SendPlayerMove();
						C_Types.Player[C_Variables.Myindex].XOffset = C_Constants.PicX * -1;
						SetPlayerX(C_Variables.Myindex, GetPlayerX(C_Variables.Myindex) + 1);
						break;
				}
				
				if (C_Types.Player[C_Variables.Myindex].XOffset == 0 && C_Types.Player[C_Variables.Myindex].YOffset == 0)
				{
					if (C_Maps.Map.Tile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].Type == (byte)Enums.TileType.Warp)
					{
						C_Variables.GettingMap = true;
					}
				}
				
			}
		}
		
		public static bool IsTryingToMove()
		{
			
			if (C_Variables.DirUp || C_Variables.DirDown || C_Variables.DirLeft || C_Variables.DirRight)
			{
				return true;
			}
            return false;
			
		}
		
		public static bool CanMove()
		{
			bool returnValue = false;
			int d = 0;
			returnValue = true;
			
			if (C_EventSystem.HoldPlayer == true)
			{
				return false;
				
			}
			
			if (C_Variables.GettingMap == true)
			{
				return false;
				
			}
			
			// Make sure they aren't trying to move when they are already moving
			if (C_Types.Player[C_Variables.Myindex].Moving != 0)
			{
				return false;
				
			}
			
			// Make sure they haven't just casted a skill
			if (C_Variables.SkillBuffer > 0)
			{
				return false;
				
			}
			
			// make sure they're not stunned
			if (C_Variables.StunDuration > 0)
			{
				return false;
				
			}
			
			if (C_EventSystem.InEvent)
			{
				return false;
				
			}
			
			// craft
			if (C_Crafting.InCraft)
			{
				return false;
				
			}
			
			// make sure they're not in a shop
			if (C_Shops.InShop > 0)
			{
				return false;
				
			}
			
			if (C_Trade.InTrade)
			{
				return false;
				
			}
			
			// not in bank
			if (C_Banks.InBank > 0)
			{
				return false;
				
			}
			
			d = GetPlayerDir(C_Variables.Myindex);
			
			if (C_Variables.DirUp)
			{
				SetPlayerDir(C_Variables.Myindex, (System.Int32) Enums.DirectionType.Up);
				
				// Check to see if they are trying to go out of bounds
				if (GetPlayerY(C_Variables.Myindex) > 0)
				{
					if (CheckDirection((byte)Enums.DirectionType.Up))
					{
						returnValue = false;
						
						// Set the new direction if they weren't facing that direction
						if (d != (int) Enums.DirectionType.Up)
						{
							C_NetworkSend.SendPlayerDir();
						}
						
						return returnValue;
					}
				}
				else
				{
					
					// Check if they can warp to a new map
					if (C_Maps.Map.Up > 0)
					{
						C_Maps.SendPlayerRequestNewMap();
						C_Variables.GettingMap = true;
						C_Variables.CanMoveNow = false;
					}
					
					return false;
					
				}
			}
			
			if (C_Variables.DirDown)
			{
				SetPlayerDir(C_Variables.Myindex, (System.Int32) Enums.DirectionType.Down);
				
				// Check to see if they are trying to go out of bounds
				if (GetPlayerY(C_Variables.Myindex) < C_Maps.Map.MaxY)
				{
					if (CheckDirection((byte)Enums.DirectionType.Down))
					{
						returnValue = false;
						
						// Set the new direction if they weren't facing that direction
						if (d != (int) Enums.DirectionType.Down)
						{
							C_NetworkSend.SendPlayerDir();
						}
						
						return returnValue;
					}
				}
				else
				{
					
					// Check if they can warp to a new map
					if (C_Maps.Map.Down > 0)
					{
						C_Maps.SendPlayerRequestNewMap();
						C_Variables.GettingMap = true;
						C_Variables.CanMoveNow = false;
					}
					
					return false;
					
				}
			}
			
			if (C_Variables.DirLeft)
			{
				SetPlayerDir(C_Variables.Myindex, (System.Int32) Enums.DirectionType.Left);
				
				// Check to see if they are trying to go out of bounds
				if (GetPlayerX(C_Variables.Myindex) > 0)
				{
					if (CheckDirection((byte)Enums.DirectionType.Left))
					{
						returnValue = false;
						
						// Set the new direction if they weren't facing that direction
						if (d != (int) Enums.DirectionType.Left)
						{
							C_NetworkSend.SendPlayerDir();
						}
						
						return returnValue;
					}
				}
				else
				{
					
					// Check if they can warp to a new map
					if (C_Maps.Map.Left > 0)
					{
						C_Maps.SendPlayerRequestNewMap();
						C_Variables.GettingMap = true;
						C_Variables.CanMoveNow = false;
					}
					
					return false;
					
				}
			}
			
			if (C_Variables.DirRight)
			{
				SetPlayerDir(C_Variables.Myindex, (System.Int32) Enums.DirectionType.Right);
				
				// Check to see if they are trying to go out of bounds
				if (GetPlayerX(C_Variables.Myindex) < C_Maps.Map.MaxX)
				{
					if (CheckDirection((byte)Enums.DirectionType.Right))
					{
						returnValue = false;
						
						// Set the new direction if they weren't facing that direction
						if (d != (int) Enums.DirectionType.Right)
						{
							C_NetworkSend.SendPlayerDir();
						}
						
						return returnValue;
					}
				}
				else
				{
					
					// Check if they can warp to a new map
					if (C_Maps.Map.Right > 0)
					{
						C_Maps.SendPlayerRequestNewMap();
						C_Variables.GettingMap = true;
						C_Variables.CanMoveNow = false;
					}
					
					return false;
					
				}
			}
			
			return returnValue;
		}
		
		public static bool CheckDirection(byte direction)
		{
			bool returnValue = false;
			int x = 0;
			int y = 0;
			int i = 0;
			int z;
			
			returnValue = false;
			
			// check directional blocking
			if (C_GameLogic.IsDirBlocked(C_Maps.Map.Tile[GetPlayerX(C_Variables.Myindex), GetPlayerY(C_Variables.Myindex)].DirBlock, (byte) (direction + 1)))
			{
				return true;
				
			}
			
			if (direction == (byte)Enums.DirectionType.Up)
			{
				x = GetPlayerX(C_Variables.Myindex);
				y = GetPlayerY(C_Variables.Myindex) - 1;
			}
			else if (direction == (byte)Enums.DirectionType.Down)
			{
				x = GetPlayerX(C_Variables.Myindex);
				y = GetPlayerY(C_Variables.Myindex) + 1;
			}
			else if (direction == (byte)Enums.DirectionType.Left)
			{
				x = GetPlayerX(C_Variables.Myindex) - 1;
				y = GetPlayerY(C_Variables.Myindex);
			}
			else if (direction == (byte)Enums.DirectionType.Right)
			{
				x = GetPlayerX(C_Variables.Myindex) + 1;
				y = GetPlayerY(C_Variables.Myindex);
			}
			
			// Check to see if the map tile is blocked or not
			if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Blocked)
			{
				return true;
				
			}
			
			// Check to see if the map tile is tree or not
			if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Resource)
			{
				return true;
				
			}
			
			// Check to see if the key door is open or not
			if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Key)
			{
				// This actually checks if its open or not
				if (C_Maps.TempTile[x, y].DoorOpen == 0)
				{
					return true;
					
				}
			}
			
			if (C_Housing.FurnitureHouse > 0 && C_Housing.FurnitureHouse == C_Types.Player[C_Variables.Myindex].InHouse)
			{
				if (C_Housing.FurnitureCount > 0)
				{
					for (i = 1; i <= C_Housing.FurnitureCount; i++)
					{
						if (Types.Item[C_Housing.Furniture[i].ItemNum].Data3 == 0)
						{
							if (x >= C_Housing.Furniture[i].X && x <= C_Housing.Furniture[i].X + Types.Item[C_Housing.Furniture[i].ItemNum].FurnitureWidth - 1)
							{
								if (y <= C_Housing.Furniture[i].Y && y >= C_Housing.Furniture[i].Y - Types.Item[C_Housing.Furniture[i].ItemNum].FurnitureHeight)
								{
									z = System.Convert.ToInt32(Types.Item[C_Housing.Furniture[i].ItemNum].FurnitureBlocks[x - C_Housing.Furniture[i].X, ((C_Housing.Furniture[i].Y - y) * -1) + Types.Item[C_Housing.Furniture[i].ItemNum].FurnitureHeight]);
									if (z == 1)
									{
										return true;
										
									}
								}
							}
						}
					}
				}
			}
			
			// Check to see if a player is already on that tile
			for (i = 1; i <= Constants.MAX_PLAYERS; i++)
			{
				if (IsPlaying(i) && GetPlayerMap(i) == GetPlayerMap(C_Variables.Myindex))
				{
					if (C_Types.Player[i].InHouse == C_Types.Player[C_Variables.Myindex].InHouse)
					{
						if (GetPlayerX(i) == x)
						{
							if (GetPlayerY(i) == y)
							{
								return true;
								
							}
							else if (C_Types.Player[i].Pet.X == x && C_Types.Player[i].Pet.Alive == 1)
							{
								if (C_Types.Player[i].Pet.Y == y)
								{
									return true;
									
								}
							}
						}
						else if (C_Types.Player[i].Pet.X == x && C_Types.Player[i].Pet.Y == y && C_Types.Player[i].Pet.Alive == 1)
						{
							return true;
							
						}
					}
				}
			}
			
			// Check to see if a npc is already on that tile
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				if (C_Maps.MapNpc[i].Num > 0 && C_Maps.MapNpc[i].X == x && C_Maps.MapNpc[i].Y == y)
				{
					return true;
					
				}
			}
			
			for (i = 1; i <= C_Maps.Map.CurrentEvents; i++)
			{
				if (C_Maps.Map.MapEvents[i].Visible == 1)
				{
					if (C_Maps.Map.MapEvents[i].X == x && C_Maps.Map.MapEvents[i].Y == y)
					{
						if (C_Maps.Map.MapEvents[i].WalkThrough == 0)
						{
							return true;
							
						}
					}
				}
			}
			
			return returnValue;
		}
		
		public static void ProcessMovement(int index)
		{
			int movementSpeed = 0;
			
			// Check if player is walking, and if so process moving them over
			if (C_Types.Player[index].Moving == (byte)Enums.MovementType.Walking)
			{
				movementSpeed = (int)(((double) C_Variables.ElapsedTime / 1000) * (C_Constants.WalkSpeed * C_Constants.SizeX));
			}
			else if (C_Types.Player[index].Moving == (byte)Enums.MovementType.Running)
			{
				movementSpeed = (int)(((double) C_Variables.ElapsedTime / 1000) * (C_Constants.RunSpeed * C_Constants.SizeX));
			}
			else
			{
				return;
			}
			
			switch (GetPlayerDir(index))
			{
				case (int) Enums.DirectionType.Up:
					C_Types.Player[index].YOffset = C_Types.Player[index].YOffset - movementSpeed;
					if (C_Types.Player[index].YOffset < 0)
					{
						C_Types.Player[index].YOffset = 0;
					}
					break;
				case (int) Enums.DirectionType.Down:
					C_Types.Player[index].YOffset = C_Types.Player[index].YOffset + movementSpeed;
					if (C_Types.Player[index].YOffset > 0)
					{
						C_Types.Player[index].YOffset = 0;
					}
					break;
				case (int) Enums.DirectionType.Left:
					C_Types.Player[index].XOffset = C_Types.Player[index].XOffset - movementSpeed;
					if (C_Types.Player[index].XOffset < 0)
					{
						C_Types.Player[index].XOffset = 0;
					}
					break;
				case (int) Enums.DirectionType.Right:
					C_Types.Player[index].XOffset = C_Types.Player[index].XOffset + movementSpeed;
					if (C_Types.Player[index].XOffset > 0)
					{
						C_Types.Player[index].XOffset = 0;
					}
					break;
			}
			
			// Check if completed walking over to the next tile
			if (C_Types.Player[index].Moving > 0)
			{
				if (GetPlayerDir(index) == (int) Enums.DirectionType.Right || GetPlayerDir(index) == (int) Enums.DirectionType.Down)
				{
					if ((C_Types.Player[index].XOffset >= 0) && (C_Types.Player[index].YOffset >= 0))
					{
						C_Types.Player[index].Moving = (byte) 0;
						if (C_Types.Player[index].Steps == 1)
						{
							C_Types.Player[index].Steps = (byte) 3;
						}
						else
						{
							C_Types.Player[index].Steps = (byte) 1;
						}
					}
				}
				else
				{
					if ((C_Types.Player[index].XOffset <= 0) && (C_Types.Player[index].YOffset <= 0))
					{
						C_Types.Player[index].Moving = (byte) 0;
						if (C_Types.Player[index].Steps == 1)
						{
							C_Types.Player[index].Steps = (byte) 3;
						}
						else
						{
							C_Types.Player[index].Steps = (byte) 1;
						}
					}
				}
			}
			
		}
		
		public static int GetPlayerDir(int index)
		{
			
			if (index > Constants.MAX_PLAYERS)
			{
				return 0;
			}
			return C_Types.Player[index].Dir;
		}
		
		public static int GetPlayerGatherSkillLvl(int index, int skillSlot)
		{
			int returnValue = 0;
			
			returnValue = 0;
			
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			
			return C_Types.Player[index].GatherSkills[skillSlot].SkillLevel;
		}
		
		public static int GetPlayerGatherSkillExp(int index, int skillSlot)
		{
			int returnValue = 0;
			
			returnValue = 0;
			
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			
			return C_Types.Player[index].GatherSkills[skillSlot].SkillCurExp;
		}
		
		public static int GetPlayerGatherSkillMaxExp(int index, int skillSlot)
		{
			int returnValue = 0;
			
			returnValue = 0;
			
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			
			return C_Types.Player[index].GatherSkills[skillSlot].SkillNextLvlExp;
		}
		
		internal static void PlayerCastSkill(int skillslot)
		{
			ByteStream buffer = new ByteStream(4);
			
			// Check for subscript out of range
			if (skillslot < 1 || skillslot > Constants.MAX_PLAYER_SKILLS)
			{
				return;
			}
			
			if (C_Variables.SkillCd[skillslot] > 0)
			{
				C_Text.AddText("Skill has not cooled down yet!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			// Check if player has enough MP
			if (GetPlayerVital(C_Variables.Myindex, Enums.VitalType.MP) < Types.Skill[C_Variables.PlayerSkills[skillslot]].MpCost)
			{
				C_Text.AddText("Not enough MP to cast " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[C_Variables.PlayerSkills[skillslot]].Name) +".", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (C_Variables.PlayerSkills[skillslot] > 0)
			{
				if (C_General.GetTickCount() > C_Types.Player[C_Variables.Myindex].AttackTimer + 1000)
				{
					if (C_Types.Player[C_Variables.Myindex].Moving == 0)
					{
						buffer.WriteInt32((System.Int32) Packets.ClientPackets.CCast);
						buffer.WriteInt32(skillslot);
						
						C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
						buffer.Dispose();
						
						C_Variables.SkillBuffer = skillslot;
						C_Variables.SkillBufferTimer = C_General.GetTickCount();
					}
					else
					{
						C_Text.AddText("Cannot cast while walking!", (System.Int32) Enums.QColorType.AlertColor);
					}
				}
			}
			else
			{
				C_Text.AddText("No skill here.", (System.Int32) Enums.QColorType.AlertColor);
			}
			
		}
		
		public static void SetPlayerMap(int index, int mapNum)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Map = mapNum;
		}
		
		public static int GetPlayerInvItemNum(int index, int invslot)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			if (invslot == 0)
			{
				return returnValue;
			}
			return C_Variables.PlayerInv[invslot].Num;
		}
		
		public static void SetPlayerName(int index, string name)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Name = name;
		}
		
		public static void SetPlayerClass(int index, int classnum)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Classes = (byte) classnum;
		}
		
		public static void SetPlayerPoints(int index, int points)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Points = points;
		}
		
		public static void SetPlayerStat(int index, Enums.StatType stat, int value)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			if (value <= 0)
			{
				value = 1;
			}
			if (value > byte.MaxValue)
			{
				value = byte.MaxValue;
			}
			C_Types.Player[index].Stat[(int)stat] = value;
		}
		
		public static void SetPlayerInvItemNum(int index, int invslot, int itemnum)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Variables.PlayerInv[invslot].Num = itemnum;
		}
		
		public static int GetPlayerInvItemValue(int index, int invslot)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Variables.PlayerInv[invslot].Value;
		}
		
		public static void SetPlayerInvItemValue(int index, int invslot, int itemValue)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Variables.PlayerInv[invslot].Value = itemValue;
		}
		
		public static int GetPlayerPoints(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Points;
		}
		
		public static void SetPlayerAccess(int index, int access)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Access = (byte) access;
		}
		
		public static void SetPlayerPk(int index, int pk)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Pk = (byte) pk;
		}
		
		public static void SetPlayerVital(int index, Enums.VitalType vital, int value)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Vital[(int)vital] = value;
			
			if (GetPlayerVital(index, vital) > GetPlayerMaxVital(index, vital))
			{
				C_Types.Player[index].Vital[(int)vital] = GetPlayerMaxVital(index, vital);
			}
		}
		
		public static int GetPlayerMaxVital(int index, Enums.VitalType vital)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			
			switch (vital)
			{
				case Enums.VitalType.HP:
					return C_Types.Player[index].MaxHp;
					break;
				case Enums.VitalType.MP:
					return C_Types.Player[index].MaxMp;
					break;
				case Enums.VitalType.SP:
					return C_Types.Player[index].MaxSp;
					break;
			}
			
			return returnValue;
		}
		
		public static void SetPlayerX(int index, int x)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].X = (byte) x;
		}
		
		public static void SetPlayerY(int index, int y)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Y = (byte) y;
		}
		
		public static void SetPlayerSprite(int index, int sprite)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Sprite = sprite;
		}
		
		public static void SetPlayerExp(int index, int exp)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Exp = exp;
		}
		
		public static void SetPlayerLevel(int index, int level)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Level = level;
		}
		
		public static void SetPlayerDir(int index, int dir)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Dir = (byte) dir;
		}
		
		public static int GetPlayerVital(int index, Enums.VitalType vital)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return System.Convert.ToInt32(C_Types.Player[index].Vital[(int)vital]);
		}
		
		public static int GetPlayerSprite(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Sprite;
		}
		
		public static int GetPlayerClass(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Classes;
		}
		
		public static int GetPlayerMap(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Map;
		}
		
		public static int GetPlayerLevel(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Level;
		}
		
		public static byte GetPlayerEquipment(int index, Enums.EquipmentType equipmentSlot)
		{
			byte returnValue = 0;
			returnValue = (byte) 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return System.Convert.ToByte(C_Types.Player[index].Equipment[(int)equipmentSlot]);
		}
		
		public static int GetPlayerStat(int index, Enums.StatType stat)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return System.Convert.ToInt32(C_Types.Player[index].Stat[(int)stat]);
		}
		
		public static int GetPlayerExp(int index)
		{
			if (index > Constants.MAX_PLAYERS)
			{
				return 0;
			}
			return C_Types.Player[index].Exp;
		}
		
		public static int GetPlayerX(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].X;
		}
		
		public static int GetPlayerY(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Y;
		}
		
		public static int GetPlayerAccess(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Access;
		}
		
		public static int GetPlayerPk(int index)
		{
			int returnValue = 0;
			returnValue = 0;
			if (index > Constants.MAX_PLAYERS)
			{
				return returnValue;
			}
			return C_Types.Player[index].Pk;
		}
		
		public static void SetPlayerEquipment(int index, int invNum, Enums.EquipmentType equipmentSlot)
		{
			if (index < 1 || index > Constants.MAX_PLAYERS)
			{
				return;
			}
			C_Types.Player[index].Equipment[(int)equipmentSlot] = invNum;
		}
		
		public static void ClearPlayer(int index)
		{
			C_Types.Player[index].Name = "";
			C_Types.Player[index].Access = (byte) 0;
			C_Types.Player[index].Attacking = (byte) 0;
			C_Types.Player[index].AttackTimer = 0;
			C_Types.Player[index].Classes = (byte) 0;
			C_Types.Player[index].Dir = (byte) 0;
			
			C_Types.Player[index].Equipment = new int[(int) Enums.EquipmentType.Count];
			for (var y = 1; y <= (int) Enums.EquipmentType.Count - 1; y++)
			{
				C_Types.Player[index].Equipment[(int) y] = 0;
			}
			
			C_Types.Player[index].Exp = 0;
			C_Types.Player[index].Level = 0;
			C_Types.Player[index].Map = 0;
			C_Types.Player[index].MapGetTimer = 0;
			C_Types.Player[index].MaxHp = 0;
			C_Types.Player[index].MaxMp = 0;
			C_Types.Player[index].MaxSp = 0;
			C_Types.Player[index].Moving = (byte) 0;
			C_Types.Player[index].Pk = (byte) 0;
			C_Types.Player[index].Points = 0;
			C_Types.Player[index].Sprite = 0;
			
			C_Types.Player[index].Stat = new int[(int)Enums.StatType.Count];
			for (var x = 1; x <= (int) Enums.StatType.Count - 1; x++)
			{
				C_Types.Player[index].Stat[(int) x] = 0;
			}
			
			C_Types.Player[index].Steps = (byte) 0;
			
			C_Types.Player[index].Vital = new int[(int) Enums.VitalType.Count];
			for (var i = 1; i <= (int) Enums.VitalType.Count - 1; i++)
			{
				C_Types.Player[index].Vital[(int) i] = 0;
			}
			
			C_Types.Player[index].X = (byte) 0;
			C_Types.Player[index].XOffset = 0;
			C_Types.Player[index].Y = (byte) 0;
			C_Types.Player[index].YOffset = 0;
			
			C_Types.Player[index].RandEquip = new Types.RandInvRec[(int) Enums.EquipmentType.Count];
			for (var y = 1; y <= (int) Enums.EquipmentType.Count - 1; y++)
			{
				C_Types.Player[index].RandEquip[(int) y].Stat = new int[(int) Enums.StatType.Count];
				for (var x = 1; x <= (int) Enums.StatType.Count - 1; x++)
				{
					C_Types.Player[index].RandEquip[(int) y].Stat[(int) x] = 0;
				}
			}
			
			C_Types.Player[index].RandInv = new Types.RandInvRec[Constants.MAX_INV + 1];
			for (var y = 1; y <= Constants.MAX_INV; y++)
			{
				C_Types.Player[index].RandInv[(int) y].Stat = new int[(int) Enums.StatType.Count];
				for (var x = 1; x <= (int) Enums.StatType.Count - 1; x++)
				{
					C_Types.Player[index].RandInv[(int) y].Stat[(int) x] = 0;
				}
			}
			
			C_Types.Player[index].PlayerQuest = new C_Quest.PlayerQuestRec[C_Quest.MaxQuests + 1];
			
			C_Types.Player[index].Hotbar = new C_HotBar.HotbarRec[C_HotBar.MaxHotbar + 1];
			
			C_Types.Player[index].GatherSkills = new Types.ResourceSkillsRec[(int) Enums.ResourceSkills.Count];
			
			C_Types.Player[index].RecipeLearned = new byte[Constants.MAX_RECIPE + 1];
			
			//pets
			C_Types.Player[index].Pet.Num = 0;
			C_Types.Player[index].Pet.Health = 0;
			C_Types.Player[index].Pet.Mana = 0;
			C_Types.Player[index].Pet.Level = 0;
			
			C_Types.Player[index].Pet.Stat = new byte[(int) Enums.StatType.Count];
			for (var i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				C_Types.Player[index].Pet.Stat[(int) i] = 0;
			}
			
			C_Types.Player[index].Pet.Skill = new int[5];
			for (var i = 1; i <= 4; i++)
			{
				C_Types.Player[index].Pet.Skill[(int) i] = 0;
			}
			
			C_Types.Player[index].Pet.X = 0;
			C_Types.Player[index].Pet.Y = 0;
			C_Types.Player[index].Pet.Dir = 0;
			C_Types.Player[index].Pet.MaxHp = 0;
			C_Types.Player[index].Pet.MaxMp = 0;
			C_Types.Player[index].Pet.Alive = (byte) 0;
			C_Types.Player[index].Pet.AttackBehaviour = 0;
			C_Types.Player[index].Pet.Exp = 0;
			C_Types.Player[index].Pet.Tnl = 0;
		}
		
	}
}
