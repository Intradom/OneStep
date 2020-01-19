using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Behavior : MonoBehaviour
{
    public  GameObject leg;

    private Leg_Hinge_Behavior lg;

    // Start is called before the first frame update
    void Awake()
    {
        lg = leg.GetComponent<Leg_Hinge_Behavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Press"))
        {
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_pos_2D = new Vector2(mouse_pos.x, mouse_pos.y);
            RaycastHit2D hit = Physics2D.Raycast(mouse_pos_2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Touch"));

            if (hit.collider)
            {
                if (hit.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
                {
                    lg.TPPressed();
                }
            }
        }
        else if (Input.GetButtonUp("Press"))
        {
            lg.TPReleased();
        }
    }
}
