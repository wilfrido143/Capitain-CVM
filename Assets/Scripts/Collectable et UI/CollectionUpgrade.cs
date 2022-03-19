using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollectionUpgrade : MonoBehaviour
{
    /// <summary>
    /// Valeur de l'énergie regagner au contact
    /// </summary>
    [SerializeField]
    private int _regainEnergie = 4;
    [SerializeField]
    private AudioClip _clip;

    private string _name, _spritename;

    //private SpriteRenderer spriteR;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _name = SceneManager.GetActiveScene().name.Replace(' ', '_')
            + $"__{(int)this.transform.position.x}_{(int)this.transform.position.y}";
        _spritename = this.GetComponent<UnityEngine.UI.Image>().sprite.name;

        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager
                .PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance
                .PlayerData.IncrEnergie(this._regainEnergie);
            GameManager.Instance
                .PlayerData.AjouterCollectable(_name);
            GameManager.Instance
               .PlayerData.AjouterSprite(_spritename);
           


            //GameManager.Instance.PlayerData.AjouterSprite(spriteR.sprite);
            GameObject.Destroy(this.gameObject);
        }
    }
}

