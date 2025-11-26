using System.Collections.Generic;
using System.Linq;
using Arkanoid.Util;
using UnityEngine;

namespace Arkanoid.Data
{
    [CreateAssetMenu(fileName = "squarewall_generator_999", menuName = "Arkanoid/Create SquareWall Enemy Generator", order = 0)]
    public class SquareEnemyGenerator : EnemyFieldGeneratorAbstract
    {
        public EnemyConfig Enemy;
        
        [Min(1)]
        public int Rows = 2;
        [Min(1)]
        public int Cols = 2;

        public HorizontalAlignment HAlign = HorizontalAlignment.Center;
        public VerticalAlignment   VAlign = VerticalAlignment.Center;

        public Vector2 Spacing = Vector2.zero;

        private Vector3 _initPos;
        
        public override List<IEnemyObject> Generate()
        {
            var result = new List<IEnemyObject>(Rows * Cols);
            var pos = _initPos;
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    var obj = Instantiate(Enemy.Prefab);
                    obj.Position = pos;
                    
                    obj.GetComponentsInChildren<IEnemyObjConfig>().ToList()
                        .ForEach(en => en.SetConfig(Enemy));
                    
                    obj.GetComponentsInChildren<IInitializable>().ToList()
                        .ForEach(en => en.Initialize());
                    
                    result.Add(obj);

                    pos.x += Spacing.x;
                }
                
                pos.x = _initPos.x;
                pos.y += Spacing.y;
            }
            
            return result;
        }

        public override void SetStartPosition(Vector3 pos)
        {
            var width  = (Cols - 1) * Spacing.x;
            var height = (Rows - 1) * Spacing.y;
            
            _initPos = new Vector3(
                Alignment.GetOffset(HAlign, pos, width),
                Alignment.GetOffset(VAlign, pos, height),
                0f
                );
        }
    }
}
