using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassTrigger : MonoBehaviour
{
    Animator ani;
    AnimatorStateInfo animState;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        animState = ani.GetCurrentAnimatorStateInfo(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!animState.IsName("down") && other.gameObject.layer == 7) //grass layer = 6, mower layer = 7
        {
            ani.SetTrigger("cut");
        }
        /*else
        {
            ani.ResetTrigger("cut");
        }*/
    }
}
