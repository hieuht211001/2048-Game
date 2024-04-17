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
    public partial class Form_GameBoard : Form
    {
        public Form_GameBoard()
        {
            InitializeComponent();
        }

        private void Form_GameBoard_Load(object sender, EventArgs e)
        {
            Board_Related_Function.Board_Init(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    Block_Related_Function.All_Block_Move_Up(this);
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
            }
            Board_Related_Function.generate_Random_Block_2(this);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
