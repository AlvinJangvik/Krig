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
    class Controll
    {
        private KeyboardState oldKstate;

        private static bool blood = false;

        public Controll()
        {

        }

        public static bool Blood
        {
            get { return blood; }
        }

        public void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.I) && !oldKstate.IsKeyDown(Keys.I))
            {
                if (!blood)
                {
                    blood = true;
                }
                else
                {
                    blood = false;
                }
            }
            if (soldiers.Game == 1 || soldiers.Game == 2)
            {
                if (kstate.IsKeyDown(Keys.Up) && !oldKstate.IsKeyDown(Keys.Up) && soldiers.Movement_speed < 4)
                {
                    soldiers.Movement_speed++;
                }
                if (kstate.IsKeyDown(Keys.Down) && !oldKstate.IsKeyDown(Keys.Down) && soldiers.Movement_speed > 1)
                {
                    soldiers.Movement_speed--;
                }
            }

            oldKstate = kstate;
        }
    }
}
