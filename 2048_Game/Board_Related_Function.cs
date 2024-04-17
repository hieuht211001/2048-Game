using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    static class Board_Related_Function
    {
        public static Dictionary< Point, BLOCK_TYPE> BoardStatus = new Dictionary< Point, BLOCK_TYPE>();

        public static void changeBoardStatus(Point blockPos, BLOCK_TYPE blockTargetStatus)
        {
            BoardStatus[blockPos] = blockTargetStatus;
        }

        public static BLOCK_TYPE getBoardStatus(Point blockPos)
        {
            return BoardStatus[blockPos];
        }

        public static void Board_Init(Form Form_Board)
        {
            // delete previous block
            for (int i = Form_Board.Controls.Count - 1; i >= 0; i--)
            {
                Control control = Form_Board.Controls[i];
                Form_Board.Controls.RemoveAt(i);
                control.Dispose();
            }

            int iRow, iCollum;
            for (int rowNum = 0; rowNum < 4; rowNum++)
            {
                iRow = ((int)Board_Space_Value.BLOACK_VALUEnDISTANCE * rowNum) + (int)Board_Space_Value.BLOCK_DISTANCE;

                for (int collumNum = 0; collumNum < 4; collumNum++)
                {
                    iCollum = ((int)Board_Space_Value.BLOACK_VALUEnDISTANCE * collumNum) + (int)Board_Space_Value.BLOCK_DISTANCE;
                    Block default_Block = new Block(new Point(iRow, iCollum), BLOCK_TYPE.BLANK);
                    default_Block.Enabled = false;
                    Form_Board.Controls.Add(default_Block);
                    default_Block.BringToFront();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                generate_Random_Block_2(Form_Board);
            }
        }

        public static void generate_Random_Block_2(Form Form_Board)
        {
            int xPos = -1;
            int yPos = -1;

            Random random = new Random();
            bool iStop = false;
            while (!iStop)
            {
                xPos = random.Next(0, 4);
                yPos = random.Next(0, 4);
                if (getBoardStatus(new Point(Block_Position.iBlock_XPos[xPos], Block_Position.iBlock_YPos[yPos])) == BLOCK_TYPE.BLANK)
                {
                    iStop = true;
                }
            }
            Block Block_2 = new Block(new Point(Block_Position.iBlock_XPos[xPos], Block_Position.iBlock_YPos[yPos]), BLOCK_TYPE.BLOCK_2);
            Form_Board.Controls.Add(Block_2);
            Block_2.BringToFront();
        }
    }
}
