using UnityEngine;
using UnityEngine.UI;

namespace Code.TransicionDePaneles.Metodo3
{
    public class MainMenu : MonoBehaviour
    {
        //Game objects que referencian cada uno de los paneles
        public GameObject menuPartidaNormalPanel;
        public GameObject menuPartidaCompetitivaPanel;
        public GameObject menuPartidaCustomPanel;
        
        //Referencia a los botones
        public Button botonPartidaNormal;
        public Button botonPartidaCompetitiva;
        public Button botonPartidaCustom;
        public Button botonCerrarSesion;
    
        void Start()
        {
            //Se agrega a los botones la funcionalidad de cambiar de paneles
            //Aquí añadimos la funcionalidad a cada boton accediendo a la propiedad "onClick" de cada boton
            botonPartidaNormal.onClick.AddListener(IrAlPanelDePartidaNormal);
            botonPartidaCompetitiva.onClick.AddListener(IrAlPanelDePartidaCompetitiva);
            botonPartidaCustom.onClick.AddListener(IrAlPanelDePartidaCustom);
            botonCerrarSesion.onClick.AddListener(Logout);
        }

        private void Logout()
        {
            //Se le dice al auth manager que cierre la sesión del jugador
            AuthenticationManager.Instance.Logout();
        }

        /// <summary>
        /// Cambia al panel de partida normal, apagando el panel actual y prendiendo el de partida normal
        /// </summary>
        private void IrAlPanelDePartidaNormal()
        {
            this.gameObject.SetActive(false);
            menuPartidaNormalPanel.SetActive(true);
        }
    
        /// <summary>
        /// Cambia al panel de partida competitiva, apagando el panel actual y prendiendo el de partida competitiva
        /// </summary>
        private void IrAlPanelDePartidaCompetitiva()
        {
            this.gameObject.SetActive(false);
            menuPartidaCompetitivaPanel.SetActive(true);
        }
    
        /// <summary>
        /// Cambia al panel de partida custom, apagando el panel actual y prendiendo el de partida custom
        /// </summary>
        private void IrAlPanelDePartidaCustom()
        {
            this.gameObject.SetActive(false);
            menuPartidaCustomPanel.SetActive(true);
        }
    }
}
