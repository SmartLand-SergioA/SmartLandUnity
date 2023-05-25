using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.TransicionDePaneles.Metodo3
{
    public class PartidaCustomPanelController : MonoBehaviour
    {
        //Game object que referencian el panel de menú principal
        public GameObject mainMenuPanel;
        
        //Referencia a los botones
        public Button startGameButton;
        public Button backToMainMenuButton;

        private void Start()
        {
            //Aquí añadimos la funcionalidad a cada boton accediendo a la propiedad "onClick" de cada boton
            startGameButton.onClick.AddListener(StartNormalGame);
            backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        }

        /// <summary>
        /// Se carga la escena de juego
        /// </summary>
        private void StartNormalGame()
        {
            //Aqui cambiamos a la escena de juego
            SceneManager.LoadScene("SampleScene");
            //Cargamos la escena del fondo sobre la escena de juego
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        }

        /// <summary>
        /// Cambia al panel de menú principal, apagando el panel actual y prendiendo el de menú principal
        /// </summary>
        private void BackToMainMenu()
        {
            this.gameObject.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }
}
