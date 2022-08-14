using UnityEngine;
using GuruCaseOne.Utilities;

namespace GuruCaseOne.Entities.Camera
{
    public class CameraFitter
    {
        public void FitCameraFOW(Vector3 bottomLeftTilePos, Vector3 topRightTilePos)
        {
            SetPosition(bottomLeftTilePos, topRightTilePos);

            UnityEngine.Camera cam = UnityEngine.Camera.main;

            AdjustFowHorizontaly(cam, bottomLeftTilePos, topRightTilePos);
            AdjustFowVerticaly(cam, bottomLeftTilePos, topRightTilePos);
        }

        private void SetPosition(Vector3 bottomLeftTilePos, Vector3 topRightTilePos)
        {
            Transform cam = UnityEngine.Camera.main.transform;

            Vector3 camPos = Vector3.zero;
            camPos.x = bottomLeftTilePos.x + topRightTilePos.x * 0.5f;
            camPos.y = bottomLeftTilePos.y + topRightTilePos.y * 0.5f;
            camPos.z = -10;

            cam.position = camPos;
        }

        private void AdjustFowHorizontaly(UnityEngine.Camera cam, Vector3 bottomLeft, Vector3 topRight)
        {
            Vector3 minFowPos = bottomLeft + new Vector3(0, topRight.y * 0.5f, 0);
            Vector3 cameraMidLeftPos = CameraUtility.GetViewPosition(0, 0.5f, 10);

            int iteration = 0;
            float edgeDistance = minFowPos.x - cameraMidLeftPos.x;

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

        private void AdjustFowVerticaly(UnityEngine.Camera cam, Vector3 bottomLeft, Vector3 topRight)
        {
            Vector3 minFowPos = bottomLeft + new Vector3(topRight.x * 0.5f, 0, 0);
            Vector3 cameraMidBottomPos = CameraUtility.GetViewPosition(0.5f, 0f, 10);

            int iteration = 0;
            float edgeDistance = minFowPos.y - cameraMidBottomPos.y;
            float targetDistance = ((float)Screen.height / Screen.width) * 1.5f;

            if (edgeDistance < targetDistance)
            {
                while (edgeDistance < targetDistance)
                {
                    cam.fieldOfView += 1f;

                    cameraMidBottomPos = CameraUtility.GetViewPosition(0.5f, 0.0f, 10);
                    edgeDistance = minFowPos.y - cameraMidBottomPos.y;

                    iteration++;
                    if (iteration >= 10000) break;
                }
            }
        }
    }
}