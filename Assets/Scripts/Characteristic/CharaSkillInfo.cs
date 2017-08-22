using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSkillInfo : MonoBehaviour {

    public string skillname;
    public Skill skill;
    public Sprite skillImage;

    private void Start()
    {
        if (skillname == "Test")
            skill = new TestSkill();
    }

}
