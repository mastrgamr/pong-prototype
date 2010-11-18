using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PongPrototype
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GamePlay : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;

        Paddle player;
        Paddle enemy;
        Ball ball;

        #region enumerate
        public enum GameState
        {
            Playing,
            Paused,
        }
        public GameState gameState = GameState.Playing;
        #endregion

        Texture2D ballBack;

        public GamePlay(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            enemy = new Paddle(Game.Content.Load<Texture2D>("bar"),
                new Vector2(Game.Window.ClientBounds.Width - 24, Game.Window.ClientBounds.Height / 2 - 50), true, "paddleHit");

            player = new Paddle(Game.Content.Load<Texture2D>("bar"),
                new Vector2(5, Game.Window.ClientBounds.Height / 2 - 50), false, "paddleHit");

            ball = new Ball(Game.Content.Load<Texture2D>("ball"),
                new Vector2(Game.Window.ClientBounds.Width / 2 , 
                Game.Window.ClientBounds.Height / 2), "ballRebound");

            ballBack = Game.Content.Load<Texture2D>("ballBack");

            font = Game.Content.Load<SpriteFont>("default");

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                if (gameState == GameState.Playing)
                {
                    gameState = GameState.Paused;
                }
            }

            if (gameState == GameState.Playing)
            {
                player.Update(gameTime, Game.Window.ClientBounds);
                enemy.Update(gameTime, Game.Window.ClientBounds);
                ball.Update(gameTime, Game.Window.ClientBounds);
            }

            if (player.collideRect.Intersects(ball.collideRect))
            {
                ball.reverseSpeed();

                if (player.soundFile != null)
                    ((Pong)Game).paddleHit.Play();
            }

            if (enemy.collideRect.Intersects(ball.collideRect))
            {
                ball.reverseSpeed();

                if (ball.soundFile != null)
                    ((Pong)Game).paddleHit.Play();
            }

            enemy.followBall(Game.Window.ClientBounds, player, enemy, ball);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            enemy.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
            ball.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, ball.countDown(), new Vector2(Game.Window.ClientBounds.Width / 2 - 10,
                Game.Window.ClientBounds.Height / 2 - 10), Color.Black);

            //spriteBatch.Draw(ballBack,
            //    new Vector2(Game.Window.ClientBounds.Width / 2 - ballBack.Width / 2,
            //        Game.Window.ClientBounds.Height / 2 - ballBack.Height / 2),null, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}