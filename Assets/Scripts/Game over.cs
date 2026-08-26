using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnTouch : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Game Over"))
        {
            SceneManager.LoadScene("Game over");
        }
    }
}

