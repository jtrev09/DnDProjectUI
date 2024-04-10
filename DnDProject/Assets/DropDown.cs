using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Dropdown dropdown3;
    [SerializeField] private TMP_Dropdown dropdown4;
    public int temp;
    public DropDown DropDown1;
    public TMP_Dropdown DropDown2;
    public string race;
    public string @class;
    public string background;
    public int level = 1;
    public List<string> feats = new List<string>();


    public TextMeshProUGUI ClassOutput, RaceOutput, SubRaceOutput, BackroundOutput, FeatOutput;
    /*
    public Transform dropdownMenu;
    int menuIndex = dropdownMenu.GetComponent<Dropdown>().value;

    //get all options available within this dropdown menu
    List<Dropdown.OptionData> menuOptions = dropdownMenu.GetComponent<Dropdown>().options;

    //get the string value of the selected index
    string value = menuOptions[menuIndex].text;
    */
    public void SetStart()
    {
        
        MainManager.Instance.race = race;
        MainManager.Instance.@class = @class;
        MainManager.Instance.background = background;
        MainManager.Instance.player.setStartInput("bob", race, @class, background);


    }
    public void showRace()
    {
        Debug.Log("Race: " + MainManager.Instance.race);
        Debug.Log("Class: " + MainManager.Instance.@class);
        Debug.Log("Background: " + MainManager.Instance.background);
        Debug.Log("Name: " + MainManager.Instance.player.GetName());
        Debug.Log("Class: " + MainManager.Instance.player.GetClassName());
        Debug.Log("Race: " + MainManager.Instance.player.GetRace());
        Debug.Log("Background: " + MainManager.Instance.player.GetBackground());
    }
    public void SetPlayerStats()
    {
        MainManager.Instance.player.SetStats(10,10,10,10,10,10,level, 40, 14, 2, 30);
    }
    public void showStats()
    {
        Debug.Log("Str: " + MainManager.Instance.player.GetStrength());
        Debug.Log("dex: " + MainManager.Instance.player.GetDexterity());
        Debug.Log("wis: " + MainManager.Instance.player.GetWisdom());
        Debug.Log("con: " + MainManager.Instance.player.GetConstitution());
        Debug.Log("int: " + MainManager.Instance.player.GetIntelligence());
        Debug.Log("cha: " + MainManager.Instance.player.GetCharisma());
        Debug.Log("Level: " + MainManager.Instance.player.GetLevel());
        Debug.Log("HP: " + MainManager.Instance.player.GetCurrentHp());
        Debug.Log("AC: " + MainManager.Instance.player.GetArmorClass());
        Debug.Log("initiative: " + MainManager.Instance.player.GetInitiative());
        Debug.Log("speed: " + MainManager.Instance.player.GetMaxSpeed());

    }
    public void ShowPlayerFeats()
    {
        Debug.Log("Feats: " + MainManager.Instance.player.GetFeats()[0]);
    }
    public void ShowPlayerItem()
    {
        Debug.Log("Item: " + MainManager.Instance.player.GetEquipment()[0]);
    }

    public void ShowPlayerSpell()
    {
        Debug.Log("Item: " + MainManager.Instance.player.GetSpells()[0]);
    }


    public void HandleRaceData(int value)
    {
        if (value == 0)
        {
            RaceOutput.text = " ";
        }
        if (value == 1)
        {
            RaceOutput.text = "Dragonborn: \n\nStr: +2, Cha: +1, Speed: 30ft";
            race = "Dragonborn";
            temp = 1;
        }
        if (value == 2)
        {
            RaceOutput.text = "Dwarf: \n\nCon: +2, Speed: 25ft";
            race = "Dwarf";
            temp = 2;
        }
        if (value == 3)
        {
            RaceOutput.text = "Elf: \n\nDex: +2, Speed: 30ft";
            race = "Elf";
            temp = 3;
        }
        if (value == 4)
        {
            RaceOutput.text = "Gnome: \n\nInt: +2, Speed: 25ft";
            race = "Gnome";
            temp = 4;
        }
        if (value == 5)
        {
            RaceOutput.text = "Half-Elf: \n\nCha: +2, Dex: +1, Speed: 30ft";
            race = "Half-Elf";
            temp = 5;
        }
        if (value == 6)
        {
            RaceOutput.text = "Half-Orc: \n\nStr: +2, Con: +1, Speed: 30ft";
            race = "Half-Orc";
            temp = 6;
        }
        if (value == 7)
        {
            RaceOutput.text = "Halfling: \n\nDex: +2, Speed: 25ft";
            race = "Halfling";
            temp = 7;
        }
        if (value == 8)
        {
            RaceOutput.text = "Human: \n\nAll: +1, Speed: 30ft";
            race = "Human";
            temp = 8;
        }
        if (value == 9)
        {
            RaceOutput.text = "Tiefling: \n\nCha: +2, Speed: 30ft";
            race = "Tiefling";
            temp = 9;
        }
        UpdateSR(value);
        
    }

    public void UpdateSR(int val)
    {
        List<string> subRace = new List<string>();

        switch (val)
        {
            case 1: //Dragon Born
                subRace.Add("Black");
                subRace.Add("Blue");
                subRace.Add("Green");
                subRace.Add("Red");
                subRace.Add("White");
                break;
            case 2: //Dwarf
                subRace.Add("Hill Dwarf");
                subRace.Add("Mountain Dwarf");
                break;
            case 3: //Elf
                subRace.Add("Dark Elf");
                subRace.Add("High Elf");
                subRace.Add("Wood Elf");
                break;
            case 4: //Gnome
                subRace.Add("Forest Gnome");
                subRace.Add("Rock");
                break;
            case 5: //Half-Elf
                subRace.Add("Normal Half-Elf");
                break;
            case 6: //Half-Orc
                subRace.Add("Normal Half-Orc");
                break;
            case 7: //Halfling
                subRace.Add("Lightfoot halfling");
                subRace.Add("Stout Halfling");
                break;
            case 8: //Human
                subRace.Add("Normal");
                subRace.Add("Variant");
                break;
            case 9: //Tiefling
                subRace.Add("Normal");
                subRace.Add("Bloodline of Asmodeus");
                break;
        }

        DropDown2.ClearOptions();
        DropDown2.AddOptions(subRace);
    }



    public void HandleClassData(int value)
    {
        if (value == 0)
        {
            ClassOutput.text = " ";
        }
        if (value == 1)
        {
            @class = "Barbarian";
            ClassOutput.text = "Barbarian: Hit Dice: 1d12 per barbarian level"+
                "\nHit Points at Higher Levels: 1d12 (or 7) + your Constitution modifier per barbarian level after 1st"+
                "\nArmor: Light armor, medium armor, shields"+
                "\nWeapons: Simple weapons, martial weapons"+
                "\nSaving Throws: Strength, Constitution";
        }
        if (value == 2)
        {
            @class = "Bard";
            ClassOutput.text = "Bard: Hit Dice: 1d8 per bard level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per bard level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons,hand crossbows, longswords, rapiers, shortswords" +
                "\nSaving Throws: Dexterity, Charisma";
        }
        if (value == 3)
        {
            @class = "Cleric";
            ClassOutput.text = "Cleric: Hit Dice: 1d8 per cleric level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per cleric level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 4)
        {
            @class = "Druid";
            ClassOutput.text = "Druid: Hit Dice: 1d8 per druid level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per druid level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Intelligence";
        }
        if (value == 5)
        {
            @class = "Fighter";
            ClassOutput.text = "Fighter: Hit Dice: 1d10 per fighter level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per fighter level after 1st" +
                "\nArmor:  All armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Strength, Constitution";
        }
        if (value == 6)
        {
            @class = "Monk";
            ClassOutput.text = "Monk: Hit Dice: 1d8 per monk level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per monk level after 1st" +
                "\nArmor:  Nope" +
                "\nWeapons: Simple weapons, shortswords" +
                "\nSaving Throws: Strength, Dexterity";
        }
        if (value == 7)
        {
            @class = "Paladin";
            ClassOutput.text = "Paladin: Hit Dice: 1d10 per paladin level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per paladin level after 1st" +
                "\nArmor:  All armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 8)
        {
            @class = "Ranger";
            ClassOutput.text = "Ranger: Hit Dice: 1d10 per ranger level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per ranger level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Dexterity, Strength";
        }
        if (value == 9)
        {
            @class = "Rogue";
            ClassOutput.text = "Rogue: Hit Dice: 1d8 per rogue level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per rogue level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons,hand crossbows, longswords, rapiers, shortswords" +
                "\nSaving Throws: Dexterity, Intelligence";
        }
        if (value == 10)
        {
            @class = "Sorcerer";
            ClassOutput.text = "Sorcerer: Hit Dice: 1d6 per sorcerer level" +
                "\nHit Points at Higher Levels: 1d6 (or 4) + your Constitution modifier per sorcerer level after 1st" +
                "\nArmor: nope" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Constitution, Charisma";
        }
        if (value == 11)
        {
            @class = "Warlock";
            ClassOutput.text = "Warlock: Hit Dice: 1d8 per warlock level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per warlock level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 12)
        {
            @class = "Wizard";
            ClassOutput.text = "Wizard: Hit Dice: 1d6 per wizard level" +
                "\nHit Points at Higher Levels: 1d6 (or 4) + your Constitution modifier per wizard level after 1st" +
                "\nArmor: nope" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Intelligence, Wisdom";
        }
    }

    public void HandleLevelDropdown(int value)
    {
        //insert different data based on levels
        level = value + 1;
    }

    public void HandleFeatDropdown()
    {
        //Insert different cases for feat and data
        int pickedEntryIndex = dropdown.value;
        string selectedOptions = dropdown.options[pickedEntryIndex].text;
        FeatOutput.text = selectedOptions;
        //feats.Add(FeatOutput);
        MainManager.Instance.player.AddFeat(selectedOptions);

    }
    public void HandleItemDropdown()
    {
        int pickedEntryIndex = dropdown3.value;
        string selectedItems = dropdown3.options[pickedEntryIndex].text;
        MainManager.Instance.player.AddEquipment(selectedItems);
    }
    public void HandleSpellDropdown()
    {
        int pickedEntryIndex = dropdown4.value;
        string selectedItems = dropdown4.options[pickedEntryIndex].text;
        MainManager.Instance.player.AddSpells(selectedItems);
    }



    public void HandleBackroundData(int value)
    {
        switch (value)
        {
            case 0:
                BackroundOutput.text = " ";
                break;
            case 1:
                BackroundOutput.text = "Acolyte";
                background = "Acolyte";
                break;
            case 2:
                BackroundOutput.text = "Anthropologist";
                background = "Anthropologist";
                break;
            case 3:
                BackroundOutput.text = "Archaeologist";
                background = "Archaeologist";
                break;

            case 4:
                BackroundOutput.text = "Athlete";
                background = "Athlete";
                break;
            case 5:
                BackroundOutput.text = "Charlatan";
                background = "Charlatan";
                break;
            case 6:
                BackroundOutput.text = "City Watch";
                background = "City Watch";
                break;
            case 7:
                BackroundOutput.text = "Clan Crafter";
                background = "Clan Crafter";
                break;
            case 8:
                BackroundOutput.text = "Cloistered Scholar";
                background = "Cloistered Scholar";
                break;
            case 9:
                BackroundOutput.text = "Courtier";
                background = "Courtier";
                break;

            case 10:
                BackroundOutput.text = "Criminal";
                background = "Criminal";
                break;
            case 11:
                BackroundOutput.text = "Entertainer";
                background = "Entertainer";
                break;
            case 12:
                BackroundOutput.text = "Faceless";
                background = "Faceless";
                break;
            case 13:
                BackroundOutput.text = "Faction Agent";
                background = "Faction Agent";
                break;
            case 14:
                BackroundOutput.text = "Far Traveler";
                background = "Far Traveler";
                break;
            case 15:
                BackroundOutput.text = "Feylost";
                background = "Feylost";
                break;

            case 16:
                BackroundOutput.text = "Fisher";
                background = "Fisher";
                break;
            case 17:
                BackroundOutput.text = "Folk Hero";
                background = "Folk Hero";
                break;
            case 18:
                BackroundOutput.text = "Giant Foundling";
                background = "Giant Foundling";
                break;
            case 19:
                BackroundOutput.text = "Gladiator";
                background = "Gladiator";
                break;
            case 20:
                BackroundOutput.text = "Guild Artisan";
                background = "Guild Artisan";
                break;
            case 21:
                BackroundOutput.text = "Guild Merchant";
                background = "Guild Merchant";
                break;

            case 22:
                BackroundOutput.text = "Haunted One";
                background = "Haunted One";
                break;
            case 23:
                BackroundOutput.text = "Hermit";
                background = "Hermit";
                break;
            case 24:
                BackroundOutput.text = "House Agent";
                background = "House Agent";
                break;
            case 25:
                BackroundOutput.text = "Inheritor";
                background = "Inheritor";
                break;
            case 26:
                BackroundOutput.text = "Knight";
                background = "Knight";
                break;
            case 27:
                BackroundOutput.text = "Knight of the Order";
                background = "Knight of the Order";
                break;

            case 28:
                BackroundOutput.text = "Marine";
                background = "Marine";
                break;
            case 29:
                BackroundOutput.text = "Mercenary Veteran";
                background = "Mercenary Veteran";
                break;
            case 30:
                BackroundOutput.text = "Noble";
                background = "Noble";
                break;
            case 31:
                BackroundOutput.text = "Outlander";
                background = "Outlander";
                break;
            case 32:
                BackroundOutput.text = "Pirate";
                background = "Pirate";
                break;
            case 33:
                BackroundOutput.text = "Rewarded";
                background = "Rewarded";
                break;

            case 34:
                BackroundOutput.text = "Ruined";
                background = "Ruined";
                break;
            case 35:
                BackroundOutput.text = "Rune Carver";
                background = "Rune Carver";
                break;
            case 36:
                BackroundOutput.text = "Sage";
                background = "Sage";
                break;
            case 37:
                BackroundOutput.text = "Sailor";
                background = "Sailor";
                break;
            case 38:
                BackroundOutput.text = "Shipwright";
                background = "Shipwright";
                break;
            case 39:
                BackroundOutput.text = "Smuggler";
                background = "Smuggler";
                break;

            case 40:
                BackroundOutput.text = "Soldier";
                background = "Soldier";
                break;
            case 41:
                BackroundOutput.text = "Spy";
                background = "Spy";
                break;
        }
    }


}
