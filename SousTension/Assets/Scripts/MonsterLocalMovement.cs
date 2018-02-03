using UnityEngine;


public class MonsterLocalMovement : MonoBehaviour
{
	
	
    // Var Scale
    public Vector3 newScale;
    int size=0;
    float newX;
    float newY;
    float newZ;
    float facteur = 1.0035f;

    // Var Movement
    public float speed = 10f;
    private GameObject player;
    private Vector3 wantedPos;
    private bool PosFound=false;
    public float distance = 2f;


    //boolupdate
    private bool finalLocationReached = false;
    private bool mooveMonster = false;
    private bool updateSize = false;

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
       
  
    }

	void FixedUpdate()
	{
		if (finalLocationReached)
            Destroy(gameObject); // 5 	sec
        if(mooveMonster)
            transform.position = Vector3.MoveTowards(transform.position, wantedPos, speed * Time.deltaTime);
        if(updateSize)
            this.transform.localScale = new Vector3(newX, newY, newZ);

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

        }
    }

    void MoveMonster()
    {
        if (this.transform.localScale.x >= 2)
        {

            if (!PosFound)
            {
                // Distance à fix
                wantedPos = player.transform.position + distance * (player.transform.position - transform.position);

                PosFound = true;
            }
            mooveMonster = true;

        }
    }

    void KillMonster()
    {
        if (Vector3.Distance(wantedPos, transform.position) <= 1f)
            finalLocationReached = true;
    }
}
