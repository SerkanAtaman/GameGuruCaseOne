using GuruCaseOne.Datas;
using GuruCaseOne.Helpers;
using UnityEngine;

namespace GuruCaseOne.Creators
{
    public class BoardCreator
    {
        private readonly TileCreator _tileCreator;

        private TileDataContainer[,] _tileDataContainers;

        public BoardCreator()
        {
            _tileCreator = new TileCreator();
        }

        public void CreateBoard()
        {
            int boarzSize = PlayReferences.Instance.BoardData.Size;

            SetTileData(boarzSize);
            for (int i = 0; i < boarzSize; i++)
            {
                for (int j = 0; j < boarzSize; j++)
                {
                    _tileCreator.CreateTile(_tileDataContainers[i, j]);
                }
            }

            CacheNeighbors(boarzSize);
            PlayReferences.Instance.CamFitter.FitCameraFOW(PlayReferences.Instance.BoardData.GetBottomLeftTilePos(), PlayReferences.Instance.BoardData.GetTopRightTilePos());
        }

        public void RebuildBoard()
        {
            DestroyExistingBoard();
            PlayReferences.Instance.ResetBoardDatas();

            CreateBoard();
        }

        private void SetTileData(int n)
        {
            _tileDataContainers = new TileDataContainer[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _tileDataContainers[i, j] = new TileDataContainer(i, j, TileType.Default);
                }
            }
        }

        private void CacheNeighbors(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    PlayReferences.Instance.BoardData.GetTile(i, j).FindNeighbors();
                }
            }
        }

        private void DestroyExistingBoard()
        {
            int tileCount = PlayReferences.Instance.BoardData.Size * PlayReferences.Instance.BoardData.Size;

            for(int i = 0; i < tileCount; i++)
            {
                Object.Destroy(PlayReferences.Instance.BoardHolder.GetChild(i).gameObject);
            }
        }
    }
}