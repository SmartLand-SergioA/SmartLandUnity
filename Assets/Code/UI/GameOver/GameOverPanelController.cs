using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    public Button restartGameButton;
    public Button goToMainMenuButton;

    private void Awake()
    {
        restartGameButton.onClick.AddListener(RestartGame);
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
    }
    
    private void RestartGame()
    {
        //Aqui cambiamos a la escena de juego
        SceneManager.LoadScene("SampleScene");
        //Cargamos la escena del fondo sobre la escena de juego
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }

    private void GoToMainMenu()
    {
        //Aqui cambiamos a la escena del menu principal
        SceneManager.LoadScene("MainMenu");
    }
}
