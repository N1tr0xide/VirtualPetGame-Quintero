using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<Pet> _playerPets = new List<Pet> { };
    [SerializeField] private Pet _currentPlayerPet;

    public Pet CurrentPlayerPet { get { return _currentPlayerPet; } }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else { Destroy(this); }
    }

    /// <summary>
    /// Returns true if pet is successfully created. Returns false otherwise
    /// </summary>
    /// <param name="petName"></param>
    /// <param name="sprite"></param>
    /// <returns></returns>
    public bool GeneratePet(string petName, Sprite sprite)
    {
        if(!string.IsNullOrEmpty(petName))
        {
            if (VerifyPetExistence(petName, out _currentPlayerPet)) return true;

            Pet newPet = new Pet(petName, sprite);
            _currentPlayerPet = newPet;
            _playerPets.Add(newPet);
            
            Debug.Log("New pet was made.");
            return true;
        }

        Debug.Log("Invalid String");
        return false;
    }
    
    private bool VerifyPetExistence(string petName, out Pet pet)
    {
        foreach(var p in _playerPets)
        {
            if (p.Name != petName) continue;
            Debug.Log("Previous Pet Entered. Data returned");
            pet = p;
            return true;
        }

        pet = null;
        return false;
    }

    public void DeletePet(string petName)
    {
        Pet petToBeRemoved = null; 

        foreach (var pet in _playerPets)
        {
            if (pet.Name != petName) continue;
            
            _currentPlayerPet = null;
            petToBeRemoved = pet;
        }

        if (petToBeRemoved != null) _playerPets.Remove(petToBeRemoved);
    }

    public string[] GetPlayerPetsNames()
    {
        List<string> pets = new List<string>();

        foreach (var pet in _playerPets)
        {
            pets.Add(pet.Name);
        }

        return pets.ToArray();
    }
}
