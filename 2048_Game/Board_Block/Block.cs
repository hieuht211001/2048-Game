using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    public enum BLOCK_TYPE
    {
        BLANK,
        BLOCK_2,
        BLOCK_4,
        BLOCK_8,
        BLOCK_16,
        BLOCK_32,
        BLOCK_64,
        BLOCK_128,
        TEMP
    }
    public class Block : PictureBox
    {
        public BLOCK_TYPE block_Type;
        public Block(Point blockPos, BLOCK_TYPE block_type)
        {
            Block_UI(blockPos, ref block_type);
            this.Size = new Size((int)Board_Space_Value.BLOCK_VALUE, (int)Board_Space_Value.BLOCK_VALUE);
            this.Location = blockPos;
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        public void Block_UI(Point blockPos, ref BLOCK_TYPE block_type)
        {
            switch (block_type)
            {
                case BLOCK_TYPE.BLANK:
                    {
                        this.BackColor = Color.FromArgb(234, 216, 192);
                        this.block_Type = BLOCK_TYPE.BLANK;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_2:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_gao;
                        this.block_Type = BLOCK_TYPE.BLOCK_2;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_4:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_bo;
                        this.block_Type = BLOCK_TYPE.BLOCK_4;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_8:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_muoi;
                        this.block_Type = BLOCK_TYPE.BLOCK_8;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_16:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_hieu;
                        this.block_Type = BLOCK_TYPE.BLOCK_16;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_32:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_nhi;
                        this.block_Type = BLOCK_TYPE.BLOCK_32;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_64:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_heart;
                        this.block_Type = BLOCK_TYPE.BLOCK_64;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
                case BLOCK_TYPE.BLOCK_128:
                    {
                        this.BackgroundImage = global::_2048_Game.Properties.Resources._2048game_home;
                        this.block_Type = BLOCK_TYPE.BLOCK_128;
                        Board_Related_Function.changeBoardStatus(blockPos, this.block_Type);
                        break;
                    }
            }
        }
    }
}
