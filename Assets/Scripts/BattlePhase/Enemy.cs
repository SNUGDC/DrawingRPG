﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    public Element element;

    public bool clicked = false;

    public Sprite portrait;
}