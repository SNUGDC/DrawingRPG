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
        int numberOfPlayer = whichPlayerReachEnemy[enemy].Count;


    }

}
