using UnityEngine;

namespace GuruCaseOne.Utilities
{
    public static class CameraUtility
    {
        public static Vector3 GetViewPosition(float x, float y, float depth)
        {
            x = Mathf.Clamp01(x);
            y = Mathf.Clamp01(y);
            depth = Mathf.Clamp(depth, 0, depth);

            Camera cam = Camera.main;

            return cam.ViewportToWorldPoint(new Vector3(x, y, depth));
        }
    }
}