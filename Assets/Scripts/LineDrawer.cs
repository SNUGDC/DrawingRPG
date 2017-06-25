using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
	public GameObject LineEnd;
	public GameObject Line;
	public int maxLineNum;


	public GameObject[] myLine;
	private GameObject Player;
	private GameObject nowLine;
	private Vector2 mousePos;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isInControlMode;

	private void Start()
	{
		isInControlMode = false;
		myLine = new GameObject[maxLineNum];

		if(myLine[0] == null)
		{
			Player = GameObject.Find("Player");
			transform.position = Player.transform.position;
		}
	}

	private void Update()
	{
		if(isInControlMode == true)
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = mousePos;
			ControlLine(nowLine);
		}
	}

	private void OnMouseDown()
	{
		if(NewLineNum() == null)
			return;

		Debug.Log("조작모드 시작");
		isInControlMode = true;
		startPos = transform.position;
		Instantiate(LineEnd, transform.position, Quaternion.identity);
		nowLine = CreateLine();
	}

	private void OnMouseUp()
	{
		if(isInControlMode == true)
		{
			Debug.Log("조작모드 끝");
			isInControlMode = false;
			myLine[NewLineNum().Value] = nowLine;
			Instantiate(LineEnd, mousePos, Quaternion.identity);
		}
	}

	private GameObject CreateLine()
	{
		if(NewLineNum() == null)
			return null;
		GameObject ControlLine = Instantiate(Line);
		return ControlLine;
	}

	private void ControlLine(GameObject Line)
	{
		if(Line == null)
			return;

		endPos = mousePos;
		Vector2 midPos = (startPos + endPos) / 2;

		Line.transform.position = midPos;
		Line.transform.localScale = new Vector2 (Vector2.Distance(startPos, endPos), 1);
		Line.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan((endPos.y - startPos.y) / (endPos.x - startPos.x)));
	}

	private int? NewLineNum()
	{
		for(int num = 0; num < maxLineNum; num++)
		{
			if(myLine[num] == null)
			{
				return num;
			}
		}

		Debug.Log("Can't Create More Line");
		return null;
	}
}