using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {

    public List<string> npcNames;
    public List<Sprite> npcImages;
    Dictionary<string, Sprite> npcMatcher;

    Image npcImage;
    Text npcName;
    Text npcText;

    public TextAsset data;
    public SortedDictionary<int, List<string>> dialogueData;

    int startPos = 1;
    const int listName = 1;
    const int listText = 2;

	// Use this for initialization
	void Start () {

        dialogueData = new SortedDictionary<int, List<string>>();
        npcMatcher = new Dictionary<string, Sprite>();
        CsvToDictionary(data.text);

        //Test();

        NpcMatherInit();

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

    void NpcMatherInit()
    {
        for (int i = 0; i < npcNames.Count; i++)
        {
            npcMatcher.Add(npcNames[i], npcImages[i]);
        }
    }

    void TextInit()
    {
        npcImage = transform.Find("Speaker Image").GetComponent<Image>();
        npcName = transform.Find("Dialogue Box/Speaker Name").GetComponent<Text>();
        npcText = transform.Find("Dialogue Box/Text").GetComponent<Text>();

        npcImage.sprite = npcMatcher[dialogueData[startPos][listName]];
        npcName.text = dialogueData[startPos][listName];
        npcText.text = dialogueData[startPos][listText];

    }

    void NextText()
    {
        startPos++;

        if (dialogueData.ContainsKey(startPos))
        {
            npcImage.sprite = npcMatcher[dialogueData[startPos][listName]];
            npcName.text = dialogueData[startPos][listName];
            npcText.text = dialogueData[startPos][listText];

        }
        
    }

}
