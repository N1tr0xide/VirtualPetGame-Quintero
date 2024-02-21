using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetScene : MonoBehaviour
{
    private Pet _pet;
    [SerializeField] private Slider fullnessSlider;
    [SerializeField] private Slider hapinessSlider;
    [SerializeField] private Slider energySlider;

    private void Awake()
    {
        _pet = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerPet;
    }

    private void Start()
    {
        fullnessSlider.value = _pet.Fullness;
        hapinessSlider.value = _pet.Happiness;
        energySlider.value = _pet.Energy;
        StartCoroutine(_pet.CharacterisicsDecrease());
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
