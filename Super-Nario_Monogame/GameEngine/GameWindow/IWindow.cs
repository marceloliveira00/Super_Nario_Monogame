using Microsoft.Xna.Framework.Graphics;

namespace Super_Nario_Monogame.GameEngine.GameWindow
{
    interface IWindow
    {
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch, Texture2D marioSprite, Texture2D backgroundSprite);
    }
}
