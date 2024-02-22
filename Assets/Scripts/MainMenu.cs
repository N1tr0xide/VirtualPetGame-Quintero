using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Sprite[] _catSprites;
    [SerializeField] private Text _nameInputText;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    public void GetPetButton()
    {
        int randomInt = Random.Range(0, _catSprites.Length);
        if (!_gameManager.GeneratePet(_nameInputText.text, _catSprites[randomInt])) return;
        
        SceneManager.LoadScene("PetScene");
        return;
    }
}
