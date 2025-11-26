using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkanoid.Data
{
    [CreateAssetMenu(fileName = "prefab_enemy_generator_999", menuName = "Arkanoid/Create Prefab Enemy Generator", order = 0)]
    public class PrefabEnemyGenerator : EnemyFieldGeneratorAbstract
    {
        public EnemyConfig Enemy;

        public GameObject Prefab;

        private Vector3 _initPos;
        
        public override List<IEnemyObject> Generate()
        {
            GameObject container = Instantiate(Prefab);
            container.transform.position = _initPos;
            List<IEnemyObject> result = new List<IEnemyObject>();
            List<EnemyObjectAbstract> objects = container.GetComponentsInChildren<EnemyObjectAbstract>().ToList();
            foreach (EnemyObjectAbstract obj in objects)
            {
                obj.GetComponentsInChildren<IEnemyObjConfig>().ToList()
                    .ForEach(en => en.SetConfig(Enemy));
                    
                obj.GetComponentsInChildren<IInitializable>().ToList()
                    .ForEach(en => en.Initialize());
                
                result.Add(obj);
            }
            
            return result;
        }

        public override void SetStartPosition(Vector3 pos)
        {
            _initPos = pos;
        }
    }
}
