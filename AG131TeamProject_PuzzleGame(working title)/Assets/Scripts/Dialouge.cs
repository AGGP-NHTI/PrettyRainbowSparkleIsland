//NOTE: PRIMARILY USES BASICINKSCRIPT FROM PLUGIN, BASICINKSCRIPT PROVIDED BY INK.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialouge : MonoBehaviour
{
   
    public TextAsset translated;
    private Story dialouge;
    public Canvas canvas;

    public float timer;
    public float starttimer = 5.0f;

    int counter;

    public Text textprefab;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        timer = starttimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        counter = (int)Mathf.Ceil(timer);

        if (counter == 0)
        {
            RemoveChildren();
            timer = starttimer;
        }
    }

   public void Translated()
    {
        RemoveChildren();
        dialouge = new Story(translated.text);
        RefreshView();
    }
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            if(canvas.transform.GetChild(i).gameObject != canvas.transform.Find("crosshair").gameObject)
            {
                GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
            }
            
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
