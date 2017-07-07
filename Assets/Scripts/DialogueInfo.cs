using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInfo
{
	public Sprite speakerImage;
	public string speakerName;
	public string dialogueText;

	public DialogueInfo(Sprite speakerImage, string speakerName, string dialogueText)
    {
        this.speakerImage = speakerImage;
		this.speakerName = speakerName;
		this.dialogueText = dialogueText;
    }
}