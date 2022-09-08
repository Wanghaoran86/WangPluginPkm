﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using WangPlugin.SortBase;
using PKHeX.Core.Searching;
using static WangPlugin.GUI.DistributionUI;

namespace WangPlugin.GUI
{
    internal class DexBuildForm : Form
    {
        private Button BuildDex_BTN;
        private Button Gen_BTN;
        private TextBox TIDBox;
        private TextBox SIDBox;
        private ComboBox LanguageBox;
        private TextBox OT_Name;
        private ComboBox GenderBox;
        private Label TIDLabel;
        private Label SIDLabel;
        private Label OTLabel;
        private Label LGLabel;
        private Button LivingDex_BTN;
        private ComboBox SortBox;
        private Button Legal_BTN;
        private Button LegalAll_BTN;
        private Button ClearAll_BTN;
        private Button RandomPID_BTN;
        private Button Sort_BTN;
        private Button DeleteBox_BTN;
        private static Random rand = new Random();
        public static Stopwatch sw = new();
        public VersionClass version = new VersionClass
        {
            Name = "按照全国图鉴顺序",
            Version = "National",
        };
        private LanguageBoxSelect7 type7 = LanguageBoxSelect7.ENG;
        private LanguageBoxSelect type = LanguageBoxSelect.ENG;
        public MOD M = MOD.BOXGod;
        public List<VersionClass> L = new();
        private GroupBox groupBox1;
        private ComboBox Mod_Select_Box;
        private Button Gift_BTN;
        private OT_Gender typeG = OT_Gender.Male;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum LanguageBoxSelect
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
        }
        enum LanguageBoxSelect7
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
            KOR,
            CHS,
            CHT,
        }
        enum OT_Gender
        {
            Male,
            Female,
        }
        public enum MOD
        {
            [Description("一箱剑盾神兽")]
            BOXGod,
            [Description("一组未知图腾")]
            BOXUnown,
        }
        public DexBuildForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData(SAV);
        }
        private void BindingData(ISaveFileProvider sav)
        {
            if (sav.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect7));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type7 = (LanguageBoxSelect7)Enum.Parse(typeof(LanguageBoxSelect7), this.LanguageBox.SelectedItem.ToString(), false);
                };
            }
            else
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type = (LanguageBoxSelect)Enum.Parse(typeof(LanguageBoxSelect), this.LanguageBox.SelectedItem.ToString(), false);
                };

            }
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (OT_Gender)Enum.Parse(typeof(OT_Gender), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.LanguageBox.SelectedIndex = 0;
            this.GenderBox.SelectedIndex = 0;
            L = VersionClass.VersionList(sav);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            SortBox.DataSource = bindingSource1.DataSource;
            SortBox.DisplayMember = "Name";
            SortBox.ValueMember = "Version";
            this.SortBox.SelectedIndexChanged += (_, __) =>
            {
                version =(VersionClass) this.SortBox.SelectedItem;
            };
            this.Mod_Select_Box.DisplayMember = "Description";
            this.Mod_Select_Box.ValueMember = "Value";
            this.Mod_Select_Box.DataSource = Enum.GetValues(typeof(MOD))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Mod_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                M = (MOD)Enum.Parse(typeof(MOD), this.Mod_Select_Box.SelectedValue.ToString(), false);
            };
            this.Mod_Select_Box.SelectedIndex = 0;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DexBuildForm));
            this.BuildDex_BTN = new System.Windows.Forms.Button();
            this.Gen_BTN = new System.Windows.Forms.Button();
            this.TIDBox = new System.Windows.Forms.TextBox();
            this.SIDBox = new System.Windows.Forms.TextBox();
            this.OT_Name = new System.Windows.Forms.TextBox();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.TIDLabel = new System.Windows.Forms.Label();
            this.SIDLabel = new System.Windows.Forms.Label();
            this.OTLabel = new System.Windows.Forms.Label();
            this.LGLabel = new System.Windows.Forms.Label();
            this.LivingDex_BTN = new System.Windows.Forms.Button();
            this.SortBox = new System.Windows.Forms.ComboBox();
            this.Legal_BTN = new System.Windows.Forms.Button();
            this.LegalAll_BTN = new System.Windows.Forms.Button();
            this.ClearAll_BTN = new System.Windows.Forms.Button();
            this.RandomPID_BTN = new System.Windows.Forms.Button();
            this.Sort_BTN = new System.Windows.Forms.Button();
            this.DeleteBox_BTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Mod_Select_Box = new System.Windows.Forms.ComboBox();
            this.Gift_BTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            this.BuildDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.BuildDex_BTN.Location = new System.Drawing.Point(120, 133);
            this.BuildDex_BTN.Name = "BuildDex_BTN";
            this.BuildDex_BTN.Size = new System.Drawing.Size(102, 26);
            this.BuildDex_BTN.TabIndex = 0;
            this.BuildDex_BTN.Text = "补齐图鉴";
            this.BuildDex_BTN.UseVisualStyleBackColor = true;
            this.BuildDex_BTN.Click += new System.EventHandler(this.BuildDex_BTN_Click);
            // 
            // Gen_BTN
            // 
            this.Gen_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Gen_BTN.Location = new System.Drawing.Point(331, 22);
            this.Gen_BTN.Name = "Gen_BTN";
            this.Gen_BTN.Size = new System.Drawing.Size(102, 25);
            this.Gen_BTN.TabIndex = 1;
            this.Gen_BTN.Text = "开始覆盖ID";
            this.Gen_BTN.UseVisualStyleBackColor = true;
            this.Gen_BTN.Click += new System.EventHandler(this.Gen_BTN_Click);
            // 
            // TIDBox
            // 
            this.TIDBox.Font = new System.Drawing.Font("Arial", 9F);
            this.TIDBox.Location = new System.Drawing.Point(52, 21);
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(73, 25);
            this.TIDBox.TabIndex = 2;
            this.TIDBox.Text = "10101";
            // 
            // SIDBox
            // 
            this.SIDBox.Font = new System.Drawing.Font("Arial", 9F);
            this.SIDBox.Location = new System.Drawing.Point(52, 54);
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(73, 25);
            this.SIDBox.TabIndex = 3;
            this.SIDBox.Text = "01010";
            // 
            // OT_Name
            // 
            this.OT_Name.Font = new System.Drawing.Font("Arial", 9F);
            this.OT_Name.Location = new System.Drawing.Point(192, 22);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(133, 25);
            this.OT_Name.TabIndex = 4;
            this.OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(210, 53);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(53, 25);
            this.LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(269, 53);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(56, 25);
            this.GenderBox.TabIndex = 6;
            // 
            // TIDLabel
            // 
            this.TIDLabel.AutoSize = true;
            this.TIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.TIDLabel.Location = new System.Drawing.Point(7, 25);
            this.TIDLabel.Name = "TIDLabel";
            this.TIDLabel.Size = new System.Drawing.Size(39, 15);
            this.TIDLabel.TabIndex = 7;
            this.TIDLabel.Text = "表ID";
            // 
            // SIDLabel
            // 
            this.SIDLabel.AutoSize = true;
            this.SIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.SIDLabel.Location = new System.Drawing.Point(7, 58);
            this.SIDLabel.Name = "SIDLabel";
            this.SIDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SIDLabel.Size = new System.Drawing.Size(39, 15);
            this.SIDLabel.TabIndex = 8;
            this.SIDLabel.Text = "里ID";
            // 
            // OTLabel
            // 
            this.OTLabel.AutoSize = true;
            this.OTLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.OTLabel.Location = new System.Drawing.Point(131, 26);
            this.OTLabel.Name = "OTLabel";
            this.OTLabel.Size = new System.Drawing.Size(55, 15);
            this.OTLabel.TabIndex = 9;
            this.OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            this.LGLabel.AutoSize = true;
            this.LGLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.LGLabel.Location = new System.Drawing.Point(131, 58);
            this.LGLabel.Name = "LGLabel";
            this.LGLabel.Size = new System.Drawing.Size(79, 15);
            this.LGLabel.TabIndex = 10;
            this.LGLabel.Text = "性别/语言";
            // 
            // LivingDex_BTN
            // 
            this.LivingDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LivingDex_BTN.Location = new System.Drawing.Point(12, 133);
            this.LivingDex_BTN.Name = "LivingDex_BTN";
            this.LivingDex_BTN.Size = new System.Drawing.Size(102, 25);
            this.LivingDex_BTN.TabIndex = 11;
            this.LivingDex_BTN.Text = "生成全图鉴";
            this.LivingDex_BTN.UseVisualStyleBackColor = true;
            this.LivingDex_BTN.Click += new System.EventHandler(this.LivingDex_BTN_Click);
            // 
            // SortBox
            // 
            this.SortBox.FormattingEnabled = true;
            this.SortBox.Location = new System.Drawing.Point(12, 102);
            this.SortBox.Name = "SortBox";
            this.SortBox.Size = new System.Drawing.Size(318, 25);
            this.SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            this.Legal_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Legal_BTN.Location = new System.Drawing.Point(444, 132);
            this.Legal_BTN.Name = "Legal_BTN";
            this.Legal_BTN.Size = new System.Drawing.Size(102, 25);
            this.Legal_BTN.TabIndex = 13;
            this.Legal_BTN.Text = "合法化箱子";
            this.Legal_BTN.UseVisualStyleBackColor = true;
            this.Legal_BTN.Click += new System.EventHandler(this.Legal_BTN_Click);
            // 
            // LegalAll_BTN
            // 
            this.LegalAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LegalAll_BTN.Location = new System.Drawing.Point(445, 101);
            this.LegalAll_BTN.Name = "LegalAll_BTN";
            this.LegalAll_BTN.Size = new System.Drawing.Size(102, 25);
            this.LegalAll_BTN.TabIndex = 14;
            this.LegalAll_BTN.Text = "合法化全部";
            this.LegalAll_BTN.UseVisualStyleBackColor = true;
            this.LegalAll_BTN.Click += new System.EventHandler(this.LegalAll_BTN_Click);
            // 
            // ClearAll_BTN
            // 
            this.ClearAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ClearAll_BTN.Location = new System.Drawing.Point(336, 133);
            this.ClearAll_BTN.Name = "ClearAll_BTN";
            this.ClearAll_BTN.Size = new System.Drawing.Size(102, 25);
            this.ClearAll_BTN.TabIndex = 15;
            this.ClearAll_BTN.Text = "删除全部";
            this.ClearAll_BTN.UseVisualStyleBackColor = true;
            this.ClearAll_BTN.Click += new System.EventHandler(this.ClearAll_BTN_Click);
            // 
            // RandomPID_BTN
            // 
            this.RandomPID_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.RandomPID_BTN.Location = new System.Drawing.Point(331, 54);
            this.RandomPID_BTN.Name = "RandomPID_BTN";
            this.RandomPID_BTN.Size = new System.Drawing.Size(102, 25);
            this.RandomPID_BTN.TabIndex = 16;
            this.RandomPID_BTN.Text = "随机PID/EC";
            this.RandomPID_BTN.UseVisualStyleBackColor = true;
            this.RandomPID_BTN.Click += new System.EventHandler(this.RandomPID_BTN_Click);
            // 
            // Sort_BTN
            // 
            this.Sort_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Sort_BTN.Location = new System.Drawing.Point(336, 101);
            this.Sort_BTN.Name = "Sort_BTN";
            this.Sort_BTN.Size = new System.Drawing.Size(102, 25);
            this.Sort_BTN.TabIndex = 17;
            this.Sort_BTN.Text = "开始排序";
            this.Sort_BTN.UseVisualStyleBackColor = true;
            this.Sort_BTN.Click += new System.EventHandler(this.Sort_BTN_Click);
            // 
            // DeleteBox_BTN
            // 
            this.DeleteBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.DeleteBox_BTN.Location = new System.Drawing.Point(228, 133);
            this.DeleteBox_BTN.Name = "DeleteBox_BTN";
            this.DeleteBox_BTN.Size = new System.Drawing.Size(102, 25);
            this.DeleteBox_BTN.TabIndex = 18;
            this.DeleteBox_BTN.Text = "删除箱子";
            this.DeleteBox_BTN.UseVisualStyleBackColor = true;
            this.DeleteBox_BTN.Click += new System.EventHandler(this.DeleteBox_BTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RandomPID_BTN);
            this.groupBox1.Controls.Add(this.LGLabel);
            this.groupBox1.Controls.Add(this.OTLabel);
            this.groupBox1.Controls.Add(this.SIDLabel);
            this.groupBox1.Controls.Add(this.TIDLabel);
            this.groupBox1.Controls.Add(this.GenderBox);
            this.groupBox1.Controls.Add(this.LanguageBox);
            this.groupBox1.Controls.Add(this.OT_Name);
            this.groupBox1.Controls.Add(this.SIDBox);
            this.groupBox1.Controls.Add(this.TIDBox);
            this.groupBox1.Controls.Add(this.Gen_BTN);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 90);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "编辑全部箱子";
            // 
            // Mod_Select_Box
            // 
            this.Mod_Select_Box.FormattingEnabled = true;
            this.Mod_Select_Box.Location = new System.Drawing.Point(448, 28);
            this.Mod_Select_Box.Name = "Mod_Select_Box";
            this.Mod_Select_Box.Size = new System.Drawing.Size(98, 25);
            this.Mod_Select_Box.TabIndex = 68;
            // 
            // Gift_BTN
            // 
            this.Gift_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Gift_BTN.Location = new System.Drawing.Point(448, 60);
            this.Gift_BTN.Name = "Gift_BTN";
            this.Gift_BTN.Size = new System.Drawing.Size(100, 25);
            this.Gift_BTN.TabIndex = 69;
            this.Gift_BTN.Text = "开始生成";
            this.Gift_BTN.UseVisualStyleBackColor = true;
            this.Gift_BTN.Click += new System.EventHandler(this.Gift_BTN_Click);
            // 
            // DexBuildForm
            // 
            this.ClientSize = new System.Drawing.Size(559, 171);
            this.Controls.Add(this.Gift_BTN);
            this.Controls.Add(this.Mod_Select_Box);
            this.Controls.Add(this.Sort_BTN);
            this.Controls.Add(this.LivingDex_BTN);
            this.Controls.Add(this.BuildDex_BTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearAll_BTN);
            this.Controls.Add(this.DeleteBox_BTN);
            this.Controls.Add(this.SortBox);
            this.Controls.Add(this.LegalAll_BTN);
            this.Controls.Add(this.Legal_BTN);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DexBuildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private int GetLanguageBox7()
        {
            var T = 1;
            switch (type7)
            {
                case LanguageBoxSelect7.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect7.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect7.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect7.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect7.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect7.ESP:
                    T = 7;
                    break;
                case LanguageBoxSelect7.KOR:
                    T = 8;
                    break;
                case LanguageBoxSelect7.CHS:
                    T = 9;
                    break;
                case LanguageBoxSelect7.CHT:
                    T = 10;
                    break;
            }
            return T;
        }
        private int GetLanguageBox()
        {
            var T = 1;
            switch (type)
            {
                case LanguageBoxSelect.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect.ESP:
                    T = 7;
                    break;
            }
            return T;
        }
        private int GetGender()
        {
            var T = 0;
            switch (typeG)
            {
                case OT_Gender.Male:
                    T = 0;
                    break;
                case OT_Gender.Female:
                    T = 1;
                    break;
            }
            return T;
        }
        public void Gen(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetID);
            SaveFileEditor.ReloadSlots();
        }
        public void SetID(PKM pkm)
        {
            var TID = Int32.Parse(TIDBox.Text);
            var SID = Int32.Parse(SIDBox.Text);
            var Name = OT_Name.Text;
            
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                 GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
                pkm.Language=GetLanguageBox7();
            else
                pkm.Language = GetLanguageBox();
            pkm.OT_Name = Name;
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
               GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                pkm.TrainerID7 = TID;
                pkm.TrainerSID7 = SID;
            }
            else
            {
                pkm.TID = TID;
                pkm.SID = SID;
                
            }
            pkm.OT_Gender = GetGender();
            pkm.ClearNickname();
        }
        public void UnionPKM(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var a = sav.GetAllPKM();
            var pkms = sav.GenerateLivingDex(out int attempts).ToList();
            foreach (var item in a)
            {
                var pk=pkms.Find(x => x.Species==item.Species);
                pkms.Remove(pk);
            }
            var o = a.Union(pkms);
            o=o.OrderBySpecies();
            var bd = sav.BoxData;
            o.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public void LivingDex(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var pkms = sav.GenerateLivingDex(out int attempts);
            var bd = sav.BoxData;
            pkms.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public static void LegalBox(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBox(sav.CurrentBox);
        }
        public static void LegalAll(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBoxes();
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }
        public static void RandomPKM(PKM pkm)
        {
            pkm.PID=Util.Rand32();
            if (pkm.Generation >= 6)
            {
                pkm.SetRandomEC();
            }
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        private void SortByRegionalDex(Func<PKM, IComparable>[] sortFunctions)
        {
            IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(sortFunctions);
            SAV.SAV.SortBoxes(0, -1, sortMethod);
            SAV.ReloadSlots();
        }
        private void SortByNationalDex()
        {
            SAV.SAV.SortBoxes();
            SAV.ReloadSlots();
        }
        public void SetUnown(ISaveFileProvider SaveFileEditor)
        {
            List<PKM> PKL = new();
            for (int i = 0; i < 28; i++)
            {
                var pk = GetUnown();
                pk.Form = (byte)i;
                pk.HealPP();
                PKL.Add(pk);
            }
           
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                DexBuildForm.LegalBox(SAV);
            }
            SaveFileEditor.ReloadSlots();
        }
        public PKM GetUnown()
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = 201,
                SearchEgg = false,
                Version = (int)SAV.SAV.Version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            PKM pk = Editor.Data;
            
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                pk = enc.ConvertToPKM(SAV.SAV);
            }
            return pk;
        }
        private static List<int> FindAllEmptySlots(IList<PKM> data, int start)
        {
            List<int> list = new List<int>();
            for (int i = start; i < data.Count; i++)
            {
                if (data[i].Species < 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        private void Gen_BTN_Click(object sender, EventArgs e)
        {
            Gen(SAV);
            MessageBox.Show("搞定了！");
        }
        private void BuildDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            UnionPKM(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void LivingDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LivingDex(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void Legal_BTN_Click(object sender, EventArgs e)
        {
            LegalBox(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }
        private void LegalAll_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LegalAll(SAV);
            SAV.ReloadSlots();
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void ClearAll_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            SAV.ReloadSlots();
        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKM);
            SAV.ReloadSlots();
        }
        private void Sort_BTN_Click(object sender, EventArgs e)
        {
            switch (version.Version)
            {
                case "National":
                    {
                        SortByNationalDex();
                        break;
                    }
                case "RYBG":
                    {
                        SortByRegionalDex(Gen1_Kanto.GetSortFunctions());
                        break;
                    }
                case "GS":
                    {
                        SortByRegionalDex(Gen2_Johto.GetSortFunctions());
                        break;
                    }
                case "E":
                    {
                        SortByRegionalDex(Gen3_Hoenn.GetSortFunctions());
                        break;
                    }
                case "FRGL":
                    {
                        SortByRegionalDex(Gen3_Kanto.GetSortFunctions());
                        break;
                    }
                case "DP":
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetDPSortFunctions());
                        break;
                    }
                case "Platinum":
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetPtSortFunctions());
                        break;
                    }
                case "GHSS":
                    {
                        SortByRegionalDex(Gen4_Johto.GetSortFunctions());
                        break;
                    }
                case "BW":
                    {
                        SortByRegionalDex(Gen5_Unova.GetBWSortFunctions());
                        break;
                    }
                case "B2W2":
                    {
                        SortByRegionalDex(Gen5_Unova.GetB2W2SortFunctions());
                        break;
                    }
                case "XY":
                    {
                        SortByRegionalDex(Gen6_Kalos.GetSortFunctions());
                        break;
                    }
                case "ORAS":
                    {
                        SortByRegionalDex(Gen6_Hoenn.GetSortFunctions());
                        break;
                    }
                case "SM":
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullSMSortFunctions());
                        break;
                    }
                case "USUM":
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullUSUMSortFunctions());
                        break;
                    }
                case "LPLE":
                    {
                        SortByRegionalDex(Gen7_Kanto.GetSortFunctions());
                        break;
                    }
                case "SWSH":
                    {
                        SortByRegionalDex(Gen8_Galar.GetGalarDexSortFunctions());
                        break;
                    }
                case "SWSH1":
                    {
                        SortByRegionalDex(Gen8_Galar.GetIoADexSortFunctions());
                        break;
                    }
                case "SWSH2":
                    {
                        SortByRegionalDex(Gen8_Galar.GetCTDexSortFunction());
                        break;
                    }
                case "SWSH3":
                    {
                        SortByRegionalDex(Gen8_Galar.GetFullGalarDexSortFunctions());
                        break;
                    }
                case "BDSP":
                    {
                        SortByRegionalDex(Gen8_Sinnoh.GetSortFunctions());
                        break;
                    }
                case "PLA":
                    {
                        SortByRegionalDex(Gen8_Hisui.GetSortFunctions());
                        break;
                    }
            }
            MessageBox.Show("排序完成", "SuperWang");
        }
        private void DeleteBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM,SAV.CurrentBox,SAV.CurrentBox);
            SAV.ReloadSlots();
        }
        private void GODex_BTN_Click(object sender, EventArgs e)
        {
            GODex(SAV);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        private void GODex(ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            PKM pk ;
            ushort j;
            List<PKM> pkMList;
            List<PKM> p=new();
            pkMList = (List<PKM>)SaveFileEditor.SAV.GetAllPKM();
           // MessageBox.Show($"{pkMList.Count()}");
            for (int i = 0; i < pkMList.Count(); i++)
            {
                pk = pkMList[i];
                var pkc = pk.Clone();
                j = pk.Species;
                var setting = new SearchSettings
                {
                    Species = pk.Species,
                    SearchEgg = false,
                    Version = 34,
                };
                var search = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV);
                var results = search.ToList();
               // MessageBox.Show($"{results.Count}");

                if (results.Count != 0)
                {
                    Results = results;
                    enc = Results[0];
                    var criteria = EncounterUtil.GetCriteria(enc, pk);
                    EntityConverter.TryMakePKMCompatible(enc.ConvertToPKM(SaveFileEditor.SAV, criteria), pk, out var c, out pk);
                    pk.Species = j;
                    pk.ClearNickname();
                    pk.Ability = pkc.Ability;
                    pk.OT_Name = RandomString(6);
                    pk.SetSuggestedMoves();
                    if( pk.Move1 != 0)
                        pk.SetSuggestedMovePP(0);
                    if (pk.Move2 != 0)
                        pk.SetSuggestedMovePP(1);
                    if (pk.Move3 != 0)
                        pk.SetSuggestedMovePP(2);
                    if (pk.Move4 != 0)
                        pk.SetSuggestedMovePP(3);
                    pk.RefreshChecksum();
                    p.Add(pk);
                }
                else
                    p.Add(pkc);
            }
            for (int i = 0; i < SaveFileEditor.SAV.BoxCount; i++)
            {
                for (j = 0; j < 30; j++)
                {
                    if (pkMList.Count >(i * 30 + j))
                        SaveFileEditor.SAV.SetBoxSlotAtIndex(p[i * 30 + j], i, j);
                    else
                        break;
                }
            }
            SaveFileEditor.ReloadSlots();
        }

        private void Gift_BTN_Click(object sender, EventArgs e)
        {
                switch (M)
                {
                    case MOD.BOXGod:
                       // SetGodPokemon(SAV);
                        break;
                    case MOD.BOXUnown:
                        SetUnown(SAV);
                        break;
                }
                SAV.ReloadSlots();
        }
    }
}
