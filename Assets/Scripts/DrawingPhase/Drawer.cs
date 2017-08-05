using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private DrawingPhase phase;

    public GameObject linePrefab;
    public float maxLineLength;

    private GameObject player;

    private GameObject currentLine;
    private Vector2 mousePos
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private Vector2 currentLineStartPos;
    private Vector2 currentLineEndPos;
    private bool isInControlMode;

    private List<Enemy> allEncountedEnemyList = new List<Enemy>();

    public void StartDrawingPhase(DrawingPhase phase)
    {
        this.phase = phase;
    }

    private void Start()
    {
        isInControlMode = false;

        allEncountedEnemyList.Clear();
        player = transform.parent.gameObject;
        var playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -1);
    }

    private void Update()
    {
        if (phase == null)
        {
            return;
        }

        if (isInControlMode == true)
        {
            transform.position = new Vector3(currentLineEndPos.x, currentLineEndPos.y, -1);
            UpdateLinePosition(currentLine);
        }
    }

    private void OnMouseDown()
    {
        if (phase == null)
            return;

		if (!phase.HaveDrawingTurn()) {
			Debug.LogWarning("Not enough turn");
			return;
		}

        Debug.Log("조작모드 시작");
        isInControlMode = true;
        currentLineStartPos = transform.position;
        RaycastTester raycastTester = gameObject.GetComponent<RaycastTester>();
        raycastTester.startPos = currentLineStartPos;
        currentLine = Instantiate(linePrefab);
    }

    private void OnMouseUp()
    {
        if (phase == null)
            return;
        if (isInControlMode == false)
        {
            Debug.LogWarning("OnMouseUp But Not Control Mode");
            return;
        }

        Debug.Log("조작모드 끝");
        isInControlMode = false;

        currentLine.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        Enemy encounteredEnemy = EncountEnemy();

        if (encounteredEnemy != null)
        {
            allEncountedEnemyList.Add(encounteredEnemy);
        }

        GameObject enemyGameObject = encounteredEnemy == null ? null : encounteredEnemy.gameObject;
		phase.OnLineDrawComplete(player, transform.position, enemyGameObject);
    }

    private void UpdateLinePosition(GameObject line)
    {
        if (line == null)
        {
            Debug.LogError("line is null");
            return;
        }
        float lineLength = Vector2.Distance(currentLineStartPos, mousePos);
        if (EncountEnemyPosition() != null)
        {
            lineLength = Vector2.Distance(EncountEnemyPosition().Value, currentLineStartPos);
            currentLineEndPos = EncountEnemyPosition().Value;
            line.GetComponent<SpriteRenderer>().color = new Color(1, 0.2f, 0.2f, 1);
        }
        else if (lineLength > maxLineLength)
        {
            lineLength = maxLineLength;
            currentLineEndPos = currentLineStartPos + (mousePos - currentLineStartPos).normalized * maxLineLength;
            line.GetComponent<SpriteRenderer>().color = new Color(1, 0.2f, 0.2f, 1);
        }
        else
        {
            currentLine.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            currentLineEndPos = mousePos;
        }

        line.transform.position = (currentLineStartPos + currentLineEndPos) / 2;
        line.transform.localScale = new Vector2(Vector2.Distance(currentLineStartPos, currentLineEndPos), 1);
        line.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan((currentLineEndPos.y - currentLineStartPos.y) / (currentLineEndPos.x - currentLineStartPos.x)));
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
}
