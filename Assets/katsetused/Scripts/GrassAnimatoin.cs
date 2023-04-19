using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAnimatoin : MonoBehaviour
{
    private Animator animator;
    private bool collisionOccured = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (collisionOccured)
        {
            StartCoroutine(Wait());
            return;
        }
        if (other.gameObject.layer == 7) //grass layer = 6
        {
            //animator.SetBool("mow", true);
            animator.SetTrigger("cut");
            collisionOccured = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        collisionOccured = false;
    }
}
