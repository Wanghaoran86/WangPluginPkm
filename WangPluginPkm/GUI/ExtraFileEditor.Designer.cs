﻿using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class ExtraFileEditor
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraFileEditor));
            OpenFile_Dialog = new OpenFileDialog();
            PKLEditor = new TabPage();
            PKL_CLB = new CheckedListBox();
            import_BTN = new Button();
            EH1tabPage = new TabPage();
            groupBox4 = new GroupBox();
            BOX_TextBox = new TextBox();
            LoadEH1_BTN = new Button();
            BOX_Label = new Label();
            GP1Tab = new TabPage();
            GenderBox = new ComboBox();
            GeoName_Label = new Label();
            ImportGP_BTN = new Button();
            GeoName_TextBox = new TextBox();
            SpeciesBox = new TextBox();
            HP_TextBox = new TextBox();
            MetDate_TextBox = new TextBox();
            OT_Name = new TextBox();
            NickNameBox = new TextBox();
            CP_TextBox = new TextBox();
            Atk_TextBox = new TextBox();
            Def_TextBox = new TextBox();
            Move2_TextBox = new TextBox();
            Move1_TextBox = new TextBox();
            ExportGP_BTN = new Button();
            ShinyCheck = new CheckBox();
            Edit_GP = new Button();
            AlolaForm_Check = new CheckBox();
            Time_Label = new Label();
            CP_Label = new Label();
            SpeciesLabel = new Label();
            CovertToPB7 = new Button();
            NickNameLabel = new Label();
            OT_Name_Label = new Label();
            Move2_label = new Label();
            Move1_label = new Label();
            HP_Label = new Label();
            Atk_Label = new Label();
            Def_Label = new Label();
            PKM_TabControl = new TabControl();
            PKL_TEXT = new TextBox();
            PKLEditor.SuspendLayout();
            EH1tabPage.SuspendLayout();
            groupBox4.SuspendLayout();
            GP1Tab.SuspendLayout();
            PKM_TabControl.SuspendLayout();
            SuspendLayout();
            // 
            // OpenFile_Dialog
            // 
            OpenFile_Dialog.Filter = "PokemonHomefile (*.eh1)|*.eh1|All files (*.*)|*.*";
            OpenFile_Dialog.Multiselect = true;
            // 
            // PKLEditor
            // 
            PKLEditor.Controls.Add(PKL_TEXT);
            PKLEditor.Controls.Add(PKL_CLB);
            PKLEditor.Controls.Add(import_BTN);
            PKLEditor.Location = new System.Drawing.Point(4, 24);
            PKLEditor.Name = "PKLEditor";
            PKLEditor.Padding = new Padding(3);
            PKLEditor.Size = new System.Drawing.Size(535, 248);
            PKLEditor.TabIndex = 3;
            PKLEditor.Text = "PKLEditor(WC9)";
            PKLEditor.UseVisualStyleBackColor = true;
            // 
            // PKL_CLB
            // 
            PKL_CLB.FormattingEnabled = true;
            PKL_CLB.Location = new System.Drawing.Point(6, 6);
            PKL_CLB.Name = "PKL_CLB";
            PKL_CLB.Size = new System.Drawing.Size(199, 212);
            PKL_CLB.TabIndex = 1;
            PKL_CLB.SelectedIndexChanged += PKL_CLB_SelectedIndexChanged;
            // 
            // import_BTN
            // 
            import_BTN.Location = new System.Drawing.Point(63, 219);
            import_BTN.Name = "import_BTN";
            import_BTN.Size = new System.Drawing.Size(75, 23);
            import_BTN.TabIndex = 0;
            import_BTN.Text = "导入";
            import_BTN.UseVisualStyleBackColor = true;
            import_BTN.Click += import_BTN_Click;
            // 
            // EH1tabPage
            // 
            EH1tabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            EH1tabPage.Controls.Add(groupBox4);
            EH1tabPage.Location = new System.Drawing.Point(4, 26);
            EH1tabPage.Name = "EH1tabPage";
            EH1tabPage.Padding = new Padding(3);
            EH1tabPage.Size = new System.Drawing.Size(535, 246);
            EH1tabPage.TabIndex = 1;
            EH1tabPage.Text = "EH1Viewer";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BOX_TextBox);
            groupBox4.Controls.Add(LoadEH1_BTN);
            groupBox4.Controls.Add(BOX_Label);
            groupBox4.Location = new System.Drawing.Point(156, 86);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(224, 50);
            groupBox4.TabIndex = 71;
            groupBox4.TabStop = false;
            groupBox4.Text = "EH1查看器";
            // 
            // BOX_TextBox
            // 
            BOX_TextBox.Location = new System.Drawing.Point(44, 17);
            BOX_TextBox.Name = "BOX_TextBox";
            BOX_TextBox.Size = new System.Drawing.Size(65, 21);
            BOX_TextBox.TabIndex = 1;
            BOX_TextBox.Text = "1";
            // 
            // LoadEH1_BTN
            // 
            LoadEH1_BTN.Font = new System.Drawing.Font("黑体", 9F);
            LoadEH1_BTN.Location = new System.Drawing.Point(115, 16);
            LoadEH1_BTN.Name = "LoadEH1_BTN";
            LoadEH1_BTN.Size = new System.Drawing.Size(100, 25);
            LoadEH1_BTN.TabIndex = 0;
            LoadEH1_BTN.Text = "读取EH1";
            LoadEH1_BTN.UseVisualStyleBackColor = true;
            LoadEH1_BTN.Click += LoadEH1_BTN_Click;
            // 
            // BOX_Label
            // 
            BOX_Label.AutoSize = true;
            BOX_Label.Font = new System.Drawing.Font("黑体", 9F);
            BOX_Label.Location = new System.Drawing.Point(6, 21);
            BOX_Label.Name = "BOX_Label";
            BOX_Label.Size = new System.Drawing.Size(29, 12);
            BOX_Label.TabIndex = 2;
            BOX_Label.Text = "箱子";
            // 
            // GP1Tab
            // 
            GP1Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            GP1Tab.Controls.Add(GenderBox);
            GP1Tab.Controls.Add(GeoName_Label);
            GP1Tab.Controls.Add(ImportGP_BTN);
            GP1Tab.Controls.Add(GeoName_TextBox);
            GP1Tab.Controls.Add(SpeciesBox);
            GP1Tab.Controls.Add(HP_TextBox);
            GP1Tab.Controls.Add(MetDate_TextBox);
            GP1Tab.Controls.Add(OT_Name);
            GP1Tab.Controls.Add(NickNameBox);
            GP1Tab.Controls.Add(CP_TextBox);
            GP1Tab.Controls.Add(Atk_TextBox);
            GP1Tab.Controls.Add(Def_TextBox);
            GP1Tab.Controls.Add(Move2_TextBox);
            GP1Tab.Controls.Add(Move1_TextBox);
            GP1Tab.Controls.Add(ExportGP_BTN);
            GP1Tab.Controls.Add(ShinyCheck);
            GP1Tab.Controls.Add(Edit_GP);
            GP1Tab.Controls.Add(AlolaForm_Check);
            GP1Tab.Controls.Add(Time_Label);
            GP1Tab.Controls.Add(CP_Label);
            GP1Tab.Controls.Add(SpeciesLabel);
            GP1Tab.Controls.Add(CovertToPB7);
            GP1Tab.Controls.Add(NickNameLabel);
            GP1Tab.Controls.Add(OT_Name_Label);
            GP1Tab.Controls.Add(Move2_label);
            GP1Tab.Controls.Add(Move1_label);
            GP1Tab.Controls.Add(HP_Label);
            GP1Tab.Controls.Add(Atk_Label);
            GP1Tab.Controls.Add(Def_Label);
            GP1Tab.Location = new System.Drawing.Point(4, 24);
            GP1Tab.Name = "GP1Tab";
            GP1Tab.Padding = new Padding(3);
            GP1Tab.Size = new System.Drawing.Size(535, 248);
            GP1Tab.TabIndex = 0;
            GP1Tab.Text = "GP1Editor";
            // 
            // GenderBox
            // 
            GenderBox.FormattingEnabled = true;
            GenderBox.Location = new System.Drawing.Point(213, 17);
            GenderBox.Name = "GenderBox";
            GenderBox.Size = new System.Drawing.Size(69, 23);
            GenderBox.TabIndex = 20;
            // 
            // GeoName_Label
            // 
            GeoName_Label.AutoSize = true;
            GeoName_Label.Font = new System.Drawing.Font("黑体", 9F);
            GeoName_Label.Location = new System.Drawing.Point(32, 145);
            GeoName_Label.Name = "GeoName_Label";
            GeoName_Label.Size = new System.Drawing.Size(53, 12);
            GeoName_Label.TabIndex = 29;
            GeoName_Label.Text = "地理位置";
            // 
            // ImportGP_BTN
            // 
            ImportGP_BTN.Font = new System.Drawing.Font("黑体", 9F);
            ImportGP_BTN.Location = new System.Drawing.Point(273, 178);
            ImportGP_BTN.Name = "ImportGP_BTN";
            ImportGP_BTN.Size = new System.Drawing.Size(96, 33);
            ImportGP_BTN.TabIndex = 0;
            ImportGP_BTN.Text = "导入GP1";
            ImportGP_BTN.UseVisualStyleBackColor = true;
            ImportGP_BTN.Click += ImportGP_BTN_Click;
            // 
            // GeoName_TextBox
            // 
            GeoName_TextBox.Location = new System.Drawing.Point(101, 140);
            GeoName_TextBox.Name = "GeoName_TextBox";
            GeoName_TextBox.Size = new System.Drawing.Size(386, 21);
            GeoName_TextBox.TabIndex = 28;
            // 
            // SpeciesBox
            // 
            SpeciesBox.Location = new System.Drawing.Point(101, 17);
            SpeciesBox.Name = "SpeciesBox";
            SpeciesBox.Size = new System.Drawing.Size(106, 21);
            SpeciesBox.TabIndex = 3;
            // 
            // HP_TextBox
            // 
            HP_TextBox.Location = new System.Drawing.Point(323, 17);
            HP_TextBox.Name = "HP_TextBox";
            HP_TextBox.Size = new System.Drawing.Size(27, 21);
            HP_TextBox.TabIndex = 4;
            // 
            // MetDate_TextBox
            // 
            MetDate_TextBox.Location = new System.Drawing.Point(101, 109);
            MetDate_TextBox.Name = "MetDate_TextBox";
            MetDate_TextBox.Size = new System.Drawing.Size(106, 21);
            MetDate_TextBox.TabIndex = 24;
            // 
            // OT_Name
            // 
            OT_Name.Location = new System.Drawing.Point(101, 78);
            OT_Name.Name = "OT_Name";
            OT_Name.Size = new System.Drawing.Size(106, 21);
            OT_Name.TabIndex = 6;
            // 
            // NickNameBox
            // 
            NickNameBox.Location = new System.Drawing.Point(101, 47);
            NickNameBox.Name = "NickNameBox";
            NickNameBox.Size = new System.Drawing.Size(106, 21);
            NickNameBox.TabIndex = 7;
            // 
            // CP_TextBox
            // 
            CP_TextBox.Location = new System.Drawing.Point(250, 47);
            CP_TextBox.Name = "CP_TextBox";
            CP_TextBox.Size = new System.Drawing.Size(78, 21);
            CP_TextBox.TabIndex = 22;
            // 
            // Atk_TextBox
            // 
            Atk_TextBox.Location = new System.Drawing.Point(390, 16);
            Atk_TextBox.Name = "Atk_TextBox";
            Atk_TextBox.Size = new System.Drawing.Size(27, 21);
            Atk_TextBox.TabIndex = 11;
            // 
            // Def_TextBox
            // 
            Def_TextBox.Location = new System.Drawing.Point(460, 16);
            Def_TextBox.Name = "Def_TextBox";
            Def_TextBox.Size = new System.Drawing.Size(27, 21);
            Def_TextBox.TabIndex = 12;
            // 
            // Move2_TextBox
            // 
            Move2_TextBox.Location = new System.Drawing.Point(390, 78);
            Move2_TextBox.Name = "Move2_TextBox";
            Move2_TextBox.Size = new System.Drawing.Size(97, 21);
            Move2_TextBox.TabIndex = 17;
            // 
            // Move1_TextBox
            // 
            Move1_TextBox.Location = new System.Drawing.Point(390, 47);
            Move1_TextBox.Name = "Move1_TextBox";
            Move1_TextBox.Size = new System.Drawing.Size(97, 21);
            Move1_TextBox.TabIndex = 16;
            // 
            // ExportGP_BTN
            // 
            ExportGP_BTN.Font = new System.Drawing.Font("黑体", 9F);
            ExportGP_BTN.Location = new System.Drawing.Point(391, 178);
            ExportGP_BTN.Name = "ExportGP_BTN";
            ExportGP_BTN.Size = new System.Drawing.Size(96, 33);
            ExportGP_BTN.TabIndex = 1;
            ExportGP_BTN.Text = "导出GP1";
            ExportGP_BTN.UseVisualStyleBackColor = true;
            ExportGP_BTN.Click += ExportGP_BTN_Click;
            // 
            // ShinyCheck
            // 
            ShinyCheck.AutoSize = true;
            ShinyCheck.Font = new System.Drawing.Font("黑体", 9F);
            ShinyCheck.Location = new System.Drawing.Point(215, 80);
            ShinyCheck.Name = "ShinyCheck";
            ShinyCheck.Size = new System.Drawing.Size(48, 16);
            ShinyCheck.TabIndex = 27;
            ShinyCheck.Text = "闪光";
            ShinyCheck.UseVisualStyleBackColor = true;
            // 
            // Edit_GP
            // 
            Edit_GP.Font = new System.Drawing.Font("黑体", 9F);
            Edit_GP.Location = new System.Drawing.Point(158, 181);
            Edit_GP.Name = "Edit_GP";
            Edit_GP.Size = new System.Drawing.Size(96, 30);
            Edit_GP.TabIndex = 2;
            Edit_GP.Text = "保存";
            Edit_GP.UseVisualStyleBackColor = true;
            Edit_GP.Click += Edit_GP_Click;
            // 
            // AlolaForm_Check
            // 
            AlolaForm_Check.AutoSize = true;
            AlolaForm_Check.Font = new System.Drawing.Font("黑体", 9F);
            AlolaForm_Check.Location = new System.Drawing.Point(215, 111);
            AlolaForm_Check.Name = "AlolaForm_Check";
            AlolaForm_Check.Size = new System.Drawing.Size(84, 16);
            AlolaForm_Check.TabIndex = 26;
            AlolaForm_Check.Text = "阿罗拉形态";
            AlolaForm_Check.UseVisualStyleBackColor = true;
            // 
            // Time_Label
            // 
            Time_Label.AutoSize = true;
            Time_Label.Font = new System.Drawing.Font("黑体", 9F);
            Time_Label.Location = new System.Drawing.Point(32, 114);
            Time_Label.Name = "Time_Label";
            Time_Label.Size = new System.Drawing.Size(53, 12);
            Time_Label.TabIndex = 25;
            Time_Label.Text = "相遇时间";
            // 
            // CP_Label
            // 
            CP_Label.AutoSize = true;
            CP_Label.Location = new System.Drawing.Point(215, 50);
            CP_Label.Name = "CP_Label";
            CP_Label.Size = new System.Drawing.Size(24, 15);
            CP_Label.TabIndex = 23;
            CP_Label.Text = "CP";
            // 
            // SpeciesLabel
            // 
            SpeciesLabel.AutoSize = true;
            SpeciesLabel.Font = new System.Drawing.Font("黑体", 9F);
            SpeciesLabel.Location = new System.Drawing.Point(56, 22);
            SpeciesLabel.Name = "SpeciesLabel";
            SpeciesLabel.Size = new System.Drawing.Size(29, 12);
            SpeciesLabel.TabIndex = 8;
            SpeciesLabel.Text = "种类";
            // 
            // CovertToPB7
            // 
            CovertToPB7.Font = new System.Drawing.Font("黑体", 9F);
            CovertToPB7.Location = new System.Drawing.Point(37, 181);
            CovertToPB7.Name = "CovertToPB7";
            CovertToPB7.Size = new System.Drawing.Size(105, 30);
            CovertToPB7.TabIndex = 21;
            CovertToPB7.Text = "转为PB7";
            CovertToPB7.UseVisualStyleBackColor = true;
            CovertToPB7.Click += CovertToPB7_Click;
            // 
            // NickNameLabel
            // 
            NickNameLabel.AutoSize = true;
            NickNameLabel.Font = new System.Drawing.Font("黑体", 9F);
            NickNameLabel.Location = new System.Drawing.Point(56, 52);
            NickNameLabel.Name = "NickNameLabel";
            NickNameLabel.RightToLeft = RightToLeft.No;
            NickNameLabel.Size = new System.Drawing.Size(29, 12);
            NickNameLabel.TabIndex = 9;
            NickNameLabel.Text = "昵称";
            // 
            // OT_Name_Label
            // 
            OT_Name_Label.AutoSize = true;
            OT_Name_Label.Font = new System.Drawing.Font("黑体", 9F);
            OT_Name_Label.Location = new System.Drawing.Point(20, 84);
            OT_Name_Label.Name = "OT_Name_Label";
            OT_Name_Label.Size = new System.Drawing.Size(65, 12);
            OT_Name_Label.TabIndex = 10;
            OT_Name_Label.Text = "初训家名字";
            // 
            // Move2_label
            // 
            Move2_label.AutoSize = true;
            Move2_label.Font = new System.Drawing.Font("黑体", 9F);
            Move2_label.Location = new System.Drawing.Point(337, 81);
            Move2_label.Name = "Move2_label";
            Move2_label.Size = new System.Drawing.Size(35, 12);
            Move2_label.TabIndex = 19;
            Move2_label.Text = "技能2";
            // 
            // Move1_label
            // 
            Move1_label.AutoSize = true;
            Move1_label.Font = new System.Drawing.Font("黑体", 9F);
            Move1_label.Location = new System.Drawing.Point(337, 52);
            Move1_label.Name = "Move1_label";
            Move1_label.Size = new System.Drawing.Size(35, 12);
            Move1_label.TabIndex = 18;
            Move1_label.Text = "技能1";
            // 
            // HP_Label
            // 
            HP_Label.AutoSize = true;
            HP_Label.Location = new System.Drawing.Point(289, 20);
            HP_Label.Name = "HP_Label";
            HP_Label.Size = new System.Drawing.Size(24, 15);
            HP_Label.TabIndex = 13;
            HP_Label.Text = "HP";
            // 
            // Atk_Label
            // 
            Atk_Label.AutoSize = true;
            Atk_Label.Location = new System.Drawing.Point(356, 20);
            Atk_Label.Name = "Atk_Label";
            Atk_Label.Size = new System.Drawing.Size(23, 15);
            Atk_Label.TabIndex = 14;
            Atk_Label.Text = "Atk";
            // 
            // Def_Label
            // 
            Def_Label.AutoSize = true;
            Def_Label.Location = new System.Drawing.Point(423, 20);
            Def_Label.Name = "Def_Label";
            Def_Label.Size = new System.Drawing.Size(26, 15);
            Def_Label.TabIndex = 15;
            Def_Label.Text = "Def";
            // 
            // PKM_TabControl
            // 
            PKM_TabControl.Controls.Add(GP1Tab);
            PKM_TabControl.Controls.Add(EH1tabPage);
            PKM_TabControl.Controls.Add(PKLEditor);
            PKM_TabControl.Location = new System.Drawing.Point(12, 12);
            PKM_TabControl.Name = "PKM_TabControl";
            PKM_TabControl.SelectedIndex = 0;
            PKM_TabControl.Size = new System.Drawing.Size(543, 276);
            PKM_TabControl.TabIndex = 30;
            // 
            // PKL_TEXT
            // 
            PKL_TEXT.Location = new System.Drawing.Point(211, 6);
            PKL_TEXT.Multiline = true;
            PKL_TEXT.Name = "PKL_TEXT";
            PKL_TEXT.Size = new System.Drawing.Size(318, 212);
            PKL_TEXT.TabIndex = 2;
            // 
            // ExtraFileEditor
            // 
            ClientSize = new System.Drawing.Size(565, 294);
            Controls.Add(PKM_TabControl);
            Font = new System.Drawing.Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ExtraFileEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            PKLEditor.ResumeLayout(false);
            PKLEditor.PerformLayout();
            EH1tabPage.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            GP1Tab.ResumeLayout(false);
            GP1Tab.PerformLayout();
            PKM_TabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        private OpenFileDialog OpenFile_Dialog;
        private TabPage PKLEditor;
        private CheckedListBox PKL_CLB;
        private Button import_BTN;
        private TabPage EH1tabPage;
        private GroupBox groupBox4;
        private TextBox BOX_TextBox;
        private Button LoadEH1_BTN;
        private Label BOX_Label;
        private TabPage GP1Tab;
        private ComboBox GenderBox;
        private Label GeoName_Label;
        private Button ImportGP_BTN;
        private TextBox GeoName_TextBox;
        private TextBox SpeciesBox;
        private TextBox HP_TextBox;
        private TextBox MetDate_TextBox;
        private TextBox OT_Name;
        private TextBox NickNameBox;
        private TextBox CP_TextBox;
        private TextBox Atk_TextBox;
        private TextBox Def_TextBox;
        private TextBox Move2_TextBox;
        private TextBox Move1_TextBox;
        private Button ExportGP_BTN;
        private CheckBox ShinyCheck;
        private Button Edit_GP;
        private CheckBox AlolaForm_Check;
        private Label Time_Label;
        private Label CP_Label;
        private Label SpeciesLabel;
        private Button CovertToPB7;
        private Label NickNameLabel;
        private Label OT_Name_Label;
        private Label Move2_label;
        private Label Move1_label;
        private Label HP_Label;
        private Label Atk_Label;
        private Label Def_Label;
        private TabControl PKM_TabControl;
        private TextBox PKL_TEXT;
    }
}
