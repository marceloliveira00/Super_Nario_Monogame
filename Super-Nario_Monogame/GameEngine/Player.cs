using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.Entities;
using Super_Nario_Monogame.GameEngine.Enumerators;

namespace Super_Nario_Monogame.GameEngine.MarioPlayer
{
    public class Player : Entity
    {
        // Variable declarations
        private SpriteBatch _spriteBatch;
        private Vector2 _position = new Vector2(-90, _mapHeight);

        private Texture2D _marioSpritesheet;
        private Rectangle _marioStatusSprite = new Rectangle(206, 3, 16, 28);
        private static short _marioStatus = (short)MarioStatus.LookingAhead;

        private readonly float _velocity = 100f;
        private readonly float _marioUpscale = 3;
        private static readonly int _mapHeight = -257; // height that mario will be rendered (this is temporarily)

        // Public functions
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _spriteBatch = new SpriteBatch(graphics);
            _marioSpritesheet = content.Load<Texture2D>("spritesheets/marioMovements");
        }

        public void Update(GameTime gameTime)
        {
            HandleInputMovements(Keyboard.GetState(), gameTime);
        }

        public void Draw()
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            _spriteBatch.Draw(_marioSpritesheet,
                _position,
                _marioStatusSprite, Color.White, 0f,
                new Vector2(-90, _mapHeight), _marioUpscale, SpriteEffects.None, 0.1f);
            _spriteBatch.End();
        }

        // Private functions
        private void HandleInputMovements(KeyboardState input, GameTime gameTime)
        {
            if ((input.IsKeyDown(Keys.A) || input.IsKeyDown(Keys.Left)) && !(input.IsKeyDown(Keys.S) || input.IsKeyDown(Keys.Down)))
            {
                _marioStatusSprite = new Rectangle(167, 3, 16, 31);
                _marioStatus = (short)MarioStatus.LookingBack;

                _position.X -= _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if ((input.IsKeyDown(Keys.D) || input.IsKeyDown(Keys.Right)) && !(input.IsKeyDown(Keys.S) || input.IsKeyDown(Keys.Down)))
            {
                _marioStatusSprite = new Rectangle(206, 3, 16, 31);
                _marioStatus = (short)MarioStatus.LookingAhead;

                _position.X += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (input.IsKeyDown(Keys.W) || input.IsKeyDown(Keys.Up))
            {
                if (_marioStatus == (short)MarioStatus.LookingBack)
                {
                    _marioStatusSprite = new Rectangle(166, 44, 16, 31);
                    _marioStatus = (short)MarioStatus.JumpingBack;
                }
                else if (_marioStatus == (short)MarioStatus.LookingAhead)
                {
                    _marioStatusSprite = new Rectangle(206, 44, 16, 31);
                    _marioStatus = (short)MarioStatus.JumpingAhead;
                }
            }
            else if (input.IsKeyDown(Keys.S) || input.IsKeyDown(Keys.Down))
            {
                if (_marioStatus == (short)MarioStatus.LookingBack)
                {
                    _marioStatusSprite = new Rectangle(86, 36, 16, 31);
                    _marioStatus = (short)MarioStatus.CrouchingBack;
                }
                else if (_marioStatus == (short)MarioStatus.LookingAhead)
                {
                    _marioStatusSprite = new Rectangle(286, 36, 16, 31);
                    _marioStatus = (short)MarioStatus.CrouchingAhead;
                }
            }
        }
    }
}
