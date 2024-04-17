
namespace _2048_Game
{
    partial class Form_Game
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
            this.panel_Board = new System.Windows.Forms.Panel();
            this.btn_NewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_Board
            // 
            this.panel_Board.Location = new System.Drawing.Point(10, 160);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(330, 330);
            this.panel_Board.TabIndex = 0;
            // 
            // btn_NewGame
            // 
            this.btn_NewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_NewGame.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewGame.ForeColor = System.Drawing.Color.White;
            this.btn_NewGame.Location = new System.Drawing.Point(224, 104);
            this.btn_NewGame.Name = "btn_NewGame";
            this.btn_NewGame.Size = new System.Drawing.Size(115, 39);
            this.btn_NewGame.TabIndex = 1;
            this.btn_NewGame.Text = "New Game";
            this.btn_NewGame.UseVisualStyleBackColor = false;
            this.btn_NewGame.Click += new System.EventHandler(this.btn_NewGame_Click);
            // 
            // Form_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Controls.Add(this.btn_NewGame);
            this.Controls.Add(this.panel_Board);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_Game";
            this.Text = "Form_Game";
            this.Load += new System.EventHandler(this.Form_Game_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Game_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Game_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_Game_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Button btn_NewGame;
    }
}