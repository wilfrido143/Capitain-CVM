﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConventionUpgrade : MonoBehaviour
{
    /// <summary>
    /// Valeur de l'énergie regagner au contact
    /// </summary>
    [SerializeField]
    private int _regainEnergie = 1;
    [SerializeField]
    private AudioClip _clip;

    private string _name;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _name = SceneManager.GetActiveScene().name.Replace(' ', '_')
            + $"__{(int)this.transform.position.x}_{(int)this.transform.position.y}";

        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager
                .PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance
                .PlayerData.IncrEnergie(this._regainEnergie, false);
            GameManager.Instance
                .PlayerData.AjouterConvention(_name);
            GameObject.Destroy(this.gameObject);
        }
    }
}
