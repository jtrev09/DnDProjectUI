using UnityEngine;

public class GoblinStats : MonoBehaviour
{
    public string name = "Goblin";
    public string size = "Small";
    public string type = "Humanoid";
    public int armorClass = 15;
    public int currentHp = 7;
    public int maxHp = 7;
    public int speed = 30;
    public int strength = 8;
    public int dexterity = 14;
    public int constitution = 10;
    public int intelligence = 10;
    public int wisdom = 8;
    public int charisma = 8;

    // This method can be used to display the goblin's stats in the Unity console
    public void DisplayStats()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Size: " + size);
        Debug.Log("Type: " + type);
        Debug.Log("AC: " + armorClass);
        Debug.Log("HP: " + currentHp);
        Debug.Log("Speed: " + speed);
        Debug.Log("STR: " + strength);
        Debug.Log("DEX: " + dexterity);
        Debug.Log("CON: " + constitution);
        Debug.Log("INT: " + intelligence);
        Debug.Log("WIS: " + wisdom);
        Debug.Log("CHA: " + charisma);
    }

    // Example usage of the GoblinStats class
    void Start()
    {
        // Create an instance of GoblinStats
        GoblinStats goblin = new GoblinStats();

        // Display the goblin's stats
        goblin.DisplayStats();
    }

    public void TakeDamage(int damage)
   {
        if(currentHp - damage <= 0)
        {
            currentHp = 0;
            gameObject.SetActive(false); // Set the GameObject to inactive
        }
        else
        {
            currentHp -= damage;
        }
   }

    //doesn't heal above maxHp, won't allow healing a negative amount
    public void HealHp(int healAmount)
    {
        if(healAmount < 0)
        {
            return;
        }
        if(currentHp + healAmount > maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp += healAmount;
        }
    }
}
