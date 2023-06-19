﻿using LandscapeGenerator.CellTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandscapeGenerator.Events
{
    internal class Draught: Event
    {
        public override void happen(Cell[,] Field)
        {
            int maxSize = Field.GetLength(0);
            Random random = new Random();

            for (int i = Math.Max(0, positionX - size); i < Math.Min(maxSize, positionX + size); i++)
            {
                for (int j = Math.Max(0, positionY - size); j < Math.Min(maxSize, positionY + size); j++)
                {
                    if (Field[i, j].Type is Water || Field[i, j].Type is Grass || Field[i, j].Type is Forest) Field[i, j].Type = TypesContainer.TypeDict[AllTypes.STONE];
                }
            }
        }
    }
}
