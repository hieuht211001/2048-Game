using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    public partial class Form_Game : Form
    {
        public Form_GameBoard form_GameBoard = null;
        public bool dragging;
        public Point startPoint;
        public Form_Game()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form_Game_Load(object sender, EventArgs e)
        {
            form_GameBoard = new Form_GameBoard();
            form_GameBoard.TopLevel = false;
            panel_Board.Controls.Add(form_GameBoard);
            int x = (form_GameBoard.Width - form_GameBoard.Width) / 2;
            int y = (form_GameBoard.Height - form_GameBoard.Height) / 2;
            form_GameBoard.Location = new Point(x, y);
            form_GameBoard.Show();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to restart?", "New Game", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Board_Related_Function.Board_Init(form_GameBoard);
            }
            form_GameBoard.Focus();
        }

        private void Form_Game_MouseDown(object sender, MouseEventArgs e)
        {
            Point cursorPos = PointToClient(Cursor.Position);
            int IcursorPosY = Convert.ToInt32(cursorPos.Y);
            if (IcursorPosY < this.Height / 30) { dragging = true; }
            startPoint = new Point(e.X, e.Y);
        }

        private void Form_Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Form_Game_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
