using UnityEngine;
using GuruCaseOne.Datas;
using GuruCaseOne.Creators;
using GuruCaseOne.Entities.Camera;
using GuruCaseOne.Entities.MatchSystem;

namespace GuruCaseOne
{
    public class PlayReferences : MonoBehaviour
    {
        public static PlayReferences Instance { get; private set; }

        [field:SerializeField] public GameAssets GameAsset { get; private set; }
        [field:SerializeField] public BoardSettings BoardSetting { get; private set; }
        [SerializeField] private GameObject _informationCanvas;

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

            _informationCanvas.SetActive(false);
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
        }

        private void DeleteDummyBoard()
        {
            GameObject dummy = GameObject.Find("BoardHolder");
            if(dummy != null) DestroyImmediate(dummy);
        }

        public void ResetBoardDatas()
        {
            BoardData = new BoardData(BoardSetting.BoardSize);
        }
    }
}