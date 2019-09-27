
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ASFW;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	sealed class C_Resources
	{
		
#region Globals & Types
		
		// Cache the Resources in an array
		internal static C_Types.MapResourceRec[] MapResource;
		
		internal static int ResourceIndex;
		internal static bool ResourcesInit;
		
#endregion
		
#region DataBase
		
		internal static void CheckResources()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Resources\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumResources++;
				i++;
			}
			
			if (C_Graphics.NumResources == 0)
			{
				return;
			}
		}
		
		public static void ClearResource(int index)
		{
			Types.Resource[index] = new Types.ResourceRec {
					Name = ""
				};
		}
		
		public static void ClearResources()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RESOURCES; i++)
			{
				ClearResource(i);
			}
			
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_ResourceCache(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			ResourceIndex = buffer.ReadInt32();
			ResourcesInit = false;
			
			if (ResourceIndex > 0)
			{
				Array.Resize(ref MapResource, ResourceIndex + 1);
				
				for (i = 0; i <= ResourceIndex; i++)
				{
					MapResource[i].ResourceState = (byte) (buffer.ReadInt32());
					MapResource[i].X = buffer.ReadInt32();
					MapResource[i].Y = buffer.ReadInt32();
				}
				
				ResourcesInit = true;
			}
			else
			{
				MapResource = new C_Types.MapResourceRec[2];
			}
			
			buffer.Dispose();
		}
		
		public static void Packet_UpdateResource(ref byte[] data)
		{
			int resourceNum = 0;
			ByteStream buffer = new ByteStream(data);
			resourceNum = buffer.ReadInt32();
			
			Types.Resource[resourceNum].Animation = buffer.ReadInt32();
			Types.Resource[resourceNum].EmptyMessage = buffer.ReadString().Trim();
			Types.Resource[resourceNum].ExhaustedImage = buffer.ReadInt32();
			Types.Resource[resourceNum].Health = buffer.ReadInt32();
			Types.Resource[resourceNum].ExpReward = buffer.ReadInt32();
			Types.Resource[resourceNum].ItemReward = buffer.ReadInt32();
			Types.Resource[resourceNum].Name = buffer.ReadString().Trim();
			Types.Resource[resourceNum].ResourceImage = buffer.ReadInt32();
			Types.Resource[resourceNum].ResourceType = buffer.ReadInt32();
			Types.Resource[resourceNum].RespawnTime = buffer.ReadInt32();
			Types.Resource[resourceNum].SuccessMessage = buffer.ReadString().Trim();
			Types.Resource[resourceNum].LvlRequired = buffer.ReadInt32();
			Types.Resource[resourceNum].ToolRequired = buffer.ReadInt32();
			Types.Resource[resourceNum].Walkthrough = System.Convert.ToBoolean(buffer.ReadInt32());
			
			if (ReferenceEquals(Types.Resource[resourceNum].Name, null))
			{
				Types.Resource[resourceNum].Name = "";
			}
			if (ReferenceEquals(Types.Resource[resourceNum].EmptyMessage, null))
			{
				Types.Resource[resourceNum].EmptyMessage = "";
			}
			if (ReferenceEquals(Types.Resource[resourceNum].SuccessMessage, null))
			{
				Types.Resource[resourceNum].SuccessMessage = "";
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		public static void SendRequestResources()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestResources);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		internal static void DrawResource(int resource, int dx, int dy, Rectangle rec)
		{
			if (resource < 1 || resource > C_Graphics.NumResources)
			{
				return;
			}
			int x = 0;
			int y = 0;
			int width;
			int height;
			
			x = C_Graphics.ConvertMapX(dx);
			y = C_Graphics.ConvertMapY(dy);
			width = rec.Right - rec.Left;
			height = rec.Bottom - rec.Top;
			
			if (rec.Width < 0 || rec.Height < 0)
			{
				return;
			}
			
			if (C_Graphics.ResourcesGfxInfo[resource].IsLoaded == false)
			{
				C_Graphics.LoadTexture(resource, (byte) 5);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref C_Graphics.ResourcesGfxInfo[resource];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			C_Graphics.RenderSprite(C_Graphics.ResourcesSprite[resource], C_Graphics.GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		internal static void DrawMapResource(int resourceNum)
		{
			int resourceMaster = 0;
			
			int resourceState;
			int resourceSprite = 0;
			Rectangle rec = new Rectangle();
			int x = 0;
			int y = 0;
			
			if (C_Variables.GettingMap)
			{
				return;
			}
			if (C_Variables.MapData == false)
			{
				return;
			}
			
			if (MapResource[resourceNum].X > C_Maps.Map.MaxX || MapResource[resourceNum].Y > C_Maps.Map.MaxY)
			{
				return;
			}
			
			// Get the Resource type
			resourceMaster = C_Maps.Map.Tile[MapResource[resourceNum].X, MapResource[resourceNum].Y].Data1;
			
			if (resourceMaster == 0)
			{
				return;
			}
			
			if (Types.Resource[resourceMaster].ResourceImage == 0)
			{
				return;
			}
			
			// Get the Resource state
			resourceState = MapResource[resourceNum].ResourceState;
			
			if (resourceState == 0) // normal
			{
				resourceSprite = Types.Resource[resourceMaster].ResourceImage;
			}
			else if (resourceState == 1) // used
			{
				resourceSprite = Types.Resource[resourceMaster].ExhaustedImage;
			}

            if (resourceSprite < C_Graphics.ResourcesGfxInfo.Length)
            {
                // src rect
                rec.Y = 0;
                rec.Height = C_Graphics.ResourcesGfxInfo[resourceSprite].Height;
                rec.X = 0;
                rec.Width = C_Graphics.ResourcesGfxInfo[resourceSprite].Width;

                // Set base x + y, then the offset due to size
                x = System.Convert.ToInt32((MapResource[resourceNum].X * C_Constants.PicX) - ((double)C_Graphics.ResourcesGfxInfo[resourceSprite].Width / 2) + 16);
                y = (MapResource[resourceNum].Y * C_Constants.PicY) - C_Graphics.ResourcesGfxInfo[resourceSprite].Height + 32;

                DrawResource(resourceSprite, x, y, rec);
            }
		}
		
#endregion
		
	}
}
