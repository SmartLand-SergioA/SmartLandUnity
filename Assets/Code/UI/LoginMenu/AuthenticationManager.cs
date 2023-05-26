using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/// <summary>
/// Se encarga de la autenticación y registro de usuarios a la base de datos por medio de API
/// </summary>
public class AuthenticationManager : MonoBehaviour
{
    //Singleton variable
    public static AuthenticationManager Instance;

    // Url de la api donde se consulta los usuarios registrados
    public string loginUrl = "http://localhost:8080/api/auth/login";

    // Url de la api donde se registran nuevos usuarios
    public string registerUrl = "http://localhost:8080/api/auth/register";

    //Singleton init
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Intentar hacer Login en la base de datos por medio de la API
    /// </summary>
    /// <param name="username">Usuario ingresado</param>
    /// <param name="password">Contraseña ingresada</param>
    public void Login(string username, string password)
    {
        StartCoroutine(SendLoginRequest(username, password));
    }

    private IEnumerator SendLoginRequest(string username, string password)
    {
        // Crear el objeto con las credenciales del usuario
        var credentials = new {username = username, password = password};
        // Convertir el objeto a formato JSON
        string json = JsonUtility.ToJson(credentials);
        // Crear una solicitud POST a la URL de inicio de sesión
        UnityWebRequest request = UnityWebRequest.Post(loginUrl, json);
        // Establecer la cabecera "Content-Type" para indicar que se está enviando JSON
        request.SetRequestHeader("Content-Type", "application/json");

        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        // Verificar si hay errores en la conexión o en el protocolo
        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"ERROR EN LA SOLICITUD: {request.error}");
        }
        else
        {
            // Obtener la respuesta en formato JSON
            string responseJson = request.downloadHandler.text;
            // Convertir la respuesta JSON a un objeto de la clase LoginResponse
            LoginResponse response = JsonUtility.FromJson<LoginResponse>(responseJson);

            // Verificar si el inicio de sesión fue exitoso
            if (response.success)
            {
                Debug.Log("Inicio de sesión exitoso");
                // Obtener el token JWT de la respuesta
                string jwtToken = response.token;

                // Almacenar el token JWT en PlayerPrefs (Localmente) o en tu clase de almacenamiento personalizado
                PlayerPrefs.SetString("JWTToken", jwtToken);
                
                //Ingresa al juego
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.Log($"Inicio de sesión fallido: {response.message}");
            }
        }
    }

    /// <summary>
    /// Intentar hacer registro en la base de datos por medio de la API
    /// </summary>
    /// <param name="username">Usuario ingresado</param>
    /// <param name="password">Contraseña ingresada</param>
    public void Register(string username, string password)
    {
        StartCoroutine(SendRegisterRequest(username, password));
    }

    private IEnumerator SendRegisterRequest(string username, string password)
    {
        // Crear el objeto con las credenciales del usuario
        var credentials = new {username = username, password = password};
        // Convertir el objeto a formato JSON
        string json = JsonUtility.ToJson(credentials);
        // Crear una solicitud POST a la URL de registro
        UnityWebRequest request = UnityWebRequest.Post(registerUrl, json);
        // Establecer la cabecera "Content-Type" para indicar que sese está enviando JSON
        request.SetRequestHeader("Content-Type", "application/json");
        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        // Verificar si hay errores en la conexión o en el protocolo
        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"ERROR EN LA SOLICITUD: {request.error}");
        }
        else
        {
            // Obtener la respuesta en formato JSON
            string responseJson = request.downloadHandler.text;
            // Convertir la respuesta JSON a un objeto de la clase RegisterResponse
            RegisterResponse response = JsonUtility.FromJson<RegisterResponse>(responseJson);

            // Verificar si el registro fue exitoso
            if (response.success)
            {
                Debug.Log("Registro exitoso");
                // Obtener el token JWT de la respuesta
                string jwtToken = response.token;

                // Almacenar el token JWT en PlayerPrefs (Localmente) o en tu clase de almacenamiento personalizado
                PlayerPrefs.SetString("JWTToken", jwtToken);
                
                //Ingresa al juego
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.Log($"Registro fallido: {response.message}");
            }
        }
    }

    public void Logout()
    {
        // Se borra el token de JWT de los player prefs para cerrar la sesión.
        PlayerPrefs.DeleteKey("JWTToken");
        SceneManager.LoadScene("Auth");
    }
}

/// <summary>
/// Estructura de codigo para la respuesta de la petición web del login
/// </summary>
[Serializable]
public class LoginResponse
{
    public bool success;
    public string message;
    public string token;
}

/// <summary>
/// Estructura de codigo para la respuesta de la petición web del registro
/// </summary>
[Serializable]
public class RegisterResponse
{
    public bool success;
    public string message;
    public string token;
}