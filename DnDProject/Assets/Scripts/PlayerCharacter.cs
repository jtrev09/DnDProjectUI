using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
    {
        private string name;
        private string className; //role
        private string race; // species
        private string background; //what the character did beforehand

        // from strength to charisma are the players attributes
        private int strength;
        private int wisdom;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int charisma;
        private int level; //the character's level
        private int maxHp; //max player health
        private int currentHp; //this is the hp that the game will change during combat
        private int armorClass; //this determines if the character gets hit
        private int initiative; //this is used to determine turn order
        private double maxSpeed; //max player movement
        private double currentSpeed; //this keeps track of how much movement a player has left for their turn

        //The Str, Dex, Con, Int, Wis, and Cha part are
        //short forms of strength, dexterity, constitution, intelligence, wisdom, and charisma
        private bool hasStrSaveProficiency = false;
        private bool hasDexSaveProficiency = false;
        private bool hasConSaveProficiency = false;
        private bool hasIntSaveProficiency = false;
        private bool hasWisSaveProficiency = false;
        private bool hasChaSaveProficiency = false;


        private int proficiencyBonus;

        private List<string> feats = new List<string>();

        private string[] armorProficiencies;
        private string[] weaponProficiencies;

        private List<string> equipment = new List<string>();//The items a player has
        private int[] spellSlots = new int[10]; //cantrips and spells from 1-9
        private List<string> spells = new List<string>(); //spells available to the player

        private List<string> conditions = new List<string>(); //any conditions that the player gets during combat
        private List<string> resistances = new List<string>(); //what the player will only take half damage from
        private List<string> immunities = new List<string>(); //what the player takes no damage from

        //what actions are available to the player
        private bool isActionAvailable = true;
        private bool isBonusActionAvailable = true;
        private bool isReactionAvailable = true;


        private (double, double) playerLocation;

        public PlayerCharacter() {  }



        public void setStartInput(string name, string race, string className, string background)
        {
            this.name = name;
            this.race = race;
            this.className = className;
            this.background = background;

        }

        public void SetStats(int str, int dex, int con, int intel, int wis, int cha, int level, int hp, int ac, int initiative, int profBonus, double speed)
        {
            strength = str;
            dexterity = dex;
            constitution = con;
            intelligence = intel;
            wisdom = wis;
            charisma = cha;
            this.level = level;
            maxHp = hp;
            currentHp = hp;
            armorClass = ac;
            this.initiative = initiative;
            this.maxSpeed = speed;
            currentSpeed = speed;
            proficiencyBonus = profBonus;

        }

    public void AddEquipment(string item)
    {
        if (!equipment.Contains(item))
        {
            equipment.Add(item);
        }
    }
    public void RemoveEquipment(string item)
    {
        if (equipment.Contains(item))
        {
            equipment.Remove(item);
        }
    }

    public void AddSpells(string spell)
    {
        if (!spells.Contains(spell))
        {
            spells.Add(spell);
        }
    }
    public void RemoveSpells(string spell)
    {
        if (spells.Contains(spell))
        {
            spells.Remove(spell);
        }
    }
    public void SetSpellSlots(int[] spellSlots)
        {
            this.spellSlots = spellSlots;
        }

        //the paramaters are the short forms of strenght, dexterity, constitution, intelligence, wisdom, and charisma
        //It determines which saves the player has proficiency in
        public void SetSaveProficiencies(bool str, bool dex, bool con, bool intel, bool wis, bool cha, int proficiencyBonus)
        {
            hasStrSaveProficiency = str;
            hasDexSaveProficiency = dex;
            hasConSaveProficiency = con;
            hasIntSaveProficiency = intel;
            hasWisSaveProficiency = wis;
            hasChaSaveProficiency = cha;
            this.proficiencyBonus = proficiencyBonus;
        }

        


        //ability modifiers
        public int WisdomModifier() => (wisdom - 10) / 2;
        public int DexterityModifier() => (dexterity - 10) / 2;
        public int ConstitutionModifier() => (constitution - 10) / 2;
        public int IntelligenceModifier() => (intelligence - 10) / 2;
        public int CharismaModifier() => (charisma - 10) / 2;
        public int StrengthModifier() => (strength - 10) / 2;

        //Resets player actions and currentSpeed at the start of their turn
        public void ResetPlayerForTurn()
        {
            isActionAvailable = true;
            isBonusActionAvailable = true;
            isReactionAvailable = true;
            currentSpeed = maxSpeed;
        }

        //TakeDamage and HealHp will be used to set currentHp to different amounts
        public void TakeDamage(int damage)
        {
            if (currentHp - damage < 0)
            {
                currentHp = 0;
            }
            else
            {
                currentHp -= damage;
            }

        }
        //doesn't heal above maxHp, won't allow healing a negative amount
        public void HealHp(int healAmount)
        {
            if (healAmount < 0)
            {
                return;
            }
            if (currentHp + healAmount > maxHp)
            {
                currentHp = maxHp;
            }
            else
            {
                currentHp += healAmount;
            }
        }

        public void SetPlayerLocation(double x, double y)
        {
            playerLocation = (x, y);
        }

        //when a player moves, they spend currentSpeed
        //can't move if they have 0 speed
        public void PlayerMove(double distance)
        {
            if (currentSpeed - distance < 0)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed -= distance;
            }

        }

        //when the player uses a spell, they spend a spell slot equal to the level they used for the spell
        public void UseSpellSlot(int spellLevel)
        {
            if (spellLevel > 9 || spellLevel < 0)
            {
                return;
            }
            if (spellSlots[spellLevel] > 0)
            {
                spellSlots[spellLevel]--;
            }
        }

        //add and remove conditions
        public void AddCondition(string condition)
        {
            if (!conditions.Contains(condition))
            {
                conditions.Add(condition);
            }
        }
        public void RemoveCondition(string condition)
        {
            if (conditions.Contains(condition))
            {
                conditions.Remove(condition);
            }
        }

        //add and remove resistances
        public void AddResistance(string resistance)
        {
            if (!resistances.Contains(resistance))
            {
                resistances.Add(resistance);
            }
        }

        public void RemoveResistance(string resistance)
        {
            if (resistances.Contains(resistance))
            {
                resistances.Remove(resistance);
            }
        }

        //add and remove immunities
        public void AddImmunity(string immunity)
        {
            if (!immunities.Contains(immunity))
            {
                immunities.Add(immunity);
            }
        }
        public void RemoveImmunity(string immunity)
        {
            if (immunities.Contains(immunity))
            {
                immunities.Remove(immunity);
            }
        }

    //Add and remove items from feat
    public void AddFeat(string feat)
    {
        if (!feats.Contains(feat))
        {
            feats.Add(feat);
        }
    }
    public void RemoveFeat(string feat)
    {
        if (feats.Contains(feat))
        {
            feats.Remove(feat);
        }
    }

    //The player used their actions, so they can't use it again
    public void UseAction()
        {
            isActionAvailable = false;
        }
        //The player used their bonus actions, so they can't use it again
        public void UseBonusAction()
        {
            isBonusActionAvailable = false;
        }
        //The player used their reaction, so they can't use it again
        public void UseReaction()
        {
            isReactionAvailable = false;
        }

        //getters
        public string GetName() => name;
        public string GetClassName() => className;
        public string GetRace() => race;
        public string GetBackground() => background;

        public int GetStrength() => strength;
        public int GetWisdom() => wisdom;
        public int GetDexterity() => dexterity;
        public int GetConstitution() => constitution;
        public int GetIntelligence() => intelligence;
        public int GetCharisma() => charisma;

        public int GetArmorClass() => armorClass;
        public int GetCurrentHp() => currentHp;
        public int GetMaxHp() => maxHp;
        public int GetLevel() => level;
        public int GetInitiative() => initiative;
        public double GetMaxSpeed() => maxSpeed;
        public double GetCurrentSpeed() => currentSpeed;

        public bool GetHasStrSaveProficiency() => hasStrSaveProficiency;
        public bool GetHasDexSaveProficiency() => hasDexSaveProficiency;
        public bool GetHasConSaveProficiency() => hasConSaveProficiency;
        public bool GetHasIntSaveProficiency() => hasIntSaveProficiency;
        public bool GetHasWisSaveProficiency() => hasWisSaveProficiency;
        public bool GetHasChaSaveProficiency() => hasChaSaveProficiency;
        public int GetProficiencyBonus() => proficiencyBonus;

        public List<string> GetFeats() => feats;
        public List<string> GetEquipment() => equipment;
        public int[] GetSpellSlots() => spellSlots;
        public List<string> GetSpells() => spells;

        public string[] GetArmorProficiencies() => armorProficiencies;
        public string[] GetWeaponProficiencies() => weaponProficiencies;


        public List<string> GetConditions() => conditions;
        public List<string> GetResistances() => resistances;
        public List<string> GetImmunities() => immunities;

        public bool GetIsActionAvailable() => isActionAvailable;
        public bool GetIsBonusActionAvailable() => isBonusActionAvailable;
        public bool GetIsReactionAvailable() => isReactionAvailable;

        public (double, double) GetPlayerLocation() => playerLocation;

    }
