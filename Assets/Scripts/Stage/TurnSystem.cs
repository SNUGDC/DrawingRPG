using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public Image[] MovePhaseImage;
    public Image[] BattlePhaseImage;
    private bool startmove;
    public Player player;

    public void StartMove()
    {
        startmove = true;
        StartCoroutine(RunTurn());
    }

    private void Start()
    {
        startmove = false;
        Screen.SetResolution(360, 640, false);
    }

    IEnumerator RunTurn()
    {
        while (player.NeedTurnPhase())
        {
            yield return StartCoroutine(StartMovePhase());
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(StartBattlePhase());
            yield return StartCoroutine(RunBattlePhase());
            if (player == null)
            {
                yield break;
            }
            player.PhaseEnd();
        }
        Debug.Log("TurnEnd");
    }

    private IEnumerator StartMovePhase()
    {
        ReturnMovePhaseImageToOrigin();
        yield return StartCoroutine(ShowMovePhasePanel());
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeMovePhasePanel());
    }

    private IEnumerator RunMovePhase()
    {
        yield return StartCoroutine(player.RunMovePhase());
    }

    private IEnumerator StartBattlePhase()
    {
        ReturnBattlePhaseImageToOrigin();
        yield return StartCoroutine(ShowBattlePhasePanel());
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeBattlePhasePanel());
    }

    private IEnumerator RunBattlePhase()
    {
        yield return StartCoroutine(player.RunBattlePhase());
    }

    private IEnumerator ShowMovePhasePanel()
    {
        while(true)
        {
            bool isShow = (MovePhaseImage[0].color.a >= 1f);
            Vector2[] movingVector = new Vector2[] {new Vector2(-1980,0), new Vector2(1980,0), new Vector2(0,1980), new Vector2(0,-1980)};

            if(isShow == false)
            {
                for(int i = 0; i < movingVector.Length; i++)
                {
                    MovePhaseImage[i].color += new Color(0, 0, 0, Time.deltaTime);
                    MovePhaseImage[i].rectTransform.anchoredPosition += movingVector[i] * Time.deltaTime;
                }
            }
            else
            {
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator FadeMovePhasePanel()
    {
        while(true)
        {
            bool isShow = (MovePhaseImage[0].color.a <= 0f);
            Vector2[] movingVector = new Vector2[] {new Vector2(-1980,0), new Vector2(1980,0), new Vector2(0,1980), new Vector2(0,-1980)};

            if(isShow == false)
            {
                for(int i = 0; i < movingVector.Length; i++)
                {
                    MovePhaseImage[i].color -= new Color(0, 0, 0, Time.deltaTime);
                    MovePhaseImage[i].rectTransform.anchoredPosition -= movingVector[i] * Time.deltaTime;
                }
            }
            else
            {
                yield break;
            }

            yield return null;
        }
    }

    private void ReturnMovePhaseImageToOrigin()
    {
        MovePhaseImage[0].rectTransform.anchoredPosition = new Vector2(1980, 0);
        MovePhaseImage[1].rectTransform.anchoredPosition = new Vector2(-1980, 0);
        MovePhaseImage[2].rectTransform.anchoredPosition = new Vector2(0, -1980);
        MovePhaseImage[3].rectTransform.anchoredPosition = new Vector2(0, 1980);

        foreach(Image image in MovePhaseImage)
        {
            image.color = new Color (1, 1, 1, 0);
        }
    }

    private IEnumerator ShowBattlePhasePanel()
    {
        while(true)
        {
            bool isShow = (BattlePhaseImage[0].color.a >= 1f);
            Vector2[] movingVector = new Vector2[] {new Vector2(-1980,0), new Vector2(1980,0), new Vector2(0,1980), new Vector2(0,-1980)};

            if(isShow == false)
            {
                for(int i = 0; i < movingVector.Length; i++)
                {
                    BattlePhaseImage[i].color += new Color(0, 0, 0, Time.deltaTime);
                    BattlePhaseImage[i].rectTransform.anchoredPosition += movingVector[i] * Time.deltaTime;
                }
            }
            else
            {
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator FadeBattlePhasePanel()
    {
        while(true)
        {
            bool isShow = (BattlePhaseImage[0].color.a <= 0f);
            Vector2[] movingVector = new Vector2[] {new Vector2(-1980,0), new Vector2(1980,0), new Vector2(0,1980), new Vector2(0,-1980)};

            if(isShow == false)
            {
                for(int i = 0; i < movingVector.Length; i++)
                {
                    BattlePhaseImage[i].color -= new Color(0, 0, 0, Time.deltaTime);
                    BattlePhaseImage[i].rectTransform.anchoredPosition -= movingVector[i] * Time.deltaTime;
                }
            }
            else
            {
                yield break;
            }

            yield return null;
        }
    }

    private void ReturnBattlePhaseImageToOrigin()
    {
        BattlePhaseImage[0].rectTransform.anchoredPosition = new Vector2(1980, 0);
        BattlePhaseImage[1].rectTransform.anchoredPosition = new Vector2(-1980, 0);
        BattlePhaseImage[2].rectTransform.anchoredPosition = new Vector2(0, -1980);
        BattlePhaseImage[3].rectTransform.anchoredPosition = new Vector2(0, 1980);

        foreach(Image image in BattlePhaseImage)
        {
            image.color = new Color (1, 1, 1, 0);
        }
    }
}
