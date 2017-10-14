using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour {

    public ScrollRect panel;
	// Update is called once per frame
	void Update () {
       panel.verticalNormalizedPosition = 0f;
	}
}
