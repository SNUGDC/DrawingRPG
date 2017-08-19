using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Player player;
    public int num;
    public GameObject Line;
	public Vector2 startPos;
	public Vector2 endPos;
    private bool isStart = false;

	private float length;

    public void SetStartLinePos(Vector2 startpos)
    {
        startPos = startpos;
    }

    public void SetEndLinePos(Vector2 endpos)
    {
        endPos = endpos;
    }

    private void Start()
    {
        Debug.Log(GameObject.FindObjectOfType<BattlePhase>().turnCount);
    }

    private void Update()
    {
        if (num == GameObject.FindObjectOfType<BattlePhase>().turnCount+1)
        {
            this.GetComponent<LineRenderer>().SetPosition(0, startPos);
            this.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        }
        else if(num < GameObject.FindObjectOfType<BattlePhase>().turnCount+1)
        {
            this.GetComponent<LineRenderer>().SetPosition(1, endPos);
        }
        else
        {
            this.GetComponent<LineRenderer>().SetPosition(0, startPos);
            this.GetComponent<LineRenderer>().SetPosition(1, startPos);
        }
    }
        /*
        if (isStart ==false && (startPos - new Vector2(player.transform.position.x, player.transform.position.y)).magnitude >= 0.05)
        {
            return;
        }
        else
        {
            
            isStart = true;
            
        }
        if (isStart == true)
        {
            Vector2 newOne = new Vector2(player.transform.position.x - endPos.x, player.transform.position.y - endPos.y);
            if (newOne.magnitude >= 0.05)
            {
                
                return;
            }
            isStart = false;
            this.GetComponent<LineRenderer>().SetPosition(1, endPos);
            Debug.Log(123);

        }*/
    
}