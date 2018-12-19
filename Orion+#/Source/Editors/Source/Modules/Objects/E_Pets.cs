
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using ASFW;
using Engine;


namespace Engine
{
	sealed class E_Pets
	{
		
#region Globals etc
		
		internal static PetRec[] Pet = new PetRec[Constants.MAX_PETS + 1];
		internal const byte EDITOR_PET = 7;
		internal static bool[] Pet_Changed;
		
		internal const int PetHpBarWidth = 129;
		internal const int PetMpBarWidth = 129;
		
		internal static int PetSkillBuffer;
		internal static int PetSkillBufferTimer;
		internal static int[] PetSkillCD;
		
		internal static bool InitPetEditor;
		
		//Pet Constants
		internal const byte PET_BEHAVIOUR_FOLLOW = 0; //The pet will attack all npcs around
		
		internal const byte PET_BEHAVIOUR_GOTO = 1; //If attacked, the pet will fight back
		internal const byte PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT = 2; //The pet will attack all npcs around
		internal const byte PET_ATTACK_BEHAVIOUR_GUARD = 3; //If attacked, the pet will fight back
		internal const byte PET_ATTACK_BEHAVIOUR_DONOTHING = 4; //The pet will not attack even if attacked
		
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
			public byte[] Stat;
			public int[] Skill;
			public int Points;
			public int X;
			public int Y;
			public int Dir;
			public int MaxHp;
			public int MaxMP;
			public byte Alive;
			public int AttackBehaviour;
			public int Exp;
			public int TNL;
			
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
		
#region Outgoing Packets
		
		public static void SendRequestPets()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestPets);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void SendRequestEditPet()
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.CRequestEditPet);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
			
		}
		
		internal static void SendSavePet(int petNum)
		{
			ByteStream buffer = new ByteStream();
			int i = 0;
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.CSavePet);
			buffer.WriteInt32(petNum);
			
			buffer.WriteInt32(Pet[petNum].Num);
			buffer.WriteString(Pet[petNum].Name.Trim());
			buffer.WriteInt32(Pet[petNum].Sprite);
			buffer.WriteInt32(Pet[petNum].Range);
			buffer.WriteInt32(Pet[petNum].Level);
            buffer.WriteInt32(Pet[petNum].IsMount);
            buffer.WriteInt32(Pet[petNum].IsFlying);
            buffer.WriteInt32(Pet[petNum].MaxLevel);
			buffer.WriteInt32(Pet[petNum].ExpGain);
			buffer.WriteInt32(Pet[petNum].LevelPnts);
			buffer.WriteInt32(Pet[petNum].StatType);
			buffer.WriteInt32(Pet[petNum].LevelingType);
			
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				buffer.WriteInt32(Pet[petNum].Stat[i]);
			}
			
			for (i = 1; i <= 4; i++)
			{
				buffer.WriteInt32(Pet[petNum].Skill[i]);
			}
			
			buffer.WriteInt32(Pet[petNum].Evolvable);
			buffer.WriteInt32(Pet[petNum].EvolveLevel);
			buffer.WriteInt32(Pet[petNum].EvolveNum);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_PetEditor(ref byte[] data)
		{
			InitPetEditor = true;
		}
		
		internal static void Packet_UpdatePet(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			
			Pet[n].Stat = new byte[(int) Enums.StatType.Count];
			Pet[n].Skill = new int[5];
			
			Pet[n].Num = buffer.ReadInt32();
			Pet[n].Name = buffer.ReadString();
			Pet[n].Sprite = buffer.ReadInt32();
			Pet[n].Range = buffer.ReadInt32();
			Pet[n].Level = buffer.ReadInt32();
            Pet[n].IsMount = (byte)(buffer.ReadInt32());
            Pet[n].IsFlying = (byte)(buffer.ReadInt32());
            Pet[n].MaxLevel = buffer.ReadInt32();
			Pet[n].ExpGain = buffer.ReadInt32();
			Pet[n].LevelPnts = buffer.ReadInt32();
			Pet[n].StatType = (byte) (buffer.ReadInt32());
			Pet[n].LevelingType = (byte) (buffer.ReadInt32());
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Pet[n].Stat[i] = (byte) (buffer.ReadInt32());
			}
			for (i = 1; i <= 4; i++)
			{
				Pet[n].Skill[i] = buffer.ReadInt32();
			}
			
			Pet[n].Evolvable = (byte) (buffer.ReadInt32());
			Pet[n].EvolveLevel = buffer.ReadInt32();
			Pet[n].EvolveNum = buffer.ReadInt32();
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region DataBase
		
		public static void ClearPet(int index)
		{
			
			Pet[index].Name = "";
			
			Pet[index].Stat = new byte[(int) Enums.StatType.Count];
			Pet[index].Skill = new int[5];
		}
		
		public static void ClearPets()
		{
			int i = 0;
			
			Pet = new E_Pets.PetRec[Constants.MAX_PETS + 1];
			PetSkillCD = new int[5];
			
			for (i = 1; i <= Constants.MAX_PETS; i++)
			{
				ClearPet(i);
			}
			
		}
		
