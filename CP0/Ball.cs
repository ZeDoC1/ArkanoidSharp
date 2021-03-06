﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace CP0
{
    [Serializable]
    class Ball
    {
        protected Bitmap balls;
        protected float x, y, dx, dy;
        public Ball()
        {
        }
        public Ball(Level lv)
        {
            lv.MoveBall += move;
            lv.SBlock += show;
            lv.BallDChange += changeDir;
            lv.BallStart += startZap;
        }

        

        public Ball(float x, float y, float dx, float dy, Level lv)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            lv.MoveBall += move;
            lv.SBlock += show;
            lv.BallDChange += changeDir;
            lv.BallStart += startZap;
        }

        public void StopDraw(Level lv)
        {
            lv.MoveBall -= move;
            lv.SBlock -= show;
            lv.BallDChange -= changeDir;
            lv.BallStart -= startZap;
        }


        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public void setX(float a)
        {
            x = a;
        }

        public void setY(float a)
        {
            y = a;
        }


        public float getDx()
        {
            return dx;
        }

        public float getDy()
        {
            return dy;
        }

        public void setDx(float a)
        {
            dx = a;
        }

        public void setDy(float a)
        {
            dy = a;
        }


        public void startZap(Form1 f1)
        {
            Random rnd = new Random();
            int num = rnd.Next(1);
            float nap = Convert.ToSingle(rnd.Next(100)) / 100;
            if (nap > (1 - nap * nap))
                nap = 1 - nap * nap;
            if (num == 1)
            {
                
                dx = nap; // от - до +
            }
            else
            {
                dx = -nap;
            }
            dy = -1 + (dx * dx);
            show(f1);
        }
        public virtual bool changeDir(char r, float c = 0, float s = 0)
        {
            bool logic= false;
            if (r != 0)
            {
                if (((r == 'в') || (r == 'В') || (r == 'd') || (r == 'D')) && (x < 534))
                {
                    dx = 1;
                    dy = 0;
                    logic=true;
                }
                else if (((r == 'в') || (r == 'В') || (r == 'd') || (r == 'D')) && (x >= 534)) dx = 0;
                if (((r == 'ф') || (r== 'Ф') || (r == 'a') || (r == 'A')) && (x > 22))
                {
                    dx = -1;
                    dy = 0;
                    logic = true;
                }
                else if (((r == 'ф') || (r== 'Ф') || (r == 'a') || (r == 'A')) && (x <= 22)) dx = 0;

                if (r == 5)
                {
                    if (c == 1) // вправо 
                    {
                        float zc = 0.1F;
                        for (int i = 0; i < 7; i++)
                            if (dx + zc < 1)
                            {
                                dx += zc;
                                break;
                            }
                            else zc /= 10;
                    }
                    else
                    {
                        float zc = 0.1F;
                        for (int i = 0; i < 7; i++)
                            if (dx - zc > -1)
                            {
                                dx -= zc;
                                break;
                            }
                            else zc /= 10;
                    }
                }
            }
            else
            {
                dx = c;
                dy = s;
            }


            if ((r == 1) || (r == 11))
            {
                if (c == 1)
                    dx = dx * (-1);
                else
                    dy = dy * (-1);

            }
            return logic;
        }
        public void move(Form1 f1, int k)
        {
            hide(f1);
            x = x + k * dx;
            y = y + k * dy;
            show(f1);
        }
        protected void hide(Form1 f1)
        {
            balls = new Bitmap(CP0.Properties.Resources.ball0);
            f1.dc.DrawImage(balls, (int)x, (int)y);

        }
        public virtual void show(Form1 f1)
        {

            balls = new Bitmap(CP0.Properties.Resources.ball);
            f1.dc.DrawImage(balls, (int)x, (int)y);
        }
    }
}
