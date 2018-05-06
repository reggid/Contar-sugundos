using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Real_Time
{
    public class Result
    {
        public List<float> Values;

        public Result()
        {
            this.Values = new List<float>();
        }

        public void Add(float value)
        {
            this.Values.Add(value);
        }

        public float GetAverage()
        {
            return Values.Average();
        }

    }
}
