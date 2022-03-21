using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Représente les données de jeu
/// </summary>
[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// Niveau sélectionné par l'utilisateur pour le vol. général
    /// </summary>
    [Range(-80, 0)]
    private float _volumeGeneral = 0;
    public float VolumeGeneral { get { return _volumeGeneral; } set { _volumeGeneral = value; } }

    /// <summary>
    /// Niveau sélectionné par l'utilisateur pour le vol. de la musique
    /// </summary>
    [Range(-80, 0)]
    private float _volumeMusique = 0;
    public float VolumeMusique { get { return _volumeMusique; } set { _volumeMusique = value; } }

    /// <summary>
    /// Niveau sélectionné par l'utilisateur pour le vol. de la musique
    /// </summary>
    [Range(-80, 0)]
    private float _volumeEffet = 0;
    public float VolumeEffet { get { return _volumeEffet; } set { _volumeEffet = value; } }

    /// <summary>
    /// Représente le nombre de points de vie du personnage
    /// </summary>
    private int _vie;
    /// <summary>
    /// Représente le nombre d'énergie (entre 0 et 4)
    /// </summary>
    private int _energie;
    /// <summary>
    /// Représente le score obtenu
    /// </summary>
    private int _score;
    /// <summary>
    /// Liste des coffres ouverts dans le jeu
    /// </summary>
    private List<string> _chestOpenList;
    /// <summary>
    /// Liste des niveaux finis
    /// </summary>
    private List<string> _niveauxReussis;
    /// <summary>
    /// Liste des cartemembres récoltés
    /// </summary>
    private List<string> _carteMembres;
    /// <summary>
    /// Liste des chapeaux récoltés
    /// </summary>
    private List<string> _chapeaux;
    /// <summary>
    /// Liste des conventions récoltés;
    /// </summary>
    private List<string> _conventions;

    /// <summary>
    /// Représente le maximum d'énergie du personnage
    /// </summary>
    public const int MAX_ENERGIE = 4;
    /// <summary>
    /// Permet d'identifier les actions sur le UI à réaliser
    /// lors de la perte d'énergie
    /// </summary>
    public System.Action UIPerteEnergie;
    /// <summary>
    /// Permet d'identifier les actions sur le UI à réaliser
    /// lors de la perte d'énergie
    /// </summary>
    public System.Action UIPerteVie;
    /// <summary>
    /// Permet d'identifier les actions à réaliser lors d'un gameover
    /// </summary>
    public System.Action Gameover;


    public int Energie { get { return this._energie; } }
    public int Vie { get { return this._vie; } }
    public int Score { get { return this._score; } }
    public string[] ListeCoffreOuvert { get { return this._chestOpenList.ToArray(); } }
    public string[] ListeNiveauxfinis { get { return this._niveauxReussis.ToArray(); } }
    public string[] ListeCarteMembres { get { return this._carteMembres.ToArray(); } }
    public string[] ListeChapeaux { get { return this._chapeaux.ToArray(); } }
    public string[] ListeConventions { get { return this._conventions.ToArray(); } }


    public PlayerData()
    {
        this._vie = 0;
        this._energie = 0;
        this._score = 0;
        this._volumeGeneral = 0;
        this._volumeMusique = 0;
        this._volumeEffet = 0;
        this.UIPerteEnergie = null;
        this.UIPerteVie = null;
        this.Gameover = null;
        this._chestOpenList = new List<string>();
        this._niveauxReussis = new List<string>();
        this._carteMembres = new List<string>();
        this._chapeaux = new List<string>();
        this._conventions = new List<string>();
    }

    public PlayerData(int vie = 0, int energie = 0, int score = 0,
        float volumeGeneral = 0, float volumeMusique = 0, float volumeEffet = 0,
        System.Action uiPerteEnergie = null, System.Action uiPerteVie = null,
        System.Action gameOver = null, List<string> ChestList = null, List<string> NiveauxList = null, 
        List<string> CarteMembres = null, List<string> Chapeaux = null, List<string> Conventions = null)
    {
        this._vie = 0;
        this._energie = 0;
        this._score = score;
        this._volumeGeneral = volumeGeneral;
        this._volumeMusique = volumeMusique;
        this._volumeEffet = volumeEffet;
        this.UIPerteEnergie += uiPerteEnergie;
        this.UIPerteVie += uiPerteVie;
        this.Gameover += gameOver;
        this._chestOpenList = new List<string>();
        if (ChestList != null)
            this._chestOpenList = ChestList;
        this._niveauxReussis = new List<string>();
        if (NiveauxList != null)
            this._niveauxReussis = NiveauxList;
        this._carteMembres = new List<string>();
        if (CarteMembres != null)
            this._carteMembres = CarteMembres;
        this._chapeaux = new List<string>();
        if (Chapeaux != null)
            this._chapeaux = Chapeaux;
        this._conventions = new List<string>();
        if (Conventions != null)
            this._conventions = Conventions;


    }

    /// <summary>
    /// Diminue l'énergie du personnage
    /// </summary>
    /// <param name="perte">Niveau de perte (par défaut 1)</param>
    public void DecrEnergie(int perte = 1)
    {
        this._energie -= perte;
        this.UIPerteEnergie();
        if (this._energie <= 0)
        {
            this.DecrVie();
        }
    }

    /// <summary>
    /// Permet de réduire la vie d'un personnage
    /// </summary>
    public void DecrVie()
    {
        this.UIPerteVie();
        this._vie--;
        if (this._vie <= 0)
            this.Gameover();
        else
        {
            this.IncrEnergie(MAX_ENERGIE, true);
            GameManager.Instance.RechargerNiveau();
        }
    }

    /// <summary>
    /// Permet d'augmenter l'énergie jusqu'à MAX_ENERGIE
    /// </summary>
    /// <param name="gain">Gain d'augmentation</param>
    public void IncrEnergie(int gain, bool revive)
    {
        this._energie += gain;
        if (revive)
        {
            this._energie = gain;
        }
        else if (this._energie > MAX_ENERGIE)
        {
            this._energie = 1;
            this.IncrVie();
        }
        
        this.UIPerteEnergie();
    }

    /// <summary>
    /// Permet d'augmenter la vie
    /// </summary>
    /// <param name="gain">Gain d'augmentation</param>
    public void IncrVie(int gain = 1)
    {
        this._vie += gain;
        this.UIPerteVie();
    }

    /// <summary>
    /// Augmente le score du joueur
    /// </summary>
    /// <param name="gain">Point gagné</param>
    public void IncrScore(int gain = 1)
    {
        this._score += gain;
    }

    /// <summary>
    /// Ajoute le nom du coffre à la liste
    /// </summary>
    /// <param name="nom">Nom du coffre à ajouter</param>
    public void AjouterCoffreOuvert(string nom)
    {
        this._chestOpenList.Add(nom);
    }

    /// <summary>
    /// Détermine si le coffre est contenu dans la liste
    /// des coffres ouverts
    /// </summary>
    /// <param name="nom">Nom du coffre à vérifier</param>
    /// <returns>true si le coffre est ouvert, false sinon</returns>
    public bool AvoirOuvertureCoffre(string nom)
    {
        return this._chestOpenList.Contains(nom);
    }


    /// <summary>
    /// Ajoute le nom du niveau fini à la liste
    /// </summary>
    /// <param name="nom">Nom du niveau à ajouter</param>
    public void NiveauxFinis(string nom)
    {
        this._niveauxReussis.Add(nom);
    }

    /// <summary>
    /// Détermine si le niveau est contenu dans la liste
    /// des niveaux finis
    /// </summary>
    /// <param name="nom">Nom du niveau à vérifier</param>
    /// <returns>true si le niveau est fini, false sinon</returns>
    public bool AvoirNiveauFinis(string nom)
    {
         return this._niveauxReussis.Contains(nom);
    }

    /// <summary>
    /// Ajoute le nom du collectable à la liste
    /// </summary>
    /// <param name="nom">Nom du collectable à ajouter</param>
    public void AjouterChapeau(string nom)
    {
        this._chapeaux.Add(nom);
    }
    public void AjouterCarteMembre(string nom)
    {
        this._carteMembres.Add(nom);
    }
    public void AjouterConvention(string nom)
    {
        this._conventions.Add(nom);
    }


    /// <summary>
    /// Détermine si les collectables ont déjà été récupérés
    /// </summary>
    /// <param name="nom">Nom du collectable à vérifier</param>
    /// <returns>true si le collectable est collecter, false sinon</returns>
    public bool AvoirChapeau(string nom)
    {
        return this._chapeaux.Contains(nom);
    }

    public bool AvoirCarteMembre(string nom)
    {
        return this._carteMembres.Contains(nom);
    }

    public bool AvoirConvention(string nom)
    {
        return this._conventions.Contains(nom);
    }

}
