﻿using LandscapeGenerator.CellTypes;
using LandscapeGenerator.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandscapeGenerator
{
    internal class MapUpdater
    {
        private LandscapeMap Map;

        private EventGenerator EventGenerator;

        public void updateNextTick()
        {

            for (int i = 0; i < Map.Height; i++)
            {
                for (int j = 0; j < Map.Width; ++j)
                {
                    Cell currentCell = Map.Field[i, j];
                    List<Cell> neighbours = Map.getNeighbours(currentCell);
                    foreach(var currentType in TypesContainer.TypeDict)
                    {
                        if (currentType.Value.determineIfSuitable(currentCell, neighbours))
                        {
                            currentCell.Type = currentType.Value;
                            //Map.Simulation.changeText(currentCell.X.ToString() + " " + currentCell.Y.ToString() + "   ");
                            break;
                        }
 
                    }

                }
            }
            Event newEvent = EventGenerator.GenerateEvent(Map.Height);
            newEvent.happen(Map.Field);
        }
        public MapUpdater(LandscapeMap Map)
        {
            this.Map = Map;
            this.EventGenerator = new EventGenerator(0.9); 
        }

        
    }
}
