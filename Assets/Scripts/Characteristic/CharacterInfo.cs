using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {

    public Text characterName;
    public Text characterLevel;
    public Text characterHP;
    public Text characterAtk;

    public void CharacterNameText(Player.CharacterName charaName)
    {
        characterName.text = charaName.ToString();
    }

    public void CharacterLevelText(int level)
    {
        characterLevel.text = "Lv. " + level;
    }

    public void CharacterHPText(float hp, float maxhp)
    {
        characterHP.text = "HP " + (int)hp + "/" + (int)maxhp;
    }

    public void CharacterATKText(float atk)
    {
        characterAtk.text = "ATK " + (int)atk;
    }

    public void SetCharacterStatus(Player player, int level)
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
        

        if (player.characterName == Player.CharacterName.Roserian)
        {
            int atk = (int)((atkDefaultRoserian + (atkAdditionalRiseRoserian + atkWeightRoserian) * level) * (1 + (atkPercentageRiseRoserian + atkWeightRoserian) / 100.0f * level));
            int hp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * level));
            int maxHp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * level));
            CharacterNameText(Player.CharacterName.Roserian);
            CharacterLevelText(level);
            CharacterATKText(atk);
            CharacterHPText(hp, maxHp);
        }
        if (player.characterName == Player.CharacterName.Hesmen)
        {
            int atk = (int)((atkDefaultHesmen + (atkAdditionalRiseHesmen + atkWeightHesmen) * level) * (1 + (atkPercentageRiseHesmen + atkWeightHesmen) / 100.0f * level));
            int hp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * level));
            int maxHp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * level));
            CharacterNameText(Player.CharacterName.Hesmen);
            CharacterLevelText(level);
            CharacterATKText(atk);
            CharacterHPText(hp, maxHp);
        }
    }
    public void CharacterInfomation(Player character)
    {
        if (character.characterName.ToString() == "Roserian")
        {
            SetCharacterStatus(character, character.levelRoserian);
        }
        else if (character.characterName.ToString() == "Hesmen")
        {
            SetCharacterStatus(character, character.levelHesmen);
        }
    }
}
