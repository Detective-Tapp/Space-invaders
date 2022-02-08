using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class Barrier : Unit
    {
        Lives lives;
        public Barrier(Vector2 pos)
        {
            //lives = new Lives(5);
            tag = "Barrier";
            this.pos = pos;
            myModel = Global.contentManager.Load<Texture2D>("Mobs\\Barrier");
            scale = 3;
            Scale();
            hitDist = myModel.Width/2;
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
