using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.Animations;
using Super_Nario_Monogame.GameEngine.Entities;
using Super_Nario_Monogame.GameEngine.Enumerators;
using Super_Nario_Monogame.GameEngine.GameManager;

namespace Super_Nario_Monogame.GameEngine.MarioPlayer
{
    public class Player
    {
        // Variable declarations
        AnimationManager<MarioAnimations> animationManager;

        SpriteBatch spriteBatch;
        Vector2 position = respawnSpot;

        Texture2D marioSpritesheet;
        Rectangle marioStatusSprite = new Rectangle(206, 3, 16, 28);
        static short marioStatus = (short)MarioStatus.LookingAhead;

        static readonly int mapHeight = -257; // map floor height calculation -> this is temporarily
        static readonly Vector2 respawnSpot = new Vector2(-90, mapHeight); // where mario will be rendered -> this is temporarily
        readonly float velocity = 100f;
        readonly float marioUpscale = 3;

        // Public functions
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            spriteBatch = new SpriteBatch(graphics);
            marioSpritesheet = content.Load<Texture2D>("spritesheets/marioMovements");
        }

        public void Update(GameTime gameTime)
        {
            HandleInputMovements(Keyboard.GetState(), gameTime);
        }

        public void Draw()
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(marioSpritesheet,
                position,
                marioStatusSprite, Color.White, 0f,
                respawnSpot, marioUpscale, SpriteEffects.None, 0.1f);
            spriteBatch.End();
        }

        // Private functions
        void HandleInputMovements(KeyboardState input, GameTime gameTime)
        {
            if ((input.IsKeyDown(Keys.A) || input.IsKeyDown(Keys.Left)) && !(input.IsKeyDown(Keys.S) || input.IsKeyDown(Keys.Down)))
            {
                marioStatusSprite = new Rectangle(167, 3, 16, 31);
                marioStatus = (short)MarioStatus.LookingBack;

                position.X -= velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (input.IsKeyDown(Keys.D) && !(input.IsKeyDown(Keys.S)))
            {
                marioStatusSprite = new Rectangle(206, 3, 16, 31);
                marioStatus = (short)MarioStatus.LookingAhead;

                position.X += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (input.IsKeyDown(Keys.W) && input.IsKeyUp(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.LookingBack)
                {
                    marioStatusSprite = new Rectangle(166, 44, 16, 31);
                    marioStatus = (short)MarioStatus.JumpingBack;
                }
                else if (marioStatus == (short)MarioStatus.LookingAhead)
                {
                    marioStatusSprite = new Rectangle(206, 44, 16, 31);
                    marioStatus = (short)MarioStatus.JumpingAhead;
                }
                else if (marioStatus == (short)MarioStatus.CrouchingBack)
                {
                    marioStatusSprite = new Rectangle(166, 44, 16, 31);
                    marioStatus = (short)MarioStatus.JumpingBack;
                }
                else if (marioStatus == (short)MarioStatus.CrouchingAhead)
                {
                    marioStatusSprite = new Rectangle(206, 44, 16, 31);
                    marioStatus = (short)MarioStatus.JumpingAhead;
                }
            }
            else if (input.IsKeyDown(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.LookingBack)
                {
                    marioStatusSprite = new Rectangle(86, 36, 16, 31);
                    marioStatus = (short)MarioStatus.CrouchingBack;
                }
                else if (marioStatus == (short)MarioStatus.LookingAhead)
                {
                    marioStatusSprite = new Rectangle(286, 36, 16, 31);
                    marioStatus = (short)MarioStatus.CrouchingAhead;
                }
            }

            if (input.IsKeyUp(Keys.A) && input.IsKeyUp(Keys.D) && input.IsKeyUp(Keys.W) && input.IsKeyUp(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.CrouchingBack)
                {
                    marioStatusSprite = new Rectangle(167, 3, 16, 31);
                    marioStatus = (short)MarioStatus.LookingBack;
                }
                else if (marioStatus == (short)MarioStatus.CrouchingAhead)
                {
                    marioStatusSprite = new Rectangle(206, 3, 16, 31);
                    marioStatus = (short)MarioStatus.LookingAhead;
                }
            }
        }
    }
}
