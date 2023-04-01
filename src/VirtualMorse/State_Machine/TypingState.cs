﻿using System;
using System.IO;

public class TypingState : State
{
	protected StateMachine stateMachine;

    string lastLetter = "";
	bool isCapitalized = false;

	//state functions
	public TypingState(StateMachine stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	public override void dot()
    {
		Console.WriteLine("storing dot");
		addDot();
	}

	public override void dash()
    {
		Console.WriteLine("storing dash, if TTT is entered: read entire page and clear TTT");
		addDash();
	}

    public override void space()
    {
		if(stateMachine.currentWord != "")
        {
			stateMachine.appendToDocument(stateMachine.currentWord);
			clearWord();
            Console.WriteLine("added word to file: " + stateMachine.currentWord);
        }
        else
        {
            stateMachine.appendToDocument(" ");
            Console.WriteLine("SPACE added to file");
        }
	}

    public override void shift()
    {
		toggleCapitalized();
		Console.WriteLine("capitalization set to: " + isCapitalized);
	}

    public override void enter()
    {
		if (stateMachine.currentLetter == "" && lastLetter != "")
		{
            addLetterToWord(lastLetter);
            Console.WriteLine("added letter: " + lastLetter);
        }
		else
        {
            string c = Function.morseToText(stateMachine.currentLetter);
            if (c != "")
            {
                if (isCapitalized)
                {
                    c = c.ToUpper();
                    isCapitalized = false;
                }
                addLetterToWord(c);
                Console.WriteLine("added letter: " + c);
            }
            else
            {
                clearLetter();
                Console.WriteLine("not a valid letter, try again");
            }
        }
	}

    public override void backspace()
    {
		if (stateMachine.currentLetter.Length > 0)
		{
			clearLetter();
            Console.WriteLine("Clearing morse symbols");
        }
		else if (stateMachine.currentWord.Length > 0)
		{
			stateMachine.currentWord = stateMachine.currentWord.Remove(stateMachine.currentWord.Length - 1, 1);
			Console.WriteLine("Delete");
		}
		else
		{
			stateMachine.backspaceDocument();
			Console.WriteLine("Backspace");
		}
	}

    public override void save()
    {
		Console.WriteLine("save text doc as is");
		Console.WriteLine("says 'now saving'");
		stateMachine.saveDocumentFile();
    }

    public override void command()
    {
		Console.WriteLine("move to command state");
		stateMachine.setState(stateMachine.getCommandState());
    }

	//helper functions
	public void addDot()
	{
		stateMachine.currentLetter += '.';
	}

	public void addDash()
	{
		stateMachine.currentLetter += '-';
	}

	public void clearLetter()
	{
		stateMachine.currentLetter = "";
	}

	public void addLetterToWord(string c)
	{
		stateMachine.currentWord += c;
		lastLetter = c;
		clearLetter();
	}
	public void clearWord()
	{
		stateMachine.currentWord = "";
	}

	public void toggleCapitalized()
	{
		isCapitalized = !isCapitalized;
	}
}
