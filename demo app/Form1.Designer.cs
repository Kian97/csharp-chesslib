namespace TestApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.PboxChess = new System.Windows.Forms.PictureBox();
            this.tmr_update = new System.Windows.Forms.Timer(this.components);
            this.PBoxWhite = new System.Windows.Forms.PictureBox();
            this.PBoxBlack = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.gbox_actions = new System.Windows.Forms.GroupBox();
            this.btn_draw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PboxChess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbox_actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PboxChess
            // 
            this.PboxChess.BackgroundImage = global::TestApp.Properties.Resources.background;
            this.PboxChess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PboxChess.Location = new System.Drawing.Point(340, 145);
            this.PboxChess.Name = "PboxChess";
            this.PboxChess.Size = new System.Drawing.Size(512, 512);
            this.PboxChess.TabIndex = 1;
            this.PboxChess.TabStop = false;
            // 
            // PBoxWhite
            // 
            this.PBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.PBoxWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBoxWhite.Location = new System.Drawing.Point(183, 145);
            this.PBoxWhite.Name = "PBoxWhite";
            this.PBoxWhite.Size = new System.Drawing.Size(140, 512);
            this.PBoxWhite.TabIndex = 2;
            this.PBoxWhite.TabStop = false;
            // 
            // PBoxBlack
            // 
            this.PBoxBlack.BackColor = System.Drawing.Color.Transparent;
            this.PBoxBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBoxBlack.Location = new System.Drawing.Point(868, 145);
            this.PBoxBlack.Name = "PBoxBlack";
            this.PBoxBlack.Size = new System.Drawing.Size(140, 512);
            this.PBoxBlack.TabIndex = 3;
            this.PBoxBlack.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::TestApp.Properties.Resources.cooltext162551327107069;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(183, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(825, 100);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_reset
            // 
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(19, 48);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(124, 41);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "Reset game";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // gbox_actions
            // 
            this.gbox_actions.BackColor = System.Drawing.Color.Transparent;
            this.gbox_actions.Controls.Add(this.btn_draw);
            this.gbox_actions.Controls.Add(this.btn_reset);
            this.gbox_actions.Location = new System.Drawing.Point(1026, 145);
            this.gbox_actions.Name = "gbox_actions";
            this.gbox_actions.Size = new System.Drawing.Size(162, 512);
            this.gbox_actions.TabIndex = 6;
            this.gbox_actions.TabStop = false;
            this.gbox_actions.Text = "Actions:";
            // 
            // btn_draw
            // 
            this.btn_draw.Enabled = false;
            this.btn_draw.Location = new System.Drawing.Point(19, 108);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(124, 41);
            this.btn_draw.TabIndex = 6;
            this.btn_draw.Text = "Draw";
            this.btn_draw.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TestApp.Properties.Resources.seamlesswhite;
            this.ClientSize = new System.Drawing.Size(1231, 698);
            this.Controls.Add(this.gbox_actions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PBoxBlack);
            this.Controls.Add(this.PBoxWhite);
            this.Controls.Add(this.PboxChess);
            this.Name = "Form1";
            this.Text = "Demo Implementation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PboxChess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbox_actions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PboxChess;
        private System.Windows.Forms.Timer tmr_update;
        private System.Windows.Forms.PictureBox PBoxWhite;
        private System.Windows.Forms.PictureBox PBoxBlack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.GroupBox gbox_actions;
        private System.Windows.Forms.Button btn_draw;

    }
}

