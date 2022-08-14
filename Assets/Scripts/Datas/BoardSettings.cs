using UnityEngine;

namespace GuruCaseOne.Datas
{
    [CreateAssetMenu(menuName = "ScriptableObject/Datas/BoardSettings")]
    public class BoardSettings : ScriptableObject
    {
        public int BoardSize
        {
            get
            {
                _size = Mathf.Clamp(_size, 2, 12);
                return _size;
            }
            set
            {
                int val = Mathf.Clamp(value, 2, 12);

                _size = val;
            }
        }
        private int _size;
    }
}