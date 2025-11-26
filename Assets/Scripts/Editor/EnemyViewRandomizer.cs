using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Arkanoid.Util
{
    public static class EnemyViewRandomizer
    {
        [MenuItem("Tools/Arkanoid/Enemy Views Randomize Transform", false, 0)]
        public static void RandomizeSelectedEnemyViews()
        {
            Selection.objects
                .Select(o => o.GetComponentInChildren<EnemyViewAbstract>())
                .ToList()
                .ForEach(o =>
                {
                    o.transform.localRotation = Quaternion.AngleAxis(
                        Random.Range(0f, 180f),
                        Vector3.forward);
                    
                    o.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
                });
        }
        
        [MenuItem("Tools/Arkanoid/Enemy Views Reset Transform", false, 0)]
        public static void ResetSelectedEnemyViews()
        {
            Selection.objects
                .Select(o => o.GetComponentInChildren<EnemyViewAbstract>())
                .ToList()
                .ForEach(o =>
                {
                    o.transform.localRotation = Quaternion.identity;
                    o.transform.localScale = Vector3.one;
                });
        }
    }
}
