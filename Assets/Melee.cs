using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float damage;
    [HideInInspector]public bool canAttack = true;
    [HideInInspector]public bool isAttacking;
    [SerializeField] private Animator anim;
    private void Start()
    {
        canAttack = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            anim.SetTrigger("Attack");
        }
    }
}
