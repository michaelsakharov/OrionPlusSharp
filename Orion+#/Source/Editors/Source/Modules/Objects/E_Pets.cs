using ASFW;

namespace Engine
{
    static class E_Pets
    {
        internal static PetRec[] Pet = new PetRec[101];
        internal const byte EDITOR_PET = 7;
        internal static bool[] Pet_Changed;

        internal const int PetHpBarWidth = 129;
        internal const int PetMpBarWidth = 129;

        internal static int PetSkillBuffer;
        internal static int PetSkillBufferTimer;
        internal static int[] PetSkillCD;

        internal static bool InitPetEditor;

        // Pet Constants
        internal const byte PET_BEHAVIOUR_FOLLOW = 0; // The pet will attack all npcs around

        internal const byte PET_BEHAVIOUR_GOTO = 1; // If attacked, the pet will fight back
        internal const byte PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT = 2; // The pet will attack all npcs around
        internal const byte PET_ATTACK_BEHAVIOUR_GUARD = 3; // If attacked, the pet will fight back
        internal const byte PET_ATTACK_BEHAVIOUR_DONOTHING = 4; // The pet will not attack even if attacked

        internal struct PetRec
        {
            public int Num;
            public string Name;
            public int Sprite;

            public int Range;

            public int Level;

            public int MaxLevel;
            public int ExpGain;
            public int LevelPnts;

            public byte StatType; // 1 for set stats, 2 for relation to owner's stats
            public byte LevelingType; // 0 for leveling on own, 1 for not leveling

            public byte[] Stat;

            public int[] Skill;

            public byte Evolvable;
            public int EvolveLevel;
            public int EvolveNum;
        }

        internal struct PlayerPetRec
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

            // Client Use Only
            public int XOffset;

            public int YOffset;
            public byte Moving;
            public byte Attacking;
            public int AttackTimer;
            public byte Steps;
            public int Damage;
        }



