using UnityEngine;

namespace Screpts.Infrastructure.Services.StaticData
{
    [CreateAssetMenu(fileName ="MonsterData",menuName ="StaticData/Monster",order =10)]
    public class MonsterStaticData : ScriptableObject
    {
        public int Hp;
        public float Damage;
        public GameObject Prefab;
    }
}
