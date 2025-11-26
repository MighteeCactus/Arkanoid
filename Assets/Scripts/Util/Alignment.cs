using System;
using UnityEngine;

namespace Arkanoid.Util
{
    public static class Alignment
    {
        public static float GetOffset(HorizontalAlignment align, Vector3 pivot, float size)
        {
            switch (align)
            {
                case HorizontalAlignment.Left:
                    // nothing changes
                    break;
                case HorizontalAlignment.Center:
                    pivot.x -= size / 2f;
                    break;
                case HorizontalAlignment.Right:
                    pivot.x -= size;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return pivot.x;
        }
        
        public static float GetOffset(VerticalAlignment align, Vector3 pivot, float size)
        {
            switch (align)
            {
                case VerticalAlignment.Top:
                    pivot.y -= size;
                    break;
                case VerticalAlignment.Center:
                    pivot.y -= size / 2f;
                    break;
                case VerticalAlignment.Bottom:
                    // nothing changes
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
            return pivot.y;
        }
    }
    
    [Serializable]
    public enum HorizontalAlignment
    {
        None,
        Left,
        Center,
        Right
    }

    [Serializable]
    public enum VerticalAlignment
    {
        None,
        Top,
        Center,
        Bottom
    }
}
