# Unity-PureMVC Framework
This is a Unity PureMVC framework contains pureMVC only and there is nothing else.


[PureMVC C# Standard Framework on GitHub](https://github.com/PureMVC/puremvc-csharp-standard-framework)

### Core

Model is singleton instance contains all references to proxies.   
View is singleton instance contains all references to mediators.
Controller is singleton instance contains all references to commands.

### Facade
Facade is singleton instance either.
This is the only entrance to access Model/View/Controller.

### Command/Mediator/Proxy
Command is a class which contains program logic.
    Receive and send notification.
Mediator is a class which contains viewComponent and manipulates it.
    Receive and send notification.
Proxy is a class which contains data and manipulates it.
    Proxy send notification only.

## Usage
Register command with a notification in Facade.
Now the command we just registered can receive notification.
We may register mediator and proxy in command or Facade.


## Example
In this case we make a following process flow :
Command -> Execute ->Register Proxy and Mediator-> Proxy send notification -> Mediator receive notification

####Sample command
```cs
public class StartUpCommand : PureMVC.Patterns.SimpleCommand {
	public override void Execute(PureMVC.Interfaces.INotification notification)
	{
		Debug.Log("Execute StartUpCommand");
        //Register proxy and mediator
		Facade.RegisterProxy( new SampleProxy("proxyName" ) );
		Facade.RegisterMediator (new SampleMediator("mediatorName"));


		SampleProxy proxy=Facade.RetrieveProxy ("porxyName) as SampleProxy;

		//Call function to SendNotification
		proxy.CallFunc ();

		//SampleMediator shoud receive notification and execute HandleNotification function 

	}
}
```

####Sample proxy
'''cs
public class SampleProxy : Proxy,IFWProxy{

	public static string NAME="sampleProxy";
	private SampleModel sm=new SampleModel(0,"name");

	public SampleProxy () 
	{
	}
	public SampleProxy(string proxyName):base(proxyName)
	{
		
	}
	public SampleProxy(string proxyName,object data):base(proxyName,data)
	{
		
	}

	public override void OnRegister ()
	{
		Debug.Log ("SampleProxy OnRegister");

	}

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
'''

####Sample mediator
```cs
public class SampleMediator :  Mediator, IFWMediator{
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
		Debug.Log (MediatorName+ " OnRegister.");
	}
	public override void OnRemove ()
	{
		Debug.Log (MediatorName+ " OnRemove.");
	}
}
```