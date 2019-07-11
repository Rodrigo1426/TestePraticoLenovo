using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerTime : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject explosion;

    public int sceneNumber;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
 
    //Método para chamar a rotina e aparecer os painéis 1 e 2
    public void PressPanel () {
        StartCoroutine(HideAndShowPanel() );
    }

    //Método para chamar a rotina e aparecer o botão explodir
    public void PressButton () {
        StartCoroutine(HideAndShowButton(3.0f) );
    }
    
    //Método para ocorrer uma ação após 20 segundos
    public IEnumerator HideAndShowPanel()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        yield return new WaitForSeconds(20.0f);
        panel1.SetActive(true);
        panel2.SetActive(true);
    }

    //Método para ocorrer uma ação após 3 segundos
    public IEnumerator HideAndShowButton(float delay)
    {
        explosion.SetActive(false);
        yield return new WaitForSeconds(delay);
        explosion.SetActive(true);
    }

    //Tem a função de sair = Alt+F4
    public void ExitButton()
    {
        Application.Quit();
    }

    //Troca de cena
    public void Scenes()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    //método que ocorre a cada frame
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //método para despausar o jogo
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //método para pausar o jogo
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
