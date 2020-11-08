namespace CurseForgeApp.Controls
{
    partial class AddonUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgAddonThumbnail = new System.Windows.Forms.PictureBox();
            this.lbAddonName = new System.Windows.Forms.Label();
            this.txtAddonDescription = new System.Windows.Forms.RichTextBox();
            this.authorsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddonThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // imgAddonThumbnail
            // 
            this.imgAddonThumbnail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.imgAddonThumbnail.Location = new System.Drawing.Point(3, 3);
            this.imgAddonThumbnail.Name = "imgAddonThumbnail";
            this.imgAddonThumbnail.Size = new System.Drawing.Size(96, 96);
            this.imgAddonThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAddonThumbnail.TabIndex = 0;
            this.imgAddonThumbnail.TabStop = false;
            // 
            // lbAddonName
            // 
            this.lbAddonName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddonName.Location = new System.Drawing.Point(105, 3);
            this.lbAddonName.Name = "lbAddonName";
            this.lbAddonName.Size = new System.Drawing.Size(481, 20);
            this.lbAddonName.TabIndex = 1;
            this.lbAddonName.Text = "lbAddonName_Text";
            this.lbAddonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddonDescription
            // 
            this.txtAddonDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddonDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtAddonDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddonDescription.Location = new System.Drawing.Point(105, 46);
            this.txtAddonDescription.Name = "txtAddonDescription";
            this.txtAddonDescription.ReadOnly = true;
            this.txtAddonDescription.Size = new System.Drawing.Size(483, 53);
            this.txtAddonDescription.TabIndex = 3;
            this.txtAddonDescription.Text = "txtAddonDescription_Text";
            // 
            // authorsContainer
            // 
            this.authorsContainer.BackColor = System.Drawing.Color.Transparent;
            this.authorsContainer.Location = new System.Drawing.Point(105, 25);
            this.authorsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.authorsContainer.Name = "authorsContainer";
            this.authorsContainer.Size = new System.Drawing.Size(481, 21);
            this.authorsContainer.TabIndex = 4;
            this.authorsContainer.WrapContents = false;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(589, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(34, 34);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "»";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // AddonUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.authorsContainer);
            this.Controls.Add(this.txtAddonDescription);
            this.Controls.Add(this.lbAddonName);
            this.Controls.Add(this.imgAddonThumbnail);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddonUserControl";
            this.Size = new System.Drawing.Size(626, 102);
            ((System.ComponentModel.ISupportInitialize)(this.imgAddonThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgAddonThumbnail;
        private System.Windows.Forms.Label lbAddonName;
        private System.Windows.Forms.RichTextBox txtAddonDescription;
        private System.Windows.Forms.FlowLayoutPanel authorsContainer;
        private System.Windows.Forms.Button btnView;
    }
}
