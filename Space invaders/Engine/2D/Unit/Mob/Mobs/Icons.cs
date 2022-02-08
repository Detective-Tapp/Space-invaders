using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class Icons : Basic2D
    {
        public Icons (Vector2 pos,int scale, string str)
        {
            myModel = Global.contentManager.Load<Texture2D>(str);
            this.pos = pos;
            this.scale = scale;
            Scale();
        }
        public void Draw() { base.Draw(); }
    }
}
