namespace AGOL_Demo
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Service_URL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Owner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_services = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.rtx_log = new System.Windows.Forms.RichTextBox();
            this.bt_signIn = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_listServices = new System.Windows.Forms.Button();
            this.bt_listWebMaps = new System.Windows.Forms.Button();
            this.cb_featureService = new System.Windows.Forms.CheckBox();
            this.cb_mapService = new System.Windows.Forms.CheckBox();
            this.cb_webMap = new System.Windows.Forms.CheckBox();
            this.cb_others = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Service_URL
            // 
            this.Service_URL.Text = "URL";
            this.Service_URL.Width = 320;
            // 
            // Service_Description
            // 
            this.Service_Description.Text = "Description";
            this.Service_Description.Width = 101;
            // 
            // Service_Type
            // 
            this.Service_Type.Text = "Type";
            this.Service_Type.Width = 127;
            // 
            // Service_Title
            // 
            this.Service_Title.Text = "Title";
            // 
            // Service_Name
            // 
            this.Service_Name.Text = "Name";
            // 
            // Service_Owner
            // 
            this.Service_Owner.Text = "Owner";
            // 
            // Service_ID
            // 
            this.Service_ID.Text = "ID";
            // 
            // Service_Tags
            // 
            this.Service_Tags.Text = "Tags";
            // 
            // lv_services
            // 
            this.lv_services.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_services.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Service_ID,
            this.Service_Owner,
            this.Service_Name,
            this.Service_Title,
            this.Service_Type,
            this.Service_Description,
            this.Service_Tags,
            this.Service_URL});
            this.lv_services.FullRowSelect = true;
            this.lv_services.GridLines = true;
            this.lv_services.HideSelection = false;
            this.lv_services.Location = new System.Drawing.Point(12, 90);
            this.lv_services.MultiSelect = false;
            this.lv_services.Name = "lv_services";
            this.lv_services.Size = new System.Drawing.Size(854, 337);
            this.lv_services.TabIndex = 18;
            this.lv_services.UseCompatibleStateImageBehavior = false;
            this.lv_services.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Log:";
            // 
            // rtx_log
            // 
            this.rtx_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtx_log.Location = new System.Drawing.Point(12, 446);
            this.rtx_log.Name = "rtx_log";
            this.rtx_log.ReadOnly = true;
            this.rtx_log.Size = new System.Drawing.Size(855, 148);
            this.rtx_log.TabIndex = 15;
            this.rtx_log.Text = "";
            // 
            // bt_signIn
            // 
            this.bt_signIn.Location = new System.Drawing.Point(338, 12);
            this.bt_signIn.Name = "bt_signIn";
            this.bt_signIn.Size = new System.Drawing.Size(71, 46);
            this.bt_signIn.TabIndex = 14;
            this.bt_signIn.Text = "Log In";
            this.bt_signIn.UseVisualStyleBackColor = true;
            this.bt_signIn.Click += new System.EventHandler(this.bt_signIn_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(80, 38);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(252, 20);
            this.tb_password.TabIndex = 13;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password:";
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(80, 12);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(252, 20);
            this.tb_userName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Name:";
            // 
            // bt_listServices
            // 
            this.bt_listServices.Enabled = false;
            this.bt_listServices.Location = new System.Drawing.Point(415, 13);
            this.bt_listServices.Name = "bt_listServices";
            this.bt_listServices.Size = new System.Drawing.Size(120, 45);
            this.bt_listServices.TabIndex = 23;
            this.bt_listServices.Text = "List My Contents";
            this.bt_listServices.UseVisualStyleBackColor = true;
            this.bt_listServices.Click += new System.EventHandler(this.bt_listServices_Click);
            // 
            // bt_listWebMaps
            // 
            this.bt_listWebMaps.Enabled = false;
            this.bt_listWebMaps.Location = new System.Drawing.Point(541, 13);
            this.bt_listWebMaps.Name = "bt_listWebMaps";
            this.bt_listWebMaps.Size = new System.Drawing.Size(164, 45);
            this.bt_listWebMaps.TabIndex = 24;
            this.bt_listWebMaps.Text = "List My Organization\'s Contents";
            this.bt_listWebMaps.UseVisualStyleBackColor = true;
            this.bt_listWebMaps.Click += new System.EventHandler(this.bt_listOrgServices_Click);
            // 
            // cb_featureService
            // 
            this.cb_featureService.AutoSize = true;
            this.cb_featureService.Checked = true;
            this.cb_featureService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_featureService.Enabled = false;
            this.cb_featureService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cb_featureService.Location = new System.Drawing.Point(14, 67);
            this.cb_featureService.Name = "cb_featureService";
            this.cb_featureService.Size = new System.Drawing.Size(101, 17);
            this.cb_featureService.TabIndex = 25;
            this.cb_featureService.Text = "Feature Service";
            this.cb_featureService.UseVisualStyleBackColor = true;
            this.cb_featureService.CheckedChanged += new System.EventHandler(this.cb_featureService_CheckedChanged);
            // 
            // cb_mapService
            // 
            this.cb_mapService.AutoSize = true;
            this.cb_mapService.Checked = true;
            this.cb_mapService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mapService.Enabled = false;
            this.cb_mapService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_mapService.Location = new System.Drawing.Point(121, 67);
            this.cb_mapService.Name = "cb_mapService";
            this.cb_mapService.Size = new System.Drawing.Size(86, 17);
            this.cb_mapService.TabIndex = 26;
            this.cb_mapService.Text = "Map Service";
            this.cb_mapService.UseVisualStyleBackColor = true;
            this.cb_mapService.CheckedChanged += new System.EventHandler(this.cb_mapService_CheckedChanged);
            // 
            // cb_webMap
            // 
            this.cb_webMap.AutoSize = true;
            this.cb_webMap.Checked = true;
            this.cb_webMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_webMap.Enabled = false;
            this.cb_webMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cb_webMap.Location = new System.Drawing.Point(213, 67);
            this.cb_webMap.Name = "cb_webMap";
            this.cb_webMap.Size = new System.Drawing.Size(73, 17);
            this.cb_webMap.TabIndex = 27;
            this.cb_webMap.Text = "Web Map";
            this.cb_webMap.UseVisualStyleBackColor = true;
            this.cb_webMap.CheckedChanged += new System.EventHandler(this.cb_webMap_CheckedChanged);
            // 
            // cb_others
            // 
            this.cb_others.AutoSize = true;
            this.cb_others.Checked = true;
            this.cb_others.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_others.Enabled = false;
            this.cb_others.ForeColor = System.Drawing.Color.Gray;
            this.cb_others.Location = new System.Drawing.Point(292, 67);
            this.cb_others.Name = "cb_others";
            this.cb_others.Size = new System.Drawing.Size(57, 17);
            this.cb_others.TabIndex = 28;
            this.cb_others.Text = "Others";
            this.cb_others.UseVisualStyleBackColor = true;
            this.cb_others.CheckedChanged += new System.EventHandler(this.cb_others_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 606);
            this.Controls.Add(this.cb_others);
            this.Controls.Add(this.cb_webMap);
            this.Controls.Add(this.cb_mapService);
            this.Controls.Add(this.cb_featureService);
            this.Controls.Add(this.bt_listWebMaps);
            this.Controls.Add(this.bt_listServices);
            this.Controls.Add(this.lv_services);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtx_log);
            this.Controls.Add(this.bt_signIn);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArcGIS Online REST API Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Service_URL;
        private System.Windows.Forms.ColumnHeader Service_Description;
        private System.Windows.Forms.ColumnHeader Service_Type;
        private System.Windows.Forms.ColumnHeader Service_Title;
        private System.Windows.Forms.ColumnHeader Service_Name;
        private System.Windows.Forms.ColumnHeader Service_Owner;
        private System.Windows.Forms.ColumnHeader Service_ID;
        private System.Windows.Forms.ColumnHeader Service_Tags;
        private System.Windows.Forms.ListView lv_services;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtx_log;
        private System.Windows.Forms.Button bt_signIn;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_listServices;
        private System.Windows.Forms.Button bt_listWebMaps;
        private System.Windows.Forms.CheckBox cb_featureService;
        private System.Windows.Forms.CheckBox cb_mapService;
        private System.Windows.Forms.CheckBox cb_webMap;
        private System.Windows.Forms.CheckBox cb_others;
    }
}

