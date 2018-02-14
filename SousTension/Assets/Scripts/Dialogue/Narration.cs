using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Narration : MonoBehaviour
{

    //AddSpriteImage
    public GameObject textArea;

    public Dialogue[] dialogues;
    public GameObject dialogueUI;
    public bool hasChoice = false;
    public bool isChoice = false;
    public ChoiceNarration choice;
    public GameObject fadeLayout;
    public RectTransform panel;
    public Narration followUpDialogue = null;

    public GameObject fadePortrait1;
    public GameObject portrait2;
    public string NextScene;

    public ScrollRect scroll;

    private Queue<Dialogue> Qdialogues;
    private Dialogue currentDialogue;

    private GameObject currentTextArea;
    private Text mtext;

    private bool choiceEngaged = false;

    private bool isLaunched = false;

    private bool dover = false;

    private GameObject portraitTheo;
    private GameObject portraitTheoZero;
    private AudioSource source;

    public Font nameFont;
    public Font dialFont;
    public string color = "#ffb83c";

    private IEnumerator coroutine;

    public GameObject SpecialQTE;

    //Launching Dialogue
    public void StartDialogue()
    {
        source = GameObject.Find("SFX_Manager").GetComponent<AudioSource>();
        portraitTheoZero = GameObject.Find("PortraitTheo");
        portraitTheo = portraitTheoZero.transform.GetChild(0).gameObject;

        isLaunched = true;

        currentTextArea = (GameObject)Instantiate(textArea);
        currentTextArea.transform.SetParent(panel);
        Qdialogues = new Queue<Dialogue>();
        mtext = currentTextArea.GetComponent<Text>();
        choiceEngaged = false;

        EventSystem.current.SetSelectedGameObject(currentTextArea.gameObject);


        Debug.Log("Engaging a new conversation ");

        Qdialogues.Clear();

        foreach (Dialogue dialogue in dialogues)
        {
            Qdialogues.Enqueue(dialogue);

        }
        currentDialogue = Qdialogues.Dequeue();
        
        if(currentDialogue.clip != null)
        {
            source.clip = currentDialogue.clip;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }

        if (currentDialogue.npcName != "")
        {
            mtext.text += "\n";
            mtext.font = nameFont;
            if (currentDialogue.npcName != "Theo :")
            {
                mtext.text = mtext.text + "<size=24><color=" + PickNPCcolor(currentDialogue.npcName) + "><b>   " + currentDialogue.npcName;
            }
            if(currentDialogue.npcName == "Theo :")
            {
                mtext.text = mtext.text + "<size=24><color=#6db5ff><b>   " + currentDialogue.npcName;
            }
            if(currentDialogue.indication != "")
            {
                mtext.font = dialFont;
                mtext.text += "<i>" + currentDialogue.indication + "</i>";
            }
            mtext.text += "</b></color></size>\n\n";
            currentTextArea = (GameObject)Instantiate(textArea);
            currentTextArea.transform.SetParent(panel);
            mtext = currentTextArea.GetComponent<Text>();
            mtext.font = dialFont;
            if(currentDialogue.npcName != "Theo :" && currentDialogue.npcName != "Théo (à lui-même) :")
            {
                fadePortrait1.SetActive(false);
                portraitTheo.SetActive(true);
                Debug.Log(currentDialogue.npcName);
                fadePortrait1.GetComponent<Image>().sprite = currentDialogue.portrait;
                portrait2.GetComponent<Image>().sprite = currentDialogue.portrait;
            }
            else
            {

                portraitTheo.SetActive(false);
                fadePortrait1.SetActive(true);
                portraitTheoZero.GetComponent<Image>().sprite = currentDialogue.portrait;
                portraitTheo.GetComponent<Image>().sprite = currentDialogue.portrait;

            }
            mtext.text += "<size=20><color=white></color></size>";
            coroutine = PlayText(15);
        }
        if (currentDialogue.npcName == "")
        {
           mtext.text += "<size=20><color=white><i></i></color></size>";
           coroutine = PlayText(19);
            portraitTheo.SetActive(true);
            fadePortrait1.SetActive(true);

        }
        StartCoroutine(coroutine); 
      // currentTextArea = (GameObject)Instantiate(textArea);
       // currentTextArea.transform.SetParent(panel);
    }

    //Continuing the dialogue to the next Sequence
    public void Update()
    {
        if (isLaunched)
        {
           if ((Input.GetKeyDown("space") || Input.GetButtonDown("Submit")) && dover)
            {
                
                dover = false;
                currentTextArea = (GameObject)Instantiate(textArea);
                currentTextArea.transform.SetParent(panel);
                mtext = currentTextArea.GetComponent<Text>();

                StopAllCoroutines();
                fadeLayout.SetActive(false);
                if (Qdialogues.Count == 0)
                {
                    if (!choiceEngaged)
                    {
                        EndDialogue();
                    }
                    return;
                }
                currentDialogue = Qdialogues.Dequeue();
                
                if (currentDialogue.clip != null)
                {
                    source.Stop();
                    source.clip = currentDialogue.clip;
                    if (!source.isPlaying)
                    {
                        source.Play();
                    }
                }

                portraitTheo.SetActive(true);
                fadePortrait1.SetActive(true);

                if (currentDialogue.npcName != "")
                {

                    mtext.font = nameFont;
                    if (currentDialogue.npcName != "Theo :")
                    {
                        mtext.text = mtext.text + "<size=24><color=" + PickNPCcolor(currentDialogue.npcName) + "><b>   " + currentDialogue.npcName;
                    }
                    if (currentDialogue.npcName == "Theo :")
                    {
                        mtext.text = mtext.text + "<size=24><color=#6db5ff><b>   " + currentDialogue.npcName;
                    }
                   
                    mtext.text += "</b></color></size>";

                    if (currentDialogue.indication != "")
                    {
                        GameObject oldText = currentTextArea;
                        currentTextArea = (GameObject)Instantiate(textArea);
                        currentTextArea.transform.SetParent(oldText.transform);
                        currentTextArea.transform.position = new Vector3(currentTextArea.transform.position.x + currentDialogue.spacingIndication, currentTextArea.transform.position.y, currentTextArea.transform.position.z);
                        mtext = currentTextArea.GetComponent<Text>();
                        mtext.font = dialFont;
                        mtext.text += "<size=20><color=" + PickNPCcolor(currentDialogue.npcName)+ "><i>" + currentDialogue.indication + "</i></color></size>";
                    }

                    currentTextArea = (GameObject)Instantiate(textArea);
                    currentTextArea.transform.SetParent(panel);
                    mtext = currentTextArea.GetComponent<Text>();
                    mtext.font = dialFont;
                    if (currentDialogue.npcName != "Theo :" && currentDialogue.npcName != "Théo (à lui-même) :")
                    {
                       fadePortrait1.SetActive(false);
                        portraitTheo.SetActive(true);
                        Debug.Log(currentDialogue.npcName);
                        fadePortrait1.GetComponent<Image>().sprite = currentDialogue.portrait;
                        portrait2.GetComponent<Image>().sprite = currentDialogue.portrait;
                    }
                    else
                    {
                        portraitTheo.SetActive(false);
                        fadePortrait1.SetActive(true);
                        portraitTheoZero.GetComponent<Image>().sprite = currentDialogue.portrait;
                        portraitTheo.GetComponent<Image>().sprite = currentDialogue.portrait;
                    }
                }

                if (currentDialogue.sentence != "")
                {
                    if(currentDialogue.npcName == "")
                    {
                        mtext.text += "\n<size=20><color=white><i></i></color></size>";
                        coroutine = PlayText(19);
                    }
                    else
                    {
                        mtext.text += "\n<size=20><color=white></color></size>";
                        coroutine = PlayText(15);
                    }
                   
                    StartCoroutine(coroutine);
                }
                else
                {
                    dover = true;
                }
            }


        }
    }

    //Ending The Conversation
    private void EndDialogue()
    {
        if (hasChoice && dialogueUI.activeSelf)
        {
            choiceEngaged = true;
            portraitTheo.SetActive(false);
            fadePortrait1.SetActive(true);
            
            choice.LaunchChoice();
            return;
        }

        if(SpecialQTE != null)
        {
            fadePortrait1.SetActive(true);
            portraitTheo.SetActive(true);
            SpecialQTE.SetActive(true);
            return;
        }

        if (followUpDialogue != null)
        {
            followUpDialogue.StartDialogue();
            Debug.Log("Follow up started");
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
  
        }
        else
        {
            Debug.Log("Ending Conversation...");
            dialogueUI.SetActive(false);

            StopAllCoroutines();
            fadeLayout.SetActive(true);
            //fadeLayout.GetComponent<FadeManager>().ChangeColor(Color.black, new Color(0, 0, 0, 0));
            if (NextScene.Equals("backingame"))
            {
                dialogueUI.transform.parent.gameObject.SetActive(false);
                fadeLayout.GetComponent<FadeManager>().Fade(false, 2f);
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
                return;
            }
            fadeLayout.GetComponent<FadeManager>().Fade(false, 30f);
            choiceEngaged = false;
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
            if (NextScene.Equals("Bonus"))
            {
                if(PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.5)
                {
                    StartCoroutine(FadeThenLoad());
                    return;
                }
                else
                {
                    NextScene = "End";
                    StartCoroutine(FadeThenLoad());
                    return;
                }
            }
            if (NextScene != "" && NextScene != "backingame")
            {
                // SceneManager.LoadScene(NextScene);
                StartCoroutine(FadeThenLoad());
            }
           
           // StartCoroutine(FadeThenLoad());
        }
    }

    IEnumerator PlayText(int i)
    {
        float delay = 0f;
        foreach (char c in currentDialogue.sentence)
        {
            mtext.text = mtext.text.Substring(0, mtext.text.Length - i) + c + mtext.text.Substring(mtext.text.Length - i);
            if (!dover) {             
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetButtonDown("Submit") && !dover)
            {
                dover = true;
            }
        }
        mtext.text = mtext.text + "\n";
        dover = true;
    }

    IEnumerator FadeThenLoad()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(NextScene);
    }

    private string PickNPCcolor(string name)
    {
        switch (name)
        {
            case "Leanne :":
                return "#ffb83c";
            case "Enrique :":
                return "#0da156";
            case "Franck :":
                return "#cd4414";
            case "SDF :":
                return "#782cd5";
            case "Theo :":
                return "#6db5ff";

            default:
                return "npc error color name";
        }

    }

}