#endregion
		
#region Editor
		
		internal static void PetEditorInit()
		{
			int i = 0;
			
			if (frmPet.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = frmPet.Default.lstIndex.SelectedIndex + 1;
			
			//populate skill combo's
			frmPet.Default.cmbSkill1.Items.Clear();
			frmPet.Default.cmbSkill2.Items.Clear();
			frmPet.Default.cmbSkill3.Items.Clear();
			frmPet.Default.cmbSkill4.Items.Clear();
			
			frmPet.Default.cmbSkill1.Items.Add("None");
			frmPet.Default.cmbSkill2.Items.Add("None");
			frmPet.Default.cmbSkill3.Items.Add("None");
			frmPet.Default.cmbSkill4.Items.Add("None");
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				frmPet.Default.cmbSkill1.Items.Add(i + ": " + Types.Skill[i].Name);
				frmPet.Default.cmbSkill2.Items.Add(i + ": " + Types.Skill[i].Name);
				frmPet.Default.cmbSkill3.Items.Add(i + ": " + Types.Skill[i].Name);
				frmPet.Default.cmbSkill4.Items.Add(i + ": " + Types.Skill[i].Name);
			}
			frmPet.Default.txtName.Text = Pet[E_Globals.Editorindex].Name.Trim();
			if (Pet[E_Globals.Editorindex].Sprite < 0 || Pet[E_Globals.Editorindex].Sprite > frmPet.Default.nudSprite.Maximum)
			{
				Pet[E_Globals.Editorindex].Sprite = 0;
			}
			
			frmPet.Default.nudSprite.Value = Pet[E_Globals.Editorindex].Sprite;
			frmPet.Default.EditorPet_DrawPet();
			
			frmPet.Default.nudRange.Value = Pet[E_Globals.Editorindex].Range;
			
			frmPet.Default.nudStrength.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength];
			frmPet.Default.nudEndurance.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance];
			frmPet.Default.nudVitality.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality];
			frmPet.Default.nudLuck.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck];
			frmPet.Default.nudIntelligence.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence];
			frmPet.Default.nudSpirit.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit];
			frmPet.Default.nudLevel.Value = Pet[E_Globals.Editorindex].Level;
			
			if (Pet[E_Globals.Editorindex].StatType == 1)
			{
				frmPet.Default.optCustomStats.Checked = true;
				frmPet.Default.pnlCustomStats.Visible = true;
			}
			else
			{
				frmPet.Default.optAdoptStats.Checked = true;
				frmPet.Default.pnlCustomStats.Visible = false;
			}
			
			frmPet.Default.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;
			
			frmPet.Default.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;
			
			frmPet.Default.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;
			
			//Set skills
			frmPet.Default.cmbSkill1.SelectedIndex = Pet[E_Globals.Editorindex].Skill[1];
			
			frmPet.Default.cmbSkill2.SelectedIndex = Pet[E_Globals.Editorindex].Skill[2];
			
			frmPet.Default.cmbSkill3.SelectedIndex = Pet[E_Globals.Editorindex].Skill[3];
			
			frmPet.Default.cmbSkill4.SelectedIndex = Pet[E_Globals.Editorindex].Skill[4];
			
			if (Pet[E_Globals.Editorindex].LevelingType == 1)
			{
				frmPet.Default.optLevel.Checked = true;
				
				frmPet.Default.pnlPetlevel.Visible = true;
				frmPet.Default.pnlPetlevel.BringToFront();
				frmPet.Default.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;
				if (Pet[E_Globals.Editorindex].MaxLevel > 0)
				{
					frmPet.Default.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;
				}
				frmPet.Default.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;
			}
			else
			{
				frmPet.Default.optDoNotLevel.Checked = true;
				
				frmPet.Default.pnlPetlevel.Visible = false;
				frmPet.Default.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;
				frmPet.Default.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;
				frmPet.Default.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;
			}
			
			if (Pet[E_Globals.Editorindex].Evolvable == 1)
			{
				frmPet.Default.chkEvolve.Checked = true;
			}
			else
			{
				frmPet.Default.chkEvolve.Checked = false;
			}
			
			frmPet.Default.nudEvolveLvl.Value = Pet[E_Globals.Editorindex].EvolveLevel;
			frmPet.Default.cmbEvolve.SelectedIndex = Pet[E_Globals.Editorindex].EvolveNum;
			
			ClearChanged_Pet();
			
			Pet_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void PetEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_PETS; i++)
			{
				if (Pet_Changed[i])
				{
					SendSavePet(i);
				}
			}
			
			frmPet.Default.Dispose();
			
			E_Globals.Editor = (byte) 0;
			ClearChanged_Pet();
			
		}
		
		internal static void PetEditorCancel()
		{
			
			E_Globals.Editor = (byte) 0;
			
			frmPet.Default.Dispose();
			
			ClearChanged_Pet();
			ClearPets();
			SendRequestPets();
			
		}
		
		internal static void ClearChanged_Pet()
		{
			
			Pet_Changed = new bool[Constants.MAX_PETS + 1];
			
		}
		
#endregion
		
	}
}
