using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class soldiers : VisualBase
    {
        private static int soldierAmount = 100;
        private int change = 1;
        private int movement_speed = 1;
        private int turns = 5;
        private static Vector2[] redSoldiers = new Vector2[soldierAmount];
        private static Vector2[] blueSoldiers = new Vector2[soldierAmount];
        private Random rand = new Random();

        public soldiers(Texture2D skin)
        {
            tex = skin;

            for (int i = soldierAmount - 1; i >= 0; i--)
            {
                redSoldiers[i] = new Vector2(Rand(1, 410), Rand(1, 460));
                blueSoldiers[i] = new Vector2(Rand(410, 800), Rand(1, 460));
            }
        }

        public void Collision()
        {
            for (int i = soldierAmount - 1; i >= 0; i--)
            {
                for (int o = soldierAmount - 1; o >= 0; o--)
                {
                    if (redSoldiers[i].X > blueSoldiers[o].X - 10 && redSoldiers[i].X < blueSoldiers[o].X + 10)
                    {
                        if (redSoldiers[i].Y > blueSoldiers[o].Y - 10 && redSoldiers[i].Y < blueSoldiers[o].Y + 10)
                        {
                            if(Rand(0, 10) == 0)
                            {
                                redSoldiers[i] = new Vector2(Rand(1, 410), Rand(1, 460));
                            }
                            else
                            {
                                blueSoldiers[o] = new Vector2(Rand(410, 800), Rand(1, 460));
                            }
                        }
                    }
                }
            }
        }

        public void Movement()
        {
            for (int i = soldierAmount - 1; i >= 0; i--)
            {

                if (redSoldiers[i].X < blueSoldiers[Rand(0, soldierAmount - 1)].X - 10)
                {
                    redSoldiers[i].X += movement_speed + Rand(0, change);
                }
                else
                {
                    redSoldiers[i].X -= movement_speed + Rand(0, change);
                }
                if (redSoldiers[i].Y < blueSoldiers[Rand(0, soldierAmount - 1)].Y - 10)
                {
                    redSoldiers[i].Y += movement_speed + Rand(0, change);
                }
                else
                {
                    redSoldiers[i].Y -= movement_speed + Rand(0, change);
                }
            }
            for (int i = soldierAmount - 1; i >= 0; i--)
            {
                if (blueSoldiers[i].X < redSoldiers[Rand(0, soldierAmount - 1)].X - 10)
                {
                    blueSoldiers[i].X += movement_speed + Rand(0, change);
                }
                else
                {
                    blueSoldiers[i].X -= movement_speed + Rand(0, change);
                }
                if (blueSoldiers[i].Y < redSoldiers[Rand(0, soldierAmount - 1)].Y - 10)
                {
                    blueSoldiers[i].Y += movement_speed + Rand(0, change);
                }
                else
                {
                    blueSoldiers[i].Y -= movement_speed + Rand(0, change);
                }
            }
        }

        public int Rand(int min, int max)
        {
            int r = rand.Next(min, max + 1);

            return r;
        }

        public override void Update()
        {
            Collision();
            if(turns == 0)
            {
                Movement();
                turns = 1;
            }
            else if(turns > 0)
            {
                turns--;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = soldierAmount - 1; i >= 0; i--)
            {
                spriteBatch.Draw(tex, new Rectangle((int)redSoldiers[i].X, (int)redSoldiers[i].Y, 10, 10), Color.Red);
                spriteBatch.Draw(tex, new Rectangle((int)blueSoldiers[i].X, (int)blueSoldiers[i].Y, 10, 10), Color.Blue);
            }
        }
    }
}
