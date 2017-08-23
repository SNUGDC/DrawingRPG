using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    Image npcImage;
    Text npcName;
    Text npcText;

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

        Test();

        TextInit();
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

    void TextInit()
    {
        npcImage = transform.Find("Speaker Image").GetComponent<Image>();
        npcName = transform.Find("Dialogue Box/Speaker Name").GetComponent<Text>();
        npcText = transform.Find("Dialogue Box/Text").GetComponent<Text>();

        npcImage.sprite = GetSprite(dialogueData[currentId][listFileName]);
        npcName.text = dialogueData[currentId][listName];
        npcText.text = dialogueData[currentId][listText];

    }

    void NextText()
    {
        currentId++;

        if (dialogueData.ContainsKey(currentId))
        {
            npcImage.sprite = GetSprite(dialogueData[currentId][listFileName]);
            npcName.text = dialogueData[currentId][listName];
            npcText.text = dialogueData[currentId][listText];
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
