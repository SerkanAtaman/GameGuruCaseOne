using UnityEngine;

namespace GuruCaseOne.Datas
{
    [CreateAssetMenu(menuName = "ScriptableObject/Datas/GameAssets")]
    public class GameAssets : ScriptableObject
    {
        [field: SerializeField] public GameObject DummyTilePref { get; private set; }
        [field: SerializeField] public GameObject TileMonoPref { get; private set; }
    }
}