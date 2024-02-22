using System.Collections;
using UnityEngine;

[System.Serializable]
public class Pet
{
    [SerializeField] private string _name;
    [SerializeField] private int _fullness, _happiness, _energy;

    public string Name 
    {
        get => _name;
        set 
        { 
            if(!string.IsNullOrEmpty(value)) _name = value; 
            else _name = "Invalid";
        } 
    }
    public int Fullness 
    {
        get => _fullness;
        set
        {
            _fullness = value switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => value
            };
        }
    }
    public int Happiness
    {
        get => _happiness;
        set
        {
            _happiness = value switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => value
            };
        }
    }
    public int Energy
    {
        get => _energy;
        set
        {
            _energy = value switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => value
            };
        }
    }

    public Sprite Sprite { get; private set; }

    public Pet(string petName, Sprite sprite)
    {
        _name = petName;
        _fullness = 50;
        _happiness = 40;
        _energy = 100;
        Sprite = sprite;
    }

    public void Eat(int byAmount)
    {
        Fullness += byAmount;
    }

    public void Rest(int byAmount)
    {
        Energy += byAmount;
    }

    public void Play(int byAmount)
    {
        Happiness += byAmount;
    }

    public void ChangeAllStats(int byAmount)
    {
        Eat(byAmount + Random.Range(-1, 2));
        Rest(byAmount + Random.Range(-1,2));
        Play(byAmount + Random.Range(-1, 2));
    }

    public bool IsAnyStatZero()
    {
        return _fullness <= 0 || _happiness <= 0 || _energy <= 0;
    }
}
