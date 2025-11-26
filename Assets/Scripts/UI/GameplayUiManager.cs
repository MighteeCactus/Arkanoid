using UnityEngine;

namespace Arkanoid.UI
{
    public class GameplayUiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryPanel; 
        [SerializeField] private GameObject _defeatPanel;
        [SerializeField] private GameObject _goBackPanel;
        
        
        private void Awake()
        {
            _victoryPanel.SetActive(false);
            _defeatPanel.SetActive(false);
            _goBackPanel.SetActive(true);
        }

        public void ShowVictory()
        {
            _victoryPanel.SetActive(true);
            _defeatPanel.SetActive(false);
            _goBackPanel.SetActive(false);
        }
        public void ShowDefeat()
        {
            _victoryPanel.SetActive(false);
            _defeatPanel.SetActive(true);
            _goBackPanel.SetActive(false);
        }
    }
}
