using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Nario_Monogame.GameEngine.MarioPlayer
{
    public interface IPlayer
    {
        public void LoadContent(ContentManager content, GraphicsDevice graphics);
        void Draw();
    }
}
