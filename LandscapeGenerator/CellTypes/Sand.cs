﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandscapeGenerator.CellTypes
{
    internal class Sand : Type
    {
        public override bool determineIfSuitable(Cell affectedCell, List<Cell> neighbours)
        {
            for (int i = 0; i < neighbours.Count; i++)
            {
                if (neighbours[i].Type is Water)
                {
                    return true;
                }
            }
            return false;
        }
        private static readonly Dictionary<int, Color> colors = new Dictionary<int, Color>()
        {
            {4, Color.FromArgb(255, 120,184,80)},
            {5, Color.FromArgb(255, 98,155,63)}
        };
        public override Color getColor(int height)
        {
            return colors[height];
        }
    }
}
