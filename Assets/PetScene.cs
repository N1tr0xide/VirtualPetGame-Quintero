using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetScene : MonoBehaviour
{
    private GameManager gameManager;
    private Pet _pet;

    [SerializeField] private Slider fullnessSlider;
    [SerializeField] private Slider hapinessSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Text nameText;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _pet = gameManager.PlayerPet;
    }

    private void Start()
    {
        nameText.text = _pet.Name;
        UpdateUISliders();
        InvokeRepeating(nameof(PetStatsDecrease), 2, 1);
    }

    private void PetStatsDecrease()
    {
        _pet.ChangeAllStats(-Random.Range(1, 4));
        UpdateUISliders();

        if(_pet.IsAnyStatZero())
        {
            CancelInvoke();
            GameOver();
            Debug.Log("GameOver");
        }
    }

    private void GameOver()
    {

    }

    private void UpdateUISliders()
    {
        fullnessSlider.value = _pet.Fullness;
        hapinessSlider.value = _pet.Happiness;
        energySlider.value = _pet.Energy;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FeedButton()
    {
        _pet.Eat(5);
        fullnessSlider.value = _pet.Fullness;
    }

    public void RestButton()
    {
        _pet.Rest(5);
        energySlider.value = _pet.Energy;
    }

    public void PlayButton()
    {
        _pet.Play(5);
        hapinessSlider.value = _pet.Happiness;
    }
}
