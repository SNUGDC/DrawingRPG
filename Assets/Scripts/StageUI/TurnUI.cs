using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour {

    private BattlePhase battlePhase;
    public Text text;

    private void Start()
    {
        battlePhase = FindObjectOfType<BattlePhase>();
        ActiveTurnUI();
    }

    public void ActiveTurnUI()
    {
        text.text = battlePhase.turnCount + "/" + battlePhase.maxTurnCount;
    }
}
