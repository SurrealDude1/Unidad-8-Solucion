using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuPontuacao;
    public GameObject Jogo;
    public GameObject mainmenu;
    void Start()
    {
        menuPrincipal.SetActive(true);
        menuPontuacao.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void Jogar()
    {
        menuPrincipal.SetActive(false);
        Jogo.SetActive(true);
        mainmenu.SetActive(false);
    }

    public void Principal()
    {
        menuPrincipal.SetActive(true);
        menuPontuacao.SetActive(false);
    }

    public void Pontuacao()
    {
        menuPrincipal.SetActive(false);
        menuPontuacao.SetActive(true);
    }
}
