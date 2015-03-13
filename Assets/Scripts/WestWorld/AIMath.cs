using UnityEngine;
using System.Collections;

public class AIMath {

    public static Vector2 Truncate(Vector2 vec, float max)
    {
        if (vec.magnitude > max)
        {
            vec = vec.normalized * max;
        }
        return vec;
    }

    public static Vector2 Perp(Vector2 vec)
    {
        return new Vector2(-vec.y, vec.x);
    }

    public static Vector2 Perp(Vector3 vec)
    {
        return new Vector2(-vec.y, vec.x);
    }
}
