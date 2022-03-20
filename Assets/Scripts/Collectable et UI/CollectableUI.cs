using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Image))]
public class CollectableUI : MonoBehaviour
{

    void Start()
    {
       
    }

    public void ActiveInventaire(GameObject Objet)
    {
        Objet.SetActive(true);

    }

    /// <summary>
    /// Désactive l'inventaire
    /// </summary>
    public void DesactiveInventaire(GameObject Objet)
    {
        Objet.SetActive(false);
    }

}
