using UnityEngine;

namespace DefaultNamespace
{
    public static class Extensions
    {
        public static Vector3Int GetDirection(this Vector3Int blockPos, Vector3 playerPosition)
        {
            Vector3 diff = blockPos - playerPosition;
            Vector3Int direction;
            if (Mathf.Abs(diff.x) > Mathf.Abs(diff.z))
            {
                return diff.x > 0 ? Vector3Int.right : Vector3Int.left;
            }
            else
            {
                return diff.z > 0 ? new Vector3Int(0, 0, 1) : new Vector3Int(0, 0, -1);
            }
        }
    }
}