using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Effects : VisualBase
    {
        private static Random rand = new Random();

        private static int num = 100000;
        private static Vector2[] pixels = new Vector2[num];
        private static int[] blood = new int[num];
        private static int[] size = new int[num];
        private static int[] life = new int[num];
        private static int last = 0;


        // ############################################################################
        //                Constructor
        // ############################################################################
        public Effects(Texture2D skin)
        {
            tex = skin;
            for (int i = 0; i < num; i++)
            {
                pixels[i].X = -20;
                life[i] = 0;
                blood[i] = Rand(1,2);
                size[i] = Rand(1, 3);
            }
        }


        // ############################################################################
        //                Boom
        // ############################################################################
        public static void Boom(Vector2 pos)
        {
            for(int i = 0; i < num; i++)
            {
                if(last >= num - 5)
                {
                    last = 0;
                }
                if(life[last] == 0 && last <= num - 5)
                {
                    blood[last] = Rand(1, 2);
                    blood[last + 1] = Rand(1, 2);
                    blood[last + 2] = Rand(1, 2);
                    blood[last + 3] = Rand(1, 2);
                    life[last] = 15;
                    life[last + 1] = 15;
                    life[last + 2] = 15;
                    life[last + 3] = 15;
                    pixels[last] = pos;
                    pixels[last + 1] = pos - new Vector2(Rand(-2, 2), Rand(-2, 2));
                    pixels[last + 2] = pos - new Vector2(Rand(-2, 2), Rand(-2, 2));
                    pixels[last + 3] = pos - new Vector2(Rand(-2, 2), Rand(-2, 2));
                    last += 4;
                    break;
                }
            }
        }

        // ############################################################################
        //                Random
        // ############################################################################
        public static void Clear_blood()
        {
            for(int i = 0; i < num; i++)
            {
                blood[i] = 5;
            }
        }

        // ############################################################################
        //                Random
        // ############################################################################
        public static int Rand(int min, int max)
        {
            int r = rand.Next(min, max + 1);

            return r;
        }


        // ############################################################################
        //                Update
        // ############################################################################
        public override void Update()
        {

            for(int i = 0; i <= num - 1; i++)
            {
                if (life[i] > 0)
                {
                    if (!Controll.Blood)
                    {
                        pixels[i].Y++;
                    }

                    life[i]--;
                }
            }
        }


        // ############################################################################
        //                Draw
        // ############################################################################
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= num - 1; i++)
            {
                if (!Controll.Blood)
                {
                    num = 50000;
                    if (blood[i] == 1)
                    {
                        spriteBatch.Draw(tex, new Rectangle((int)pixels[i].X, (int)pixels[i].Y, size[i], size[i]), Color.Red);
                    }
                    else if (blood[i] == 2)
                    {
                        spriteBatch.Draw(tex, new Rectangle((int)pixels[i].X, (int)pixels[i].Y, size[i], size[i]), Color.DarkRed);
                    }
                }
                else
                {
                    num = 5000;
                    spriteBatch.Draw(tex, new Rectangle((int)pixels[i].X, (int)pixels[i].Y, 5, 5), Color.Purple);
                }
            }
        }
    }
}
