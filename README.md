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

### 
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



由於 Unity 沒有全域 Root Scene，如果將 new Mediator( viewComponent ) 寫在 PureMVC 架構下，即使透過 GameObject.Find 找那個對應的 GameObject 就轉了九彎十八拐，寫起來一點都不愉快，尤其考慮到場景的轉換，兩個場景中相關 Mediator 的註冊與移除處理，何況對 Unity 組件來說，能不能用被打包動態載入是件重要的事。綜合以上問題點，反向思考，改由 GameObject 掛載中介組件，在 OnEnable 與 OnDisable 通知 Facade 去註冊與移除其 Mediator，一來簡化為了實作 Meditaor 掛載 ViewComponent 而對 static class GameObject 的依賴，二來也不會對 Unity 組件開發模式有太大的影響。
    
    // IMediatorPlug 用來處理設定 Meditaor 資料的 Unity 中介組件（當然也可以由程式指定）
    public interface IMediatorPlug{
        void Connect();
        void Disconnect();
        string GetName();
        string GetClassRef();
        //傳送 ViewComponent
        UnityEngine.Object GetView();
    }

    //Mediator 中，需要實作兩個屬性的 Constructor
    public CustomMediator(string mediatorName, object viewComponent ):base(mediatorName, viewComponent ) {}

還有一支處理 IMediatorPlug 串接的 UnityFacade ，主要兩個處理方法為：

    public void ConnectMediator( IMediatorPlug item ){...}
    public void DisconnectMediator( string mediatorName ){...}

#### 修改 MediatorPlug 的執行順序
為確保 MediatorPlug 執行時間在場景起始後，需修改 Script Execution Order。打開 Edit / Project Settings / Script Execution Order，修改如下：<br />
<a href="https://2.bp.blogspot.com/-3J5p7t3qndY/VsXuaAFpLbI/AAAAAAAA2sg/ZC4tjqohoDI/s1600/Scene1_unity_-_PureMVC_-_Web_Player__Personal___OpenGL_4_1_.png" imageanchor="1" ><img border="0" src="https://2.bp.blogspot.com/-3J5p7t3qndY/VsXuaAFpLbI/AAAAAAAA2sg/ZC4tjqohoDI/s320/Scene1_unity_-_PureMVC_-_Web_Player__Personal___OpenGL_4_1_.png" /></a>
#### 執行結果：
<a href="https://2.bp.blogspot.com/-XbAqINc91uI/VsX3m3GhafI/AAAAAAAA2sw/W_1moBWy6QQ/s1600/Scene1_unity.png" imageanchor="1" ><img border="0" src="https://2.bp.blogspot.com/-XbAqINc91uI/VsX3m3GhafI/AAAAAAAA2sw/W_1moBWy6QQ/s320/Scene1_unity.png" /></a>

最後試驗結果挺令人滿意的，轉換場景後也沒有垃圾留下來，測試專案內寫了兩種 ViewComponent <-> Mediator 與 Proxy 更新範例。



