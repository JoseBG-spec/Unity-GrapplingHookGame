using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [SerializeField]
    DistanceJoint2D rope;
    [SerializeField]
    Movement m;
    [SerializeField]
    AudioSource ad;

    private LineRenderer line;

    bool checker=true;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {

        // Detect mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0) && checker == true)
        {
            var c = Physics2D.CircleCast(mousePos, 0.4f, Vector2.zero);

            //mousePos = new Vector2(mousePos.x + 3, mousePos.y + 3);
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos);
            
            if (c.collider.gameObject.tag == "Grapplin" && c.collider!=null)
            {
                ad.Play();
                m.numJumps = 1;
                line.enabled = true;
                line.SetPosition(1, mousePos);
                rope.enabled = true;
                rope.connectedAnchor = mousePos;
                checker = false;
            }
            else
            {
                Debug.Log("no");
            }

        }


        // Destroy rope
        else if (Input.GetMouseButtonDown(0))
        {
            rope.enabled = false;
            line.enabled = false;
            checker = true;
        }

        if (!checker)
        {
            Vector2 v2 = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y+.5f);
            line.SetPosition(0, v2);
        }
    }
    
}
