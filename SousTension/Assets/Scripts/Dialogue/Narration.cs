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
    public string color = "yellow";

    private IEnumerator coroutine;
    

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
                mtext.text = mtext.text + "<size=24><color=" + color + "><b>   " + currentDialogue.npcName;
            }
            if(currentDialogue.npcName == "Theo :")
            {
                mtext.text = mtext.text + "<size=24><color=#e2d5e7><b>   " + currentDialogue.npcName;
            }
            if(currentDialogue.indication != "")
            {
                mtext.text += "<i>" + currentDialogue.indication + "</i>";
            }
            mtext.text += "</b></color></size>\n\n";
            currentTextArea = (GameObject)Instantiate(textArea);
            currentTextArea.transform.SetParent(panel);
            mtext = currentTextArea.GetComponent<Text>();
            mtext.font = dialFont;
            if(currentDialogue.npcName != "Theo :" || currentDialogue.npcName != "Théo (à lui-même) :")
            {
                fadePortrait1.SetActive(false);
                fadePortrait1.GetComponent<Image>().sprite = currentDialogue.portrait;
                portrait2.GetComponent<Image>().sprite = currentDialogue.portrait;
            }
            else
            {
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
                        mtext.text = mtext.text + "<size=24><color=" + color + "><b>   " + currentDialogue.npcName;
                    }
                    if (currentDialogue.npcName == "Theo :")
                    {
                        mtext.text = mtext.text + "<size=24><color=#e2d5e7><b>   " + currentDialogue.npcName;
                    }
                    if (currentDialogue.indication != "")
                    {
                        mtext.text += " <i>" + currentDialogue.indication + "</i>";
                    }
                    mtext.text += "</b></color></size>";
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

            choice.LaunchChoice();
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
            fadeLayout.GetComponent<FadeManager>().Fade(false, 30f);
            choiceEngaged = false;
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
            if (NextScene != "")
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

}
