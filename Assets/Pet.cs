using System.Collections;
using UnityEngine;

[System.Serializable]
public class Pet
{
    [SerializeField] private string name;
    [SerializeField] private int fullness, hapiness, energy;

    public string Name 
    {
        get { return name; } 
        set 
        { 
            if(!string.IsNullOrEmpty(value)) name = value; 
            else name = "Unvalid";
        } 
    }
    public int Fullness 
    {
        get {  return fullness; }
        set
        {
            if(value > 100) fullness = 100;
            else if(value < 0) fullness = 0;
            else fullness = value;
        }
    }
    public int Happiness
    {
        get { return hapiness; }
        set
        {
            if (value > 100) hapiness = 100;
            else if (value < 0) hapiness = 0;
            else hapiness = value;
        }
    }
    public int Energy
    {
        get { return energy; }
        set
        {
            if (value > 100) energy = 100;
            else if (value < 0) energy = 0;
            else energy = value;
        }
    }

    public Pet(string petName)
    {
        name = petName;
        fullness = 50;
        hapiness = 20;
        energy = 50;
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

    public IEnumerator CharacterisicsDecrease()
    {
        yield return new WaitForSeconds(1);
        Eat(-5);
        Rest(-5);
        Play(-5);
        yield return new WaitUntil(() => fullness <= 0 || hapiness <= 0 || energy <= 0);
    }
}
