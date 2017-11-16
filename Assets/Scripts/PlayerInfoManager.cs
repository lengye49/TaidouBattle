using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        GameControl._playerInfoChange += Test2;
	}
	


    void Test2(string infoType){
        print("Test --> 2");
    }
}
