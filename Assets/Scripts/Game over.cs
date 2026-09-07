using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class GameOverOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject gameOverManager;
[SerializeField] private Animator animator;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Game Over"))
        {
            gameOverManager.SetActive(true);
            animator.SetTrigger("Idle");
        }
    }
}
