﻿using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.IO;

namespace WangPlugin
{
    internal class GP1Edit:Form
    {
        private Button ImportGP_BTN;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private GP1M gp = new();
        private GP1 gpm = new();
        private Button ExportGP_BTN;
        private Button Edit_GP;
        private TextBox SpeciesBox;
        private TextBox HP_TextBox;
        private TextBox OT_Name;
        private TextBox NickNameBox;
        private Label SpeciesLabel;
        private Label NickNameLabel;
        private Label OT_Name_Label;
        private TextBox Atk_TextBox;
        private TextBox Def_TextBox;
        private Label HP_Label;
        private Label Atk_Label;
        private Label Def_Label;
        private TextBox Move1_TextBox;
        private TextBox Move2_TextBox;
        private Label Move1_label;
        private Label Move2_label;
        private ComboBox GenderBox;
        private const string GoFilter = "Go Park Entity |*.gp1|All Files|*.*";
        private Button CovertToPB7;
        private TextBox CP_TextBox;
        private Label CP_Label;
        private TextBox MetDate_TextBox;
        private Label Time_Label;
        private CheckBox AlolaForm_Check;
        private CheckBox ShinyCheck;
        private GenderType Gtype = GenderType.None;
        enum GenderType
        {
            NULL,
            Male,
            Female,
            None,
        }
        public GP1Edit(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GP1Edit));
            this.ImportGP_BTN = new System.Windows.Forms.Button();
            this.ExportGP_BTN = new System.Windows.Forms.Button();
            this.Edit_GP = new System.Windows.Forms.Button();
            this.SpeciesBox = new System.Windows.Forms.TextBox();
            this.HP_TextBox = new System.Windows.Forms.TextBox();
            this.OT_Name = new System.Windows.Forms.TextBox();
            this.NickNameBox = new System.Windows.Forms.TextBox();
            this.SpeciesLabel = new System.Windows.Forms.Label();
            this.NickNameLabel = new System.Windows.Forms.Label();
            this.OT_Name_Label = new System.Windows.Forms.Label();
            this.Atk_TextBox = new System.Windows.Forms.TextBox();
            this.Def_TextBox = new System.Windows.Forms.TextBox();
            this.HP_Label = new System.Windows.Forms.Label();
            this.Atk_Label = new System.Windows.Forms.Label();
            this.Def_Label = new System.Windows.Forms.Label();
            this.Move1_TextBox = new System.Windows.Forms.TextBox();
            this.Move2_TextBox = new System.Windows.Forms.TextBox();
            this.Move1_label = new System.Windows.Forms.Label();
            this.Move2_label = new System.Windows.Forms.Label();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.CovertToPB7 = new System.Windows.Forms.Button();
            this.CP_TextBox = new System.Windows.Forms.TextBox();
            this.CP_Label = new System.Windows.Forms.Label();
            this.MetDate_TextBox = new System.Windows.Forms.TextBox();
            this.Time_Label = new System.Windows.Forms.Label();
            this.AlolaForm_Check = new System.Windows.Forms.CheckBox();
            this.ShinyCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ImportGP_BTN
            // 
            this.ImportGP_BTN.Location = new System.Drawing.Point(273, 165);
            this.ImportGP_BTN.Name = "ImportGP_BTN";
            this.ImportGP_BTN.Size = new System.Drawing.Size(96, 33);
            this.ImportGP_BTN.TabIndex = 0;
            this.ImportGP_BTN.Text = "ImportGP1";
            this.ImportGP_BTN.UseVisualStyleBackColor = true;
            this.ImportGP_BTN.Click += new System.EventHandler(this.ImportGP_BTN_Click);
            // 
            // ExportGP_BTN
            // 
            this.ExportGP_BTN.Location = new System.Drawing.Point(386, 165);
            this.ExportGP_BTN.Name = "ExportGP_BTN";
            this.ExportGP_BTN.Size = new System.Drawing.Size(96, 33);
            this.ExportGP_BTN.TabIndex = 1;
            this.ExportGP_BTN.Text = "ExportGP1";
            this.ExportGP_BTN.UseVisualStyleBackColor = true;
            this.ExportGP_BTN.Click += new System.EventHandler(this.ExportGP_BTN_Click);
            // 
            // Edit_GP
            // 
            this.Edit_GP.Location = new System.Drawing.Point(152, 166);
            this.Edit_GP.Name = "Edit_GP";
            this.Edit_GP.Size = new System.Drawing.Size(96, 30);
            this.Edit_GP.TabIndex = 2;
            this.Edit_GP.Text = "Save";
            this.Edit_GP.UseVisualStyleBackColor = true;
            this.Edit_GP.Click += new System.EventHandler(this.Edit_GP_Click);
            // 
            // SpeciesBox
            // 
            this.SpeciesBox.Location = new System.Drawing.Point(96, 22);
            this.SpeciesBox.Name = "SpeciesBox";
            this.SpeciesBox.Size = new System.Drawing.Size(106, 25);
            this.SpeciesBox.TabIndex = 3;
            // 
            // HP_TextBox
            // 
            this.HP_TextBox.Location = new System.Drawing.Point(318, 22);
            this.HP_TextBox.Name = "HP_TextBox";
            this.HP_TextBox.Size = new System.Drawing.Size(27, 25);
            this.HP_TextBox.TabIndex = 4;
            // 
            // OT_Name
            // 
            this.OT_Name.Location = new System.Drawing.Point(96, 83);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(106, 25);
            this.OT_Name.TabIndex = 6;
            // 
            // NickNameBox
            // 
            this.NickNameBox.Location = new System.Drawing.Point(96, 52);
            this.NickNameBox.Name = "NickNameBox";
            this.NickNameBox.Size = new System.Drawing.Size(106, 25);
            this.NickNameBox.TabIndex = 7;
            // 
            // SpeciesLabel
            // 
            this.SpeciesLabel.AutoSize = true;
            this.SpeciesLabel.Location = new System.Drawing.Point(29, 25);
            this.SpeciesLabel.Name = "SpeciesLabel";
            this.SpeciesLabel.Size = new System.Drawing.Size(61, 17);
            this.SpeciesLabel.TabIndex = 8;
            this.SpeciesLabel.Text = "Species";
            // 
            // NickNameLabel
            // 
            this.NickNameLabel.AutoSize = true;
            this.NickNameLabel.Location = new System.Drawing.Point(15, 55);
            this.NickNameLabel.Name = "NickNameLabel";
            this.NickNameLabel.Size = new System.Drawing.Size(75, 17);
            this.NickNameLabel.TabIndex = 9;
            this.NickNameLabel.Text = "NickName";
            // 
            // OT_Name_Label
            // 
            this.OT_Name_Label.AutoSize = true;
            this.OT_Name_Label.Location = new System.Drawing.Point(22, 86);
            this.OT_Name_Label.Name = "OT_Name_Label";
            this.OT_Name_Label.Size = new System.Drawing.Size(68, 17);
            this.OT_Name_Label.TabIndex = 10;
            this.OT_Name_Label.Text = "OTName";
            // 
            // Atk_TextBox
            // 
            this.Atk_TextBox.Location = new System.Drawing.Point(385, 21);
            this.Atk_TextBox.Name = "Atk_TextBox";
            this.Atk_TextBox.Size = new System.Drawing.Size(27, 25);
            this.Atk_TextBox.TabIndex = 11;
            // 
            // Def_TextBox
            // 
            this.Def_TextBox.Location = new System.Drawing.Point(455, 21);
            this.Def_TextBox.Name = "Def_TextBox";
            this.Def_TextBox.Size = new System.Drawing.Size(27, 25);
            this.Def_TextBox.TabIndex = 12;
            // 
            // HP_Label
            // 
            this.HP_Label.AutoSize = true;
            this.HP_Label.Location = new System.Drawing.Point(284, 25);
            this.HP_Label.Name = "HP_Label";
            this.HP_Label.Size = new System.Drawing.Size(28, 17);
            this.HP_Label.TabIndex = 13;
            this.HP_Label.Text = "HP";
            // 
            // Atk_Label
            // 
            this.Atk_Label.AutoSize = true;
            this.Atk_Label.Location = new System.Drawing.Point(351, 25);
            this.Atk_Label.Name = "Atk_Label";
            this.Atk_Label.Size = new System.Drawing.Size(28, 17);
            this.Atk_Label.TabIndex = 14;
            this.Atk_Label.Text = "Atk";
            // 
            // Def_Label
            // 
            this.Def_Label.AutoSize = true;
            this.Def_Label.Location = new System.Drawing.Point(418, 25);
            this.Def_Label.Name = "Def_Label";
            this.Def_Label.Size = new System.Drawing.Size(31, 17);
            this.Def_Label.TabIndex = 15;
            this.Def_Label.Text = "Def";
            // 
            // Move1_TextBox
            // 
            this.Move1_TextBox.Location = new System.Drawing.Point(385, 52);
            this.Move1_TextBox.Name = "Move1_TextBox";
            this.Move1_TextBox.Size = new System.Drawing.Size(97, 25);
            this.Move1_TextBox.TabIndex = 16;
            // 
            // Move2_TextBox
            // 
            this.Move2_TextBox.Location = new System.Drawing.Point(385, 83);
            this.Move2_TextBox.Name = "Move2_TextBox";
            this.Move2_TextBox.Size = new System.Drawing.Size(97, 25);
            this.Move2_TextBox.TabIndex = 17;
            // 
            // Move1_label
            // 
            this.Move1_label.AutoSize = true;
            this.Move1_label.Location = new System.Drawing.Point(329, 55);
            this.Move1_label.Name = "Move1_label";
            this.Move1_label.Size = new System.Drawing.Size(50, 17);
            this.Move1_label.TabIndex = 18;
            this.Move1_label.Text = "Move1";
            // 
            // Move2_label
            // 
            this.Move2_label.AutoSize = true;
            this.Move2_label.Location = new System.Drawing.Point(329, 86);
            this.Move2_label.Name = "Move2_label";
            this.Move2_label.Size = new System.Drawing.Size(50, 17);
            this.Move2_label.TabIndex = 19;
            this.Move2_label.Text = "Move2";
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(208, 22);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(69, 25);
            this.GenderBox.TabIndex = 20;
            // 
            // CovertToPB7
            // 
            this.CovertToPB7.Location = new System.Drawing.Point(29, 166);
            this.CovertToPB7.Name = "CovertToPB7";
            this.CovertToPB7.Size = new System.Drawing.Size(105, 30);
            this.CovertToPB7.TabIndex = 21;
            this.CovertToPB7.Text = "CovertToPB7";
            this.CovertToPB7.UseVisualStyleBackColor = true;
            this.CovertToPB7.Click += new System.EventHandler(this.CovertToPB7_Click);
            // 
            // CP_TextBox
            // 
            this.CP_TextBox.Location = new System.Drawing.Point(245, 52);
            this.CP_TextBox.Name = "CP_TextBox";
            this.CP_TextBox.Size = new System.Drawing.Size(78, 25);
            this.CP_TextBox.TabIndex = 22;
            // 
            // CP_Label
            // 
            this.CP_Label.AutoSize = true;
            this.CP_Label.Location = new System.Drawing.Point(210, 55);
            this.CP_Label.Name = "CP_Label";
            this.CP_Label.Size = new System.Drawing.Size(29, 17);
            this.CP_Label.TabIndex = 23;
            this.CP_Label.Text = "CP";
            // 
            // MetDate_TextBox
            // 
            this.MetDate_TextBox.Location = new System.Drawing.Point(96, 114);
            this.MetDate_TextBox.Name = "MetDate_TextBox";
            this.MetDate_TextBox.Size = new System.Drawing.Size(106, 25);
            this.MetDate_TextBox.TabIndex = 24;
            // 
            // Time_Label
            // 
            this.Time_Label.AutoSize = true;
            this.Time_Label.Location = new System.Drawing.Point(29, 117);
            this.Time_Label.Name = "Time_Label";
            this.Time_Label.Size = new System.Drawing.Size(63, 17);
            this.Time_Label.TabIndex = 25;
            this.Time_Label.Text = "MetTime";
            // 
            // AlolaForm_Check
            // 
            this.AlolaForm_Check.AutoSize = true;
            this.AlolaForm_Check.Location = new System.Drawing.Point(210, 116);
            this.AlolaForm_Check.Name = "AlolaForm_Check";
            this.AlolaForm_Check.Size = new System.Drawing.Size(96, 21);
            this.AlolaForm_Check.TabIndex = 26;
            this.AlolaForm_Check.Text = "AlolaForm";
            this.AlolaForm_Check.UseVisualStyleBackColor = true;
            // 
            // ShinyCheck
            // 
            this.ShinyCheck.AutoSize = true;
            this.ShinyCheck.Location = new System.Drawing.Point(210, 85);
            this.ShinyCheck.Name = "ShinyCheck";
            this.ShinyCheck.Size = new System.Drawing.Size(66, 21);
            this.ShinyCheck.TabIndex = 27;
            this.ShinyCheck.Text = "Shiny";
            this.ShinyCheck.UseVisualStyleBackColor = true;
            // 
            // GP1Edit
            // 
            this.ClientSize = new System.Drawing.Size(526, 217);
            this.Controls.Add(this.ShinyCheck);
            this.Controls.Add(this.AlolaForm_Check);
            this.Controls.Add(this.Time_Label);
            this.Controls.Add(this.MetDate_TextBox);
            this.Controls.Add(this.CP_Label);
            this.Controls.Add(this.CP_TextBox);
            this.Controls.Add(this.CovertToPB7);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.Move2_label);
            this.Controls.Add(this.Move1_label);
            this.Controls.Add(this.Move2_TextBox);
            this.Controls.Add(this.Move1_TextBox);
            this.Controls.Add(this.Def_Label);
            this.Controls.Add(this.Atk_Label);
            this.Controls.Add(this.HP_Label);
            this.Controls.Add(this.Def_TextBox);
            this.Controls.Add(this.Atk_TextBox);
            this.Controls.Add(this.OT_Name_Label);
            this.Controls.Add(this.NickNameLabel);
            this.Controls.Add(this.SpeciesLabel);
            this.Controls.Add(this.NickNameBox);
            this.Controls.Add(this.OT_Name);
            this.Controls.Add(this.HP_TextBox);
            this.Controls.Add(this.SpeciesBox);
            this.Controls.Add(this.Edit_GP);
            this.Controls.Add(this.ExportGP_BTN);
            this.Controls.Add(this.ImportGP_BTN);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GP1Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void BindingData()
        {
            this.GenderBox.DataSource = Enum.GetNames(typeof(GenderType));
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                Gtype = (GenderType)Enum.Parse(typeof(GenderType), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.GenderBox.SelectedIndex = 0;
        }
            private void ImportGP1From(string path)
        {
            var data = File.ReadAllBytes(path);
            if (data.Length != GP1.SIZE)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
                return;
            }
            var gp1 = new GP1M();          
            data.CopyTo(gp1.Data, 0);
            data.CopyTo(gpm.Data, 0);
            gp = gp1;
        }
        private void EditGP(GP1M pk)
        {
            byte a = 0;
            byte b = 0;
            pk.Species=SpeciesName.GetSpeciesID(SpeciesBox.Text, 9);
            gp.Username1 = OT_Name.Text;
            var Move1 = Array.IndexOf(GameInfo.Strings.movelist,Move1_TextBox.Text);
            var Move2 = Array.IndexOf(GameInfo.Strings.movelist,Move2_TextBox.Text);
          //gp.Username2 = OName.Text;
            gp.Nickname = NickNameBox.Text;
            gp.IV_HP =Convert.ToInt16(HP_TextBox.Text);
            gp.IV_ATK = Convert.ToInt16(Atk_TextBox.Text);
            gp.IV_DEF = Convert.ToInt16(Def_TextBox.Text);
            gp.Gender = GenderBox.SelectedIndex;
            gp.Move1= Move1;
            gp.Move2= Move2;
            gp.CP = Convert.ToInt16(CP_TextBox.Text);
            gp.Date = Convert.ToInt32(MetDate_TextBox.Text);
            if (ShinyCheck.Checked)
                a = 1;
            gp.IsShiny = a;
            if (AlolaForm_Check.Checked)
                b = 1;
            gp.Form = b;
            gp = pk;
            
        }
        private void ImportGP_BTN_Click(object sender, EventArgs e)
        {
         
            using var sfd = new OpenFileDialog
            {
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
         // Export
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            ImportGP1From(path);
            var Name = SpeciesName.GetSpeciesName(gp.Species, 9);
            var Move1 = ParseSettings.GetMoveName(gp.Move1);
            var Move2 = ParseSettings.GetMoveName(gp.Move2);
            SpeciesBox.Text = Name;
            NickNameBox.Text = gp.Nickname;
            OT_Name.Text = gp.Username1;
          //OName.Text = gp.Username2;
            HP_TextBox.Text = gp.IV_HP.ToString();
            Atk_TextBox.Text = gp.IV_ATK.ToString();
            Def_TextBox.Text = gp.IV_DEF.ToString();
            Move1_TextBox.Text = Move1;
            Move2_TextBox.Text = Move2;
            CP_TextBox.Text = gp.CP.ToString();
            GenderBox.SelectedIndex = gp.Gender%4;
            MetDate_TextBox.Text = gp.Date.ToString();
            if (gp.IsShiny == 1)
                ShinyCheck.Checked = true;
            else
                ShinyCheck.Checked = false;
            if (gp.Form == 1)
                AlolaForm_Check.Checked = true;
            else
                AlolaForm_Check.Checked = false;
        }

        private void ExportGP_BTN_Click(object sender, EventArgs e)
        {
            var data = gp;
            using var sfd = new SaveFileDialog
            {
                FileName = data.FileName,
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(sfd.FileName, data.Data);
        }

        private void Edit_GP_Click(object sender, EventArgs e)
        {
            EditGP(gp);
        }

        private void CovertToPB7_Click(object sender, EventArgs e)
        {
            PB7 pkm ;
            pkm=gpm.ConvertToPB7(SAV.SAV);
            Editor.PopulateFields(pkm, false);
            SAV.ReloadSlots();
        }
    }
}
