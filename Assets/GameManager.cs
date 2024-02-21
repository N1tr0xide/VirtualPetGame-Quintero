using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
            if(petName != _playerPet.Name)
            {
                _playerPet = new Pet(petName);
                Debug.Log("New pet was created");
                return true;
            }

            Debug.Log("Same name entered. Returned existing pet");
            return true;
        }

        Debug.Log("Invalid String");
        return false;
    }
}
