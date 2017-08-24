using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public Image roserianImage;
    public Image hesmenImage;
    public Image roserianBackground;
    public Image hesmenBackground;
    public Text roserianName;
    public Text hesmenName;
    public Text npcText;

    public TextAsset data;
    public SortedDictionary<int, List<string>> dialogueData;

    int currentId = 1;
    const int commandId = 9999;
    const int listName = 1;
    const int listFileName = 2;
    const int listText = 3;
    const int listCommandNum = 1;
    const int listSceneNum = 2;

    // Use this for initialization
    void Start()
    {
        dialogueData = new SortedDictionary<int, List<string>>();
        CsvToDictionary(data.text);

        // Test();

        ShowDialogue();
    }

    public void CsvToDictionary(string data)
    {
        fgCSVReader.LoadFromString(data, DictionaryDelegate);
    }

    //Debug Section
    #region
    void Test()
    {
        foreach (var entry in dialogueData)
        {
            Debug.Log("Key is " + entry.Key);
            ShowContent(entry.Value);
        }
    }

    void ShowContent(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
    #endregion

    void DictionaryDelegate(int lineNumber, List<string> line)
    {
        Debug.Log("Linenumber " + lineNumber);
        if (lineNumber == 0)
        {
            return;
        }
        for (int i = 0; i < line.Count; i++)
        {
            int id = int.Parse(line[0]);
            if (i == 0)
            {
                List<string> lines = new List<string>();
                dialogueData.Add(id, lines);
            }
            dialogueData[id].Add(line[i]);
        }
    }

    void ShowDialogue()
    {
        string characterName = dialogueData[currentId][listFileName];
        if (characterName == "roserian")
        {
            roserianImage.enabled = true;
            hesmenImage.enabled = false;
            roserianName.text = dialogueData[currentId][listName];
            hesmenName.text = "";
            roserianBackground.enabled = true;
            hesmenBackground.enabled = false;
        }
        else if (characterName == "hesmen")
        {
            hesmenImage.enabled = true;
            roserianImage.enabled = false;
            hesmenName.text = dialogueData[currentId][listName];
            roserianName.text = "";
            roserianBackground.enabled = false;
            hesmenBackground.enabled = true;
        }
        else
        {
            hesmenImage.enabled = false;
            roserianImage.enabled = false;
            hesmenName.text = dialogueData[currentId][listName];
            roserianName.text = "";
            roserianBackground.enabled = false;
            hesmenBackground.enabled = true;
        }
        npcText.text = dialogueData[currentId][listText];
    }

    void NextText()
    {
        currentId++;

        if (dialogueData.ContainsKey(currentId))
        {
            ShowDialogue();
        }
        else
        {
            string command = dialogueData[commandId][listCommandNum];
            if (command == "stage")
            {
                int sceneNum = int.Parse(dialogueData[commandId][listSceneNum]);
                SceneLoader.LoadStage(sceneNum);
            }
            else if (command == "stageselect")
            {
                SceneLoader.LoadScene("Stage_Select");
            }
            else
            {
                Debug.LogError("Invalid command " + command);
            }
        }
    }

    private Sprite GetSprite(string fileName)
    {
        return Resources.Load<Sprite>("standing/" + fileName);
    }
}
