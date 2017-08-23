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
    public int experiencePointRoserian;
    public int experiencePointHesmen;

    public int gainedExperiencePoint;
    public float maxHp;
    public float atk;
    public float hp;

    public Element element;
    public CharacterName characterName;
    public Sprite portrait;

    public Skill skill;
    
    private void Start()
    {
        levelHesmen = PlayerPrefs.GetInt("levelHesmen");
        levelRoserian = PlayerPrefs.GetInt("levelRoserian");
        experiencePointRoserian = PlayerPrefs.GetInt("experiencePointRoserian");
        experiencePointHesmen = PlayerPrefs.GetInt("experiencePointHesmen");
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

    public void LevelAndExperiencePointUp()
    {

        if (this.characterName == CharacterName.Roserian)
        {
            Dictionary<string, int> levelAndExperiencePoint;
            levelAndExperiencePoint = ExperiencePoint.CalculateExperiencePoint(levelRoserian, experiencePointRoserian, gainedExperiencePoint);
            gainedExperiencePoint = 0;
            levelRoserian = levelAndExperiencePoint["Level"];
            experiencePointRoserian = levelAndExperiencePoint["ExperiencePoint"];
        }
        if (this.characterName == CharacterName.Hesmen)
        {
            Dictionary<string, int> levelAndExperiencePoint;
            levelAndExperiencePoint = ExperiencePoint.CalculateExperiencePoint(levelHesmen, experiencePointHesmen, gainedExperiencePoint);
            gainedExperiencePoint = 0;
            levelHesmen = levelAndExperiencePoint["Level"];
            experiencePointHesmen = levelAndExperiencePoint["ExperiencePoint"];
        }
        PlayerPrefs.SetInt("levelHesmen", levelHesmen);
        PlayerPrefs.SetInt("levelRoserian", levelRoserian);
        PlayerPrefs.SetInt("experiencePointRoserian", experiencePointRoserian);
        PlayerPrefs.SetInt("experiencePointHesmen", experiencePointHesmen);

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
            skill = new Strike();
            skill.Use(this);
        }
        if (this.characterName == CharacterName.Hesmen)
        {
            atk = (int)((atkDefaultHesmen + (atkAdditionalRiseHesmen + atkWeightHesmen) * levelHesmen) * (1 + (atkPercentageRiseHesmen + atkWeightHesmen) / 100.0f * levelHesmen));
            hp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * levelHesmen) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * levelHesmen));
            maxHp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * levelHesmen) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * levelHesmen));
            skill = new EnhanceHealth();
            skill.Use(this);
        }
    }
}