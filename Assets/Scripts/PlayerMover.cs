using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	private LineDrawer LineDrawer;
	private bool startmove;
	public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();
    
	private void Start()
	{
		startmove = false;
		LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
	}

	private void Update()
	{
        //임의로 추가햇으니 없애도 됩니다
        if (Input.GetMouseButtonDown(0) && LineDrawer.return_line_num())
        {
            startmove = !startmove;
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
    
    public bool return_startmove()
    {
        return startmove;
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