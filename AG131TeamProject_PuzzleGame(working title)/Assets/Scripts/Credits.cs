using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public TextAsset credits;
    public TextAsset second;
    public TextAsset music;
    public TextAsset mainisland;
    public TextAsset iceisland;
    private Story dialouge;
    public Canvas canvas;

    string start = "Start";

   
   public bool startmusic = false;
   public bool startmainisland = false;
   public bool starticeisland = false;
   public  bool endgame = false;
    bool transition = false;

    public float timer;
    public float starttimer = 5.0f;

    int counter;

    public Text textprefab;

    // Start is called before the first frame update
    void Start()
    {
        timer = starttimer;
        Started();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        counter = (int)Mathf.Ceil(timer);

        if (counter == 0)
        {
            if (startmusic == false && startmainisland == false && starticeisland == false && endgame == false)
            {
                RemoveChildren();
                timer = starttimer;
          
                Second();
            }
            else if(startmusic == true && startmainisland == false)
            {
                timer = starttimer;
             
                Music();
            }
            else if (startmainisland == true && starticeisland == false)
            {
                timer = starttimer;
               
                MainIsland();
            }
            else if (starticeisland == true && endgame == false)
            {
                timer = starttimer;
               
                IceIsland();
            }
            else if (endgame == true)
            {
                Return();
            }

        }
    }
    public void Started()
    {
        RemoveChildren();
        dialouge = new Story(credits.text);
        RefreshView();
    }
    public void Second()
    {
        RemoveChildren();
        dialouge = new Story(second.text);
        startmusic = true;
        RefreshView();
    }
    public void Music()
    {
        RemoveChildren();
        dialouge = new Story(music.text);
        startmusic = false;
        startmainisland = true;
        RefreshView();
    }
    public void MainIsland()
    {
        RemoveChildren();
        dialouge = new Story(mainisland.text);
        startmainisland = false;
        starticeisland = true;
        RefreshView();
    }
    public void IceIsland()
    {
        RemoveChildren();
        dialouge = new Story(iceisland.text);
        starticeisland = false;
        endgame = true;
        RefreshView();
    }
    public void Return()
    {
        RemoveChildren();
        SceneManager.LoadScene(start);
    }
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }
    void RefreshView()
    {

        RemoveChildren();


        while (dialouge.canContinue)
        {

            string text = dialouge.Continue();

            text = text.Trim();

            CreateContentView(text);
        }



    }


    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textprefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }
}
