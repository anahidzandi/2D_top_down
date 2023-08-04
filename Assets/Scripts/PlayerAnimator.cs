using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;
    public Transform attackPoint;
    private Vector3 attackPointInitialLocalPosition;


    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();

        attackPointInitialLocalPosition = attackPoint.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
            attackPoint.localPosition = attackPointInitialLocalPosition;
            SpriteDirectionChecker();

        }
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
            attackPoint.localPosition = new Vector3(-attackPointInitialLocalPosition.x, attackPointInitialLocalPosition.y, attackPointInitialLocalPosition.z);
        }
        else
        {
            sr.flipX = false;
            attackPoint.localPosition = attackPointInitialLocalPosition;
        }
    }
}