using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    static class Block_Related_Function
    {
        public static void All_Block_Move_Up(Form Form_Board)
        {
            foreach (Control control in Form_Board.Controls)
            {
                if (control is Block block && block.Enabled == true)
                {
                    Single_Block_Move_Up(block);
                }
            }
        }

        public static void Single_Block_Move_Up(Block block)
        {
            Point BeforePos = block.Location;
            int currentXPos = block.Location.X;
            int currentYPos = block.Location.Y;

            // right
            while (currentYPos > Block_Position.iBlock_YPos[0])
            {
                currentYPos += (int)Board_Space_Value.STEP_UP;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (Board_Related_Function.getBoardStatus(PossiblePoint) == BLOCK_TYPE.BLANK)
                {
                    block.Location = PossiblePoint;
                    BLOCK_TYPE thisBlockStatus = block.block_Type;
                    Board_Related_Function.changeBoardStatus(PossiblePoint, thisBlockStatus);
                    Board_Related_Function.changeBoardStatus(BeforePos, BLOCK_TYPE.BLANK);
                }
            }
        }
    }
}
