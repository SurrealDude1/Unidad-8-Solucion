using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuPontuacao;
    public GameObject Jogo;
    public GameObject mainmenu;
    public GameObject gameOver;

    void Start()
    {
        MostrarMenuPrincipal();
    }

    public void MostrarMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuPontuacao.SetActive(false);
        Jogo.SetActive(false);
        mainmenu.SetActive(true);
        gameOver.SetActive(false);
    }

    public void Jogar()
    {
        menuPrincipal.SetActive(false);
        menuPontuacao.SetActive(false);
        Jogo.SetActive(true);
        mainmenu.SetActive(false);
        gameOver.SetActive(false);
    }

    public void Pontuacao()
    {
        menuPrincipal.SetActive(false);
        menuPontuacao.SetActive(true);
        Jogo.SetActive(false);
        mainmenu.SetActive(true);
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        menuPrincipal.SetActive(false);
        menuPontuacao.SetActive(false);
        Jogo.SetActive(false);
        mainmenu.SetActive(false);
        gameOver.SetActive(true);
    }

    public void Principal()
    {
        MostrarMenuPrincipal();
    }
}
