using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapeauxManager : MonoBehaviour
{

    /// <summary>
    /// Détermine si le collectable a été collecté
    /// </summary>
    [SerializeField]
    private bool _estCollecter = false;

    /// <summary>
    /// Sprite du collectable
    /// </summary>
    ///[SerializeField]
    ///private Sprite _collectable;

    /// <summary>
    /// Nom du coffre utiliser dans le fichier de sauvegarde
    /// Le nom est autogénéré dans la méthode Start
    /// </summary>
    private string _name;

    private void Start()
    {
        _name = SceneManager.GetActiveScene().name.Replace(' ', '_')
            + $"__{(int)this.transform.position.x}_{(int)this.transform.position.y}";

        this._estCollecter = GameManager.Instance.PlayerData.AvoirChapeau(_name);

        if (_estCollecter != null)
            if (_estCollecter)
                GameObject.Destroy(this.gameObject);
    }

}
