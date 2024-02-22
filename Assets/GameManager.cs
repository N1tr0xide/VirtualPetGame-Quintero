using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] List<Pet> playerPets = new List<Pet> { };

    [SerializeField] private Pet _playerPet;

    public Pet PlayerPet { get { return _playerPet; } }

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else { Destroy(this); }
    }

    /// <summary>
    /// Returns true if pet is successfully created. Returns false otherwise
    /// </summary>
    /// <param name="petName"></param>
    /// <returns></returns>
    public bool GeneratePet(string petName)
    {
        if(!string.IsNullOrEmpty(petName))
        {
            _playerPet = VerifyPetExistence(petName);
            return true;
        }

        Debug.Log("Invalid String");
        return false;
    }

    private Pet VerifyPetExistence(string petName)
    {
        foreach(var pet in playerPets) 
        {
            if(pet.Name == petName)
            {
                Debug.Log("Previous Pet Entered. Data returned");
                return pet;
            }
        }

        Pet newPet = new Pet(petName);
        playerPets.Add(newPet);
        Debug.Log("New pet was made.");
        return newPet;
    }

    public void DeletePet(string petName)
    {
        foreach (var pet in playerPets)
        {
            if (pet.Name == petName)
            {
                playerPets.Remove(pet);
            }
        }
    }
}
