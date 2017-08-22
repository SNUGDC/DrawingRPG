using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

    // --------------씬 전환 Button--------------//
    public void MainMenuScene()
    {
        SceneLoader.LoadScene_using_string("Main_Menu");
    }
    public void OptionScene()
    {
        SceneLoader.LoadScene_using_string("Option");
    }
    public void StageSelectScene()
    {
        SceneLoader.LoadScene_using_string("Stage_Select");
    }
    public void CharacteristicScene()
    {
        SceneLoader.LoadScene_using_string("Characteristic");
    }
    public void StageScene(int stage)
    {
        SceneLoader.LoadStage(stage);
    }
    public void CreditsScene()
    {
        SceneLoader.LoadScene_using_string("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OnClearAllButtonClick()
    {
        SaveManager.ClearAllStage();
        StageSelectScene();
    }
    public void OnLockAllButtonClick()
    {
        SaveManager.ResetSave();
        StageSelectScene();
    }

 
    // --------------게임 내 상태 조작 Button------------//
   
    //라인 그리고 난 후 스타트
    public void OnClickStartGame()
    {
        //GameObject.Find("UIManager").GetComponent<UIManager>().InactiveInitialUI();
        GameObject.Find("UIManager").GetComponent<UIManager>().OnStartButtonClick();
    }

    // --------------특성창 Button--------------//
    public void CharacterChooseButton(string charaName)
    {
        PlayerInfoAndLevel playerInfo = new PlayerInfoAndLevel();
        playerInfo = playerInfo.FindPlayerInfoAndLevel(charaName);
        playerInfo.gameObject.SetActive(true);
        CharacterInfo characterInfo = GameObject.FindObjectOfType<CharacterInfo>();
        characterInfo.CharacterInfomation(playerInfo);
    }

    public void OpenDetailCharacteristicInfo(CharaSkillInfo charaSkillInfo)
    {
            GameObject DetailPanel = GameObject.Find("Canvas").transform.Find("DetailPanel").gameObject;
            DetailPanel.SetActive(true);
            DetailPanel.GetComponent<CharaDetailPanel>().SkillDetail(charaSkillInfo);
        
    }

    public void CloseDetailCharacteristicInfo()
    {
        GameObject DetailPanel = GameObject.Find("Canvas").transform.Find("DetailPanel").gameObject;
        DetailPanel.SetActive(false);
    }

    public void SkillLevelUp(CharaDetailPanel charaInfoDetail)
    {
        charaInfoDetail.SkillLevelUp();
    }

    public void SkillLevelDown(CharaDetailPanel charaInfoDetail)
    {
        charaInfoDetail.SkillLevelDown();
    }
    
    public void Test(UnityEngine.UI.Text text)
    {
        text.text = PlayerPrefs.GetInt("TestSkill").ToString();
    }
}
