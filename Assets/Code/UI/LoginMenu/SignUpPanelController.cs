using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUpPanelController : MonoBehaviour
{
    // Referencia al panel de login
    public GameObject loginPanel;

    // Referencia de los botones
    public Button signUpButton;
    public Button goToLoginButton;

    // Refrencia de los input fields
    public InputField userInputField;
    public InputField passwordInputField;

    // variables para guardar los campos capturados en los input fields
    private string user;
    private string password;
    
    private void Start()
    {
        //Se le asigna la funcionalidad a los botones por medio de la propiedad onClick de los botones
        signUpButton.onClick.AddListener(RegisterUser);
        goToLoginButton.onClick.AddListener(GoToLoginPanel);
        
        //Se le asigna la funcionalidad a los input field por medio de la propiedad onValueChanged de los botones
        userInputField.onValueChanged.AddListener(SetUser);
        passwordInputField.onValueChanged.AddListener(SetPassword);
    }

    /// <summary>
    /// Trancisión a la pantalla de login
    /// </summary>
    private void GoToLoginPanel()
    {
        loginPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Registra los usuarios en la base de datos
    /// </summary>
    private void RegisterUser()
    {
        //TODO: Register User in DB
        AuthenticationManager.Instance.Register(user, password);
    }

    /// <summary>
    /// Captura el texto ingresado en el campo de usuario
    /// </summary>
    /// <param name="user">usuario ingresado en el input field de usuario</param>
    private void SetUser(string user)
    {
        this.user = user;
    }
    
    /// <summary>
    /// Captura el texto ingresado en el campo de contraseña
    /// </summary>
    /// <param name="user">contraseña ingresado en el input field de contraseña</param>
    private void SetPassword(string password)
    {
        this.password = password;
    }
}
