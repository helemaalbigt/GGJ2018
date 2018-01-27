using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 NormalizeAngles(this Vector3 vec)
    {
        for (int i = 0; i < 3; i++)
        {
            if (vec[i] > 180)
            {
                vec[i] = vec[i] - 360;
            }
        }
        return vec;
    }
}