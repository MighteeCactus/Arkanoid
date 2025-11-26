using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Arkanoid.UI
{
    public class LevelReloadCurrentButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
