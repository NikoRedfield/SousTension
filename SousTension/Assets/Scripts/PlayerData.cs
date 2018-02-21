using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public static int maxSanteMentale = 1500;
    public static int santeMentale = 1500;
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

    public static bool clues;

    /*Spawn Positions*/
    public static Vector3 station1 = new Vector3(21,-3.16f,0);
    public static Vector3 tunnel1 = new Vector3(95,9.65f,0);

    public static string previousScene="";
    public static string currentScene="";

    /*Objectives*/
    public static bool objective3;
    public static bool objective5;
    public static bool generators;

    /*Speech Once*/
    public static bool stationOnce;
    public static bool tunnelOnce;
    public static bool localOnce;
    public static bool caughtOnce;

    /*Monster Spawn*/
    public static bool spawnedAfterLocal;


    public static void ResetAllData()
    {
        santeMentale = maxSanteMentale;
        caughtByMonster = 0;
        TutoBreath = false;
        hasKey = false;
        Esang = false;
        Sang1 = false;
        Sang2 = false;
        Ejournal = false;
        Journal1 = false;
        Journal2 = false;
        clues = false;
        previousScene = "";
        currentScene = "";
        objective3 = false;
        objective5 = false;
        generators = false;
        stationOnce = false;
        tunnelOnce = false;
        localOnce = false;
        caughtOnce = false;
        spawnedAfterLocal = false;
    }
}
