using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
   
    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;
    [SerializeField] public float m_vidaActual = 100f;

   private int m_playerTurn = 0;
   private QuizDB m_quizDB = null;
   private QuizUI m_quizUI = null;
   private AudioSource m_audioSource = null;
   

   private void Start()
   {
    m_quizDB = GameObject.FindObjectOfType<QuizDB>();
    m_quizUI = GameObject.FindObjectOfType<QuizUI>();
    m_audioSource = GetComponent<AudioSource>();
   

    NextQuestion();
   }

   private void NextQuestion()
   {
        m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer );

       
   }


   private void GiveAnswer(OptionPlayer optionPlayer)
   {
        StartCoroutine(GiveAnswerRoutine(optionPlayer));
    
   }


   private IEnumerator GiveAnswerRoutine(OptionPlayer optionPlayer)
   {

    if(m_audioSource.isPlaying)
           m_audioSource.Stop();

        m_audioSource.clip = optionPlayer.Option.correct ? m_correctSound : m_incorrectSound;
        optionPlayer.SetColor(optionPlayer.Option.correct ? m_correctColor : m_incorrectColor);
     
        m_audioSource.Play();    


        yield return new WaitForSeconds(m_waitTime );

          if(optionPlayer.Option.correct)
               NextQuestion();
          else 
          {
               m_vidaActual -= 10f; // Reducir la vida actual del jugador en (10%)
               NextQuestion();
               FindObjectOfType<BarraDeVida>().Update();
          } 
              
          // Cambiar el turno de jugador
        m_playerTurn = (m_playerTurn + 1) % 2;

         // Mostrar mensaje de turno
        Debug.Log("Es el turno del jugador " + (m_playerTurn + 1));
   }

 
   public void GameOver()
   {
     SceneManager.LoadScene("Demo"); // Reemplazar "NombreDeLaEscena" con el nombre de la escena deseada
     //Se puede agregar la logica para quitar vida si se escoge una pregunta incorrecta 
         // SceneManager.LoadScene(0);
          //SceneManager.LoadScene("Demo_Scene_D");
               
   }


}
