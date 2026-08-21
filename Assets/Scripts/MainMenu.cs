using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Escena");
    }
    public void Pontuação()
    {
        SceneManager.LoadScene("Points");
    }
}