using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines {
    public Player player;
    public List<LineController> lineControl;
}

public class LineController : MonoBehaviour
{
    public Player player;
    public int num;
	public Vector2 startPos;
	public Vector2 endPos;

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
        this.GetComponent<LineRenderer>().SetPosition(0, startPos);
        this.GetComponent<LineRenderer>().SetPosition(1, startPos);
        Debug.Log(GameObject.FindObjectOfType<BattlePhase>().turnCount);
    }
    public static LineController FindLineWithNum(Player playerim, int linenum)
    {
        LineController[] lineControl = GameObject.FindObjectsOfType<LineController>();
        foreach(LineController line in lineControl)
        {
            if (line.num == linenum && line.player == playerim)
                return line;
        }
        return null;
    }
    public void PlayerMove()
    {
        this.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
    }

    public void PlayerAfterMove()
    {
        this.GetComponent<LineRenderer>().SetPosition(1, endPos);
    }
    public void PlayerBeforeMove()
    {
        this.GetComponent<LineRenderer>().SetPosition(1, startPos);
    }
}