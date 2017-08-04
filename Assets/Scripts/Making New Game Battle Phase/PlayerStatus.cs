using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    public int speed;

    public Element element;


    public Vector2 PlayerPositionXY()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
