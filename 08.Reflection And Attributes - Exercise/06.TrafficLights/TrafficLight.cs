using System;

namespace TrafficLights
{
    public class TrafficLight
    {
        private Color currentColor;

        public TrafficLight(string color)
        {
            this.currentColor = (Color)Enum.Parse(typeof(Color), color); 
        }

        public void Update()
        {
            int lastColor = (int)this.currentColor;
            this.currentColor = (Color)(++lastColor % Enum.GetNames(typeof(Color)).Length); 
        }
    }
}
