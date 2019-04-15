using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Dialouge : MonoBehaviour
{
    public TextAsset untranslated;
    public TextAsset translated;
    private Story dialouge;
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
}
