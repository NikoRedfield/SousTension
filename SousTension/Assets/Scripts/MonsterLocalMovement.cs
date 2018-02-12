using UnityEngine;


public class MonsterLocalMovement : MonoBehaviour
{


    // Var Scale
    public Vector3 newScale;
    int size = 0;
    float newX;
    float newY;
    float newZ;
    float facteur = 1.0035f;

    // Var Movement
    private float speed = 5f;
    private GameObject player;
    private Vector3 wantedPos;
    private bool PosFound = false;
    private float distance = 20f;
    private float offset = 4f;
    private float offsetMin = 0;
    private float offsetMax = 4;

    //boolupdate
    private bool finalLocationReached = false;
    private bool mooveMonster = false;
    private bool updateSize = false;

    //CheckSanteMentale
    public int santeMentalePallier1 = 200;
    public int santeMentalePallier2 = 100;

    private void Awake()
    {

    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Scale 
        newX = this.transform.localScale.x;
        newY = this.transform.localScale.y;
        newZ = this.transform.localScale.z;

    }


    void Update()
    {
        ResizeMonster();
        MoveMonster();
        KillMonster();
        CheckSanteMentale();
    }

    void FixedUpdate()
    {
        if (finalLocationReached)
            Destroy(gameObject); // 5 	sec
        if (mooveMonster)
            transform.position = Vector3.MoveTowards(transform.position, wantedPos, speed * Time.deltaTime);
       // if (updateSize)
            //this.transform.localScale = new Vector3(newX, newY, newZ);
    }

    void ResizeMonster()
    {
        if (this.transform.localScale.x <= 2)
        {
            size++;
            newX = newX * facteur;
            newY = newY * facteur;
            newZ = newZ * facteur;
            updateSize = true;
            this.transform.localScale = new Vector3(newX, newY, newZ);
        }
       
    }

    //void movemonster()
    //{
    //    if (this.transform.localscale.x >= 2)
    //    {

    //        if (!posfound)
    //        {
    //            // distance à fix
    //            wantedpos = player.transform.position + distance * (player.transform.position - transform.position);
    //            if (player.transform.localscale.x == 2)
    //                wantedpos.x = wantedpos.x + 20;
    //            if (player.transform.localscale.x == 2)
    //                wantedpos.x = wantedpos.x - 20;
    //            posfound = true;
    //        }
    //        moovemonster = true;

    //    }
    //}

    void MoveMonster()
    {
        if (this.transform.localScale.x >= 2)
        {

            if (!PosFound)
            {
                offset = Random.Range(offsetMin, offsetMax);
                Debug.Log(offset);
                Debug.Log(speed);
                wantedPos = player.transform.position;
                if (player.transform.localScale.x == 2)
                    wantedPos.x = wantedPos.x + offset;
                else if (player.transform.localScale.x == -2)
                    wantedPos.x = wantedPos.x - offset;
                Vector3 cross = wantedPos;
                Debug.DrawLine(cross - Vector3.up / 4, cross + Vector3.up / 4, Color.red, 10.0f);
                Debug.DrawLine(cross - Vector3.right / 4, cross + Vector3.right / 4, Color.red, 10.0f);
                wantedPos = GetPointWithDirectionAndDistance(transform.position, wantedPos, distance);
                PosFound = true;
            }
            mooveMonster = true;

        }
    }

    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale >= santeMentalePallier1)
        {
            offsetMin = 0f;
            offsetMax = 4f;
            speed = 5f;
        }
        else if (PlayerData.santeMentale < santeMentalePallier1 && PlayerData.santeMentale >= santeMentalePallier2)
        {
            offsetMin = 2f;
            offsetMax = 6f;
            speed = 8f;
        }
        else if (PlayerData.santeMentale < santeMentalePallier2)
        {
            offsetMin = 4f;
            offsetMax = 8f;
            speed = 12f;
        }
    }

    void KillMonster()
    {
        if (Vector3.Distance(wantedPos, transform.position) <= 1f)
            finalLocationReached = true;
    }

    Vector3 GetPointWithDirectionAndDistance(Vector3 origin, Vector3 direction, float distance)
    {
        Vector3 point = direction - origin;
        float factor = distance / Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.y, 2)); // Get the proportion of hypotenuse
        point = origin + (point * factor);
        point.z = origin.z;
        return point;
    }

}
