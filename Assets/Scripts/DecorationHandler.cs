using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationHandler : MonoBehaviour {

    private int borderLeft = -900;
    private int borderRight = 900;
	// Use this for initialization
	void Start () {
        int rLeft = Random.Range(borderLeft,0);
        int rRight = Random.Range(0, borderRight);
        int rTime = Random.Range(12, 16);

        transform.localPosition = new Vector3(rLeft, transform.localPosition.y, 0);
        Hashtable args = new Hashtable();
        args.Add("time", rTime);
        args.Add("loopType", "pingpong");
        args.Add("x", rRight);
        args.Add("easeType", iTween.EaseType.linear);
        iTween.MoveTo(this.gameObject, args);
	}
}
