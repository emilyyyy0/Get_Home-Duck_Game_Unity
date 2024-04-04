using UnityEngine;

namespace DefaultNamespace
{
    public class Utils
    {
        public static float SquaredDistance(Vector3 a, Vector3 b)
        {
            var deltaX = a.x - b.x;
            var deltaY = a.y - b.y;
            var deltaZ = a.z - b.z;

            return deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ;
        }
    }
}