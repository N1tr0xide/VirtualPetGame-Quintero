using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Text nameInputText;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    public void GetPetButton()
    {
        if (gameManager.GeneratePet(nameInputText.text))
        {
            SceneManager.LoadScene("PetScene");
            return;
        }
    }
}
