using Generator.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static GeneratorMap;

namespace Generator.GenerationStrategies
{
    public class SimpleTileGenerationStrategy : IGenerationStrategy
    {
        public Func<GeneratorMapTile> GenerationAction { get; }

        public SimpleTileGenerationStrategy(Func<GeneratorMapTile> generationAction)
        {
            GenerationAction = generationAction;
        }

        public MapTiles GenerateMapTiles(Vector3Int size)
        {
            MapTiles result = new MapTiles(size);

            var it = new WidthFirstVectorIterator(size);

            while (it.MoveNext())
            {
                result[it.Current] = GenerationAction();
            }

            return result;
        }
    }
}
