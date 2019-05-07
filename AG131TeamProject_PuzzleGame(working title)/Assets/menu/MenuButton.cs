using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){

                animator.SetBool("pressed", true);
           

            }
            else if (animator.GetBool ("pressed")){
				animator.SetBool ("selected", false);
                    SceneManager.LoadScene("MainIsland");
                animatorFunctions.disableOnce = true;
			}
            
     
		}
        else
        {
			animator.SetBool ("selected", false);
            Application.Quit();
            //SceneManager.LoadScene("Quit");
        }
    }
}
