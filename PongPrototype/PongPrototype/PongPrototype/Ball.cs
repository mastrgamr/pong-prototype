using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPrototype
{
    class Ball : AI
    {
        Vector2 speed = new Vector2(9, 3);

        public TimeSpan ballStart = TimeSpan.FromSeconds(3);

        public Ball(Texture2D texture, Vector2 position, string soundFile)
            : base(texture, position, soundFile)
        { }

        bool CPUserve()
        {
                if(position.Y < 0)
                {
                    return true;
                }
            return false;
        }

        public void Update(GameTime gameTime, Rectangle clientBounds)
        {
            ballStart -= gameTime.ElapsedGameTime;
            if (ballStart <= TimeSpan.Zero)
            {
                //if (CPUserve())
                //{
                    position += speed;
                //}else {
                //    position += speed;
                //}

                //if (position.X < 0)
                //    speed.X *= -1;
                if (position.Y < 0)
                    speed.Y *= -1;
                //if (position.X > clientBounds.Width - texture.Width)
                //    speed.X *= -1;
                if (position.Y > clientBounds.Height - texture.Height)
                    speed.Y *= -1;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

        public float reverseSpeed()
        {
            return speed.X *= -1f;
        }

        public string countDown()
        {
            if (ballStart <= new TimeSpan(0, 0, 3) && ballStart >= new TimeSpan(0, 0, 2))
            {
                return "Ready?";
            }
            if (ballStart <= new TimeSpan(0, 0, 2) && ballStart >= new TimeSpan(0, 0, 1))
            {
                return "Set.";
            }
            if (ballStart <= new TimeSpan(0, 0, 1) && ballStart >= new TimeSpan(0, 0, 0))
            {
                return "GO!";
            }

            return string.Empty;
        }
    }
}
