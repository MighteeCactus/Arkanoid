using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Arkanoid.UI
{
    public class LevelSceneNameButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private string _scene;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
