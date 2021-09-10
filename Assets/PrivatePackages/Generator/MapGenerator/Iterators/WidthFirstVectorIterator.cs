using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Iterators
{
    public class WidthFirstVectorIterator : IEnumerator<Vector3Int>
    {
        private Vector3Int _currentIndex = new Vector3Int(-1, 0, 0);

        private readonly Vector3Int _size;

        public Vector3Int CurrentIndex => _currentIndex;

        public int X => CurrentIndex.x;
        public int Y => CurrentIndex.y;
        public int Z => CurrentIndex.z;

        public WidthFirstVectorIterator(Vector3Int size)
        {
            _size = size;
        }


        public Vector3Int Current => _currentIndex;

        object IEnumerator.Current => _currentIndex;

        public bool MoveNext()
        {
            if (Z >= _size.z) return false;
            if (Y >= _size.y)
            {
                _currentIndex.z += 1;
                _currentIndex.y = 0;

                return MoveNext();
            }

            if (X >= _size.x - 1)
            {
                _currentIndex.y++;
                _currentIndex.x = -1;

                return MoveNext();
            }

            _currentIndex.x++;

            return true;
        }

        public void Reset()
        {
            _currentIndex = Vector3Int.zero;
            _currentIndex.x = -1;
        }

        public void Dispose()
        {
        }
    }
}
