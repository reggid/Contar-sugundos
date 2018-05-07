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
        public List<Floor> piso;
        private Vector2 Pos = new Vector2(30, 390);
        private Texture2D Textu;
        private int t;
   
        public DoColumn(List <int> h, Texture2D textu)
        {
            height = h;
            Textu = textu;
            t = 0;
            piso = new List<Floor>();
        }

        public void Create()
        {
            
            foreach (var he in height)
            {
                for (int i = 0; i < he; i++)
                {
                    piso.Add(new Floor(new Rectangle((int)Pos.X + (t * 100), (int)Pos.Y - 35 * i, 35, 35)));
                }
                t++;
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var p in piso)
            {
                if (p.Done)
                {
                    spriteBatch.Draw(Textu, p.Box, Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Textu, p.Box, Color.LimeGreen);
                }
                
            }
            
        }

    }
}