        public static void SendRequestPets()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CRequestPets);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditPet()
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.CRequestEditPet);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendSavePet(int petNum)
        {
            ByteStream buffer;
            int i;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.EditorPackets.CSavePet);
            buffer.WriteInt32(petNum);

            {
                var withBlock = Pet[petNum];
                buffer.WriteInt32(withBlock.Num);
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(withBlock.Name)));
                buffer.WriteInt32(withBlock.Sprite);
                buffer.WriteInt32(withBlock.Range);
                buffer.WriteInt32(withBlock.Level);
                buffer.WriteInt32(withBlock.MaxLevel);
                buffer.WriteInt32(withBlock.ExpGain);
                buffer.WriteInt32(withBlock.LevelPnts);
                buffer.WriteInt32(withBlock.StatType);
                buffer.WriteInt32(withBlock.LevelingType);

                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    buffer.WriteInt32(withBlock.Stat[i]);

                for (i = 1; i <= 4; i++)
                    buffer.WriteInt32(withBlock.Skill[i]);

                buffer.WriteInt32(withBlock.Evolvable);
                buffer.WriteInt32(withBlock.EvolveLevel);
                buffer.WriteInt32(withBlock.EvolveNum);
            }

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        internal static void Packet_PetEditor(ref byte[] data)
        {
            InitPetEditor = true;
        }

        internal static void Packet_UpdatePet(ref byte[] data)
        {
            int n;
            int i;
            ByteStream buffer = new ByteStream(data);
            n = buffer.ReadInt32();

            Pet[n].Stat = new byte[7];
            Pet[n].Skill = new int[5];

            {
                var withBlock = Pet[n];
                withBlock.Num = buffer.ReadInt32();
                withBlock.Name = buffer.ReadString();
                withBlock.Sprite = buffer.ReadInt32();
                withBlock.Range = buffer.ReadInt32();
                withBlock.Level = buffer.ReadInt32();
                withBlock.MaxLevel = buffer.ReadInt32();
                withBlock.ExpGain = buffer.ReadInt32();
                withBlock.LevelPnts = buffer.ReadInt32();
                withBlock.StatType = (byte)buffer.ReadInt32();
                withBlock.LevelingType = (byte)buffer.ReadInt32();
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    withBlock.Stat[i] = (byte)buffer.ReadInt32();
                for (i = 1; i <= 4; i++)
                    withBlock.Skill[i] = buffer.ReadInt32();

                withBlock.Evolvable = (byte)buffer.ReadInt32();
                withBlock.EvolveLevel = buffer.ReadInt32();
                withBlock.EvolveNum = buffer.ReadInt32();
            }

            buffer.Dispose();
        }



        public static void ClearPet(int index)
        {
            Pet[index].Name = "";

            Pet[index].Stat = new byte[7];
            Pet[index].Skill = new int[5];
        }

        public static void ClearPets()
        {
            int i;

            Pet = new PetRec[101];
            PetSkillCD = new int[5];

            for (i = 1; i <= Constants.MAX_PETS; i++)
                ClearPet(i);
        }



        internal static void PetEditorInit()
        {
            int i;

            if (My.MyProject.Forms.frmPet.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.frmPet.lstIndex.SelectedIndex + 1;

            {
                var withBlock = My.MyProject.Forms.frmPet;
                // populate skill combo's
                withBlock.cmbSkill1.Items.Clear();
                withBlock.cmbSkill2.Items.Clear();
                withBlock.cmbSkill3.Items.Clear();
                withBlock.cmbSkill4.Items.Clear();

                withBlock.cmbSkill1.Items.Add("None");
                withBlock.cmbSkill2.Items.Add("None");
                withBlock.cmbSkill3.Items.Add("None");
                withBlock.cmbSkill4.Items.Add("None");

                for (i = 1; i <= Constants.MAX_SKILLS; i++)
                {
                    withBlock.cmbSkill1.Items.Add(i + ": " + Types.Skill[i].Name);
                    withBlock.cmbSkill2.Items.Add(i + ": " + Types.Skill[i].Name);
                    withBlock.cmbSkill3.Items.Add(i + ": " + Types.Skill[i].Name);
                    withBlock.cmbSkill4.Items.Add(i + ": " + Types.Skill[i].Name);
                }
                withBlock.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Pet[E_Globals.Editorindex].Name);
                if (Pet[E_Globals.Editorindex].Sprite < 0 || Pet[E_Globals.Editorindex].Sprite > withBlock.nudSprite.Maximum)
                    Pet[E_Globals.Editorindex].Sprite = 0;

                withBlock.nudSprite.Value = Pet[E_Globals.Editorindex].Sprite;
                withBlock.EditorPet_DrawPet();

                withBlock.nudRange.Value = Pet[E_Globals.Editorindex].Range;

                withBlock.nudStrength.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength];
                withBlock.nudEndurance.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance];
                withBlock.nudVitality.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality];
                withBlock.nudLuck.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck];
                withBlock.nudIntelligence.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence];
                withBlock.nudSpirit.Value = Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit];
                withBlock.nudLevel.Value = Pet[E_Globals.Editorindex].Level;

                if (Pet[E_Globals.Editorindex].StatType == 1)
                {
                    withBlock.optCustomStats.Checked = true;
                    withBlock.pnlCustomStats.Visible = true;
                }
                else
                {
                    withBlock.optAdoptStats.Checked = true;
                    withBlock.pnlCustomStats.Visible = false;
                }

                withBlock.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;

                withBlock.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;

                withBlock.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;

                // Set skills
                withBlock.cmbSkill1.SelectedIndex = Pet[E_Globals.Editorindex].Skill[1];

                withBlock.cmbSkill2.SelectedIndex = Pet[E_Globals.Editorindex].Skill[2];

                withBlock.cmbSkill3.SelectedIndex = Pet[E_Globals.Editorindex].Skill[3];

                withBlock.cmbSkill4.SelectedIndex = Pet[E_Globals.Editorindex].Skill[4];

                if (Pet[E_Globals.Editorindex].LevelingType == 1)
                {
                    withBlock.optLevel.Checked = true;

                    withBlock.pnlPetlevel.Visible = true;
                    withBlock.pnlPetlevel.BringToFront();
                    withBlock.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;
                    if (Pet[E_Globals.Editorindex].MaxLevel > 0)
                        withBlock.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;
                    withBlock.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;
                }
                else
                {
                    withBlock.optDoNotLevel.Checked = true;

                    withBlock.pnlPetlevel.Visible = false;
                    withBlock.nudPetExp.Value = Pet[E_Globals.Editorindex].ExpGain;
                    withBlock.nudMaxLevel.Value = Pet[E_Globals.Editorindex].MaxLevel;
                    withBlock.nudPetPnts.Value = Pet[E_Globals.Editorindex].LevelPnts;
                }

                if (Pet[E_Globals.Editorindex].Evolvable == 1)
                    withBlock.chkEvolve.Checked = true;
                else
                    withBlock.chkEvolve.Checked = false;

                withBlock.nudEvolveLvl.Value = Pet[E_Globals.Editorindex].EvolveLevel;
                withBlock.cmbEvolve.SelectedIndex = Pet[E_Globals.Editorindex].EvolveNum;
            }

            ClearChanged_Pet();

            Pet_Changed[E_Globals.Editorindex] = true;
        }

        internal static void PetEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_PETS; i++)
            {
                if (Pet_Changed[i])
                    SendSavePet(i);
            }

            My.MyProject.Forms.frmPet.Dispose();

            E_Globals.Editor = 0;
            ClearChanged_Pet();
        }

        internal static void PetEditorCancel()
        {
            E_Globals.Editor = 0;

            My.MyProject.Forms.frmPet.Dispose();

            ClearChanged_Pet();
            ClearPets();
            SendRequestPets();
        }

        internal static void ClearChanged_Pet()
        {
            Pet_Changed = new bool[101];
        }
    }
}
