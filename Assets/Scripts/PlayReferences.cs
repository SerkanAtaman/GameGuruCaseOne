using UnityEngine;
using GuruCaseOne.Datas;
using GuruCaseOne.Creators;
using GuruCaseOne.Entities.Camera;

namespace GuruCaseOne
{
    public class PlayReferences : MonoBehaviour
    {
        public static PlayReferences Instance { get; private set; }

        [field:SerializeField] public GameAssets GameAsset { get; private set; }
        [field:SerializeField] public BoardSettings BoardSetting { get; private set; }

        public BoardData BoardData { get; private set; }
        public BoardCreator BoardCreator { get; private set; }
        public CameraFitter CamFitter { get; private set; }

        public Transform BoardHolder { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
        }

        private void Start()
        {
            DeleteDummyBoard();

            BoardHolder = new GameObject("Board Holder").transform;
            BoardHolder.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            BoardData = new BoardData(BoardSetting.BoardSize);
            BoardCreator = new BoardCreator();
            CamFitter = new CameraFitter();
            
            BoardCreator.CreateBoard();

            CamFitter.FitCameraFOW(BoardData.GetBottomLeftTilePos(), BoardData.GetTopRightTilePos());
        }

        private void DeleteDummyBoard()
        {
            GameObject dummy = GameObject.Find("BoardHolder");
            if(dummy != null) DestroyImmediate(dummy);
        }
    }
}