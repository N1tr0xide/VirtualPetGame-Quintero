using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetScene : MonoBehaviour
{
    private GameManager _gameManager;
    private Pet _pet;

    [SerializeField] private Slider _fullnessSlider;
    [SerializeField] private Slider _happinessSlider;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Text _nameText;
    [SerializeField] private Image _petImage;
    [SerializeField] private GameObject _gameOverPanel;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _pet = _gameManager.CurrentPlayerPet;
    }

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _nameText.text = _pet.Name;
        _petImage.sprite = _pet.Sprite;
        UpdateUISliders();
        InvokeRepeating(nameof(PetStatsDecrease), 2, 1);
    }

    private void PetStatsDecrease()
    {
        _pet.ChangeAllStats(-Random.Range(1, 4));
        UpdateUISliders();

        if (!_pet.IsAnyStatZero()) return;
        CancelInvoke();
        _gameOverPanel.SetActive(true);
    }
    
    private void UpdateUISliders()
    {
        _fullnessSlider.value = _pet.Fullness;
        _happinessSlider.value = _pet.Happiness;
        _energySlider.value = _pet.Energy;
    }
    
    public void GameOverButton()
    {
        ToMainMenu();
        _gameManager.DeletePet(_pet.Name);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FeedButton()
    {
        _pet.Eat(5);
        _fullnessSlider.value = _pet.Fullness;
    }

    public void RestButton()
    {
        _pet.Rest(5);
        _energySlider.value = _pet.Energy;
    }

    public void PlayButton()
    {
        _pet.Play(5);
        _happinessSlider.value = _pet.Happiness;
    }
}
