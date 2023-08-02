using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //References
    Animator am;
    EnemyController ec;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        ec = GetComponent<EnemyController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ec.direction != 0)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
            SpriteDirectionChecker();
        }
    }

    void SpriteDirectionChecker()
    {
        if (ec.direction < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
