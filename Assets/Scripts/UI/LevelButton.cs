using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Arkanoid.UI
{
    public class LevelButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private string _scene;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
