using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ConfigPanelController : MonoBehaviour
{
    //Referencia al boton de cerrar panel
    public Button closeConfigButton;
    //Referencia del toggle de configuración para el video
    public Toggle videoBackgroundToggle;
    
    //Referencia del slider del volumen de la musica
    public Slider musicVolumeSlider;
    public AudioSource audioSource;
    
    //Referencia de los botones de la imagenes
    public List<Button> backgroundButtonsList = new List<Button>();
    
    //Referencia de la imagen de fondo
    public Image backgroundImage;
    //Referencia del video de fondo
    public VideoPlayer backgroundVideo;
    
    //Referencia del contenedor de botones de configuracion de imagen de fondo
    public GameObject backgroundButtonsContainer;

    private void Start()
    {
        //Se le añade la funcionalidad al botón de cerrar el panel de configuración por medio de la propiedad onClick
        closeConfigButton.onClick.AddListener(CloseConfigPanel);
        
        //Se define la funcionalidad del objeto toggle que nos indica si puede reproducir el video o cambiar a la imagen de fondo
        videoBackgroundToggle.onValueChanged.AddListener(ToggleVideoBackground);
        //Inicializamos el panel de configuración con el video siempre activo
        ToggleVideoBackground(true);
        
        //Se inicializa el valor del slider al valor inicial de la musica
        musicVolumeSlider.value = audioSource.volume;
        //Se le agrega la funcionalidad al slider para que cada que cambie de valor haga el llamado de la función correspondiente
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);

        //Se recorre la lista de botones para agregar la funcionalidad de cambiar imagen pasando como parametro la imagen que se tenga en ese botón
        foreach (Button button in backgroundButtonsList)
        {
            button.onClick.AddListener(() => ChangeMenuBackground(button.image.sprite));
        }
    }

    /// <summary>
    /// Cambia el sprite de la imagen del fondo
    /// </summary>
    /// <param name="sprite">Nuevo sprite que se quiere poner</param>
    private void ChangeMenuBackground(Sprite sprite)
    {
        backgroundImage.sprite = sprite;
    }

    /// <summary>
    /// Se establece el valor del volumen de la musica
    /// </summary>
    /// <param name="value">Nuevo valor del volumen</param>
    private void SetMusicVolume(float value)
    {
        audioSource.volume = value;
    }
    
    /// <summary>
    /// Se cierra el panel de configuración
    /// </summary>
    private void CloseConfigPanel()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Cambiar el video por la imagen de fondo y viceversa
    /// </summary>
    /// <param name="isActive">verdadero si se quiere activar el video, falso si se quiere activar la imagen</param>
    private void ToggleVideoBackground(bool isActive)
    {
        if (isActive)
        {
            //Se esconde los botones para de imagen
            backgroundButtonsContainer.SetActive(false);
            //Se esconde la imagen
            backgroundImage.enabled = false;
            //Se muestra el video
            backgroundVideo.enabled = true;
            
            //Se para el video para iniciarlo desde el principio
            backgroundVideo.Stop();
            backgroundVideo.Play();
        }
        else
        {
            //Se muestra los botones para cambiar la imagen de fondo
            backgroundButtonsContainer.SetActive(true);
            //Se muestra la imagen
            backgroundImage.enabled = true;
            //Se esconde el video
            backgroundVideo.enabled = false;
        }
    }
    
}
