using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPrototype
{
    abstract class AI
    {
        protected Vector2 position;
        public Texture2D texture;
        public bool isCPU;
        public string soundFile {get; private set;}

        public AI(Texture2D texture, Vector2 position, string soundFile)
        {
            this.texture = texture;
            this.position = position;
            this.soundFile = soundFile;
        }

        public AI(Texture2D texture, Vector2 position, bool isCPU, string soundFile)
        {
            this.texture = texture;
            this.position = position;
            this.isCPU = isCPU;
            this.soundFile = soundFile;
        }

        public void followBall(Rectangle clientBounds, Paddle player, Paddle enemy, Ball ball)
        {
                if (ball.position.Y > enemy.position.Y + 40 && ball.position.X > clientBounds.Width / 2)
                {
                    enemy.position.Y += 7.0f;
                }

                if (ball.position.Y < enemy.position.Y + 40 && ball.position.X > clientBounds.Width / 2)
                {
                    enemy.position.Y -= 7.0f;
                }
        }

        public Rectangle collideRect
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height);
            }
        }
    }
}
