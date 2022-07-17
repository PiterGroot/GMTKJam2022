using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    private List<Transform> wayPoints = new List<Transform>();
    private Wallet wallet;

    [SerializeField] public RuntimeAnimatorController rollAnim, normalAnim;

    [SerializeField] public Animator anim;
    [SerializeField] private float towerPrice;
    public GameObject bleedParticleEffect;
    public bool canBuild;
    private void Start()
    {
        wallet = gameObject.GetComponent<Wallet>();
        GetAllWayPoints();
    }
    private void GetAllWayPoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            wayPoints.Add(transform.GetChild(i));
        }
    }
    public Transform GetWayPoint(int index)
    {
        return wayPoints[index];
    }

    public bool isRolling;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(wallet.GetMoney() >= towerPrice && !isRolling && canBuild)
            {
                anim.runtimeAnimatorController = rollAnim;
                wallet.RemoveMoney(towerPrice);
                isRolling = true;
                //play sound
                anim.SetTrigger("roll");
                Invoke("Disable", 2.5f);
            }
        }
    }
    private void Disable()
    {
        isRolling = false;
        anim.runtimeAnimatorController = normalAnim;
    }
}
