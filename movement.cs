using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
	private int currentsceneindex;
	private int collisioncount=0;
	public GameObject level_complete;
	public Text scre;
	public int highscore = 0;
	private ARRaycastManager _raycastManager;
	Camera cam;
	//public float animation;
	float i, k, j;
	Vector3 startPos, endPos, direction,direction1; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction
                                                         //GameObject dust;
    [SerializeField]
    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInZ = 5f; // to control throw force in Z direction

    Rigidbody rb;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		//animation = Time.deltaTime;
		//animation = animation % 5f;
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{

			
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}

		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{ 

			
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch(0).position;

			// calculating swipe direction in 2D space
			//direction = cam.ScreenToWorldPoint(startPos - endPos);
			direction = startPos - endPos;
			direction1 = (-1) * direction;
			// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
			rb.isKinematic = false;
			rb.AddForce(-direction1.x * ((throwForceInXandY)), direction1.z* (throwForceInZ), -direction1.y * (0));
			//rb.AddForce((-direction1.x * (-1))  * ((throwForceInXandY)*2), -direction1.y / (2), (throwForceInZ) / timeInterval);
		
			//transform.Translate(direction1.z * (direction));
			//transform.Translate(Vector3.forward * (timeInterval * 2));
		    //transform.Translate(Vector3.up * (timeInterval/2 ));						
		}
	}
    private void OnCollisionEnter(Collision collision)
    {
	

        if (collision.gameObject.tag=="bin")
        {
			//collisioncount++;
			score.scoreValue += 1;
			
			if(score.scoreValue>highscore)
            {
				highscore = score.scoreValue;
            }
			//scre.text = score.scoreValue.ToString();
			//SceneManager.LoadScene("main scene");
			//        Destroy(collision.gameObject);
		}
		//PlayerPrefs.SetInt("highscore", highscore);
	}
	public void levelcomplete()
    {
		currentsceneindex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("main scene", currentsceneindex);
		// SceneManager.LoadScene(0);
	}

}