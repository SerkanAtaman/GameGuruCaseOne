using UnityEngine;
using GuruCaseOne.Utilities;

namespace GuruCaseOne.Entities.Camera
{
    public class CameraFitter
    {
        public void FitCameraFOW(Vector3 bottomLeftTilePos, Vector3 topRightTilePos)
        {
            UnityEngine.Camera cam = UnityEngine.Camera.main;

            Vector3 minFowPos = bottomLeftTilePos + new Vector3(0, topRightTilePos.y * 0.5f, 0);
            Vector3 cameraMidLeftPos = CameraUtility.GetViewPosition(0, 0.5f, 10);

            float edgeDistance = minFowPos.x - cameraMidLeftPos.x;

            int iteration = 0;

            if (edgeDistance < 1)
            {
                while (edgeDistance < 1)
                {
                    cam.fieldOfView += 1f;

                    cameraMidLeftPos = CameraUtility.GetViewPosition(0, 0.5f, 10);
                    edgeDistance = minFowPos.x - cameraMidLeftPos.x;

                    iteration++;
                    if (iteration >= 10000) break;
                }
            }
            else if (edgeDistance > 1)
            {
                while (edgeDistance > 1)
                {
                    cam.fieldOfView -= 1f;

                    cameraMidLeftPos = CameraUtility.GetViewPosition(0, 0.5f, 10);
                    edgeDistance = minFowPos.x - cameraMidLeftPos.x;

                    iteration++;
                    if (iteration >= 10000) break;
                }
            }
        }
    }
}