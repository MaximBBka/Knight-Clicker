using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] Rigidbody rb;
    private float attackTimer = 0.5f;
    private bool canAttack = true;

    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int a = Random.Range(1, 4);
                if (a == 1)
                {
                    playerAnim.SetTrigger("isAttack1");
                    Audio.Instance.Volume.Play();
                }
                else if (a == 2)
                {
                    playerAnim.SetTrigger("isAttack2");
                    Audio.Instance.Volume.Play();
                }
                else if (a == 3)
                {
                    playerAnim.SetTrigger("isAttack3");
                    Audio.Instance.Volume.Play();
                }
                canAttack = false;
                attackTimer = 0.5f;
            }
        }
        if (!MainUI.Instance.isStop)
        {
            if (rb.velocity.magnitude > 0.2f)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

