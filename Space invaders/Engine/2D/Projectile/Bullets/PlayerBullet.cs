using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class PlayerBullet : Projectile
    {
        //public Vector2 pos { get; protected set; }
        public PlayerBullet(Vector2 pos, int speed)
        {
            this.pos = pos;
            Speed = speed;
            myModel = Global.contentManager.Load<Texture2D>("Bullets\\Bullet_Player");
            scale = 5;
            Scale();
        }
        public void Update()
        {
            base.Update();
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
