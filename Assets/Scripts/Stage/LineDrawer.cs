using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    public GameObject Line_text;
	public GameObject LineEnd;
	public GameObject Line;
	public float maxLineLength;
	public List<GameObject> myLine = new List<GameObject>();

    public int used_line_count = 0;

	public GameObject Player;

    public GameObject LineDeleteButton;
    

    private GameObject nowLine;
	private Vector2 mousePos;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isInControlMode;

    public List<Vector2> PlayerPassedPosition = new List<Vector2>(); 
    private List<Enemy> allEncountedEnemyList = new List<Enemy>();


    /* public void Delete_Line()
     {
         Debug.Log("Delete_Done");
         if (used_line_count <= 0)
             return;
         if (thisPlayerClicked == true)
         {
             used_line_count--;
             player_passed_position.RemoveAt(player_passed_position.Count - 1);
             Player.GetComponent<Player>().PlayerGoalPosition.RemoveAt(Player.GetComponent<Player>().PlayerGoalPosition.Count - 1);
             transform.position = player_passed_position[player_passed_position.Count - 1];
             Destroy(myLine[myLine.Count - 1]);
             myLine.RemoveAt(myLine.Count - 1);
         }*/

    //}

    public static void LineCounting(LineDrawer LineDrawer, int maxLine, Text text)
    {
        text.text = LineDrawer.used_line_count + "/" + maxLine;
    }

    private void Start()
	{
		isInControlMode = false;
        LineDeleteButton.SetActive(false);
        
		//myLine = new GameObject[max_line.GetComponent<MaxLine_Turn>().Max_Line];
        allEncountedEnemyList.Clear();
        //if (myLine[0] == null)
        /*if (myLine.Count == 0)    
		{
			Player = GameObject.Find("Player");
			transform.position = Player.transform.position;
		}*/
        transform.position = Player.transform.position;
        //PlayerPassedPosition.Add(Player.transform.position);
        //player_passed_position.Add(Player.transform.position);
        //Debug.Log(player_passed_position[0]);
        //Player.GetComponent<Player>().PlayerGoalPosition.Add(transform.position);
        Line_text = GameObject.Find("Line_text");
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

    private void LineDeleteButtonDisabled()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.GetComponent<Player>().thisPlayerClicked = false;
        }
    }

    public void DeleteLine()
    {
        Debug.Log("Delete_Done");
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Player thisPlayer = player.GetComponent<Player>();
            if (thisPlayer.thisPlayerClicked == true)
            {
                if (thisPlayer.LineDrawerPrefeb.used_line_count <= 0)
                    return;
                thisPlayer.LineDrawerPrefeb.used_line_count--;
                thisPlayer.LineDrawerPrefeb.PlayerPassedPosition.RemoveAt(thisPlayer.LineDrawerPrefeb.PlayerPassedPosition.Count - 1);
                Destroy(thisPlayer.LineDrawerPrefeb.myLine[thisPlayer.LineDrawerPrefeb.myLine.Count - 1]);
                thisPlayer.LineDrawerPrefeb.myLine.RemoveAt(thisPlayer.LineDrawerPrefeb.myLine.Count - 1);
                thisPlayer.LineDrawerPrefeb.transform.position = thisPlayer.LineDrawerPrefeb.PlayerPassedPosition[thisPlayer.LineDrawerPrefeb.PlayerPassedPosition.Count - 1];
            }
        }
    }

    private void OnMouseDown()
	{
		//if(NewLineNum() == null)
			//return;
        if (used_line_count >= FindObjectOfType<UIManager>().maxLine)
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
            LineDeleteButtonDisabled();
            Player.GetComponent<Player>().thisPlayerClicked = true;
            PlayerPassedPosition.Add(transform.position);
            //Player.GetComponent<Player>().PlayerGoalPosition.Add(transform.position);
            used_line_count++;
            LineCounting(this, FindObjectOfType<UIManager>().maxLine, Line_text.GetComponent<UnityEngine.UI.Text>());

            Debug.Log("조작모드 끝");
            LineDeleteButton.SetActive(true);
            //Debug.Log(NewLineNum().Value);
			isInControlMode = false;
            //myLine[NewLineNum().Value] = nowLine;
            
            
            nowLine.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);

            Enemy encounteredEnemy = EncountEnemy();
            //Player.GetComponent<Player>().moveToGoal.Add(new MoveToGoal(endPos, encounteredEnemy));

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
        if (used_line_count >= FindObjectOfType<UIManager>().maxLine)
            return null;

		GameObject ControlLine = Instantiate(Line);
        //ControlLine.transform.parent = Player_Line.transform;

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