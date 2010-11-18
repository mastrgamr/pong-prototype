using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongPrototype
{
    class Paddle : AI
    {
        public const int SPEED = 8;

        public Paddle(Texture2D texture, Vector2 position, bool isCPU, string soundFile)
            : base(texture, position, isCPU, soundFile)
        { }
        
        #region Constructors
        public Vector2 direction
        {
            get
            {
                Vector2 input = Vector2.Zero;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    input.Y -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    input.Y += 1;

                return input * SPEED;
            }
        }

        #endregion

        public void Update(GameTime gameTime, Rectangle clientBounds)
        {
            if (isCPU == false)
            {
                position += direction;
            }

            //set paddle bounds
            if (position.Y < 0)
                position.Y = 0;
            if (position.Y > clientBounds.Height - texture.Height)
                position.Y = clientBounds.Height - texture.Height;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }
    }
}
