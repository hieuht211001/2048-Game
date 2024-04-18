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
        // dictionary that save all <timer for animation> states -> if all animation is done -> add a new block
        public static Dictionary<Timer, bool> timerStates = new Dictionary<Timer, bool>();
        public static void All_Block_Move_Up(Form Form_Board)
        {
            List<Block> blocks = Form_Board.Controls.OfType<Block>().Where(b => b.Enabled).ToList();
            blocks.Sort((b1, b2) => b1.Location.Y.CompareTo(b2.Location.Y));

            // Thực hiện di chuyển cho từng block theo thứ tự
            foreach (Block block in blocks)
            {
                Single_Block_Move_Up(block, Form_Board);
            }
        }

        public static void Single_Block_Move_Up(Block block, Form Form_Board)
        {
            Point BeforePos = block.Location;
            Point AfterPos = BeforePos;
            int currentXPos = block.Location.X;
            int currentYPos = block.Location.Y;
            BLOCK_TYPE thisBlockStatus = block.block_Type;
            bool bPlusFlag = false;
            Timer timer;

            // up
            while (currentYPos > Block_Position.iBlock_YPos[0])
            {
                currentYPos += (int)Board_Space_Value.STEP_UP;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (Board_Related_Function.getBoardStatus(PossiblePoint) == BLOCK_TYPE.BLANK)
                {
                    AfterPos = PossiblePoint;
                }
                else if (Board_Related_Function.getBoardStatus(PossiblePoint) == thisBlockStatus)
                {
                    AfterPos = PossiblePoint;
                    bPlusFlag = true;
                }
                else { break; }
            }

            if (AfterPos == BeforePos) { return;}
            Board_Related_Function.changeBoardStatus(BeforePos, BLOCK_TYPE.BLANK);
            Board_Related_Function.changeBoardStatus(AfterPos, thisBlockStatus);
            if (bPlusFlag) { Board_Related_Function.changeBoardStatus(AfterPos, BLOCK_TYPE.TEMP); }
            int iGap = 0;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender1, e1) =>
            {
                block.BringToFront();
                block.Location = new Point(AfterPos.X, BeforePos.Y - iGap);
                if (iGap == BeforePos.Y - AfterPos.Y) 
                { 
                    timer.Stop();
                    // change state of timer in dictionary (stop)
                    timerStates[timer] = false;
                    if (bPlusFlag) { Block_Plus_Algorithm(block, AfterPos, Form_Board); }
                }
                iGap+=10;
            };
            timer.Start();
            // change state of timer in dictionary (start)
            timerStates[timer] = true;
        }

        public static void All_Block_Move_Down(Form Form_Board)
        {
            List<Block> blocks = Form_Board.Controls.OfType<Block>().Where(b => b.Enabled).ToList();
            blocks.Sort((b1, b2) => b2.Location.Y.CompareTo(b1.Location.Y));

            foreach (Block block in blocks)
            {
                Single_Block_Move_Down(block, Form_Board);
            }
        }

        public static void Single_Block_Move_Down(Block block, Form Form_Board)
        {
            Point BeforePos = block.Location;
            Point AfterPos = BeforePos;
            int currentXPos = block.Location.X;
            int currentYPos = block.Location.Y;
            BLOCK_TYPE thisBlockStatus = block.block_Type;
            bool bPlusFlag = false;
            Timer timer;

            // up
            while (currentYPos < Block_Position.iBlock_YPos[3])
            {
                currentYPos += (int)Board_Space_Value.STEP_DOWN;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (Board_Related_Function.getBoardStatus(PossiblePoint) == BLOCK_TYPE.BLANK)
                {
                    AfterPos = PossiblePoint;
                }
                else if (Board_Related_Function.getBoardStatus(PossiblePoint) == thisBlockStatus)
                {
                    AfterPos = PossiblePoint;
                    bPlusFlag = true;
                }
                else { break; }
            }

            if (AfterPos == BeforePos) { return; }
            Board_Related_Function.changeBoardStatus(BeforePos, BLOCK_TYPE.BLANK);
            Board_Related_Function.changeBoardStatus(AfterPos, thisBlockStatus);
            if (bPlusFlag) { Board_Related_Function.changeBoardStatus(AfterPos, BLOCK_TYPE.TEMP); }
            int iGap = 0;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender1, e1) =>
            {
                block.BringToFront();
                block.Location = new Point(AfterPos.X, BeforePos.Y + iGap);
                if (iGap == AfterPos.Y - BeforePos.Y)
                {
                    timer.Stop();
                    timerStates[timer] = false;
                    if (bPlusFlag) { Block_Plus_Algorithm(block, AfterPos, Form_Board); }
                }
                iGap += 10;
            };
            timer.Start();
            timerStates[timer] = true;
        }

        public static void All_Block_Move_Right(Form Form_Board)
        {
            List<Block> blocks = Form_Board.Controls.OfType<Block>().Where(b => b.Enabled).ToList();
            blocks.Sort((b1, b2) => b2.Location.X.CompareTo(b1.Location.X));

            // Thực hiện di chuyển cho từng block theo thứ tự
            foreach (Block block in blocks)
            {
                Single_Block_Move_Right(block, Form_Board);
            }
        }

        public static void Single_Block_Move_Right(Block block, Form Form_Board)
        {
            Point BeforePos = block.Location;
            Point AfterPos = BeforePos;
            int currentXPos = block.Location.X;
            int currentYPos = block.Location.Y;
            BLOCK_TYPE thisBlockStatus = block.block_Type;
            bool bPlusFlag = false;
            Timer timer;

            // up
            while (currentXPos < Block_Position.iBlock_XPos[3])
            {
                currentXPos += (int)Board_Space_Value.STEP_RIGHT;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (Board_Related_Function.getBoardStatus(PossiblePoint) == BLOCK_TYPE.BLANK)
                {
                    AfterPos = PossiblePoint;
                }
                else if (Board_Related_Function.getBoardStatus(PossiblePoint) == thisBlockStatus)
                {
                    AfterPos = PossiblePoint;
                    bPlusFlag = true;
                }
                else { break; }
            }

            if (AfterPos == BeforePos) { return; }
            Board_Related_Function.changeBoardStatus(BeforePos, BLOCK_TYPE.BLANK);
            Board_Related_Function.changeBoardStatus(AfterPos, thisBlockStatus);
            if (bPlusFlag) { Board_Related_Function.changeBoardStatus(AfterPos, BLOCK_TYPE.TEMP); }
            int iGap = 0;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender1, e1) =>
            {
                block.BringToFront();
                block.Location = new Point(BeforePos.X + iGap, AfterPos.Y);
                if (iGap == AfterPos.X - BeforePos.X)
                {
                    timer.Stop();
                    timerStates[timer] = false;
                    if (bPlusFlag) { Block_Plus_Algorithm(block, AfterPos, Form_Board); }
                }
                iGap += 10;
            };
            timer.Start();
            timerStates[timer] = true;
        }

        public static void All_Block_Move_Left(Form Form_Board)
        {
            List<Block> blocks = Form_Board.Controls.OfType<Block>().Where(b => b.Enabled).ToList();
            blocks.Sort((b1, b2) => b1.Location.X.CompareTo(b2.Location.X));

            // Thực hiện di chuyển cho từng block theo thứ tự
            foreach (Block block in blocks)
            {
                Single_Block_Move_Left(block, Form_Board);
            }
        }

        public static void Single_Block_Move_Left(Block block, Form Form_Board)
        {
            Point BeforePos = block.Location;
            Point AfterPos = BeforePos;
            int currentXPos = block.Location.X;
            int currentYPos = block.Location.Y;
            BLOCK_TYPE thisBlockStatus = block.block_Type;
            bool bPlusFlag = false;
            Timer timer;

            // up
            while (currentXPos > Block_Position.iBlock_XPos[0])
            {
                currentXPos += (int)Board_Space_Value.STEP_LEFT;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (Board_Related_Function.getBoardStatus(PossiblePoint) == BLOCK_TYPE.BLANK)
                {
                    AfterPos = PossiblePoint;
                }
                else if (Board_Related_Function.getBoardStatus(PossiblePoint) == thisBlockStatus)
                {
                    AfterPos = PossiblePoint;
                    bPlusFlag = true;
                }
                else { break; }
            }

            if (AfterPos == BeforePos) { return; }
            Board_Related_Function.changeBoardStatus(BeforePos, BLOCK_TYPE.BLANK);
            Board_Related_Function.changeBoardStatus(AfterPos, thisBlockStatus);
            if (bPlusFlag) { Board_Related_Function.changeBoardStatus(AfterPos, BLOCK_TYPE.TEMP); }
            int iGap = 0;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender1, e1) =>
            {
                block.BringToFront();
                block.Location = new Point(BeforePos.X - iGap, AfterPos.Y);
                if (iGap == BeforePos.X - AfterPos.X)
                {
                    timer.Stop();
                    timerStates[timer] = false;
                    if (bPlusFlag) { Block_Plus_Algorithm(block, AfterPos, Form_Board); }
                }
                iGap += 10;
            };
            timer.Start();
            timerStates[timer] = true;
        }

        public static void Block_Plus_Algorithm(Block block, Point AfterPos, Form Form_Board)
        {
            Block Block_Plus = null;
            switch (block.block_Type)
            {
                case BLOCK_TYPE.BLOCK_2:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_4);
                    Form_Game.TotalScore += 4;
                    break;
                case BLOCK_TYPE.BLOCK_4:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_8);
                    Form_Game.TotalScore += 8;
                    break;
                case BLOCK_TYPE.BLOCK_8:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_16);
                    Form_Game.TotalScore += 16;
                    break;
                case BLOCK_TYPE.BLOCK_16:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_32);
                    Form_Game.TotalScore += 32;
                    break;
                case BLOCK_TYPE.BLOCK_32:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_64);
                    Form_Game.TotalScore += 64;
                    break;
                case BLOCK_TYPE.BLOCK_64:
                    Block_Plus = new Block(AfterPos, BLOCK_TYPE.BLOCK_128);
                    Form_Game.TotalScore += 128;
                    break;
            }
            Form_Board.Controls.Add(Block_Plus);
            Block_Plus.BringToFront();
            for (int i = Form_Board.Controls.Count - 1; i >= 0; i--)
            {
                Control control = Form_Board.Controls[i];
                if (control is Block sameblock && sameblock.Location == AfterPos && sameblock.block_Type == block.block_Type)
                {
                    Form_Board.Controls.RemoveAt(i);
                    sameblock.Dispose();
                }
            }
        }
    }
}
