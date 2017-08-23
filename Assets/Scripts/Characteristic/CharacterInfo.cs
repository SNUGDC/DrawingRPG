using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {

    public List<Sprite> characterPortraitList;
    public Image portrait;
    public Text characterName;
    public Text characterLevel;
    public Text characterHP;
    public Text characterAtk;
    
    public void CharacterPortait(string charaName)
    {
        Debug.Log(charaName);
        if (charaName == "Roserian")
        {
            portrait.sprite = characterPortraitList[0];
        }
        else if (charaName == "Hesmen")
        {
            portrait.sprite = characterPortraitList[1];
        }
        else
            return;
    }

    
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
    
    public void SetCharacterStatus(PlayerInfoAndLevel player)
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
        

        if (player.characterName == "Roserian")
        {
            int atk = (int)((atkDefaultRoserian + (atkAdditionalRiseRoserian + atkWeightRoserian) * player.level) * (1 + (atkPercentageRiseRoserian + atkWeightRoserian) / 100.0f * player.level));
            int hp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * player.level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * player.level));
            int maxHp = (int)((hpDefaultRoserian + (hpAdditionalRiseRoserian + hpWeightRoserian) * player.level) * (1 + (hpPercentageRiseRoserian + hpWeightRoserian) / 100.0f * player.level));
            CharacterNameText(Player.CharacterName.Roserian);
            CharacterLevelText(player.level);
            CharacterATKText(atk);
            CharacterHPText(hp, maxHp);
            CharacterPortait(player.characterName);
        }
        if (player.characterName == "Hesmen")
        {
            int atk = (int)((atkDefaultHesmen + (atkAdditionalRiseHesmen + atkWeightHesmen) * player.level) * (1 + (atkPercentageRiseHesmen + atkWeightHesmen) / 100.0f * player.level));
            int hp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * player.level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * player.level));
            int maxHp = (int)((hpDefaultHesmen + (hpAdditionalRiseHesmen + hpWeightHesmen) * player.level) * (1 + (hpPercentageRiseHesmen + hpWeightHesmen) / 100.0f * player.level));
            CharacterNameText(Player.CharacterName.Hesmen);
            CharacterLevelText(player.level);
            CharacterATKText(atk);
            CharacterHPText(hp, maxHp);
            CharacterPortait(player.characterName);
        }
    }

    public void CharacterInfomation(PlayerInfoAndLevel character)
    {
            SetCharacterStatus(character);
    }
}
