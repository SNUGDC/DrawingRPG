using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum CharacterName { Roserian, Hesmen };

    public int speed;

    public int levelRoserian;
    public int levelHesmen;

    public int maxHp;
    public double atk;
    public double hp;
    public int def;

    public Element element;
    public CharacterName characterName;
    public Sprite portrait;

    private Skill skill;

    private void Start()
    {
        levelHesmen = PlayerPrefs.GetInt("levelHesmen");
        levelRoserian = PlayerPrefs.GetInt("levelRoserian");
        SetCharacterStatus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            levelHesmen++;
            PlayerPrefs.SetInt("levelHesmen", levelHesmen);
            SetCharacterStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            levelHesmen--;
            PlayerPrefs.SetInt("levelHesmen", levelHesmen);
            SetCharacterStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            levelRoserian++;
            PlayerPrefs.SetInt("levelRoserian", levelRoserian);
            SetCharacterStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            levelRoserian--;
            PlayerPrefs.SetInt("levelRoserian", levelRoserian);
            SetCharacterStatus();
        }
    }

    public void SetCharacterStatus()
    {
        int atkDefaultRoserian = 20;
        int atkWeightRoserian = 4;
        int atkAdditionalRiseRoserian = 6;
        int atkPercentageRiseRoserian = 3;

        int hpDefaultRoserian = 80;
        int hpWeightRoserian = -1;
        int hpAdditionalRiseRoserian = 10;
        int hpPercentageRiseRoserian = 5;

        int atkDefaultHesmen = 15;
        int atkWeightHesmen = -1;
        int atkAdditionalRiseHesmen = 6;
        int atkPercentageRiseHesmen = 3;

        int hpDefaultHesmen = 100;
        int hpWeightHesmen = 3;
        int hpAdditionalRiseHesmen = 10;
        int hpPercentageRiseHesmen = 5;

        if (this.characterName == CharacterName.Roserian)
        {
            atk = (int)((atkDefaultRoserian + (atkAdditionalRiseRoserian + atkWeightRoserian) * levelRoserian) * (1 + (atkPercentageRiseRoserian + atkWeightRoserian) / 100.0f * levelRoserian));
            hp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * levelRoserian) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * levelRoserian));
            maxHp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * levelRoserian) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * levelRoserian));
            skill.Use(this);
        }
        if (this.characterName == CharacterName.Hesmen)
        {
            atk = (int)((atkDefaultHesmen + (atkAdditionalRiseHesmen + atkWeightHesmen) * levelHesmen) * (1 + (atkPercentageRiseHesmen + atkWeightHesmen) / 100.0f * levelHesmen));
            hp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * levelHesmen) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * levelHesmen));
            maxHp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * levelHesmen) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * levelHesmen));
        }
    }
}