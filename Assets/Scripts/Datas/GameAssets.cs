using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Datas/GameAssets")]
public class GameAssets : ScriptableObject
{
    [field: SerializeField] public GameObject DummyTilePref { get; private set; }
    [field: SerializeField] public GameObject Sphere { get; private set; }
}