using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Image))]
public class CollectableUI : MonoBehaviour
{
    /// <summary>
    /// Liste des sprites à utiliser selon le type
    /// de contrôler
    /// </summary>
    [SerializeField]
    private List<string> _sprites;
    /// <summary>
    /// Défini le contrôle à retrouver sur un clavier
    /// </summary>
    [SerializeField]

    private Sprite spriteR;

    [SerializeField]
    private bool _ouvert;
    

    private void Start()
    {
        DesactiveInventaire();
    }

    private void Update()
    {
        if (Input.GetKey("E")  && !_ouvert)
        {
            ActiveInventaire();
            _ouvert = true;
        }
        else if (Input.GetKey("E") && _ouvert)
        {
            DesactiveInventaire();
            _ouvert = false;
        }
    }


    public void SetSpriteFromList()
    {
        
        _sprites = GameManager.Instance.PlayerData.AvoirSprite();

        for (int i = 1; i < gameObject.transform.childCount;)
        {
            spriteR = gameObject.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().sprite;
            spriteR.name = _sprites[i - 1];
        }
    }

    /// <summary>
    /// Affiche le GO avec le message
    /// </summary>
    /// <param name="message">Message à afficher</param>
    public void ActiveInventaire()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Désactive le GO
    /// </summary>
    public void DesactiveInventaire()
    {
        this.gameObject.SetActive(false);
    }
}
