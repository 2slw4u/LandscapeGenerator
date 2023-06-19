
using LandscapeGenerator.CellTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandscapeGenerator
{
    internal class Cell
    {

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public Color Color { get; private set; }
        public CellTypes.Type Type { get; set; }
        public LandscapeMap landscapeMap { get; private set; }
        public Cell(int x, int y, int h = 0)
        {
            X = x;
            Y = y;
            Height = h;
            Random rand = new Random();
            Color = Color.FromArgb(255, rand.Next(1, 255), rand.Next(1, 255), rand.Next(1, 255));
            Type = TypesContainer.TypeList[0];
        }
        
        public void updateColorGreen()
        {
            double step = 255 / 10;
            Color = Color.FromArgb(255, 0, (int)(Height * step), 0);
        }

        public void updateColor()
        {
            Color = Type.getColor(Height);
        }


    }
}
