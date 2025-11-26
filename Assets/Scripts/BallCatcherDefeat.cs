using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class BallCatcherDefeat : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Defeat");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
