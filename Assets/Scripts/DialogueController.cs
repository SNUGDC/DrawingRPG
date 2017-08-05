using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
	public Image SpeakerImage;
	public Text SpeakerName;
	public Text DialogueText;
	public List<DialogueInfo> dialogueInfo = new List<DialogueInfo>();

	public Sprite[] Image;
	public string[] Name;
	public string[] Text;

	private bool shouldIUpdateDialogue;

	private void Start()
	{
		Debug.Log("HI");
		shouldIUpdateDialogue = true;

		dialogueInfo.Add(new DialogueInfo(Image[0], Name[0], Text[0]));
		dialogueInfo.Add(new DialogueInfo(Image[1], Name[1], Text[1]));
		dialogueInfo.Add(new DialogueInfo(Image[2], Name[2], Text[2]));
		dialogueInfo.Add(new DialogueInfo(Image[1], Name[1], Text[3]));
		dialogueInfo.Add(new DialogueInfo(Image[0], Name[0], Text[4]));
		dialogueInfo.Add(new DialogueInfo(Image[2], Name[2], Text[5]));
		dialogueInfo.Add(new DialogueInfo(Image[1], Name[1], Text[6]));
		dialogueInfo.Add(new DialogueInfo(Image[0], Name[0], Text[7]));
		dialogueInfo.Add(new DialogueInfo(Image[0], Name[0], Text[8]));
	}

	private void Update()
	{
		if(shouldIUpdateDialogue == true)
		{
			UpdateDialogue();
		}
	}

	private void UpdateDialogue()
	{
		SpeakerImage.sprite = dialogueInfo[0].speakerImage;
		SpeakerImage.SetNativeSize(); //원본 사이즈로 조절
		SpeakerName.text = dialogueInfo[0].speakerName;
		DialogueText.text = dialogueInfo[0].dialogueText;

		shouldIUpdateDialogue = false;

		dialogueInfo.RemoveAt(0);
	}

	public void NextDialogue()
	{
		shouldIUpdateDialogue = true;
	}
}