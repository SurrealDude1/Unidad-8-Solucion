using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.ChangeScore(1);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("ScoreManager não foi encontrado!");
            }
        }
    }
}