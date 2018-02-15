using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue {

    public string npcName;
   [TextArea(3,10)]
    public string sentence;
    public Sprite portrait;
    public AudioClip clip;
    public string indication;
    public int spacingIndication = 0;
    public bool On = false;
    public bool Off = false;

}
