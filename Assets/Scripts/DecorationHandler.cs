using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DecorationHandler : MonoBehaviour {

    private int borderLeft = -900;
    private int borderRight = 900;
	// Use this for initialization
	void Start () {
        int rLeft = Random.Range(borderLeft,0);
        int rRight = Random.Range(0, borderRight);
        int rTime = Random.Range(12, 16);

        transform.localPosition = new Vector3(rLeft, transform.localPosition.y, 0);
        transform.DOLocalMoveX(rRight, rTime).SetLoops(-1);

	}
}
