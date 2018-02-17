using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public static int maxSanteMentale = 300;
    public static int santeMentale = 300;
    public static int caughtByMonster = 0;

    public static bool TutoBreath = false;

    public static bool hasKey = false;

    public static int sprint = 200;

    /*Enquete*/
    public static bool Esang;
    public static bool Sang1;
    public static bool Sang2;
    public static bool Ejournal;
    public static bool Journal1;
    public static bool Journal2;

    /*Spawn Positions*/
    public static Vector3 station1 = new Vector3(21,-3.16f,0);
    public static Vector3 tunnel1 = new Vector3(95,9.65f,0);

    public static string previousScene="";
    public static string currentScene="";
}
