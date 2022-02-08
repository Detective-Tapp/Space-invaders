using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class Alien_Bullet : Projectile
    {
        public Alien_Bullet(Vector2 pos, string str, int speed)
        {
            tag = "Alien_Bullet";
            this.pos = pos;
            Speed = speed;
            myModel = Global.contentManager.Load<Texture2D>(str);
            scale = 5;
            Scale();
        }
        public void Update()
        {
            pos.Y += Speed;
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
