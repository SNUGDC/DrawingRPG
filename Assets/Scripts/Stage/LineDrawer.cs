using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject max_line;
    public GameObject Line_text;
	public GameObject LineEnd;
	public GameObject Line;
	public float maxLineLength;
	public List<GameObject> myLine = new List<GameObject>();

    public int used_line_count = 0;

	public GameObject Player;
    public GameObject Player_Line;
	private GameObject nowLine;
	private Vector2 mousePos;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isInControlMode;

    public List<Vector2> player_passed_position = new List<Vector2>(); 
    private List<Enemy> allEncountedEnemyList = new List<Enemy>();
    

    public void Delete_Line()
    {
        Debug.Log("Delete_Done");
        if (used_line_count <= 0)
            return;

        used_line_count--;
        player_passed_position.RemoveAt(player_passed_position.Count - 1);
        Player.GetComponent<Player>().Lines.RemoveAt(Player.GetComponent<Player>().Lines.Count - 1);
        transform.position = player_passed_position[player_passed_position.Count-1];
        Destroy(myLine[myLine.Count -1]);
        myLine.RemoveAt(myLine.Count - 1);

/*        if (myLine[0] != null && myLine[max_line.GetComponent<MaxLine_Turn>().Max_Line-1] ==null)
        {
            myLine[NewLineNum().Value - 1] = null;
        }
        else if(myLine[max_line.GetComponent<MaxLine_Turn>().Max_Line-1] != null)
        {
            
            myLine[max_line.GetComponent<MaxLine_Turn>().Max_Line-1] = null;

        }*/
    }

	private void Start()
	{
		isInControlMode = false;
		//myLine = new GameObject[max_line.GetComponent<MaxLine_Turn>().Max_Line];
        allEncountedEnemyList.Clear();
        //if (myLine[0] == null)
        /*if (myLine.Count == 0)    
		{
			Player = GameObject.Find("Player");
			transform.position = Player.transform.position;
		}*/
        transform.position = Player.transform.position;
        player_passed_position.Add(transform.position);
        Player.GetComponent<Player>().Lines.Add(transform.position);
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
		//if(NewLineNum() == null)
			//return;
        if (used_line_count >= max_line.GetComponent<MaxLine_Turn>().Max_Line)
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
            player_passed_position.Add(transform.position);
            Player.GetComponent<Player>().Lines.Add(transform.position);
            used_line_count++;
            Line_and_Turn_count.Line_Counting(this, max_line.GetComponent<MaxLine_Turn>(), Line_text.GetComponent<UnityEngine.UI.Text>());

            Debug.Log("조작모드 끝");
            //Debug.Log(NewLineNum().Value);
			isInControlMode = false;
            //myLine[NewLineNum().Value] = nowLine;
            
            
            nowLine.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);

            Enemy encounteredEnemy = EncountEnemy();
            Player.GetComponent<Player>().moveToGoal.Add(new MoveToGoal(endPos, encounteredEnemy));

            if (encounteredEnemy != null)
            {
                allEncountedEnemyList.Add(encounteredEnemy);
            }
            myLine.Add(nowLine);
        }
	}

	private GameObject CreateLine()
	{
        //if(NewLineNum() == null)
        //return null;
        if (used_line_count >= max_line.GetComponent<MaxLine_Turn>().Max_Line)
            return null;

		GameObject ControlLine = Instantiate(Line);
        ControlLine.transform.parent = Player_Line.transform;

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

        return raycastTester.GetNearestEnemyPosition(ignoreList: allEncountedEnemyList);
    }

    private Enemy EncountEnemy()
    {
        RaycastTester raycastTester = gameObject.GetComponent<RaycastTester>();

        return raycastTester.GetNearestEnemy(ignoreList: allEncountedEnemyList);
    }
    
    /*private int? NewLineNum()
	{
		for(int num = 0; num < max_line.GetComponent<MaxLine_Turn>().Max_Line; num++)
		{
			//if(myLine[num] == null)
            if (myLine.Last() == null)
			{
				return num;
			}
		}

		Debug.Log("Can't Create More Line");
		return null;
	}
    */
    
}