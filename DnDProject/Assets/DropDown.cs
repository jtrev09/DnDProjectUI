using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public int temp;
    public DropDown DropDown1;
    public TMP_Dropdown DropDown2;
    string feat1 = "";
    string feat2 = "";
    string feat3 = "";
    string feat4 = "";
    string feat5 = "";

    public TextMeshProUGUI ClassOutput, RaceOutput, SubRaceOutput, BackroundOutput, FeatOutput, SpellOutput, ItemOutput;
    public void HandleRaceData(int value)
    {
        if (value == 0)
        {
            RaceOutput.text = " ";
        }
        if (value == 1)
        {
            RaceOutput.text = "Dragonborn: \n\nStr: +2, Cha: +1, Speed: 30ft";
            temp = 1;
        }
        if (value == 2)
        {
            RaceOutput.text = "Dwarf: \n\nCon: +2, Speed: 25ft";
            temp = 2;
        }
        if (value == 3)
        {
            RaceOutput.text = "Elf: \n\nDex: +2, Speed: 30ft";
            temp = 3;
        }
        if (value == 4)
        {
            RaceOutput.text = "Gnome: \n\nInt: +2, Speed: 25ft"; 
            temp = 4;
        }
        if (value == 5)
        {
            RaceOutput.text = "Half-Elf: \n\nCha: +2, Dex: +1, Speed: 30ft";
            temp = 5;
        }
        if (value == 6)
        {
            RaceOutput.text = "Half-Orc: \n\nStr: +2, Con: +1, Speed: 30ft";
            temp = 6;
        }
        if (value == 7)
        {
            RaceOutput.text = "Halfling: \n\nDex: +2, Speed: 25ft";
            temp = 7;
        }
        if (value == 8)
        {
            RaceOutput.text = "Human: \n\nAll: +1, Speed: 30ft";
            temp = 8;
        }
        if (value == 9)
        {
            RaceOutput.text = "Tiefling: \n\nCha: +2, Speed: 30ft";
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
            ClassOutput.text = "Barbarian: Hit Dice: 1d12 per barbarian level"+
                "\nHit Points at Higher Levels: 1d12 (or 7) + your Constitution modifier per barbarian level after 1st"+
                "\nArmor: Light armor, medium armor, shields"+
                "\nWeapons: Simple weapons, martial weapons"+
                "\nSaving Throws: Strength, Constitution";
        }
        if (value == 2)
        {
            ClassOutput.text = "Bard: Hit Dice: 1d8 per bard level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per bard level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons,hand crossbows, longswords, rapiers, shortswords" +
                "\nSaving Throws: Dexterity, Charisma";
        }
        if (value == 3)
        {
            ClassOutput.text = "Cleric: Hit Dice: 1d8 per cleric level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per cleric level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 4)
        {
            ClassOutput.text = "Druid: Hit Dice: 1d8 per druid level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per druid level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Intelligence";
        }
        if (value == 5)
        {
            ClassOutput.text = "Fighter: Hit Dice: 1d10 per fighter level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per fighter level after 1st" +
                "\nArmor:  All armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Strength, Constitution";
        }
        if (value == 6)
        {
            ClassOutput.text = "Monk: Hit Dice: 1d8 per monk level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per monk level after 1st" +
                "\nArmor:  Nope" +
                "\nWeapons: Simple weapons, shortswords" +
                "\nSaving Throws: Strength, Dexterity";
        }
        if (value == 7)
        {
            ClassOutput.text = "Paladin: Hit Dice: 1d10 per paladin level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per paladin level after 1st" +
                "\nArmor:  All armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 8)
        {
            ClassOutput.text = "Ranger: Hit Dice: 1d10 per ranger level" +
                "\nHit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per ranger level after 1st" +
                "\nArmor: Light armor, medium armor, shields" +
                "\nWeapons: Simple weapons, martial weapons" +
                "\nSaving Throws: Dexterity, Strength";
        }
        if (value == 9)
        {
            ClassOutput.text = "Rogue: Hit Dice: 1d8 per rogue level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per rogue level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons,hand crossbows, longswords, rapiers, shortswords" +
                "\nSaving Throws: Dexterity, Intelligence";
        }
        if (value == 10)
        {
            ClassOutput.text = "Sorcerer: Hit Dice: 1d6 per sorcerer level" +
                "\nHit Points at Higher Levels: 1d6 (or 4) + your Constitution modifier per sorcerer level after 1st" +
                "\nArmor: nope" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Constitution, Charisma";
        }
        if (value == 11)
        {
            ClassOutput.text = "Warlock: Hit Dice: 1d8 per warlock level" +
                "\nHit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per warlock level after 1st" +
                "\nArmor: Light armor" +
                "\nWeapons: Simple weapons" +
                "\nSaving Throws: Wisdom, Charisma";
        }
        if (value == 12)
        {
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
    }

    public void HandleFeatDropdown(int val)
    {
        //Insert different cases for feat and data
        if (val == 0)
        {
            FeatOutput.text = "Alert: " +
                "\n Gain a +5 bonus to initiative." +
                "\n Can’t be surprised while conscious." +
                "\n Other creatures don’t gain advantage on attack rolls against you as a result of being hidden from you.";
        }
        if (val == 1)
        {
            FeatOutput.text = "Athlete: " +
                "\n Increase your Strength or Dexterity score by 1, to a maximum of 20." +
                "\n Standing up from prone uses only 5 feet of movement." +
                "\n Climbing doesn’t halve your speed." +
                "\n Can make a running long jump or a running high jump after moving only 5 feet on foot.";
        }
        if (val == 2)
        {
            FeatOutput.text = "Actor: " +
                "\n Increase your Charisma score by 1, to a maximum of 20." +
                "\n Have advantage on Charisma (Deception) and Charisma (Performance) checks when trying to pass yourself off as a different person." +
                "\n Can mimic the speech of another person or the sounds made by other creatures.";
        }
        if (val == 3)
        {
            FeatOutput.text = "Crossbow Expert: " +
                "\n You ignore the loading quality of crossbow s with which you are proficient." +
                "\n Being within 5 feet of a hostile creature doesn’t impose disadvantage on your ranged attack rolls." +
                "\n When you use the Attack action and attack with a one handed weapon, you can use a bonus action to attack with a loaded hand crossbow you are holding.";
        }
        if (val == 4)
        {
            FeatOutput.text = "Defensive Duelist" +
                "\n When you are wielding a finesse weapon with which you are proficient and another creature hits you with a melee attack, you can use your reaction to add your proficiency bonus to your AC for that attack, potentially causing the attack to miss you.";
        }
        if (val == 5)
        {
            FeatOutput.text = "Dual Wielder" +
                "\n You gain a +1 bonus to AC while you are wielding a separate melee weapon in each hand.";
        }
        if (val == 6)
        {
            FeatOutput.text = "Durable" +
                "\n Increase constitution by 1";
        }
        if (val == 7)
        {
            FeatOutput.text = "Elemental Adept" +
                "\n choose one o f the following damage types: acid, cold, fire, lightning, or thunder. Spells you cast ignore resistance to damage of the chosen type.";
        }
        if (val == 8)
        {
            FeatOutput.text = "Great Weapon Master" +
                "\n On your turn, when you score a critical hit with a melee weapon or reduce a creature to 0 hit points with one, you can make one melee weapon attack as abonus action." +
                "\n you can choose to take a - 5 penalty to the attack roll. If the attack hits, you add +10 to the attack’s damage." ;
        }
        if (val == 9)
        {
            FeatOutput.text = "Mobile" +
                "\n Speed increases by 10ft" +
                "\n Difficult terrain doesn't cost extra movement";
        }

    }

    public void HandleSpellDraopdown()
    {
        //Insert different cases for feat and data
        int pickedEntryIndex = dropdown.value;
        string selectedOptions = dropdown.options[pickedEntryIndex].text;
        FeatOutput.text = selectedOptions;

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
                break;
            case 2:
                BackroundOutput.text = "Anthropologist";
                break;
            case 3:
                BackroundOutput.text = "Archaeologist";
                break;

            case 4:
                BackroundOutput.text = "Athlete";
                break;
            case 5:
                BackroundOutput.text = "Charlatan";
                break;
            case 6:
                BackroundOutput.text = "City Watch";
                break;
            case 7:
                BackroundOutput.text = "Clan Crafter";
                break;
            case 8:
                BackroundOutput.text = "Cloistered Scholar";
                break;
            case 9:
                BackroundOutput.text = "Courtier";
                break;

            case 10:
                BackroundOutput.text = "Criminal";
                break;
            case 11:
                BackroundOutput.text = "Entertainer";
                break;
            case 12:
                BackroundOutput.text = "Faceless";
                break;
            case 13:
                BackroundOutput.text = "Faction Agent";
                break;
            case 14:
                BackroundOutput.text = "Far Traveler";
                break;
            case 15:
                BackroundOutput.text = "Feylost";
                break;

            case 16:
                BackroundOutput.text = "Fisher";
                break;
            case 17:
                BackroundOutput.text = "Folk Hero";
                break;
            case 18:
                BackroundOutput.text = "Giant Foundling";
                break;
            case 19:
                BackroundOutput.text = "Gladiator";
                break;
            case 20:
                BackroundOutput.text = "Guild Artisan";
                break;
            case 21:
                BackroundOutput.text = "Guild Merchant";
                break;

            case 22:
                BackroundOutput.text = "Haunted One";
                break;
            case 23:
                BackroundOutput.text = "Hermit";
                break;
            case 24:
                BackroundOutput.text = "House Agent";
                break;
            case 25:
                BackroundOutput.text = "Inheritor";
                break;
            case 26:
                BackroundOutput.text = "Knight";
                break;
            case 27:
                BackroundOutput.text = "Knight of the Order";
                break;

            case 28:
                BackroundOutput.text = "Marine";
                break;
            case 29:
                BackroundOutput.text = "Mercenary Veteran";
                break;
            case 30:
                BackroundOutput.text = "Noble";
                break;
            case 31:
                BackroundOutput.text = "Outlander";
                break;
            case 32:
                BackroundOutput.text = "Pirate";
                break;
            case 33:
                BackroundOutput.text = "Rewarded";
                break;

            case 34:
                BackroundOutput.text = "Ruined";
                break;
            case 35:
                BackroundOutput.text = "Rune Carver";
                break;
            case 36:
                BackroundOutput.text = "Sage";
                break;
            case 37:
                BackroundOutput.text = "Sailor";
                break;
            case 38:
                BackroundOutput.text = "Shipwright";
                break;
            case 39:
                BackroundOutput.text = "Smuggler";
                break;

            case 40:
                BackroundOutput.text = "Soldier";
                break;
            case 41:
                BackroundOutput.text = "Spy";
                break;
        }
    }


}
