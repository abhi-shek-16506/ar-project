using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject canonball1;
    public Transform firepoint;
    private Camera cam;
    private bool pressmouse = false;
    private Vector3 initialvelocity;
    private const int trajectorypoints=10;
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lineRenderer.positionCount = trajectorypoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { pressmouse = true;
            lineRenderer.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressmouse = false;
           lineRenderer.enabled = false;

            fire();
        }
        if(pressmouse)
        {
            Vector3 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            transform.LookAt(mousepos);
            initialvelocity = mousepos - firepoint.position;
            updatelinerenderer();
        }


    }
    private void fire()
    {
        GameObject canonball = Instantiate(canonball1,firepoint.position,Quaternion.identity);
        Rigidbody rb = canonball.GetComponent<Rigidbody>();
        rb.AddForce(initialvelocity,ForceMode.Impulse);

    }
    private void updatelinerenderer()
    {
        float g = Physics.gravity.magnitude;
        float velocity = initialvelocity.magnitude;
        float angle = Mathf.Atan2(initialvelocity.y, initialvelocity.x);
        float timestep = 0.1f;
        float ftime = 0f;
        Vector3 start = firepoint.position;
        for(int i=0;i<trajectorypoints;i++)
        {
            float dx = velocity * ftime * Mathf.Cos(angle);
            float dy = velocity * ftime * Mathf.Sin(angle)*g*ftime*ftime/2f;
            Vector3 pos = new Vector3(start.x + dx, start.y + dy,0);
            lineRenderer.SetPosition(i, pos);
            ftime += timestep;
        }
    }
}
