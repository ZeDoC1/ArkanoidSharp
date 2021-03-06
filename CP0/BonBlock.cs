﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CP0
{
    [Serializable]
    class BonBlock : Block
    {
        private Bitmap blocks;

        public BonBlock(int x, int y, char ID, Level lv)
        {
            this.x=x;
            this.y=y;
            this.ID = ID;
            lv.SBlock += show;
        }

        public BonBlock(int x, int y, char ID, Redac Rc)
        {
            this.x = x;
            this.y = y;
            this.ID = ID;
            Rc.SBlock += show;
        }

        public override void show(Form1 f1)
        {
            blocks = new Bitmap(CP0.Properties.Resources.BonBlock64);
            f1.dc.DrawImage(blocks, (int)(x * 64), (int)(y * 16));
        }
        public override void show(Redac f1)
        {
            blocks = new Bitmap(CP0.Properties.Resources.BonBlock64);
            f1.dc.DrawImage(blocks, (int)(x * 64), (int)(y * 16));
        }


    }
}
