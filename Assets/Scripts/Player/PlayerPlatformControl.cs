using UnityEngine;

namespace Arkanoid
{
    public class PlayerPlatformControl : MonoBehaviour
    {
        private Vector3 _lastPos = Vector3.zero;

        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastPos = GetWorldPos();
            }

            if (Input.GetMouseButton(0))
            {
                var pos = GetWorldPos();
                var curPos = transform.position;
                curPos.x += pos.x - _lastPos.x;
                transform.position = curPos;
                _lastPos = pos;
            }
        }

        private Vector3 GetWorldPos()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition).origin;
        }
    }
}
