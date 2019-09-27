using System.Windows.Forms;
using Microsoft.VisualBasic;
using ASFW;
using ASFW.IO;
using System;

namespace Engine
{
    static class E_NetworkSend
    {
        internal static void SendEditorLogin(string Name, string Password)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.EditorLogin);
            buffer.WriteString((E_Globals.EKeyPair.EncryptString(Name)));
            buffer.WriteString((E_Globals.EKeyPair.EncryptString(Password)));
            buffer.WriteString((E_Globals.EKeyPair.EncryptString(Application.ProductVersion)));
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendEditorMap()
        {
            int X;
            int Y;
            int i;
            byte[] data;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32(E_Types.Map.mapNum);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Name)));
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Music)));
            buffer.WriteInt32(E_Types.Map.Moral);
            buffer.WriteInt32(E_Types.Map.tileset);
            buffer.WriteInt32(E_Types.Map.Up);
            buffer.WriteInt32(E_Types.Map.Down);
            buffer.WriteInt32(E_Types.Map.Left);
            buffer.WriteInt32(E_Types.Map.Right);
            buffer.WriteInt32(E_Types.Map.BootMap);
            buffer.WriteInt32(E_Types.Map.BootX);
            buffer.WriteInt32(E_Types.Map.BootY);
            buffer.WriteInt32(E_Types.Map.MaxX);
            buffer.WriteInt32(E_Types.Map.MaxY);
            buffer.WriteInt32(E_Types.Map.WeatherType);
            buffer.WriteInt32(E_Types.Map.Fogindex);
            buffer.WriteInt32(E_Types.Map.WeatherIntensity);
            buffer.WriteInt32(E_Types.Map.FogAlpha);
            buffer.WriteInt32(E_Types.Map.FogSpeed);
            buffer.WriteInt32(E_Types.Map.HasMapTint);
            buffer.WriteInt32(E_Types.Map.MapTintR);
            buffer.WriteInt32(E_Types.Map.MapTintG);
            buffer.WriteInt32(E_Types.Map.MapTintB);
            buffer.WriteInt32(E_Types.Map.MapTintA);
            buffer.WriteInt32(E_Types.Map.Instanced);
            buffer.WriteInt32(E_Types.Map.Panorama);
            buffer.WriteInt32(E_Types.Map.Parallax);
            buffer.WriteInt32(E_Types.Map.Brightness);

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                buffer.WriteInt32(E_Types.Map.Npc[i]);
            var loopTo = E_Types.Map.MaxX;
            for (X = 0; X <= loopTo; X++)
            {
                var loopTo1 = E_Types.Map.MaxY;
                for (Y = 0; Y <= loopTo1; Y++)
                {
                    buffer.WriteInt32(E_Types.Map.Tile[X, Y].Data1);
                    buffer.WriteInt32(E_Types.Map.Tile[X, Y].Data2);
                    buffer.WriteInt32(E_Types.Map.Tile[X, Y].Data3);
                    buffer.WriteInt32(E_Types.Map.Tile[X, Y].DirBlock);
                    for (i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                    {
                        buffer.WriteInt32(E_Types.Map.Tile[X, Y].Layer[i].Tileset);
                        buffer.WriteInt32(E_Types.Map.Tile[X, Y].Layer[i].X);
                        buffer.WriteInt32(E_Types.Map.Tile[X, Y].Layer[i].Y);
                        buffer.WriteInt32(E_Types.Map.Tile[X, Y].Layer[i].AutoTile);
                    }
                    buffer.WriteInt32(E_Types.Map.Tile[X, Y].Type);
                }
            }

            // Event Data
            buffer.WriteInt32(E_Types.Map.EventCount);
            if (E_Types.Map.EventCount > 0)
            {
                var loopTo2 = E_Types.Map.EventCount;
                for (i = 1; i <= loopTo2; i++)
                {
                    {
                        ref var withBlock = ref E_Types.Map.Events[i];
                        buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock.Name)));
                        buffer.WriteInt32(withBlock.Globals);
                        buffer.WriteInt32(withBlock.X);
                        buffer.WriteInt32(withBlock.Y);
                        buffer.WriteInt32(withBlock.PageCount);
                    }
                    if (E_Types.Map.Events[i].PageCount > 0)
                    {
                        var loopTo3 = E_Types.Map.Events[i].PageCount;
                        for (X = 1; X <= loopTo3; X++)
                        {
                            {
                                ref var withBlock1 = ref E_Types.Map.Events[i].Pages[X];
                                buffer.WriteInt32(withBlock1.ChkVariable);
                                buffer.WriteInt32(withBlock1.Variableindex);
                                buffer.WriteInt32(withBlock1.VariableCondition);
                                buffer.WriteInt32(withBlock1.VariableCompare);
                                buffer.WriteInt32(withBlock1.ChkSwitch);
                                buffer.WriteInt32(withBlock1.Switchindex);
                                buffer.WriteInt32(withBlock1.SwitchCompare);
                                buffer.WriteInt32(withBlock1.ChkHasItem);
                                buffer.WriteInt32(withBlock1.HasItemindex);
                                buffer.WriteInt32(withBlock1.HasItemAmount);
                                buffer.WriteInt32(withBlock1.ChkSelfSwitch);
                                buffer.WriteInt32(withBlock1.SelfSwitchindex);
                                buffer.WriteInt32(withBlock1.SelfSwitchCompare);
                                buffer.WriteInt32(withBlock1.GraphicType);
                                buffer.WriteInt32(withBlock1.Graphic);
                                buffer.WriteInt32(withBlock1.GraphicX);
                                buffer.WriteInt32(withBlock1.GraphicY);
                                buffer.WriteInt32(withBlock1.GraphicX2);
                                buffer.WriteInt32(withBlock1.GraphicY2);
                                buffer.WriteInt32(withBlock1.MoveType);
                                buffer.WriteInt32(withBlock1.MoveSpeed);
                                buffer.WriteInt32(withBlock1.MoveFreq);
                                buffer.WriteInt32(E_Types.Map.Events[i].Pages[X].MoveRouteCount);
                                buffer.WriteInt32(withBlock1.IgnoreMoveRoute);
                                buffer.WriteInt32(withBlock1.RepeatMoveRoute);
                                if (withBlock1.MoveRouteCount > 0)
                                {
                                    var loopTo4 = withBlock1.MoveRouteCount;
                                    for (Y = 1; Y <= loopTo4; Y++)
                                    {
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Index);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data1);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data2);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data3);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data4);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data5);
                                        buffer.WriteInt32(withBlock1.MoveRoute[Y].Data6);
                                    }
                                }
                                buffer.WriteInt32(withBlock1.WalkAnim);
                                buffer.WriteInt32(withBlock1.DirFix);
                                buffer.WriteInt32(withBlock1.WalkThrough);
                                buffer.WriteInt32(withBlock1.ShowName);
                                buffer.WriteInt32(withBlock1.Trigger);
                                buffer.WriteInt32(withBlock1.CommandListCount);
                                buffer.WriteInt32(withBlock1.Position);
                                buffer.WriteInt32(withBlock1.Questnum);

                                buffer.WriteInt32(withBlock1.ChkPlayerGender);
                            }
                            if (E_Types.Map.Events[i].Pages[X].CommandListCount > 0)
                            {
                                var loopTo5 = E_Types.Map.Events[i].Pages[X].CommandListCount;
                                for (Y = 1; Y <= loopTo5; Y++)
                                {
                                    buffer.WriteInt32(E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount);
                                    buffer.WriteInt32(E_Types.Map.Events[i].Pages[X].CommandList[Y].ParentList);
                                    if (E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount > 0)
                                    {
                                        var loopTo6 = E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount;
                                        for (var z = 1; z <= loopTo6; z++)
                                        {
                                            {
                                                ref var withBlock2 = ref E_Types.Map.Events[i].Pages[X].CommandList[Y].Commands[z];
                                                buffer.WriteInt32(withBlock2.Index);
                                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock2.Text1)));
                                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock2.Text2)));
                                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock2.Text3)));
                                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock2.Text4)));
                                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock2.Text5)));
                                                buffer.WriteInt32(withBlock2.Data1);
                                                buffer.WriteInt32(withBlock2.Data2);
                                                buffer.WriteInt32(withBlock2.Data3);
                                                buffer.WriteInt32(withBlock2.Data4);
                                                buffer.WriteInt32(withBlock2.Data5);
                                                buffer.WriteInt32(withBlock2.Data6);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.CommandList);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Condition);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data1);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data2);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data3);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.ElseCommandList);
                                                buffer.WriteInt32(withBlock2.MoveRouteCount);
                                                if (withBlock2.MoveRouteCount > 0)
                                                {
                                                    var loopTo7 = withBlock2.MoveRouteCount;
                                                    for (var w = 1; w <= loopTo7; w++)
                                                    {
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Index);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data1);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data2);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data3);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data4);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data5);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data6);
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
            }
            // End Event Data

            data = buffer.ToArray();

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.EditorPackets.EditorSaveMap);
            buffer.WriteBlock(Compression.CompressBytes(data));

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditResource()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditResource);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestResources()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestResources);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveResource(int ResourceNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveResource);

            buffer.WriteInt32(ResourceNum);
            buffer.WriteInt32(Types.Resource[ResourceNum].Animation);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Resource[ResourceNum].EmptyMessage)));
            buffer.WriteInt32(Types.Resource[ResourceNum].ExhaustedImage);
            buffer.WriteInt32(Types.Resource[ResourceNum].Health);
            buffer.WriteInt32(Types.Resource[ResourceNum].ExpReward);
            buffer.WriteInt32(Types.Resource[ResourceNum].ItemReward);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Resource[ResourceNum].Name)));
            buffer.WriteInt32(Types.Resource[ResourceNum].ResourceImage);
            buffer.WriteInt32(Types.Resource[ResourceNum].ResourceType);
            buffer.WriteInt32(Types.Resource[ResourceNum].RespawnTime);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Resource[ResourceNum].SuccessMessage)));
            buffer.WriteInt32(Types.Resource[ResourceNum].LvlRequired);
            buffer.WriteInt32(Types.Resource[ResourceNum].ToolRequired);
            buffer.WriteInt32(Convert.ToInt32(Types.Resource[ResourceNum].Walkthrough));

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditNpc()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditNpc);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveNpc(int NpcNum)
        {
            ByteStream buffer = new ByteStream(4);
            int i;

            buffer.WriteInt32((int)Packets.EditorPackets.SaveNpc);
            buffer.WriteInt32(NpcNum);

            buffer.WriteInt32(Types.Npc[NpcNum].Animation);
            buffer.WriteString((Types.Npc[NpcNum].AttackSay));
            buffer.WriteInt32(Types.Npc[NpcNum].Behaviour);
            for (i = 1; i <= 5; i++)
            {
                buffer.WriteInt32(Types.Npc[NpcNum].DropChance[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItem[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItemValue[i]);
            }

            buffer.WriteInt32(Types.Npc[NpcNum].Exp);
            buffer.WriteInt32(Types.Npc[NpcNum].Faction);
            buffer.WriteInt32(Types.Npc[NpcNum].Hp);
            buffer.WriteString((Types.Npc[NpcNum].Name));
            buffer.WriteInt32(Types.Npc[NpcNum].Range);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnTime);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnSecs);
            buffer.WriteInt32(Types.Npc[NpcNum].Sprite);

            for (i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Stat[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].QuestNum);

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Skill[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].Level);
            buffer.WriteInt32(Types.Npc[NpcNum].Damage);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestNPCS()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestNPCS);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditSkill()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditSkill);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestSkills()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestSkills);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveSkill(int skillnum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveSkill);
            buffer.WriteInt32(skillnum);

            buffer.WriteInt32(Types.Skill[skillnum].AccessReq);
            buffer.WriteInt32(Types.Skill[skillnum].AoE);
            buffer.WriteInt32(Types.Skill[skillnum].CastAnim);
            buffer.WriteInt32(Types.Skill[skillnum].CastTime);
            buffer.WriteInt32(Types.Skill[skillnum].CdTime);
            buffer.WriteInt32(Types.Skill[skillnum].ClassReq);
            buffer.WriteInt32(Types.Skill[skillnum].Dir);
            buffer.WriteInt32(Types.Skill[skillnum].Duration);
            buffer.WriteInt32(Types.Skill[skillnum].Icon);
            buffer.WriteInt32(Types.Skill[skillnum].Interval);
            buffer.WriteInt32(Convert.ToInt32(Types.Skill[skillnum].IsAoE));
            buffer.WriteInt32(Types.Skill[skillnum].LevelReq);
            buffer.WriteInt32(Types.Skill[skillnum].Map);
            buffer.WriteInt32(Types.Skill[skillnum].MpCost);
            buffer.WriteString((Types.Skill[skillnum].Name));
            buffer.WriteInt32(Types.Skill[skillnum].Range);
            buffer.WriteInt32(Types.Skill[skillnum].SkillAnim);
            buffer.WriteInt32(Types.Skill[skillnum].StunDuration);
            buffer.WriteInt32(Types.Skill[skillnum].Type);
            buffer.WriteInt32(Types.Skill[skillnum].Vital);
            buffer.WriteInt32(Types.Skill[skillnum].X);
            buffer.WriteInt32(Types.Skill[skillnum].Y);

            buffer.WriteInt32(Types.Skill[skillnum].IsProjectile);
            buffer.WriteInt32(Types.Skill[skillnum].Projectile);

            buffer.WriteInt32(Types.Skill[skillnum].KnockBack);
            buffer.WriteInt32(Types.Skill[skillnum].KnockBackTiles);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendRequestShops()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestShops);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveShop(int shopnum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveShop);
            buffer.WriteInt32(shopnum);

            buffer.WriteInt32(Types.Shop[shopnum].BuyRate);
            buffer.WriteString((Types.Shop[shopnum].Name));
            buffer.WriteInt32(Types.Shop[shopnum].Face);

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                buffer.WriteInt32(Types.Shop[shopnum].TradeItem[i].CostItem);
                buffer.WriteInt32(Types.Shop[shopnum].TradeItem[i].CostValue);
                buffer.WriteInt32(Types.Shop[shopnum].TradeItem[i].Item);
                buffer.WriteInt32(Types.Shop[shopnum].TradeItem[i].ItemValue);
            }

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditShop()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditShop);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveAnimation(int Animationnum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveAnimation);
            buffer.WriteInt32(Animationnum);
            var loopTo = Information.UBound(Types.Animation[Animationnum].Frames);
            for (var i = 0; i <= loopTo; i++)
                buffer.WriteInt32(Types.Animation[Animationnum].Frames[i]);
            var loopTo1 = Information.UBound(Types.Animation[Animationnum].LoopCount);
            for (int i = 0; i <= loopTo1; i++)
                buffer.WriteInt32(Types.Animation[Animationnum].LoopCount[i]);
            var loopTo2 = Information.UBound(Types.Animation[Animationnum].LoopTime);
            for (int i = 0; i <= loopTo2; i++)
                buffer.WriteInt32(Types.Animation[Animationnum].LoopTime[i]);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Animation[Animationnum].Name)));
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Animation[Animationnum].Sound)));
            var loopTo3 = Information.UBound(Types.Animation[Animationnum].Sprite);
            for (var i = 0; i <= loopTo3; i++)
                buffer.WriteInt32(Types.Animation[Animationnum].Sprite[i]);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestAnimations()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestAnimations);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditAnimation()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditAnimation);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestMapreport()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CMapReport);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestClasses()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestClasses);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditClass()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditClasses);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveClasses()
        {
            int i;
            int n;
            int q;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveClasses);

            buffer.WriteInt32(E_Globals.Max_Classes);
            var loopTo = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name)));
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Desc)));

                // set sprite array size
                n = Information.UBound(Types.Classes[i].MaleSprite);

                // send array size
                buffer.WriteInt32(n);
                var loopTo1 = n;

                // loop around sending each sprite
                for (q = 0; q <= loopTo1; q++)
                    buffer.WriteInt32(Types.Classes[i].MaleSprite[q]);

                // set sprite array size
                n = Information.UBound(Types.Classes[i].FemaleSprite);

                // send array size
                buffer.WriteInt32(n);
                var loopTo2 = n;

                // loop around sending each sprite
                for (q = 0; q <= loopTo2; q++)
                    buffer.WriteInt32(Types.Classes[i].FemaleSprite[q]);

                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Strength]);
                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Endurance]);
                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Vitality]);
                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Intelligence]);
                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Luck]);
                buffer.WriteInt32(Types.Classes[i].Stat[(byte)Enums.StatType.Spirit]);

                for (q = 1; q <= 5; q++)
                {
                    buffer.WriteInt32(Types.Classes[i].StartItem[q]);
                    buffer.WriteInt32(Types.Classes[i].StartValue[q]);
                }

                buffer.WriteInt32(Types.Classes[i].StartMap);
                buffer.WriteInt32(Types.Classes[i].StartX);
                buffer.WriteInt32(Types.Classes[i].StartY);

                buffer.WriteInt32(Types.Classes[i].BaseExp);
            }

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendLeaveGame()
        {
            if (E_NetworkConfig.Socket != null & E_NetworkConfig.Socket.IsConnected)
            {
                ByteStream buffer = new ByteStream(4);

                buffer.WriteInt32((int)Packets.ClientPackets.CQuit);
                E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
                buffer.Dispose();
            }
        }

        internal static void SendEditorRequestMap(int mapNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.EditorRequestMap);
            buffer.WriteInt32(mapNum);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }
    }
}
