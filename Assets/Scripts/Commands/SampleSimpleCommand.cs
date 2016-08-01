using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class SampleSimpleCommand :  SimpleCommand
{
	override public void Execute(PureMVC.Interfaces.INotification notification)
	{
		//Facade.RegisterProxy( new SampleProxy( ) );
	}
}

