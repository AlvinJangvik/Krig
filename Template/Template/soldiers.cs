using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class soldiers : VisualBase
    {
        private Texture2D red;
        private SoundEffect hit;

        private static int movement_speed = 1;
        private static int turns = 5;
        private static float temp = 0;
        private static float temp2 = 0;
        private static float temp3 = 0;
        private static float temp4 = 0;
        private static int game = 3;
        private static int alive = 1;
        private static int push = 10;
        private static int wait = 15;

        private static bool fun = false;

        // RED VARS
        private static int redHealthValue = 100;
        private static int redDmgValue = 15;
        private static int redSoldierAmount = 10;
        private static Vector2[] redSoldiers = new Vector2[redSoldierAmount];
        private static int[] redHealth = new int[redSoldierAmount];
        private static int[] redDmg = new int[redSoldierAmount];
        private static int[] redChange = new int[redSoldierAmount];
        private static int[] redAim = new int[redSoldierAmount];

        // BLUE VARS
        private static int blueHealthValue = 100;
        private static int blueDmgValue = 15;
        private static int blueSoldierAmount = 10;
        private static Vector2[] blueSoldiers = new Vector2[blueSoldierAmount];
        private static int[] blueHealth = new int[blueSoldierAmount];
        private static int[] blueDmg = new int[blueSoldierAmount];
        private static int[] blueChange = new int[blueSoldierAmount];
        private static int[] blueAim = new int[blueSoldierAmount];


        private static Random rand = new Random();


        // ############################################################################
        //                Constructor
        // ############################################################################
        public soldiers(Texture2D skin1, Texture2D skin2, SoundEffect sfx)
        {
            tex = skin1;
            red = skin2;
            hit = sfx;
        }


        // ############################################################################
        //                Get/Sets
        // ############################################################################
        public static int Game
        {
            get { return game; }
            set { game = value; }
        }
        public static int Movement_speed
        {
            get { return movement_speed; }
            set { movement_speed = value; }
        }
        // RED
        public static int RedSoldierAmount
        {
            get { return redSoldierAmount; }
            set { redSoldierAmount = value; }
        }
        public static int RedDmgValue
        {
            get { return redDmgValue; }
            set { redDmgValue = value; }
        }
        public static int RedHealthValue
        {
            get { return redHealthValue; }
            set { redHealthValue = value; }
        }
        // BLUE
        public static int BlueSoldierAmount
        {
            get { return blueSoldierAmount; }
            set { blueSoldierAmount = value; }
        }
        public static int BlueDmgValue
        {
            get { return blueDmgValue; }
            set { blueDmgValue = value; }
        }
        public static int BlueHealthValue
        {
            get { return blueHealthValue; }
            set { blueHealthValue = value; }
        }


        // ############################################################################
        //                Fight
        // ############################################################################
        public static void Fight(int bluSize, int bluDmg, int bluHealth)
        {
            // Difficulty
            blueSoldierAmount = bluSize;
            blueDmgValue = bluDmg;
            blueHealthValue = bluHealth;


            blueSoldiers = new Vector2[blueSoldierAmount];
            blueHealth = new int[blueSoldierAmount];
            blueDmg = new int[blueSoldierAmount];
            blueChange = new int[blueSoldierAmount];
            blueAim = new int[blueSoldierAmount];

            redSoldiers = new Vector2[redSoldierAmount];
            redHealth = new int[redSoldierAmount];
            redDmg = new int[redSoldierAmount];
            redChange = new int[redSoldierAmount];
            redAim = new int[redSoldierAmount];


            // ############################################################################
            // ########################### Red ############################################
            for (int i = redSoldierAmount - 1; i >= 0; i--)
            {
                if (fun == false)
                {
                    // ####################### Position ########################################
                    redSoldiers[i] = new Vector2(Rand(1, 250), Rand(1, 460));
                }
                else
                {
                    redSoldiers[i] = new Vector2(Rand(395, 405), Rand(220, 230));
                }

                // ####################### Aim ########################################
                redAim[i] = 0;

                // ####################### change ########################################
                redChange[i] = Rand(1, 5);

                // ####################### Health ########################################
                redHealth[i] = Rand(1, redHealthValue);
                temp3 += redHealth[i];

                // ####################### DMG ########################################
                redDmg[i] = Rand(1, redDmgValue);
                temp += redDmg[i];
            }

            // ############################################################################
            // ########################### Blue ###########################################
            for (int i = blueSoldierAmount - 1; i >= 0; i--)
            {
                // ####################### Position ########################################
                if (fun == false)
                {
                    blueSoldiers[i] = new Vector2(Rand(550, 800), Rand(1, 460));
                }
                else
                {
                    blueSoldiers[i] = new Vector2(Rand(1, 800), Rand(1, 460));
                }

                // ####################### Aim ########################################
                blueAim[i] = 0;

                // ####################### change ########################################
                blueChange[i] = Rand(1, 5);

                // ####################### Health ########################################
                blueHealth[i] = Rand(1, blueHealthValue);
                temp4 += blueHealth[i];

                // ####################### DMG ########################################
                blueDmg[i] = Rand(1, blueDmgValue);
                temp2 += blueDmg[i];
            }

            // DEBUG
            temp = temp / redSoldierAmount;
            temp2 = temp2 / blueSoldierAmount;
            temp3 = temp3 / redSoldierAmount;
            temp4 = temp4 / blueSoldierAmount;
            Console.WriteLine("Total red dmg: " + temp);
            Console.WriteLine("Total red Health: " + temp3);
            Console.WriteLine("Total blue dmg: " + temp2);
            Console.WriteLine("Total blue Health: " + temp4);
        }



        // ############################################################################
        //                Collision
        // ############################################################################
        public void Collision()
        {
            for (int i = redSoldierAmount - 1; i >= 0; i--)
            {
                for (int o = blueSoldierAmount - 1; o >= 0; o--)
                {
                    if (redHealth[i] > 0 && blueHealth[o] > 0)
                    {
                        if (redSoldiers[i].X > blueSoldiers[o].X - 10 && redSoldiers[i].X < blueSoldiers[o].X + 10)
                        {
                            if (redSoldiers[i].Y > blueSoldiers[o].Y - 10 && redSoldiers[i].Y < blueSoldiers[o].Y + 10)
                            {
                                temp = Rand(-redDmg[i], blueDmg[o]);
                                if (temp < 0)
                                {
                                    Effects.Boom(blueSoldiers[o]);
                                    blueHealth[o] -= Rand(0, redDmg[i]);
                                    Push("blue", redSoldiers[i], i, blueSoldiers[o], o);
                                    if (Rand(0, alive) < (alive) / 25)
                                    {
                                        hit.Play(0.05f, 0, 0);
                                    }
                                }
                                else if(temp > 0)
                                {
                                    Effects.Boom(redSoldiers[i]);
                                    redHealth[i] -= Rand(0, blueDmg[o]);
                                    Push("red", redSoldiers[i], i, blueSoldiers[o], o);
                                    if (Rand(-1, alive) < (alive) / 25)
                                    {
                                        hit.Play(0.05f, 0, 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        // ############################################################################
        //                MOVEMENT
        // ############################################################################
        public void Movement()
        {
            // ####################
            //    red movement
            // ####################
            for (int i = redSoldierAmount - 1; i >= 0; i--)
            {
                if(temp2 == 0) { break; }
                if (redChange[i] > 0)
                {
                    if (redHealth[i] > 0) // If current soldier is alive
                    {
                        while (true) // Checks which enemy's alive
                        {
                            if (blueHealth[redAim[i]] >= 1) { break; }

                            redAim[i] = -1;
                            temp2 = blueSoldierAmount;
                            for (int o = blueSoldierAmount - 1; o >= 0; o--)
                            {
                                if (redSoldiers[i].X > blueSoldiers[o].X - 5 && redSoldiers[i].X < blueSoldiers[o].X + 5) // If enemy above
                                {
                                    redAim[i] = o;
                                    break;
                                }
                                else if (redSoldiers[i].Y > blueSoldiers[o].Y - 10 && redSoldiers[i].Y < blueSoldiers[o].Y + 10) // If enemy is infront
                                {
                                    redAim[i] = o;
                                    break;
                                }

                                if (blueHealth[o] <= 0) { temp2--; }
                                if (temp2 == 0)
                                {
                                    Console.WriteLine("Red Won");
                                    Menu.Win();
                                    game = 0;
                                    break;
                                }
                            }
                            if(temp2 == 0) { break; }
                            else if (redAim[i] != -1) { break; }
                            else
                            {
                                for (int o = 0; o < blueSoldierAmount; o++)
                                    if (blueHealth[o] > 0) { redAim[i] = o; break; }
                            }
                            break;
                        }



                        if (redAim[i] != -1)
                        {
                            if(redSoldiers[i].Y <= 0) { redSoldiers[i].Y = 1; }

                            if (redSoldiers[i].X < blueSoldiers[redAim[i]].X - 10)
                            {
                                if (redSoldiers[i].X < 810)
                                {
                                    redSoldiers[i].X += movement_speed + Rand(-1, 1);
                                }
                            }
                            else
                            {
                                if (redSoldiers[i].X > 0)
                                {
                                    redSoldiers[i].X -= movement_speed + Rand(-1, 1);
                                }
                            }

                            if (redSoldiers[i].Y < blueSoldiers[redAim[i]].Y - 10)
                            {
                                if (redSoldiers[i].Y < 470)
                                {
                                    redSoldiers[i].Y += movement_speed + Rand(-1, 1 / 3);
                                }
                            }
                            else
                            {
                                if (redSoldiers[i].Y > 0)
                                {
                                    redSoldiers[i].Y -= movement_speed + Rand(-1, 1 / 3);
                                }
                            }
                        }
                        redChange[i]--;
                    }
                }
                else
                {
                    if(Rand(0,wait) == 0)
                    {
                        redChange[i] = Rand(1, 50);
                    }
                }
            }



            // ####################
            //   blue movement
            // ####################
            for (int i = blueSoldierAmount - 1; i >= 0; i--)
            {
                if (blueChange[i] > 0)
                {
                    if (blueHealth[i] > 0)
                    {
                        while (true)// Checks who's alive
                        {
                            if (redHealth[blueAim[i]] >= 1) { break; }

                            blueAim[i] = -1;
                            temp2 = redSoldierAmount;
                            for (int o = redSoldierAmount - 1; o >= 0; o--)
                            {
                                if (blueSoldiers[i].X > redSoldiers[o].X - 5 && blueSoldiers[i].X < redSoldiers[o].X + 5)
                                {
                                    blueAim[i] = o;
                                    break;
                                }
                                else if (blueSoldiers[i].Y > redSoldiers[o].Y - 10 && blueSoldiers[i].Y < redSoldiers[o].Y + 10)
                                {
                                    blueAim[i] = o;
                                    break;
                                }

                                if (redHealth[o] <= 0) { temp2--; }
                                if (temp2 == 0)
                                {
                                    game = 0;
                                    break;
                                }
                            }

                            if (blueAim[i] != -1) { break; }
                            else
                            {
                                for (int o = 0; o < redSoldierAmount; o++)
                                    if (redHealth[o] > 0) { blueAim[i] = o; break; }
                            }
                            break;
                        }
                        if (blueSoldiers[i].Y <= 0) { blueSoldiers[i].Y = 1; }

                        if (blueAim[i] != -1)
                        {
                            if (blueSoldiers[i].X > redSoldiers[blueAim[i]].X + 10)
                            {
                                if (blueSoldiers[i].X > 0)
                                {
                                    blueSoldiers[i].X -= movement_speed + Rand(-1, 1);
                                }
                            }
                            else
                            {
                                if (blueSoldiers[i].X < 810)
                                {
                                    blueSoldiers[i].X += movement_speed + Rand(-1, 1);
                                }
                            }
                            if (blueSoldiers[i].Y > redSoldiers[blueAim[i]].Y - 10)
                            {
                                if (blueSoldiers[i].Y > 0)
                                {
                                    blueSoldiers[i].Y -= movement_speed + Rand(-1, 1 / 3);
                                }
                            }
                            else
                            {
                                if (blueSoldiers[i].Y < 470)
                                {
                                    blueSoldiers[i].Y += movement_speed + Rand(-1, 1 / 3);
                                }
                            }
                        }
                        blueChange[i]--;
                    }
                }
                else
                {
                    if(Rand(0,wait) == 0)
                    {
                        blueChange[i] = Rand(1, 50);
                    }
                }
            }
        }


        // ############################################################################
        //                DIE
        // ############################################################################
        public void Die()
        {
            for(int i = redSoldierAmount - 1; i >= 0; i--)
            {
                if(redHealth[i] <= 0)
                {
                    redSoldiers[i] = new Vector2(400, 200);
                }
            }
            for (int i = blueSoldierAmount - 1; i >= 0; i--)
            {
                if (blueHealth[i] <= 0)
                {
                    blueSoldiers[i] = new Vector2(400, 200);
                }
            }
        }

        // ############################################################################
        //                Respawn
        // ############################################################################
        public void Respawn()
        {
            if (!fun)
            {
                for (int i = redSoldierAmount - 1; i >= 0; i--)
                {
                    if (redHealth[i] <= 0)
                    {
                        redSoldiers[i] = new Vector2(Rand(1, 300), Rand(1, 460));
                        redHealth[i] = Rand(1, redHealthValue);
                        redDmg[i] = Rand(1, redDmgValue);
                    }
                }
                for (int i = blueSoldierAmount - 1; i >= 0; i--)
                {
                    if (blueHealth[i] <= 0)
                    {
                        blueSoldiers[i] = new Vector2(Rand(500, 800), Rand(1, 460));
                        blueHealth[i] = Rand(1, blueHealthValue);
                        blueDmg[i] = Rand(1, blueDmgValue);
                    }
                }
            }
            else
            {
                for (int i = redSoldierAmount - 1; i >= 0; i--)
                {
                    if (redHealth[i] <= 0)
                    {
                        redSoldiers[i] = new Vector2(Rand(1, 800), Rand(1, 460));
                        redHealth[i] = Rand(1, redHealthValue);
                        redDmg[i] = Rand(1, redDmgValue);
                    }
                }
                for (int i = blueSoldierAmount - 1; i >= 0; i--)
                {
                    if (blueHealth[i] <= 0)
                    {
                        blueSoldiers[i] = new Vector2(Rand(395, 405), Rand(220, 225));
                        blueHealth[i] = Rand(1, blueHealthValue);
                        blueDmg[i] = Rand(1, blueDmgValue);
                    }
                }
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
        //                Alive check
        // ############################################################################
        public void Alive()
        {
            alive = 0;
            for(int i = 0; i < redSoldierAmount; i++)
            {
                if (redHealth[i] > 0) { alive++; }
            }
            for (int i = 0; i < blueSoldierAmount; i++)
            {
                if (blueHealth[i] > 0) { alive++; }
            }
            if(alive == 0) { alive = 1; }
        }

        // ############################################################################
        //                push
        // ############################################################################
        public void Push(string color, Vector2 red, int i, Vector2 blue, int o) // color: 1 == red; 2 == blue;
        {
            if(color == "red")
            {
                if(blue.X > red.X)
                {
                    redSoldiers[i].X -= push;
                }
                if (blue.X < red.X)
                {
                    redSoldiers[i].X += push;
                }
                if (blue.Y > red.Y)
                {
                    redSoldiers[i].Y -= push;
                }
                if (blue.Y < red.Y)
                {
                    redSoldiers[i].Y += push;
                }
            }
            if (color == "blue")
            {
                if (blue.X < red.X)
                {
                    blueSoldiers[o].X -= push;
                }
                if (blue.X > red.X)
                {
                    blueSoldiers[o].X += push;
                }
                if (blue.Y < red.Y)
                {
                    blueSoldiers[o].Y -= push;
                }
                if (blue.Y > red.Y)
                {
                    blueSoldiers[o].Y += push;
                }
            }
        }


        // ############################################################################
        //                Update
        // ############################################################################
        public override void Update()
        {
            if(game == 1)
            {
                Die();
            }
            if(game == 3)
            {
                Respawn();
            }
            if (game == 1 || game == 3)
            {
                // ALIVE CHECK
                Alive();


                // MAIN GAME
                Collision();
                if (turns == 0)
                {
                    Movement();
                    turns = 0;
                }
                else if (turns > 0)
                {
                    turns--;
                }
            }
            else if(game == 0)
            {
                game = 2;
            }

        }


        // ############################################################################
        //                Draw
        // ############################################################################
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (game == 1 || game == 3)
            {
                for (int i = redSoldierAmount - 1; i >= 0; i--)
                {
                    if (redHealth[i] > 0)
                    {
                        spriteBatch.Draw(red, new Rectangle((int)redSoldiers[i].X, (int)redSoldiers[i].Y, 15, 15), Color.White);
                    }
                }
                for (int i = blueSoldierAmount - 1; i >= 0; i--)
                {
                    if (blueHealth[i] > 0)
                    {
                        spriteBatch.Draw(tex, new Rectangle((int)blueSoldiers[i].X, (int)blueSoldiers[i].Y, 15, 15), Color.LightBlue);
                    }
                }
            }
        }
    }
}
