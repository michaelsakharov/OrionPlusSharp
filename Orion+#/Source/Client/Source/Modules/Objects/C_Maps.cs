
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ASFW;
using ASFW.IO;
using Microsoft.VisualBasic.CompilerServices;
using System.Threading;
using Engine;


namespace Engine
{
	sealed class C_Maps
	{
		
#region Globals & Types
		
		internal static C_Types.MapRec Map;
		internal static object MapLock = new object();
		internal static C_Types.MapItemRec[] MapItem = new C_Types.MapItemRec[Constants.MAX_MAP_ITEMS + 1];
		internal static C_Types.MapNpcRec[] MapNpc = new C_Types.MapNpcRec[Constants.MAX_MAP_NPCS + 1];
		internal static C_Types.TempTileRec[,] TempTile;
		
#endregion
		
#region DataBase
		
		internal static void CheckTilesets()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "\\tilesets\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumTileSets++;
				i++;
			}
			
			if (C_Graphics.NumTileSets == 0)
			{
				return;
			}
		}
		
		public static void ClearMap()
		{
			
			lock(MapLock)
			{
				Map.Name = "";
				Map.Tileset = 1;
				Map.MaxX = C_Constants.ScreenMapx;
				Map.MaxY = C_Constants.ScreenMapy;
				Map.BootMap = 0;
				Map.BootX = (byte) 0;
				Map.BootY = (byte) 0;
				Map.Down = 0;
				Map.Left = 0;
				Map.Moral = (byte) 0;
				Map.Music = "";
				Map.Revision = 0;
				Map.Right = 0;
				Map.Up = 0;
				
				Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
				Map.Tile = new Types.TileRec[Map.MaxX + 1, Map.MaxY + 1];
				
				for (var x = 0; x <= C_Constants.ScreenMapx; x++)
				{
					for (var y = 0; y <= C_Constants.ScreenMapy; y++)
					{
						Map.Tile[(int) x, (int) y].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
						for (var l = 0; l <= (int) Enums.LayerType.Count - 1; l++)
						{
							Map.Tile[(int) x, (int) y].Layer[(int) l].Tileset = (byte) 0;
							Map.Tile[(int) x, (int) y].Layer[(int) l].X = (byte) 0;
							Map.Tile[(int) x, (int) y].Layer[(int) l].Y = (byte) 0;
							Map.Tile[(int) x, (int) y].Layer[(int) l].AutoTile = (byte) 0;
						}
						
					}
				}
				
			}
			
		}
		
		public static void ClearMapItems()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
			{
				ClearMapItem(i);
			}
			
		}
		
		public static void ClearMapItem(int index)
		{
			MapItem[index].Frame = (byte) 0;
			MapItem[index].Num = 0;
			MapItem[index].Value = 0;
			MapItem[index].X = (byte) 0;
			MapItem[index].Y = (byte) 0;
		}
		
		public static void ClearMapNpc(int index)
		{
			MapNpc[index].Attacking = (byte) 0;
			MapNpc[index].AttackTimer = 0;
			MapNpc[index].Dir = (byte) 0;
			MapNpc[index].Map = 0;
			MapNpc[index].Moving = (byte) 0;
			MapNpc[index].Num = 0;
			MapNpc[index].Steps = 0;
			MapNpc[index].Target = 0;
			MapNpc[index].TargetType = (byte) 0;
			MapNpc[index].Vital[(byte)Enums.VitalType.HP] = 0;
			MapNpc[index].Vital[(byte)Enums.VitalType.MP] = 0;
			MapNpc[index].Vital[(byte)Enums.VitalType.SP] = 0;
			MapNpc[index].X = (byte) 0;
			MapNpc[index].XOffset = 0;
			MapNpc[index].Y = (byte) 0;
			MapNpc[index].YOffset = 0;
		}
		
		public static void ClearMapNpcs()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				ClearMapNpc(i);
			}
			
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_EditMap(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_UpdateUI.InitMapEditor = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_CheckMap(ref byte[] data)
		{
			int x;
			int y;
			int i = 0;
			byte needMap = 0;
			ByteStream buffer = new ByteStream(data);
			C_Variables.GettingMap = true;
			
			// Erase all players except self
			for (i = 1; i <= C_Variables.TotalOnline; i++) //MAX_PLAYERS
			{
				if (i != C_Variables.Myindex)
				{
					C_Player.SetPlayerMap(i, 0);
				}
			}
			
			// Erase all temporary tile values
			C_GameLogic.ClearTempTile();
			ClearMapNpcs();
			ClearMapItems();
			C_DataBase.ClearBlood();
			ClearMap();
			
			// Get map num
			x = buffer.ReadInt32();
			// Get revision
			y = buffer.ReadInt32();
			
			needMap = (byte) 1;
			
			// Either the revisions didn't match or we dont have the map, so we need it
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CNeedMap);
			buffer.WriteInt32(needMap);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		public static void Packet_MapData(ref byte[] data)
		{
			int x = 0;
			int y = 0;
			int i = 0;
			int mapNum;
			ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));
			
			C_Variables.MapData = false;
			
			ClearMap();
			
			lock(MapLock)
			{
				if (buffer.ReadInt32() == 1)
				{
					
					mapNum = buffer.ReadInt32();
					Map.Name = buffer.ReadString().Trim();
					Map.Music = buffer.ReadString().Trim();
					Map.Revision = buffer.ReadInt32();
					Map.Moral = (byte) (buffer.ReadInt32());
					Map.Tileset = buffer.ReadInt32();
					Map.Up = buffer.ReadInt32();
					Map.Down = buffer.ReadInt32();
					Map.Left = buffer.ReadInt32();
					Map.Right = buffer.ReadInt32();
					Map.BootMap = buffer.ReadInt32();
					Map.BootX = (byte) (buffer.ReadInt32());
					Map.BootY = (byte) (buffer.ReadInt32());
					Map.MaxX = (byte) (buffer.ReadInt32());
					Map.MaxY = (byte) (buffer.ReadInt32());
					Map.WeatherType = (byte) (buffer.ReadInt32());
					Map.Fogindex = buffer.ReadInt32();
					Map.WeatherIntensity = buffer.ReadInt32();
					Map.FogAlpha = (byte) (buffer.ReadInt32());
					Map.FogSpeed = (byte) (buffer.ReadInt32());
					Map.HasMapTint = (byte) (buffer.ReadInt32());
					Map.MapTintR = (byte) (buffer.ReadInt32());
					Map.MapTintG = (byte) (buffer.ReadInt32());
					Map.MapTintB = (byte) (buffer.ReadInt32());
					Map.MapTintA = (byte) (buffer.ReadInt32());
					Map.Instanced = (byte) (buffer.ReadInt32());
					Map.Panorama = (byte) (buffer.ReadInt32());
					Map.Parallax = (byte) (buffer.ReadInt32());
					Map.Brightness = (byte) (buffer.ReadInt32());
					
					Map.Tile = new Types.TileRec[Map.MaxX + 1, Map.MaxY + 1];
					
					for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
					{
						Map.Npc[x] = buffer.ReadInt32();
					}
					
					for (x = 0; x <= Map.MaxX; x++)
					{
						for (y = 0; y <= Map.MaxY; y++)
						{
							Map.Tile[x, y].Data1 = buffer.ReadInt32();
							Map.Tile[x, y].Data2 = buffer.ReadInt32();
							Map.Tile[x, y].Data3 = buffer.ReadInt32();
							Map.Tile[x, y].DirBlock = (byte) (buffer.ReadInt32());
							
							Map.Tile[x, y].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
							
							for (i = 0; i <= (int) Enums.LayerType.Count - 1; i++)
							{
								Map.Tile[x, y].Layer[i].Tileset = (byte) (buffer.ReadInt32());
								Map.Tile[x, y].Layer[i].X = (byte) (buffer.ReadInt32());
								Map.Tile[x, y].Layer[i].Y = (byte) (buffer.ReadInt32());
								Map.Tile[x, y].Layer[i].AutoTile = (byte) (buffer.ReadInt32());
							}
							Map.Tile[x, y].Type = (byte) (buffer.ReadInt32());
						}
					}
					
					//Event Data!
					C_EventSystem.ResetEventdata();
					
					Map.EventCount = buffer.ReadInt32();
					
					if (Map.EventCount > 0)
					{
						Map.Events = new C_EventSystem.EventRec[Map.EventCount + 1];
						for (i = 1; i <= Map.EventCount; i++)
						{
							ref var with_1 = ref Map.Events[i];
							with_1.Name = buffer.ReadString().Trim();
							with_1.Globals = buffer.ReadInt32();
							with_1.X = buffer.ReadInt32();
							with_1.Y = buffer.ReadInt32();
							with_1.PageCount = buffer.ReadInt32();
							if (Map.Events[i].PageCount > 0)
							{
								Map.Events[i].Pages = new C_EventSystem.EventPageRec[Map.Events[i].PageCount + 1];
								for (x = 1; x <= Map.Events[i].PageCount; x++)
								{
									ref var with_2 = ref Map.Events[i].Pages[x];
									with_2.ChkVariable = buffer.ReadInt32();
									with_2.Variableindex = buffer.ReadInt32();
									with_2.VariableCondition = buffer.ReadInt32();
									with_2.VariableCompare = buffer.ReadInt32();
									
									with_2.ChkSwitch = buffer.ReadInt32();
									with_2.Switchindex = buffer.ReadInt32();
									with_2.SwitchCompare = buffer.ReadInt32();
									
									with_2.ChkHasItem = buffer.ReadInt32();
									with_2.HasItemindex = buffer.ReadInt32();
									with_2.HasItemAmount = buffer.ReadInt32();
									
									with_2.ChkSelfSwitch = buffer.ReadInt32();
									with_2.SelfSwitchindex = buffer.ReadInt32();
									with_2.SelfSwitchCompare = buffer.ReadInt32();
									
									with_2.GraphicType = (byte) (buffer.ReadInt32());
									with_2.Graphic = buffer.ReadInt32();
									with_2.GraphicX = buffer.ReadInt32();
									with_2.GraphicY = buffer.ReadInt32();
									with_2.GraphicX2 = buffer.ReadInt32();
									with_2.GraphicY2 = buffer.ReadInt32();
									
									with_2.MoveType = (byte) (buffer.ReadInt32());
									with_2.MoveSpeed = (byte) (buffer.ReadInt32());
									with_2.MoveFreq = (byte) (buffer.ReadInt32());
									
									with_2.MoveRouteCount = buffer.ReadInt32();
									
									with_2.IgnoreMoveRoute = buffer.ReadInt32();
									with_2.RepeatMoveRoute = buffer.ReadInt32();
									
									if (with_2.MoveRouteCount > 0)
									{
										Map.Events[i].Pages[x].MoveRoute = new C_EventSystem.MoveRouteRec[with_2.MoveRouteCount + 1];
										for (y = 1; y <= with_2.MoveRouteCount; y++)
										{
											with_2.MoveRoute[y].Index = buffer.ReadInt32();
											with_2.MoveRoute[y].Data1 = buffer.ReadInt32();
											with_2.MoveRoute[y].Data2 = buffer.ReadInt32();
											with_2.MoveRoute[y].Data3 = buffer.ReadInt32();
											with_2.MoveRoute[y].Data4 = buffer.ReadInt32();
											with_2.MoveRoute[y].Data5 = buffer.ReadInt32();
											with_2.MoveRoute[y].Data6 = buffer.ReadInt32();
										}
									}
									
									with_2.WalkAnim = (byte) (buffer.ReadInt32());
									with_2.DirFix = (byte) (buffer.ReadInt32());
									with_2.WalkThrough = (byte) (buffer.ReadInt32());
									with_2.ShowName = (byte) (buffer.ReadInt32());
									with_2.Trigger = (byte) (buffer.ReadInt32());
									with_2.CommandListCount = buffer.ReadInt32();
									
									with_2.Position = (byte) (buffer.ReadInt32());
									with_2.Questnum = buffer.ReadInt32();
									
									with_2.ChkPlayerGender = buffer.ReadInt32();
									
									if (Map.Events[i].Pages[x].CommandListCount > 0)
									{
										Map.Events[i].Pages[x].CommandList = new C_EventSystem.CommandListRec[Map.Events[i].Pages[x].CommandListCount + 1];
										for (y = 1; y <= Map.Events[i].Pages[x].CommandListCount; y++)
										{
											Map.Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
											Map.Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
											if (Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
											{
												Map.Events[i].Pages[x].CommandList[y].Commands = new C_EventSystem.EventCommandRec[Map.Events[i].Pages[x].CommandList[y].CommandCount + 1];
												for (var z = 1; z <= Map.Events[i].Pages[x].CommandList[y].CommandCount; z++)
												{
													ref var with_3 = ref Map.Events[i].Pages[x].CommandList[y].Commands[(int) z];
													with_3.Index = buffer.ReadInt32();
													with_3.Text1 = buffer.ReadString().Trim();
													with_3.Text2 = buffer.ReadString().Trim();
													with_3.Text3 = buffer.ReadString().Trim();
													with_3.Text4 = buffer.ReadString().Trim();
													with_3.Text5 = buffer.ReadString().Trim();
													with_3.Data1 = buffer.ReadInt32();
													with_3.Data2 = buffer.ReadInt32();
													with_3.Data3 = buffer.ReadInt32();
													with_3.Data4 = buffer.ReadInt32();
													with_3.Data5 = buffer.ReadInt32();
													with_3.Data6 = buffer.ReadInt32();
													with_3.ConditionalBranch.CommandList = buffer.ReadInt32();
													with_3.ConditionalBranch.Condition = buffer.ReadInt32();
													with_3.ConditionalBranch.Data1 = buffer.ReadInt32();
													with_3.ConditionalBranch.Data2 = buffer.ReadInt32();
													with_3.ConditionalBranch.Data3 = buffer.ReadInt32();
													with_3.ConditionalBranch.ElseCommandList = buffer.ReadInt32();
													with_3.MoveRouteCount = buffer.ReadInt32();
													if (with_3.MoveRouteCount > 0)
													{
														Array.Resize(ref with_3.MoveRoute, with_3.MoveRouteCount + 1);
														for (var w = 1; w <= with_3.MoveRouteCount; w++)
														{
															with_3.MoveRoute[(int) w].Index = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data1 = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data2 = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data3 = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data4 = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data5 = buffer.ReadInt32();
															with_3.MoveRoute[(int) w].Data6 = buffer.ReadInt32();
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					//End Event Data
				}
				
				for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
				{
					MapItem[i].Num = buffer.ReadInt32();
					MapItem[i].Value = buffer.ReadInt32();
					MapItem[i].X = (byte) (buffer.ReadInt32());
					MapItem[i].Y = (byte) (buffer.ReadInt32());
				}
				
				for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
				{
					MapNpc[i].Num = buffer.ReadInt32();
					MapNpc[i].X = (byte) (buffer.ReadInt32());
					MapNpc[i].Y = (byte) (buffer.ReadInt32());
					MapNpc[i].Dir = (byte) (buffer.ReadInt32());
					MapNpc[i].Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
					MapNpc[i].Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
				}
				
				if (buffer.ReadInt32() == 1)
				{
					C_Resources.ResourceIndex = buffer.ReadInt32();
					C_Resources.ResourcesInit = false;
					
					if (C_Resources.ResourceIndex > 0)
					{
						C_Resources.MapResource = new C_Types.MapResourceRec[C_Resources.ResourceIndex + 1];
						
						for (i = 0; i <= C_Resources.ResourceIndex; i++)
						{
							C_Resources.MapResource[i].ResourceState = (byte) (buffer.ReadInt32());
							C_Resources.MapResource[i].X = buffer.ReadInt32();
							C_Resources.MapResource[i].Y = buffer.ReadInt32();
						}
						
						C_Resources.ResourcesInit = true;
					}
					else
					{
						C_Resources.MapResource = new C_Types.MapResourceRec[2];
					}
				}
				
				C_GameLogic.ClearTempTile();
				
				buffer.Dispose();
				
			}
			
			C_AutoTiles.InitAutotiles();
			
			C_Variables.MapData = true;
			
			for (i = 1; i <= byte.MaxValue; i++)
			{
				C_GameLogic.ClearActionMsg((byte) i);
			}
			
			C_Weather.CurrentWeather = Map.WeatherType;
			C_Weather.CurrentWeatherIntensity = Map.WeatherIntensity;
			C_Weather.CurrentFog = Map.Fogindex;
			C_Weather.CurrentFogSpeed = Map.FogSpeed;
			C_Weather.CurrentFogOpacity = Map.FogAlpha;
			C_Weather.CurrentTintR = Map.MapTintR;
			C_Weather.CurrentTintG = Map.MapTintG;
			C_Weather.CurrentTintB = Map.MapTintB;
			C_Weather.CurrentTintA = Map.MapTintA;
			
			C_Sound.PlayMusic(Map.Music.Trim());
			
			C_GameLogic.UpdateDrawMapName();
			
			C_Variables.GettingMap = false;
			C_Variables.CanMoveNow = true;
			
		}
		
		public static void Packet_MapNPCData(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				
				ref var with_1 = ref MapNpc[i];
				with_1.Num = buffer.ReadInt32();
				with_1.X = (byte)buffer.ReadInt32();
				with_1.Y = (byte)buffer.ReadInt32();
				with_1.Dir = (byte)buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
				
			}
			
			buffer.Dispose();
		}
		
		public static void Packet_MapNPCUpdate(ref byte[] data)
		{
			int npcNum = 0;
			ByteStream buffer = new ByteStream(data);
			npcNum = buffer.ReadInt32();
			
			ref var with_1 = ref MapNpc[npcNum];
			with_1.Num = buffer.ReadInt32();
			with_1.X = (byte)buffer.ReadInt32();
			with_1.Y = (byte)buffer.ReadInt32();
			with_1.Dir = (byte)buffer.ReadInt32();
			with_1.Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
			with_1.Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		public static void Packet_MapDone(ref byte[] data)
		{
			int i = 0;
			string musicFile = "";
			
			for (i = 1; i <= byte.MaxValue; i++)
			{
				C_GameLogic.ClearActionMsg((byte) i);
			}
			
			C_Weather.CurrentWeather = Map.WeatherType;
			C_Weather.CurrentWeatherIntensity = Map.WeatherIntensity;
			C_Weather.CurrentFog = Map.Fogindex;
			C_Weather.CurrentFogSpeed = Map.FogSpeed;
			C_Weather.CurrentFogOpacity = Map.FogAlpha;
			C_Weather.CurrentTintR = Map.MapTintR;
			C_Weather.CurrentTintG = Map.MapTintG;
			C_Weather.CurrentTintB = Map.MapTintB;
			C_Weather.CurrentTintA = Map.MapTintA;
			
			musicFile = Map.Music.Trim();
			C_Sound.PlayMusic(musicFile);
			
			C_GameLogic.UpdateDrawMapName();
			
			C_Variables.GettingMap = false;
			C_Variables.CanMoveNow = true;
			
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendPlayerRequestNewMap()
		{
			if (C_Variables.GettingMap)
			{
				return;
			}
			
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestNewMap);
			buffer.WriteInt32(C_Player.GetPlayerDir(C_Variables.Myindex));
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void SendRequestEditMap()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestEditMap);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendMap()
		{
			int x = 0;
			int y = 0;
			int i = 0;
			byte[] data;
			ByteStream buffer = new ByteStream(4);
			C_Variables.CanMoveNow = false;
			
			buffer.WriteString(Map.Name.Trim());
			buffer.WriteString(Map.Music.Trim());
			buffer.WriteInt32(Map.Moral);
			buffer.WriteInt32(Map.Tileset);
			buffer.WriteInt32(Map.Up);
			buffer.WriteInt32(Map.Down);
			buffer.WriteInt32(Map.Left);
			buffer.WriteInt32(Map.Right);
			buffer.WriteInt32(Map.BootMap);
			buffer.WriteInt32(Map.BootX);
			buffer.WriteInt32(Map.BootY);
			buffer.WriteInt32(Map.MaxX);
			buffer.WriteInt32(Map.MaxY);
			buffer.WriteInt32(Map.WeatherType);
			buffer.WriteInt32(Map.Fogindex);
			buffer.WriteInt32(Map.WeatherIntensity);
			buffer.WriteInt32(Map.FogAlpha);
			buffer.WriteInt32(Map.FogSpeed);
			buffer.WriteInt32(Map.HasMapTint);
			buffer.WriteInt32(Map.MapTintR);
			buffer.WriteInt32(Map.MapTintG);
			buffer.WriteInt32(Map.MapTintB);
			buffer.WriteInt32(Map.MapTintA);
			buffer.WriteInt32(Map.Instanced);
			buffer.WriteInt32(Map.Panorama);
			buffer.WriteInt32(Map.Parallax);
			buffer.WriteInt32(Map.Brightness);
			
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				buffer.WriteInt32(Map.Npc[i]);
			}
			
			for (x = 0; x <= Map.MaxX; x++)
			{
				for (y = 0; y <= Map.MaxY; y++)
				{
					buffer.WriteInt32(Map.Tile[x, y].Data1);
					buffer.WriteInt32(Map.Tile[x, y].Data2);
					buffer.WriteInt32(Map.Tile[x, y].Data3);
					buffer.WriteInt32(Map.Tile[x, y].DirBlock);
					for (i = 0; i <= (int) Enums.LayerType.Count - 1; i++)
					{
						buffer.WriteInt32(Map.Tile[x, y].Layer[i].Tileset);
						buffer.WriteInt32(Map.Tile[x, y].Layer[i].X);
						buffer.WriteInt32(Map.Tile[x, y].Layer[i].Y);
						buffer.WriteInt32(Map.Tile[x, y].Layer[i].AutoTile);
					}
					buffer.WriteInt32(Map.Tile[x, y].Type);
				}
			}
			
			//Event Data
			buffer.WriteInt32(Map.EventCount);
			if (Map.EventCount > 0)
			{
				for (i = 1; i <= Map.EventCount; i++)
				{
					ref var with_1 = ref Map.Events[i];
					buffer.WriteString(System.Convert.ToString(with_1.Name.Trim()));
					buffer.WriteInt32(System.Convert.ToInt32(with_1.Globals));
					buffer.WriteInt32(System.Convert.ToInt32(with_1.X));
					buffer.WriteInt32(System.Convert.ToInt32(with_1.Y));
					buffer.WriteInt32(System.Convert.ToInt32(with_1.PageCount));
					if (Map.Events[i].PageCount > 0)
					{
						for (x = 1; x <= Map.Events[i].PageCount; x++)
						{
							ref var with_2 = ref Map.Events[i].Pages[x];
							buffer.WriteInt32(with_2.ChkVariable);
							buffer.WriteInt32(with_2.Variableindex);
							buffer.WriteInt32(with_2.VariableCondition);
							buffer.WriteInt32(with_2.VariableCompare);
							buffer.WriteInt32(with_2.ChkSwitch);
							buffer.WriteInt32(with_2.Switchindex);
							buffer.WriteInt32(with_2.SwitchCompare);
							buffer.WriteInt32(with_2.ChkHasItem);
							buffer.WriteInt32(with_2.HasItemindex);
							buffer.WriteInt32(with_2.HasItemAmount);
							buffer.WriteInt32(with_2.ChkSelfSwitch);
							buffer.WriteInt32(with_2.SelfSwitchindex);
							buffer.WriteInt32(with_2.SelfSwitchCompare);
							buffer.WriteInt32(with_2.GraphicType);
							buffer.WriteInt32(with_2.Graphic);
							buffer.WriteInt32(with_2.GraphicX);
							buffer.WriteInt32(with_2.GraphicY);
							buffer.WriteInt32(with_2.GraphicX2);
							buffer.WriteInt32(with_2.GraphicY2);
							buffer.WriteInt32(with_2.MoveType);
							buffer.WriteInt32(with_2.MoveSpeed);
							buffer.WriteInt32(with_2.MoveFreq);
							buffer.WriteInt32(Map.Events[i].Pages[x].MoveRouteCount);
							buffer.WriteInt32(with_2.IgnoreMoveRoute);
							buffer.WriteInt32(with_2.RepeatMoveRoute);
							if (with_2.MoveRouteCount > 0)
							{
								for (y = 1; y <= with_2.MoveRouteCount; y++)
								{
									buffer.WriteInt32(with_2.MoveRoute[y].Index);
									buffer.WriteInt32(with_2.MoveRoute[y].Data1);
									buffer.WriteInt32(with_2.MoveRoute[y].Data2);
									buffer.WriteInt32(with_2.MoveRoute[y].Data3);
									buffer.WriteInt32(with_2.MoveRoute[y].Data4);
									buffer.WriteInt32(with_2.MoveRoute[y].Data5);
									buffer.WriteInt32(with_2.MoveRoute[y].Data6);
								}
							}
							buffer.WriteInt32(with_2.WalkAnim);
							buffer.WriteInt32(with_2.DirFix);
							buffer.WriteInt32(with_2.WalkThrough);
							buffer.WriteInt32(with_2.ShowName);
							buffer.WriteInt32(with_2.Trigger);
							buffer.WriteInt32(with_2.CommandListCount);
							buffer.WriteInt32(with_2.Position);
							buffer.WriteInt32(with_2.Questnum);
							
							buffer.WriteInt32(with_2.ChkPlayerGender);
							if (Map.Events[i].Pages[x].CommandListCount > 0)
							{
								for (y = 1; y <= Map.Events[i].Pages[x].CommandListCount; y++)
								{
									buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].CommandCount);
									buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].ParentList);
									if (Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
									{
										for (var z = 1; z <= Map.Events[i].Pages[x].CommandList[y].CommandCount; z++)
										{
											ref var with_3 = ref Map.Events[i].Pages[x].CommandList[y].Commands[(int) z];
											buffer.WriteInt32(with_3.Index);
											buffer.WriteString(with_3.Text1);
											buffer.WriteString(with_3.Text2);
											buffer.WriteString(with_3.Text3);
											buffer.WriteString(with_3.Text4);
											buffer.WriteString(with_3.Text5);
											buffer.WriteInt32(with_3.Data1);
											buffer.WriteInt32(with_3.Data2);
											buffer.WriteInt32(with_3.Data3);
											buffer.WriteInt32(with_3.Data4);
											buffer.WriteInt32(with_3.Data5);
											buffer.WriteInt32(with_3.Data6);
											buffer.WriteInt32(with_3.ConditionalBranch.CommandList);
											buffer.WriteInt32(with_3.ConditionalBranch.Condition);
											buffer.WriteInt32(with_3.ConditionalBranch.Data1);
											buffer.WriteInt32(with_3.ConditionalBranch.Data2);
											buffer.WriteInt32(with_3.ConditionalBranch.Data3);
											buffer.WriteInt32(with_3.ConditionalBranch.ElseCommandList);
											buffer.WriteInt32(with_3.MoveRouteCount);
											if (with_3.MoveRouteCount > 0)
											{
												for (var w = 1; w <= with_3.MoveRouteCount; w++)
												{
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Index);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data1);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data2);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data3);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data4);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data5);
													buffer.WriteInt32(with_3.MoveRoute[(int) w].Data6);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			//End Event Data
			
			data = buffer.ToArray();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSaveMap);
			buffer.WriteBlock(Compression.CompressBytes(data));
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendMapRespawn()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CMapRespawn);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		internal static void DrawMapTile(int x, int y)
		{
			if (C_Variables.GettingMap)
			{
				return;
			}
			if (ReferenceEquals(Map.Tile, null))
			{
				return;
			}
			if (C_Variables.MapData == false)
			{
				return;
			}
            
            int i = 0;
            Rectangle srcrect = new Rectangle(0, 0, 0, 0);

            for (i = (byte)Enums.LayerType.Ground; i <= (byte)Enums.LayerType.Mask2; i++)
			{
				if (ReferenceEquals(Map.Tile[x, y].Layer, null))
				{
					return;
				}
				// skip tile if tileset isn't set
				if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
				{
					if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
					{
						C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, (byte) 1);
					}
                    // we use it, lets update timer
                    C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].TextureTimer = C_General.GetTickCount() + 100000;
					if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateNormal)
					{
						srcrect.X = (Map.Tile[x, y].Layer[i].X * 32);
						srcrect.Y = (Map.Tile[x, y].Layer[i].Y * 32);
						srcrect.Width = 32;
						srcrect.Height = 32;
						
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[Map.Tile[x, y].Layer[i].Tileset], C_Graphics.GameWindow, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
						
					}
					else if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
					{
						// Draw autotiles
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), 1, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY), 2, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 3, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 4, x, y, 0, false);
					}
				}
			}
			
		}
		
		internal static void DrawMapFringeTile(int x, int y)
		{
			//Dim dest As Rectangle = New Rectangle(FrmMainGame.PointToScreen(FrmMainGame.picscreen.Location), New Size(32, 32))
			
			if (C_Variables.GettingMap)
			{
				return;
			}
			if (ReferenceEquals(Map.Tile, null))
			{
				return;
			}
			if (C_Variables.MapData == false)
			{
				return;
			}

            int i = 0;
            Rectangle srcrect = new Rectangle(0, 0, 0, 0);

            for (i = (byte)Enums.LayerType.Fringe; i <= (byte)Enums.LayerType.Fringe2; i++)
			{
				if (ReferenceEquals(Map.Tile[x, y].Layer, null))
				{
					return;
				}
				// skip tile if tileset isn't set
				if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
				{
					if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
					{
						C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, 1);
					}

                    // we use it, lets update timer
                    C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].TextureTimer = C_General.GetTickCount() + 100000;
					
					// render
					if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateNormal)
					{
						srcrect.X = Map.Tile[x, y].Layer[i].X * 32;
						srcrect.Y = Map.Tile[x, y].Layer[i].Y * 32;
						srcrect.Width = 32;
						srcrect.Height = 32;
						
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[Map.Tile[x, y].Layer[i].Tileset], C_Graphics.GameWindow, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
						
					}
					else if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
					{
						// Draw autotiles
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), 1, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY), 2, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 3, x, y, 0, false);
						C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 4, x, y, 0, false);
					}
				}
			}
			
		}
		
#endregion
		
	}
}
