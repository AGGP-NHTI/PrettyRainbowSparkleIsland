using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Credits : MonoBehaviour
{
    public TextAsset credits;
    public TextAsset second;
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
        Started();
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
            Second();
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
        RefreshView();
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
