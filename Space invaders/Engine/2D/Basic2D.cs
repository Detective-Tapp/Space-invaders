using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class Basic2D
    {
        public string tag { get; protected set; }
        public bool IsDead { get; protected set; }
        public Vector2 pos, size;

        public Texture2D myModel;

        public float rotation;

        protected int scale;

        protected Basic2D() { }
        protected Basic2D( Texture2D model, int scale)
        {
            myModel = model;
            this.scale = scale;
        }
        protected Basic2D(Vector2 POS, Vector2 SIZE) 
        {
            pos = POS;
            size = SIZE;
        }
        protected Basic2D(string PATH, Vector2 POS, Vector2 DIMS, int scale = 0)
        {
            myModel = Global.contentManager.Load<Texture2D>(PATH);
            pos = POS;
            size = DIMS;
            this.scale = scale;
            if (scale != 0)
            {
                Scale();
            }
        }

        protected void Scale()
        {
            Color[] bits = new Color[myModel.Width * myModel.Height];
            myModel.GetData(bits);      // scale = now about scaling the edges of the texture where the surface follows.
            Color[] newBits = new Color[(myModel.Width * scale) * (myModel.Height * scale)];

            int cnt = 0;
            int count = 0;
            int width = myModel.Width * scale;

            // if the scale is a greater power than 2 then compensate for that factor.
            for (int i = 0; i < myModel.Height; i++)
            {
                for (int j = 0; j < myModel.Width; j++)
                {
                    

                    for (int k = 0; k < scale; k++)
                    {
                        for (int l = 0; l < scale; l++)
                        {
                            newBits[cnt + l + (width * k)] = bits[count];
                        }
                    }
                    
                    cnt += scale;
                    if (cnt % width == 0)
                        cnt += width * (scale - 1);
                    count++;
                }
            }

            myModel = new Texture2D(Global.graphicsDevice, myModel.Width * scale, myModel.Height * scale);
            myModel.SetData(newBits);

            size.X = myModel.Width;
            size.Y = myModel.Height;
        }
        
        protected void Update()
        {
            
        }

        protected void RotateTexture(float rot)
        {
            rotation = rot + rotation;
        }

        protected void RotateTextureToMouse(float rot)
        {
            rotation = rot;
        }

        protected void Draw()
        {
            if (myModel != null)
            {
                Global.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X), (int)(pos.Y), (int)size.X, (int)size.Y), null, Color.White);
            }
        }

        protected void Draw(Vector2 ORIGIN)
        {
            if (myModel != null)
            {
                Global.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X ), (int)(pos.Y ), (int)pos.X, (int)pos.Y), null, Color.White, rotation, new Vector2(ORIGIN.X , ORIGIN.Y), new SpriteEffects(), 0);
            }
        }
    }
}