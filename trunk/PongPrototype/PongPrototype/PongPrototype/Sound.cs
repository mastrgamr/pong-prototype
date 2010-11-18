using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace PongPrototype
{
    class Sound : Pong
    {
        SoundEffect paddleHit;
        SoundEffect ballRebound;

        public void LoadContent()
        {
            // initialize sound components
            paddleHit = Content.Load<SoundEffect>("sounds/paddleHit");
            ballRebound = Content.Load<SoundEffect>("sounds/ballRebound");
        }
    }
}
