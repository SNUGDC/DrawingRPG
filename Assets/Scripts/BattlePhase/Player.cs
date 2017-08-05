﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    public int speed;

    public Element element;

    public Sprite portrait;

    public Vector2 PlayerPositionXY()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}