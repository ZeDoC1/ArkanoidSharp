﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CP0
{
    [Serializable]
    class Block
    {
        private Bitmap blocks;
        protected int x, y;
        protected char ID;

        public Block()
        {
        }

        public Block(Level lv)
        {
            lv.SBlock += show;
        }

        public Block(int x, int y, char ID, Level lv)
        {
            this.x=x;
            this.y=y;
            this.ID = ID;
            lv.SBlock += show;
        }

        public Block(int x, int y, char ID, Redac Rc)
        {
            this.x = x;
            this.y = y;
            this.ID = ID;
            Rc.SBlock += show;
        }

        public void DisagreeS(Redac Rc)
        {
            Rc.SBlock -= show;
        }

        public void AgreeS(Level lv)
        {
            lv.SBlock += show;
        }

        public void AgreeH(Level lv)
        {
            lv.HBlock += hide;
        }

        public char GetID()
        {
            return ID;
        }
        public int getX() 
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public virtual void show(Form1 f1)
        {
            blocks = new Bitmap(CP0.Properties.Resources.block);
            f1.dc.DrawImage(blocks, (int)(x*64), (int)(y*16));
        }

        public virtual void show(Redac f1)
        {
            blocks = new Bitmap(CP0.Properties.Resources.block);
            f1.dc.DrawImage(blocks, (int)(x * 64), (int)(y * 16));
        }

        public void hide(Form1 f1)
        {
            blocks = new Bitmap(CP0.Properties.Resources.block0);
            f1.dc.DrawImage(blocks, (int)(x * 64), (int)(y * 16));
        }
    }
}
