using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;

/// <summary>
/// Sample proxy is a pureMVC proxy sample.
/// -----
/// Attributes
/// protected m_proxyName
/// protected m_data
/// static NAME="Proxy"
/// -----
/// Get/Set
/// string ProxyName [get]
/// object Data[get,set]
/// </summary>
public class SampleProxy : Proxy,IFWProxy
{

	public static string NAME="sampleProxy";
	private SampleModel sm=new SampleModel(0,"name");

	/// <summary>
	/// Initializes a new instance of the <see cref="SampleProxy"/> class.
	/// </summary>
	/// <param name="proxyName">Proxy name.</param>
	public SampleProxy () 
	{
	}
	public SampleProxy(string proxyName):base(proxyName)
	{
		
	}
	public SampleProxy(string proxyName,object data):base(proxyName,data)
	{
		
	}
	/// <summary>
	/// Raises the register event.
	/// </summary>
	public override void OnRegister ()
	{
		Debug.Log ("SampleProxy OnRegister");
//		SendNotification ("");
	}

	/// <summary>
	/// Raises the remove event.
	/// </summary>
	public override void OnRemove ()
	{
		Debug.Log ("SampleProxy OnRemove");
	}
		

	public void CallFunc()
	{
		Debug.Log ("SampleProxy Callfunc");
		SendNotification (Notification.SMAPLE_NOTIFICATION,1);
	}
}

