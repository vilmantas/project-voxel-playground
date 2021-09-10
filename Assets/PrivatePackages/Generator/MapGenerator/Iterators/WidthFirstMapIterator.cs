using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Iterators
{
    public class WidthFirstMapIterator : IEnumerator<GeneratorMapTile>
    {
        private Vector3Int _currentIndex = Vector3Int.zero;

        public Vector3Int CurrentIndex => _currentIndex;

        public int X => CurrentIndex.x;
        public int Y => CurrentIndex.y;
        public int Z => CurrentIndex.z;

        private GeneratorMapTile _currentTile;
        private readonly GeneratorMapTile[][][] Tiles;

        public WidthFirstMapIterator(GeneratorMapTile[][][] tiles)
        {
            Tiles = tiles;
        }

        public GeneratorMapTile Current => _currentTile;

        object IEnumerator.Current => _currentTile;

        public bool MoveNext()
        {
            if (Z >= Tiles.Length) return false;
            if (Y >= Tiles[Z].Length)
            {
                _currentIndex.z += 1;
                _currentIndex.y = 0;

                return MoveNext();
            }

            if (X >= Tiles[Z][Y].Length)
            {
                _currentIndex.y++;
                _currentIndex.x = 0;

                return MoveNext();
            }

            _currentTile = Tiles[Z][Y][X];

            _currentIndex.x++;

            return true;
        }

        public void Reset()
        {
            _currentIndex = Vector3Int.zero;
        }

        public void Dispose()
        {
        }
    }

}
