using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Player player;
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
        this.GetComponent<LineRenderer>().enabled = false;
        endPos = new Vector2(-100, -100);
        isStart = false;
    }
    
    private void Update()
    {
        if (isStart ==false && (startPos - new Vector2(player.transform.position.x, player.transform.position.y)).magnitude >= 0.01)
        {
            return;
        }
        else
        {
            this.GetComponent<LineRenderer>().enabled = true;
            isStart = true;
            this.GetComponent<LineRenderer>().SetPosition(0, startPos);
        }
        if (isStart == true)
        {
            Vector2 newOne = new Vector2(player.transform.position.x - endPos.x, player.transform.position.y - endPos.y);
            if (newOne.magnitude >= 0.01)
            {
                this.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
                return;
            }
            isStart = false;
            this.GetComponent<LineRenderer>().SetPosition(1, endPos);
            Debug.Log(123);

        }
    }
}