using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenu : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Sprite[] _catSprites;
    [SerializeField] private Text _nameInputText;
    [SerializeField] private GameObject _playerPetsPanel, _instructionsPanel;
    [SerializeField] private Text _playerPetsText;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _playerPetsPanel.SetActive(false);
        _instructionsPanel.SetActive(false);
    }
    
    public void GetPetButton()
    {
        int randomInt = Random.Range(0, _catSprites.Length);
        if (!_gameManager.GeneratePet(_nameInputText.text, _catSprites[randomInt])) return;
        
        SceneManager.LoadScene("PetScene");
    }

    public void PetsPanel()
    {
        ActivatePanel(_playerPetsPanel);

        String[] petsNames = _gameManager.GetPlayerPetsNames();
        string text = "";
        
        foreach (var petName in petsNames)
        {
            text += petName + "\n";
        }

        _playerPetsText.text = text;
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
