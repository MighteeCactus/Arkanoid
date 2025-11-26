using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class BallCatcherVictory : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Victory!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
