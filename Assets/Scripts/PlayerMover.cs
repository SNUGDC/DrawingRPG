using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	private LineDrawer LineDrawer;
	private bool startmove;
	public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();

    public int move_count;

	private void Start()
	{
        move_count = 0;
		startmove = false;
		LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
	}

	private void Update()
	{
        //임의로 추가햇습니다
        if (Input.GetMouseButtonDown(0) && LineDrawer.return_line_num())
        {
            if (startmove == true)
            {
                startmove = false;
                move_count++;
            }
            else
                startmove = true;
        }
        
            if (moveToGoal.Count != 0)
            {
                if (moveToGoal[0].IsArrive(transform) == false)
                {
                    moveToGoal[0].Move(transform, startmove);
                }
                else if (moveToGoal[0].IsArrive(transform) == true)
                {
                    moveToGoal.RemoveAt(0);
                }
            }

            ///**/이 안에 있는게 원본
            /*
         if(startmove == true)
		   {   
            if (moveToGoal.Count != 0)
			{
				if (moveToGoal[0].IsArrive(transform) == false)
				{
					moveToGoal[0].Move(transform);
				}
				else if (moveToGoal[0].IsArrive(transform) == true)
				{
					moveToGoal.RemoveAt(0);
				}
			}
          }*/
          
    }
    
    //요까지..


	private GameObject NowLine()
	{
		for(int i = 0; i < LineDrawer.maxLineNum; i++)
		{
			if(LineDrawer.myLine[i] != null)
				return LineDrawer.myLine[i];
		}

		return null;
	}
    
}