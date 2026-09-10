using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class GameOverOnTouch : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MainMenu mainMenu;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Game Over"))
        {
            animator.SetTrigger("Idle");
            mainMenu.GameOver();
        }
    }
}
