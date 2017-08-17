using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum CharacterName { Roserian, Hasmen };

    public int speed;

    public int level;
    public int maxHp;

    public int atk;
    public int hp;
    public int def;

    public Element element;
    public CharacterName characterName;
    public Sprite portrait;

    public void Start()
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
            atk = (int)((atkDefaultRoserian + (atkAdditionalRiseRoserian + atkWeightRoserian) * level) * (1 + (atkPercentageRiseRoserian + atkWeightRoserian) / 100.0f * level));
            hp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * level));
            maxHp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * level));
        }
        if (this.characterName == CharacterName.Hasmen)
        {
            atk = (int)((atkDefaultHesmen + (atkAdditionalRiseHesmen + atkWeightHesmen) * level) * (1 + (atkPercentageRiseHesmen + atkWeightHesmen) / 100.0f * level));
            hp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * level));
            maxHp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * level));
        }
    }
}
