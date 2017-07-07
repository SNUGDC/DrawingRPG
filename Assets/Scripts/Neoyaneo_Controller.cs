using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neoyaneo_Controller : MonoBehaviour{

    public Animator anime;
    public Animator anim;
    //   IEnumerator MyCoroutine()
    //    {
    //       while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action1"))
    //        {
    //            yield return null;
    //      }
    //
    //     if (anim.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action1"))
    //    {
    //    anim.SetBool("Action1", false);
    // }

    // }
    public float Repeat_number_of_Action1;
    public float Repeat_number_of_Action2;
    public float Repeat_number_of_Action3;

    private void reset()
    {
        anime.ResetTrigger("Action1");
        anime.ResetTrigger("Action2");
        anime.ResetTrigger("Action3");
        anime.ResetTrigger("Die");
    }   


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anime.SetBool("Action1", true);
            Debug.Log("pressed A");
        }

        else if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime > Repeat_number_of_Action1 && anime.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action1"))
        {
            anime.SetBool("Action1", false);
        }
        //Action1 0.5초 재생시 죽음 parameter1이 reset 되지않는 문제점.
        else if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5 && anime.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action1"))
        {
            anime.Play("Nayana_Die");
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            reset();
            anime.SetBool("Action2", true);
            Debug.Log("pressed 2");
        }

        else if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime > Repeat_number_of_Action2 && anime.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action2"))
        {
            anime.SetBool("Action2", false);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            anime.SetBool("Action3", true);
            Debug.Log("pressed 3");
        }

        else if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime > Repeat_number_of_Action3 && anime.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action3"))
        {
            anime.SetBool("Action3", false);
        }

        if (Input.GetKeyDown(KeyCode.Z) || (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > Repeat_number_of_Action3 && anim.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action3")))
        {
            anime.SetBool("Die", true);
        }
        // 한 애니메이션 플레이중일때 나머지 파라미터 리셋 유니티 기본으로 애니메이션을 linear combination 하는데 이부분 수정안하면 오류남
        //  else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Nayana_Action1") != true)
        //{
        //    Debug.Log("parameter reset");
        //    anim.ResetTrigger("Action1");
        //    anim.ResetTrigger("Action2");
        //    anim.ResetTrigger("Action3");
        //}

        if (Input.GetKeyDown(KeyCode.V))
        {
            reset();
        }
    }

}
