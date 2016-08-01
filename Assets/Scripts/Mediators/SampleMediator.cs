using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using PureMVC.Core;
using System.Collections.Generic;
/// <summary>
/// Sample mediators.
/// </summary>
public class SampleMediator :  Mediator, IFWMediator{

	//member data
	//m_mediatorName
	//m_viewComponent
	//NAME="Mediator"

	//get set
	//ViewComponent
	//MediatorName {get]
	public static string NAME="smapleMediator";
	private IList<string> notificationList=new List<string>();

	public SampleMediator()
	{
		init ();
	}
	public SampleMediator(string mediatorName):base(mediatorName)
	{
		init ();
	}
	public SampleMediator(string mediatorName,object viewComponent):base(mediatorName,viewComponent)
	{
		init ();
	}

	private void init()
	{
		notificationList.Add(Notification.SMAPLE_NOTIFICATION);
	}

	public override void HandleNotification(INotification notification)
	{
		Debug.Log ("Receive "+notification.Name);
	}
	public override  IList<string>ListNotificationInterests()
	{
		return notificationList;
	}
	public override void OnRegister()
	{
		Debug.Log (MediatorName+ " onRegisterd.");
	}
	public override void OnRemove ()
	{
		
	}

}
