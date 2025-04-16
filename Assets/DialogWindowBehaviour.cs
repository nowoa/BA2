using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogWindowBehaviour : MonoBehaviour
{
    public Animator characterSpriteAnimator;

    public TMP_Text textField;
    public Animator CharacterSpriteAnimator;
    public float typeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TypeText(string message)
    {
        characterSpriteAnimator.SetBool("isTalking", true);
        textField.text = "";
        
        foreach (char letter in message)
        {
            textField.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        
        characterSpriteAnimator.SetBool("isTalking",false);
    }
}
