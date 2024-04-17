using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Game
{
    public enum Board_Space_Value
    {
        BLOCK_VALUE = 70,
        BLOCK_DISTANCE = 10,
        BLOACK_VALUEnDISTANCE = 80,
        BOARD_VALUE = 330,
        STEP_UP = -80,
        STEP_DOWN = 80,
        STEP_LEFT = -80,
        STEP_RIGHT = 80
    }

    public static class Block_Position
    {
        public readonly static int[] iBlock_XPos = { 10, 90, 170, 250 };
        public readonly static int[] iBlock_YPos = { 10, 90, 170, 250 };
    }
}
