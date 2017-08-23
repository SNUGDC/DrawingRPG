using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePoint {

    public static List<int> maxExperiencePoint = MakeInitialData();

    static List<int> MakeInitialData() {

        List<int> experiencePoint = new List<int>();
        experiencePoint.Add(0);
        for(int i=1; i<100; i++)
        {
            int maxExperiencePointForThisLevel = (int)(90 + 10 * i + (135 + 15 * i) * Mathf.Pow(1.05f, (float)(i - 1)));
            experiencePoint.Add(maxExperiencePointForThisLevel);
        }
        return experiencePoint;
	}

    public static void passExperiencePoint(GameObject enemy, Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy)
    {
        List<GameObject> LastAttackPlayerList = whichPlayerReachEnemy[enemy];
        for(int i = 0; i < LastAttackPlayerList.Count; i++)
        {
            GameObject player = LastAttackPlayerList[i];
            Player playerStatus = player.gameObject.GetComponent<Player>();
            Enemy EnemyStatus = enemy.gameObject.GetComponent<Enemy>();
            playerStatus.gainedExperiencePoint += (EnemyStatus.exp/LastAttackPlayerList.Count);
        }
    }

    public static Dictionary<string,int> CalculateExperiencePoint(int level, int currentExperincePoint, int gainedExperincePoint)
    {
        Dictionary<string, int> levelAndExperiencePoint = new Dictionary<string, int>();
        
        if (currentExperincePoint + gainedExperincePoint >= maxExperiencePoint[level]) {
            levelAndExperiencePoint.Add("Level", level+1);
            levelAndExperiencePoint.Add("ExperiencePoint", (currentExperincePoint + gainedExperincePoint) - maxExperiencePoint[level]);
            return levelAndExperiencePoint;
        }
        else
        {
            levelAndExperiencePoint.Add("Level", level);
            levelAndExperiencePoint.Add("ExperiencePoint", (currentExperincePoint + gainedExperincePoint));
            return levelAndExperiencePoint;
        }
    }

    
}
