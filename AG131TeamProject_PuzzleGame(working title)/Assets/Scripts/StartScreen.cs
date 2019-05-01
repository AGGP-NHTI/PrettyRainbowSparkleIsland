using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class StartScreen : MonoBehaviour
{

    public TextAsset start;
    private Story startup;
    public Canvas canvas;

    public Text textprefab;
    public Button button;

    string main = "MainIsland";

    // Start is called before the first frame update
    void Start()
    {
        Screen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Screen()
    {
        RemoveChildren();
        startup = new Story(start.text);
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


        while (startup.canContinue)
        {

            string text = startup.Continue();

            text = text.Trim();

            CreateContentView(text);
        }



    }


    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textprefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    
    	// Display all the choices, if there are any!
		if(startup.currentChoices.Count > 0) {
			for (int i = 0; i<startup.currentChoices.Count; i++) {
				Choice choice = startup.currentChoices[i];
        Button button = CreateChoiceView(choice.text.Trim());
    // Tell the button what to do when we press it
        button.onClick.AddListener(delegate {
					OnClickChoiceButton(choice); });

			}
		}
	
	
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
    {
    startup.ChooseChoiceIndex(choice.index);
        if (choice.text == "Start Game")
        {
            SceneManager.LoadScene(main);
        }
        else if (choice.text == "Exit Game")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        RefreshView();
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

