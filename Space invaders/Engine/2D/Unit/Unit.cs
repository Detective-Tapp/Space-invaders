
namespace Space_invaders
{
    public class Unit : Basic2D
    {
        public float hitDist;
        protected Unit() { }
        public virtual void GetHit()
        {
            if (tag != "Player")
                IsDead = true;
            else Lives.removeLife();
        }
        protected void Update()
        {
            base.Update();
        }
        protected void Draw()
        {
            base.Draw();
        }
    }
}
