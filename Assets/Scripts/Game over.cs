using UnityEngine;

public class GameOverOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject gameOverManager;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Game Over"))
        {
            gameOverManager.SetActive(true);
        }
    }
}
