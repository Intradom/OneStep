using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg_Behavior : MonoBehaviour
{
    Collider2D self_collider;

    private void Awake()
    {
        self_collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Leg")
        {

            Physics2D.IgnoreCollision(collision.collider, self_collider);
        }
    }
}
