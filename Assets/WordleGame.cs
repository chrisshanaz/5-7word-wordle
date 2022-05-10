using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordleGame : MonoBehaviour
{
	public Text[] word7;
	public Text[] word6;
	public Text[] word5;
	public Text userInputText;
	
	private int wordLength;
	[SerializeField]
	private GameObject handler;

	public string[] words;
	public string userInput;
	public string selectedWord;
	public GameObject[] wordleRows;
	
	public void Start(){
		NewGame();
	}
	
    void NewGame(){
		selectedWord = words[Random.Range(0, words.Length)];
		foreach(GameObject row in wordleRows){
			row.SetActive(false);
		}
		
		if(selectedWord.Length == 7){
			wordleRows[0].SetActive(true);
			handler = wordleRows[0];
		}
		if(selectedWord.Length == 6){
			wordleRows[1].SetActive(true);
			handler = wordleRows[1];
		}
		if(selectedWord.Length == 5){
			wordleRows[2].SetActive(true);
			handler = wordleRows[2];
		}
		
		wordLength = selectedWord.Length;
	}

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                handler.GetComponent<WordleHandler>().UpdateText(true, c.ToString());
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                handler.GetComponent<WordleHandler>().UserPressedEnter();
            }
            else
            {
                handler.GetComponent<WordleHandler>().UpdateText(false, c.ToString());
            }
			userInput = userInputText.text;
        }
    }
}
