using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPanelController : MonoBehaviour
{
    //Referencia al panel de registro
    public GameObject singUpPanel;

    //Referencia a los botones
    public Button loginButton;
    public Button goToSignUpButton;
    

    //Referencia a los input field de usuario
    public InputField userInputField;
    public InputField passwordInputField;

    //Variables para guardar los datos de usuario ingresados
    private string user;
    private string password;

    private void Start()
    {
        //Se le asigna la funcionalidad a los botones por medio de la propiedad onClick de los botones
        goToSignUpButton.onClick.AddListener(GoToSignUpPanel);
        loginButton.onClick.AddListener(AuthUser);
        
        //Se le asigna la funcionalidad a los input field por medio de la propiedad onValueChanged de los botones
        userInputField.onValueChanged.AddListener(SetUser);
        passwordInputField.onValueChanged.AddListener(SetPassword);
    }

    /// <summary>
    /// Trancisión a la pantalla de registro
    /// </summary>
    private void GoToSignUpPanel()
    {
        this.gameObject.SetActive(false);
        singUpPanel.SetActive(true);
    }

    /// <summary>
    /// Autentica los usuarios en la base de datos
    /// </summary>
    private void AuthUser()
    {
        //TODO: Validate User in DB
        AuthenticationManager.Instance.Login(user, password);
        SceneManager.LoadScene("MainMenu");
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
