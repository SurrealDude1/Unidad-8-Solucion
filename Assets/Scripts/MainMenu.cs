using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject menuPrincipal;
    public GameObject menuPontuacao;

    public void Start() {
        Principal();
    }

    public void Jogar() {
        SceneManager.LoadScene("Escena");
    }
    public void Principal() {
        menuPrincipal.SetActive(true);
        menuPontuacao.SetActive(false);
    }
    public void Pontuação() {
        menuPrincipal.SetActive(false);
        menuPontuacao.SetActive(true);
    }
}
