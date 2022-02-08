using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Space_invaders
{
    public class Projectile : Basic2D
    {
        MCTimer timer;
        public float Speed { get; protected set; }
        protected Projectile()
        {
            timer = new MCTimer(4000);
        }
        public virtual bool HitSomething(List<Unit> UNITS)
        {
            for (int i = 0; i < UNITS.Count; i++)
            {
                if (Global.GetDistance(new Vector2(pos.X + myModel.Width/2, pos.Y + myModel.Height/2), new Vector2(UNITS[i].pos.X + UNITS[i].myModel.Width/2, UNITS[i].pos.Y + UNITS[i].myModel.Height/2)) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit();
                    return true;
                }
            }

            return false;
        }
        public virtual bool HitSomething(Unit UNIT)
        {
            if (Global.GetDistance(new Vector2(pos.X + myModel.Width / 2, pos.Y + myModel.Height / 2), new Vector2(UNIT.pos.X + UNIT.myModel.Width / 2, UNIT.pos.Y + UNIT.myModel.Height / 2)) < UNIT.hitDist)
            {
                UNIT.GetHit();

                return true;
            }

            return false;
        }
        public void Update(List<Unit> UNITS)
        {
            timer.UpdateTimer();
            if (timer.Test())
            {
                IsDead = true;
            }
            if (HitSomething(UNITS))
            {
                IsDead = true;
            }
            pos.Y -= Speed;
            base.Update();
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
