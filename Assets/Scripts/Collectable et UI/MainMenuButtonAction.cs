using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonAction : MonoBehaviour
{
    public Button button;
    private bool _niveau2, _niveau3 = false;

    /// <summary>
    /// Permet d'afficher un panel transmis en paramètre
    /// </summary>
    /// <param name="PanelAOuvrir">Panel à afficher</param>
    public void AfficherPanel(GameObject PanelAOuvrir)
    {
        PanelAOuvrir.SetActive(true);
    }
    /// <summary>
    /// Permet d'activer les boutons des niveaux pour
    /// les accéders 
    /// </summary>
    public void ActiverBouttons()
    {
        this._niveau2 = GameManager.Instance.PlayerData.AvoirNiveauFinis("Level1");
        this._niveau3 = GameManager.Instance.PlayerData.AvoirNiveauFinis("Level2");
        if (_niveau2)
        {
            button  = GameObject.Find("ButtonNiv2").GetComponent<Button>();
            button.interactable = true;
        }
        if (_niveau3)
        {
            button = GameObject.Find("ButtonNiv3").GetComponent<Button>();
            button.interactable = true;
        }
    }



    /// <summary>
    /// Permet de ferme aussi le panel actuel
    /// </summary>
    /// <param name="PanelAFermer">Panel à fermer</param>
    public void FermerPanel(GameObject PanelAFermer)
    {
        PanelAFermer.SetActive(false);
    }

    /// <summary>
    /// Permet de charger un niveau
    /// </summary>
    /// <param name="nom">Nom du niveau à charger</param>
    public void ChargerNiveau(string nom)
    {
        SceneManager.LoadScene(nom);
    }

    /// <summary>
    /// Permet de fermer l'application
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }
}
