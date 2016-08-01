using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Main.
/// This is a unity pureMVC example framwork.
/// Core 
/// 	Model:	Singleton pattern.
/// 			Holding reference to all proxies.
/// 	View:	Singleton pattern.
/// 			Holding reference to all mediators.
/// 	Controller:	Singleton pattern.
/// 			Holding reference to all commands.
/// Interact
/// 	Ovserver/Notification pattern.
/// 
/// Facade
/// 	Facade pattern.
/// 	Only entrance to Model/View/Controller.
/// 	Register proxy/mediator/command
/// 	Remove proxy/mediator/command
/// 	Retrive proxy/mediator/command
/// 	Holding notification mapping to command and mediator.
/// 	When notification sent the mapping command's public function Execute will be called by Controller.
/// 	When notification sent the mapping mediator's public funciton HandleNotification will be called by View.
/// Flow Input/control->command->proxy->mediator.
/// Command:
/// 	Send and receive notifications.
/// 	
/// Proxy:
/// 	Receive notifications only.
/// 	
/// Mediator:
/// 	Send and receive notifications.
/// </summary>
public class Main : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UnityFacade.GetInstance().StartUp();
	}

}
