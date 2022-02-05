using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Super_Nario_Monogame.GameEngine
{
    public abstract class Animation//<TAnimation> where TAnimation : Animation<TAnimation>
    {
        public abstract void PlayAnimation(KeyboardState input, GameTime gameTime, short marioStatus);
    }
}
