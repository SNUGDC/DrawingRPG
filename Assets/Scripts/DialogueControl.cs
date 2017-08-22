using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    public List<string> npcNames;
    public List<Sprite> npcImages;

    Image npcImage;
    Text npcName;
    Text npcText;

    public TextAsset data;
    public SortedDictionary<int, List<string>> dialogueData;

    int startPos = 1;
    const int listName = 1;
    const int listFileName = 2;
    const int listText = 3;

    // Use this for initialization
    void Start()
    {

        dialogueData = new SortedDictionary<int, List<string>>();
        CsvToDictionary(data.text);

        //Test();

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
        for (int i = 1; i < dialogueData.Count; i++)
        {
            Debug.Log(i.ToString() + " ");
            ShowContent(dialogueData[i]);
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

    void DictionaryDelegate(int index, List<string> line)
    {

        if (index == 0)
        {
            return;
        }
        for (int i = 0; i < line.Count; i++)
        {

            if (i == 0)
            {
                List<string> lines = new List<string>();
                dialogueData.Add(index, lines);
            }
            dialogueData[index].Add(line[i]);

        }
    }

    void TextInit()
    {
        npcImage = transform.Find("Speaker Image").GetComponent<Image>();
        npcName = transform.Find("Dialogue Box/Speaker Name").GetComponent<Text>();
        npcText = transform.Find("Dialogue Box/Text").GetComponent<Text>();

        npcImage.sprite = GetSprite(dialogueData[startPos][listFileName]);
        npcName.text = dialogueData[startPos][listName];
        npcText.text = dialogueData[startPos][listText];

    }

    void NextText()
    {
        startPos++;

        if (dialogueData.ContainsKey(startPos))
        {
            npcImage.sprite = GetSprite(dialogueData[startPos][listFileName]);
            npcName.text = dialogueData[startPos][listName];
            npcText.text = dialogueData[startPos][listText];
        }
    }

    private Sprite GetSprite(string fileName)
    {
        return Resources.Load<Sprite>("standing/" + fileName);
    }
}
