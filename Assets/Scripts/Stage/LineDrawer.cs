using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
	public GameObject LineEnd;
	public GameObject Line;
	public int maxLineNum;
	public float maxLineLength;
	public GameObject[] myLine;
    public int this_num = 0;

	private GameObject Player;
	private GameObject nowLine;
	private Vector2 mousePos;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isInControlMode;
    private List<Enemy> allEncountedEnemyList = new List<Enemy>();
    

    public void Delete_Line()
    {
        if (myLine[0] != null && myLine[maxLineNum-1] ==null)
        {
            Debug.Log("Delete_Done");
            this_num--;
            transform.position = 2 * myLine[NewLineNum().Value - 1].transform.position - transform.position;
            Destroy(myLine[NewLineNum().Value - 1]);
            myLine[NewLineNum().Value - 1] = null;
        }
        else if(myLine[maxLineNum-1] != null)
        {
            Debug.Log("null");
            this_num--;
            transform.position = 2 * myLine[maxLineNum-1].transform.position - transform.position;
            Destroy(myLine[maxLineNum-1]);
            myLine[maxLineNum-1] = null;

        }
    }
	private void Start()
	{
		isInControlMode = false;
		myLine = new GameObject[maxLineNum];
        allEncountedEnemyList.Clear();

        if (myLine[0] == null)
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
			transform.position = endPos;
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
        RaycastTester raycastTester = gameObject.GetComponent<RaycastTester>();
        raycastTester.startPos = startPos;
        nowLine = CreateLine();
	}

	private void OnMouseUp()
	{
		if(isInControlMode == true)
		{
            this_num++;
			Debug.Log("조작모드 끝");
            Debug.Log(NewLineNum().Value);
			isInControlMode = false;
            myLine[NewLineNum().Value] = nowLine;
            
            nowLine.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);

            Enemy encounteredEnemy = EncountEnemy();
            Player.GetComponent<PlayerMover>().moveToGoal.Add(new MoveToGoal(endPos, encounteredEnemy));

            if (encounteredEnemy != null)
            {
                allEncountedEnemyList.Add(encounteredEnemy);
            }
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
        if (Line == null)
        {
            return;
        }
		float lineLength;

		lineLength = Vector2.Distance(startPos, mousePos);
        if (EncountEnemyPosition() != null)
        {
            lineLength = Vector2.Distance(EncountEnemyPosition().Value, startPos);
            endPos = EncountEnemyPosition().Value;
            Line.GetComponent<SpriteRenderer>().color = new Color(1, 0.2f, 0.2f, 1);
        }
        else if(lineLength > maxLineLength)
		{
			lineLength = maxLineLength;
			endPos = startPos + (mousePos - startPos).normalized * maxLineLength;
			Line.GetComponent<SpriteRenderer>().color = new Color (1, 0.2f, 0.2f, 1);
		}
        else
		{
			nowLine.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
			endPos = mousePos;
		}

		Line.transform.position = (startPos + endPos) / 2;
		Line.transform.localScale = new Vector2 (Vector2.Distance(startPos, endPos), 1);
		Line.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan((endPos.y - startPos.y) / (endPos.x - startPos.x)));
	}

    private Vector2? EncountEnemyPosition()
    {
        RaycastTester raycastTester = gameObject.GetComponent<RaycastTester>();

        return raycastTester.GetNeariestEnemyPosition(ignoreList: allEncountedEnemyList);
    }

    private Enemy EncountEnemy()
    {
        RaycastTester raycastTester = gameObject.GetComponent<RaycastTester>();

        return raycastTester.GetNeariestEnemy(ignoreList: allEncountedEnemyList);
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