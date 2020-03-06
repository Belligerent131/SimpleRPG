namespace SimpleRPG
{
    partial class SimpleRPG
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.LblGold = new System.Windows.Forms.Label();
            this.LblHitPoints = new System.Windows.Forms.Label();
            this.selectAction = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnPotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.dgInventory = new System.Windows.Forms.DataGridView();
            this.dgQuests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(28, 20);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "Lvl";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(34, 20);
            this.lblExperience.TabIndex = 6;
            this.lblExperience.Text = "exp";
            // 
            // LblGold
            // 
            this.LblGold.AutoSize = true;
            this.LblGold.Location = new System.Drawing.Point(110, 45);
            this.LblGold.Name = "LblGold";
            this.LblGold.Size = new System.Drawing.Size(43, 20);
            this.LblGold.TabIndex = 5;
            this.LblGold.Text = "Gold";
            // 
            // LblHitPoints
            // 
            this.LblHitPoints.AutoSize = true;
            this.LblHitPoints.Location = new System.Drawing.Point(110, 19);
            this.LblHitPoints.Name = "LblHitPoints";
            this.LblHitPoints.Size = new System.Drawing.Size(56, 20);
            this.LblHitPoints.TabIndex = 4;
            this.LblHitPoints.Text = "Health";
            // 
            // selectAction
            // 
            this.selectAction.AutoSize = true;
            this.selectAction.Location = new System.Drawing.Point(776, 531);
            this.selectAction.Name = "selectAction";
            this.selectAction.Size = new System.Drawing.Size(103, 20);
            this.selectAction.TabIndex = 8;
            this.selectAction.Text = "Select Action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(528, 559);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 28);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(528, 593);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 28);
            this.cboPotions.TabIndex = 10;
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(571, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 30);
            this.btnWest.TabIndex = 11;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(732, 554);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(122, 33);
            this.btnUseWeapon.TabIndex = 12;
            this.btnUseWeapon.Text = "Use Weapon";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnPotion
            // 
            this.btnPotion.Location = new System.Drawing.Point(732, 588);
            this.btnPotion.Name = "btnPotion";
            this.btnPotion.Size = new System.Drawing.Size(122, 34);
            this.btnPotion.TabIndex = 13;
            this.btnPotion.Text = "Use Potion";
            this.btnPotion.UseVisualStyleBackColor = true;
            this.btnPotion.Click += new System.EventHandler(this.btnPotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(652, 433);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 31);
            this.btnNorth.TabIndex = 14;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(732, 457);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 30);
            this.btnEast.TabIndex = 15;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(652, 487);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 34);
            this.btnSouth.TabIndex = 16;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(506, 130);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 286);
            this.rtbMessages.TabIndex = 17;
            this.rtbMessages.Text = "";
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(506, 19);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(360, 105);
            this.rtbLocation.TabIndex = 18;
            this.rtbLocation.Text = "";
            // 
            // dgInventory
            // 
            this.dgInventory.AllowUserToAddRows = false;
            this.dgInventory.AllowUserToDeleteRows = false;
            this.dgInventory.AllowUserToResizeRows = false;
            this.dgInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgInventory.Location = new System.Drawing.Point(16, 130);
            this.dgInventory.MultiSelect = false;
            this.dgInventory.Name = "dgInventory";
            this.dgInventory.ReadOnly = true;
            this.dgInventory.RowHeadersVisible = false;
            this.dgInventory.RowHeadersWidth = 62;
            this.dgInventory.RowTemplate.Height = 28;
            this.dgInventory.Size = new System.Drawing.Size(450, 309);
            this.dgInventory.TabIndex = 19;
            // 
            // dgQuests
            // 
            this.dgQuests.AllowUserToAddRows = false;
            this.dgQuests.AllowUserToDeleteRows = false;
            this.dgQuests.AllowUserToResizeRows = false;
            this.dgQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgQuests.Location = new System.Drawing.Point(16, 446);
            this.dgQuests.MultiSelect = false;
            this.dgQuests.Name = "dgQuests";
            this.dgQuests.ReadOnly = true;
            this.dgQuests.RowHeadersVisible = false;
            this.dgQuests.RowHeadersWidth = 62;
            this.dgQuests.RowTemplate.Height = 28;
            this.dgQuests.Size = new System.Drawing.Size(450, 189);
            this.dgQuests.TabIndex = 20;
            // 
            // SimpleRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 654);
            this.Controls.Add(this.dgQuests);
            this.Controls.Add(this.dgInventory);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnPotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.selectAction);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.LblGold);
            this.Controls.Add(this.LblHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SimpleRPG";
            this.Text = "My Game";
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label LblGold;
        private System.Windows.Forms.Label LblHitPoints;
        private System.Windows.Forms.Label selectAction;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnPotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.DataGridView dgInventory;
        private System.Windows.Forms.DataGridView dgQuests;
    }
}

