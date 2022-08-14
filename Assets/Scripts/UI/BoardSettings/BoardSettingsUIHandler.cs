using UnityEngine;


namespace GuruCaseOne.UI.BoardSettings
{
    public class BoardSettingsUIHandler : MonoBehaviour
    {
        public void SetBoardSize(string textInput)
        {
            Debug.Log(textInput);
            int size = int.Parse(textInput);

            PlayReferences.Instance.BoardSetting.BoardSize = size;
        }

        public void BuildBoard()
        {
            PlayReferences.Instance.BoardCreator.RebuildBoard();
        }
    }
}