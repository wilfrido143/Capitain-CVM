using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CarteUI : MonoBehaviour
{
    /// <summary>
    /// Référence à la composante TextMesh du GO
    /// </summary>
    private TextMeshProUGUI _text;

    void Start()
    {
        _text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
      
        _text.text = GameManager.Instance.PlayerData.ListeCarteMembres.Count().ToString();
        
    }

}
