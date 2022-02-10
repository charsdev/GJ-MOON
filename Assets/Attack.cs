using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private float time = 0.6f;
    [SerializeField] private GameObject attackZone;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool attackAnim;
    [SerializeField] private GameObject lightTrail;
    private Win winScript;

    private void Start()
    {
        winScript = gameObject.GetComponent<Win>();
    }

    private void Update()
    {
        if (winScript.GetStaffState())
        {
            if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    gameObject.GetComponent<Animator>().Play("Attack");
                    gameObject.GetComponent<CharacterMovement>().canMove = false;
                    /*isWalking = false;
                    isRunning = false;
                    attackAnim = true;
                    gameObject.GetComponent<Animator>().SetBool("isWalking", isWalking);
                    gameObject.GetComponent<Animator>().SetBool("isRunning", isRunning);*/
                }
            }
        }
    }
    

    public void enableAttack()
    {
        attackZone.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<CharacterMovement>().canMove = false;
        lightTrail.SetActive(true);
    }

    public void disableAttack()
    {
        attackZone.GetComponent<BoxCollider>().enabled = false;
        isAttacking = false;
        gameObject.GetComponent<CharacterMovement>().canMove = true;
        lightTrail.SetActive(false);
    }
}