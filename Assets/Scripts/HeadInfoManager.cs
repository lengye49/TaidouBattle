using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInfoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameControl._playerInfoChange += Test1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Test1(string infoType){
        print("Test --> 1");
    }
}
