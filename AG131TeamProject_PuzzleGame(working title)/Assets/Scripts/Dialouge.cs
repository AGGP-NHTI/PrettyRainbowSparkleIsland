using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialouge : MonoBehaviour
{
    public TextAsset untranslated;
    public TextAsset translated;
    private Story dialouge;
    public Canvas canvas;

    public Text textprefab;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Untranslated()
    {
        dialouge = new Story(untranslated.text);
    }
   public void Translated()
    {
        dialouge = new Story(translated.text);
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


        if (dialouge.currentChoices.Count > 0)
        {
            for (int i = 0; i < dialouge.currentChoices.Count; i++)
            {
                Choice choice = dialouge.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());

                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }

        else
        {
            Button choice = CreateChoiceView("Exit");
            choice.onClick.AddListener(delegate {
                RemoveChildren();
            });
        }
    }
    
    void OnClickChoiceButton(Choice choice)
    {
        dialouge.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

 
    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textprefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }


    Button CreateChoiceView(string text)
    {

        Button choice = Instantiate(button) as Button;
        choice.transform.SetParent(canvas.transform, false);


        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;


        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }
}
