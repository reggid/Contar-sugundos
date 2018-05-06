using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Real_Time
{
    class DoColumn
    {
        private List <int> height;
        private List<Rectangle> piso;
        private Vector2 Pos = new Vector2(20, 220);
        private Texture2D Textu;
        private int t;
        private bool Done;
   
        public DoColumn(List <int> h, Texture2D textu)
        {
            height = h;
            Textu = textu;
            t = 0;
      
        }

        public void Create()
        {
            
            foreach (var he in height)
            {
                for (int i = 0; i < he; i++)
                {
                    piso.Add(new Rectangle((int)Pos.X + (t*100) ,(int)Pos.Y - 42*i, 42, 42));
                }
                t++;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var p in piso)
            {
                spriteBatch.Draw(Textu,p,Color.Green);
            }
            
        }

    }
}
