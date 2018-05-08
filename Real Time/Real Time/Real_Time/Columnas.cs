using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Real_Time
{
    class Columnas
    {
        private Vector2 Pos = new Vector2(20, 390);
        private SpriteFont Arial;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private string text;
        private bool escribir = false;
        private List<List<int>> LimitSet;
        private List<Result> ResultSet;
        private float TimePased;
        private int TimesPressed;
        private List<int> Limits;
        private Result CurrentResult;
        private int CurrentList;
        private bool Finished;
        private List<DoColumn> Cubes;
        private Texture2D Textu;
        private int drawCubes;
        private int colorCubes;

        public Columnas(List<List<int>> Limites, SpriteFont arial,Texture2D textu)
        {
            drawCubes = -1;
            colorCubes = 0;
            Textu = textu;
            Cubes = new List<DoColumn>();
            this.LimitSet = Limites;
            Arial = arial;
            CurrentList = 0;
            Finished = false;
            InitializeTest(CurrentList);
            ResultSet = new List<Result>();
        }

        public void Update(GameTime gameTime)
        {
            if (Finished)
            {
                return;                
            }                

            _currentKeyboardState = Keyboard.GetState();

            if (TimesPressed == -1)
            {
                escribir = true;
                text = "apreta espacio para empezar";
                if (_currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
                {
                    TimesPressed++;
                }
            }
            else if (TimesPressed < Limits.Count())
            {
                TimePased += (float)gameTime.ElapsedGameTime.TotalSeconds;
                escribir = false;

                if (_currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
                {
                    CurrentResult.Add((TimePased - Limits[TimesPressed]));

                    foreach (var c in Cubes[drawCubes].piso)
                          if (c.Done)
                                colorCubes++;
                    
                 
                    for (int i = 0; i <(colorCubes + Limits[TimesPressed]); i++)
                    {
                        Cubes[drawCubes].piso[i].Done = true;
                    }

                    colorCubes = 0;
                    TimesPressed++;
                    TimePased = 0;
                }

            }
            else if (TimesPressed >= Limits.Count())
            {
                escribir = true;
                text = $"congratulations your average is {CurrentResult.GetAverage().ToString("0.00")}, space para el siguiente";

                if (_currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
                {
                    ResultSet.Add(CurrentResult);
                    if (LimitSet.Count() > ResultSet.Count())
                    {
                        InitializeTest(++CurrentList);
                    }
                    else
                    {

                        text = $"your final current avarage is {Total(ResultSet).ToString("0.00")}";
                        Finished = true;
                    }

                }
                // aca termina cada set, y puede pasar al siguiente

            }
                       

            _previousKeyboardState = Keyboard.GetState();
        }

        void InitializeTest(int testIndex)
        {
            TimesPressed = -1;
            TimePased = 0;
            Limits = LimitSet[testIndex];
            CurrentResult = new Result();
            Cubes.Add(new DoColumn(Limits, Textu));
            drawCubes++;
            Cubes[drawCubes].Create();
        }

        private float Total(List<Result> results)
        {
            List<float> AvgTotal = new List<float>();

            foreach (var resu in ResultSet)
            {
                AvgTotal.Add(resu.GetAverage());
            }

            return AvgTotal.Average();
        }
        

        public void draw(SpriteBatch spriteBatch)
        {
            //for (int i = 0; i < Limits.Count(); i++)
              //spriteBatch.DrawString(Arial, Limits[i].ToString(), new Vector2(Pos.X + (i * 100), Pos.Y), Color.Black);

            Cubes[drawCubes].Draw(spriteBatch);
            
            if (escribir)
            {
                spriteBatch.DrawString(Arial, text, new Vector2(0, 0), Color.Black);
                if (TimesPressed >= Limits.Count())
                {
                    for (int i = 0; i < CurrentResult.Values.Count; i++)
                    {
                        spriteBatch.DrawString(Arial, CurrentResult.Values[i].ToString("0.00"), new Vector2(Pos.X + (i * 100), Pos.Y + 50), Color.Black);
                    }
                }
            }

        }
    }

}
