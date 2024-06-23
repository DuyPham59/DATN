using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    protected int grassPos;
    protected int numberDice;
    protected Transform posTarget;
    protected float speed;
    protected Animator jump;

    protected virtual void Awake()
    {
        speed = 2;
        jump = GetComponentInParent<Animator>();
    }
    protected void Moving()
    {
        if(posTarget == null) return;
        float PosX = gameObject.transform.parent.position.x;
        float PosY = gameObject.transform.parent.position.y;
        float PosTargetX = posTarget.position.x;
        float PosTargetY = posTarget.position.y;
        float moveTime = speed * UnityEngine.Time.deltaTime;
        if (PosX <= (PosTargetX + moveTime) && PosX >= (PosTargetX - moveTime) && PosY <= (PosTargetY + moveTime) && PosY >= (PosTargetY - moveTime)) return;
        Vector2 direction = posTarget.position - gameObject.transform.parent.position;
        transform.parent.Translate(direction.normalized * speed * UnityEngine.Time.deltaTime);
    }

}
