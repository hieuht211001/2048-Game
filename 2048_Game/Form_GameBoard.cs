using _2048_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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
            SoundPlayer player = new SoundPlayer(Resources.sound_button_click);
            player.Play();

            Timer timerFinal;
            Dictionary<Point, BLOCK_TYPE> tempBoardStatus = new Dictionary<Point, BLOCK_TYPE>();
            tempBoardStatus = new Dictionary<Point, BLOCK_TYPE>(Board_Related_Function.BoardStatus);
            switch (keyData)
            {
                case Keys.Up:
                    Block_Related_Function.All_Block_Move_Up(this);
                    break;
                case Keys.Down:
                    Block_Related_Function.All_Block_Move_Down(this);
                    break;
                case Keys.Left:
                    Block_Related_Function.All_Block_Move_Left(this);
                    break;
                case Keys.Right:
                    Block_Related_Function.All_Block_Move_Right(this);
                    break;
            }

            timerFinal = new Timer();
            timerFinal.Interval = 10;
            timerFinal.Tick += (sender1, e1) =>
            {
                // only add a new block when all animation is done
                if (AllAnimationTimersStopped())
                {
                    if ((AreDictionariesEqual(tempBoardStatus, Board_Related_Function.BoardStatus) == false)
                        && (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right))
                    { Board_Related_Function.generate_Random_Block_2(this); timerFinal.Stop(); }
                }
            };
            timerFinal.Start();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //function to check all animation timer stoped?
        static bool AllAnimationTimersStopped()
        {
            foreach (var timer in Block_Related_Function.timerStates.Keys)
            {
                if (timer.Enabled) { return false; }
            }
            Block_Related_Function.timerStates.Clear();
            return true;
        }

        public static bool AreDictionariesEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            if (dict1 == null || dict2 == null || dict1.Count != dict2.Count)
                return false;

            foreach (var kvp in dict1)
            {
                if (!dict2.TryGetValue(kvp.Key, out TValue value) || !EqualityComparer<TValue>.Default.Equals(value, kvp.Value))
                    return false;
            }

            return true;
        }
    }
}
