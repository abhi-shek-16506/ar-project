using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System;

[RequireComponent(typeof(ARRaycastManager))]
public class artap : MonoBehaviour
{
    public static int dummy;
    public GameObject dust,dustbin,panel;
    private GameObject swannedobject, swannedobject1;
    private ARRaycastManager arrnamanager;
    private Vector2 touchposition;
    private bool initiated = false,stopwatchactive=true;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>(); private ARRaycastManager _raycastManager;
    public float animation;
    float currenttime;
    public int startmin;
    public Text currenttimetext;
    Rigidbody rb;
    Vector3 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction
    private void Awake()
    {
        arrnamanager = GetComponent<ARRaycastManager>();
    }

    bool Try(out Vector2 touchposition)
    {
        if (Input.touchCount > 0)
        {           
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        // panel.SetActive(false);
        currenttime = startmin * 60;
    }
    // Update is called once per frame
    void Update()
    {
        dustbin.SetActive(true);
        animation = Time.deltaTime;
        animation = animation % 5f;
        if (!Try(out Vector2 touchposition))
            return;
        if (arrnamanager.Raycast(touchposition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitpos = hits[0].pose;
            if (swannedobject == null)
            {
                //dustbin.SetActive(true);
                swannedobject = Instantiate(original: dustbin, hitpos.position, hitpos.rotation);
                return;
               // timecounter.secondleft;
            }
            else
            {
                swannedobject.transform.position = hitpos.position;
                //timecounter.secondleft -= 1;
            }
        }
        if (initiated) return;

        if (!initiated)

        {

            if (Input.touchCount > 0)
            {
                // The screen has been touched so store the touch
                Touch touch = Input.GetTouch(0);
                touchposition = Input.GetTouch(0).position;

                if (arrnamanager.Raycast(touchposition, hits, TrackableType.PlaneWithinPolygon))
 
                {
                    var hitpos = hits[0].pose;
                    if (swannedobject1 == null)
                    {
                             var hitPose = hits[0].pose;

                        swannedobject = Instantiate(dust, hitPose.position, hitPose.rotation);                                               
                    }
                    else
                    {
                        swannedobject.transform.position = hitpos.position;                  
                    }                  
                    initiated = true;                    
                }
            }                      
        }
        if(stopwatchactive==true)
        {
            currenttime = currenttime - Time.deltaTime;
            if(currenttime<0)
            {
                stopwatchactive = false;
                Start();

            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currenttime);
        currenttimetext.text = time.Minutes.ToString()+";"+time.Seconds.ToString();

    }
    public void OnMouseDown()
    {
        //stopwatchactive = true;
    }

}
