using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.Animations;
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
        Rectangle marioStatusSprite;
        static short marioStatus = (short)MarioStatus.LookingAhead;
        readonly float marioVelocity = 100f;
        readonly float marioUpscale = (float)MarioSize.Normal;

        static readonly int mapHeight = -257; // map floor height calculation -> this is temporarily
        static readonly Vector2 respawnSpot = new Vector2(-90, mapHeight); // where mario will be rendered -> this is temporarily

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
            HandleSpriteStatus(marioStatus);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(marioSpritesheet, position,
                marioStatusSprite, Color.White, 0f,
                respawnSpot, marioUpscale, SpriteEffects.None, 0.1f);
            spriteBatch.End();
        }

        // Private functions
        void HandleInputMovements(KeyboardState input, GameTime gameTime)
        {
            if ((input.IsKeyDown(Keys.A) || input.IsKeyDown(Keys.Left)) && !(input.IsKeyDown(Keys.S) || input.IsKeyDown(Keys.Down)))
            {
                marioStatus = (short)MarioStatus.LookingBack;
                position.X -= marioVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (input.IsKeyDown(Keys.D) && !(input.IsKeyDown(Keys.S)))
            {
                marioStatus = (short)MarioStatus.LookingAhead;
                position.X += marioVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (input.IsKeyDown(Keys.W) && input.IsKeyUp(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.LookingBack)
                    marioStatus = (short)MarioStatus.JumpingBack;
                else if (marioStatus == (short)MarioStatus.LookingAhead)
                    marioStatus = (short)MarioStatus.JumpingAhead;
                else if (marioStatus == (short)MarioStatus.CrouchingBack)
                    marioStatus = (short)MarioStatus.JumpingBack;
                else if (marioStatus == (short)MarioStatus.CrouchingAhead)
                    marioStatus = (short)MarioStatus.JumpingAhead;
            }
            else if (input.IsKeyDown(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.LookingBack)
                    marioStatus = (short)MarioStatus.CrouchingBack;
                else if (marioStatus == (short)MarioStatus.LookingAhead)
                    marioStatus = (short)MarioStatus.CrouchingAhead;
            }

            if (input.IsKeyUp(Keys.A) && input.IsKeyUp(Keys.D) && input.IsKeyUp(Keys.W) && input.IsKeyUp(Keys.S))
            {
                if (marioStatus == (short)MarioStatus.CrouchingBack)
                    marioStatus = (short)MarioStatus.LookingBack;
                else if (marioStatus == (short)MarioStatus.CrouchingAhead)
                    marioStatus = (short)MarioStatus.LookingAhead;
            }
        }

        void HandleSpriteStatus(short currentMarioStatus)
        {
            marioStatusSprite = currentMarioStatus switch
            {
                (short)MarioStatus.LookingBack => new Rectangle(167, 3, 16, 31),
                (short)MarioStatus.LookingAhead => new Rectangle(206, 3, 16, 31),
                (short)MarioStatus.CrouchingBack => new Rectangle(86, 36, 16, 31),
                (short)MarioStatus.CrouchingAhead => new Rectangle(286, 36, 16, 31),
                (short)MarioStatus.JumpingBack => new Rectangle(166, 44, 16, 31),
                (short)MarioStatus.JumpingAhead => new Rectangle(206, 44, 16, 31),
                _ => new Rectangle(206, 3, 16, 31),
            };
        }
    }
}
