using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg_Hinge_Behavior : MonoBehaviour
{
    public GameObject end_point;
    public float rot_speed = 1f;

    private HingeJoint2D self_hinge_joint;
    private bool tp_pressed = false;

    public void TPPressed()
    {
        tp_pressed = true;
    }

    public void TPReleased()
    {
        tp_pressed = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        self_hinge_joint = this.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tp_pressed)
        {
            float spd = rot_speed * Time.deltaTime * 100;

            Vector3 targ_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 current_pos = Camera.main.WorldToScreenPoint(end_point.transform.position);
            float diff_x = targ_pos.x - current_pos.x;
            float diff_y = targ_pos.y - current_pos.y;
            //Debug.Log("Diffx: " + diff_x + " Diffy: " + diff_y);
            float angle = -Mathf.Atan2(diff_x, diff_y) * Mathf.Rad2Deg + 180; // add 180 to align with bottom of leg
            //Debug.Log("Angle: " + angle);
            Quaternion target_angle = Quaternion.Euler(new Vector3(0, 0, angle));
            self_hinge_joint.transform.rotation = Quaternion.RotateTowards(self_hinge_joint.transform.rotation, target_angle, spd);
        }
    }
}
