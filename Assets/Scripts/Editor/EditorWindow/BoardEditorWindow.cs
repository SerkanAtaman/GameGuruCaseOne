using UnityEngine;
using UnityEditor;
using GuruCaseOne.Datas;
using GuruCaseOne.Utilities;

namespace GuruCaseOne.Editor
{
    public class BoardEditorWindow : EditorWindow
    {
        private int _boardSize = 4;

        [MenuItem("Window/BoardEditor")]
        static void Init()
        {
            BoardEditorWindow window = (BoardEditorWindow)GetWindow(typeof(BoardEditorWindow));
            window.Show();
        }

        void OnGUI()
        {
            _boardSize = EditorGUILayout.IntField("Board Size:", _boardSize);

            EditorGUILayout.Space();

            if (GUILayout.Button("Create Board"))
            {
                CreateBoard();
            }
        }

        private void CreateBoard()
        {
            GameObject boardHolder = GameObject.Find("BoardHolder");

            if (boardHolder == null)
            {
                boardHolder = new GameObject("BoardHolder");
                boardHolder.transform.position = Vector3.zero;
            }
            else
            {
                int childCount = boardHolder.transform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    DestroyImmediate(boardHolder.transform.GetChild(0).gameObject);
                }
            }

            GameAssets assets = GetAssetData();

            if (assets == null) return;

            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Instantiate(assets.DummyTilePref, boardHolder.transform.position + new Vector3(i, j, 0), Quaternion.identity, boardHolder.transform);
                }
            }

            PlaceMainCamera(boardHolder.transform);
            SetBoardSettings();
        }

        private GameAssets GetAssetData()
        {
            string[] result = AssetDatabase.FindAssets("t:GameAssets");
            GameAssets gameAssets;

            if (result.Length > 1)
            {
                Debug.LogError("More than 1 Asset founded");
                return null;
            }

            if (result.Length == 0)
            {
                Debug.LogError("There is no valid asset at given path");
                return null;
            }
            else
            {
                string path = AssetDatabase.GUIDToAssetPath(result[0]);
                gameAssets = (GameAssets)AssetDatabase.LoadAssetAtPath(path, typeof(GameAssets));
                return gameAssets;
            }
        }

        private void SetBoardSettings()
        {
            string[] result = AssetDatabase.FindAssets("t:BoardSettings");
            BoardSettings boardSettings;

            if(result.Length == 1)
            {
                string path = AssetDatabase.GUIDToAssetPath(result[0]);
                boardSettings = (BoardSettings)AssetDatabase.LoadAssetAtPath(path, typeof(BoardSettings));
                boardSettings.BoardSize = _boardSize;
            }
        }

        private void PlaceMainCamera(Transform boardHolder)
        {
            Transform camera = GameObject.Find("Main Camera").transform;

            Vector3 bottomLeftTilePos = boardHolder.GetChild(0).position;
            Vector3 topRightTilePos = boardHolder.GetChild(boardHolder.childCount - 1).position;

            Vector3 camPos = Vector3.zero;
            camPos.x = (topRightTilePos.x - bottomLeftTilePos.x) / 2.0f;
            camPos.y = (topRightTilePos.y - bottomLeftTilePos.y) / 2.0f;
            camPos.z = -10;

            camera.position = camPos;

            SetFOW(bottomLeftTilePos, topRightTilePos);
        }

        private void SetFOW(Vector3 bottomLeft, Vector3 topRight)
        {
            Camera cam = Camera.main;

            AdjustFowHorizontaly(cam, bottomLeft, topRight);
            AdjustFowVerticaly(cam, bottomLeft, topRight);
        }

        private void AdjustFowHorizontaly(Camera cam, Vector3 bottomLeft, Vector3 topRight)
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

        private void AdjustFowVerticaly(Camera cam, Vector3 bottomLeft, Vector3 topRight)
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
            /*else if (edgeDistance > targetDistance)
            {
                while (edgeDistance > targetDistance)
                {
                    cam.fieldOfView -= 1f;

                    cameraMidBottomPos = CameraUtility.GetViewPosition(0.5f, 0.0f, 10);
                    edgeDistance = minFowPos.y - cameraMidBottomPos.y;

                    iteration++;
                    if (iteration >= 10000) break;
                }
            }*/
        }
    }
}