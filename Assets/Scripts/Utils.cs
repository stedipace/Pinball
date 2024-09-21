using UnityEngine;

public static class Utils
{
    public static bool IsBall(this Collider2D collision)
    {
        return collision.CompareTag(Tags.Ball);
    }
}