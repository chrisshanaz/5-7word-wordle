using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WordleHandler : MonoBehaviour
{
    public Image[] row1image;
	public Image[] row2image;
	public Image[] row3image;
	public Image[] row4image;
	public Image[] row5image;
	public Image[] row6image;
	
	public int AmountOfLetters;
	
	public string answerString;
	
	public int rowNumber = 0;
	public Text[] texts;
	
	public string spaces;
	
	public void UpdateText(bool didDelete, string character)
	{
		if(!didDelete)
		{
			texts[rowNumber].text = texts[rowNumber].text + character + spaces;
		} else 
		{
			if(texts[rowNumber].text.Length != 0)
                {
                    texts[rowNumber].text = texts[rowNumber].text.Substring(0, texts[rowNumber].text.Length - (1 + spaces.Length));
                }
		}
	}
	
	
    public void UserPressedEnter(){
		
		
		answerString = texts[rowNumber].text.Replace(" ", string.Empty);
		
		if(answerString.Length != AmountOfLetters){
			return;
			// string isn't long enough
		}
		rowNumber += 1;
	}
}
 