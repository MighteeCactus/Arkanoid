using UnityEngine;

namespace Arkanoid
{
    /// <summary>
    /// Hahahack!<br/>
    /// Камеры игры настроена как ортогональная для 9:16.<br/>
    /// Когда экран устройства меньше, "отдаляем"!
    /// </summary>
    public class CameraToScreenCorrection : MonoBehaviour
    {
        private const float kRatio9to16 = 9f/16f;
        
        private const float kSize9to20 = 6f;
        
        private void Awake()
        {
            float ratio = (float) Screen.width / Screen.height;
            if (ratio < kRatio9to16)
            {
                Camera.main.orthographicSize = kSize9to20;
            }
        }
    }
}
