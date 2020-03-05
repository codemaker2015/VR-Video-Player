# OmniVirt VR Player: 360° Video Player for Unity (iOS, Android, Cardboard, Gear VR, Daydream)

![Screenshot](https://github.com/Codemaker2015/VR-Video-Player/blob/master/Screenshots/Screenshot.png)

**OmniVirt** makes the leading player for 360° video experiences across mobile and desktop. Upload your 360° content to OmniVirt and serve it into your app with few easy steps.

**OmniVirt VR Player** for Unity provides you a really easy way to embed 360° content on your iOS and Android game with just few lines of code. OmniVirt VR Player could be used on **Unity 5.3 or newer**.

## Get Started

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com/vr-player/)
2. **Upload** your VR / 360° photo or video on [OmniVirt](https://www.omnivirt.com/vr-player/).
3. Keep the **Content ID** assigned to your content for further use.

## Add the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://static.omnivirt.com/sdk/unity/v2.5.4/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

## Switch Platform

Currently OmniVirt VR Player for Unity is supported only on iOS and Android. So to make it works, you need to switch platform to either iOS or Android first. To do so, click at **File -> Build Settings**, choose your target platform (iOS or Android) and then click **Switch Platform**.

Please note that if you are switching to Android then you should mention package id

## Prepare a script

You can now let you VR content played in your game with just a single line of code !

First, create an empty GameObject in the scene and rename it to `VRPlayerControl` 

And then, create a C# script and rename it to `VRPlayerControl`.

**Drag** the script and **drop** it a created GameObject to assign it to the scene.

## Launch a VR Player

The following code snippet is used to launch a VR Player.

```csharp
vrPlayer.LoadAndPlay (CONTENT_ID,    // Replace your Content ID here
                      true           // Cardboard Enabled; false for non-VR mode
                      );
```

Replace `CONTENT_ID` with a **Content ID** got from step above to let it play the specific content you need, for example,

```csharp

using OmniVirt;

public class VRPlayerControl : MonoBehaviour {

    VRPlayer vrPlayer;

    // Use this for initialization
    void Start () {
        // Create VR Player instance
        vrPlayer = new VRPlayer ();

        // Register Callback for Video Playing Completion Event
        vrPlayer.OnVideoEnd += OnVRPlayerEnded;
        vrPlayer.OnUnloaded += OnVRPlayerUnloaded;

        // Play
        vrPlayer.LoadAndPlay (47793, true);  // Use your Content ID here
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    /*************************
      Callback for VR Player
    *************************/

    // Video Playing Completion Event
    void OnVRPlayerEnded() {
        // Automatically close the player after played
        if (vrPlayer != null)
            vrPlayer.Unload ();
    }

    // VR Player Unloaded Event
    void OnVRPlayerUnloaded() {
        vrPlayer = null;		
    }
}
```

You can now build project and run to test the VR Player.

## Extra: Earn Money

Would like to earn money from your 360° content? You can create an **Ad Space** on [OmniVirt](www.omnivirt.com) and pass the **Ad Space ID** acquired to the command like shown below to enable ad on the player.

```csharp
vrPlayer.LoadAndPlay (CONTENT_ID,    // Your Content ID
                      AD_SPACE_ID,   // Your Ad Space ID
                      true           // Cardboard Enabled; false for non-VR mode
                      );
```

Once you set it up correctly, user will sometime see an preroll-ad before the content is played and that will turn into your revenue !

## Player Callback

Any change on the player could be detected by registering a callback function in the pattern like this.

```csharp
void Start () {
    ...
    
    // Register a Callback
    vrPlayer.OnVideoEnd += OnVRPlayerEnded;
}

// Video Playing Completion Event
void OnVRPlayerEnded() {

}
```

These are the list of callback functions available.

- **`OnVideoReady()`**

  Called when video is ready to play.

- **`OnVideoEnd()`**

  Called when VR Player has finished playing.

- **`OnUnloaded()`**

  Called when VR Player has been destroyed.


## Day Dream Controller Support

Since Day Dream game controller support is required on Day Dream compatible application / game, OmniVirt SDK also provides support on this funcionality as well. You can enable it with some easy following steps.

1) Import [Google VR SDK for Unity](https://github.com/googlevr/gvr-unity-sdk/releases) into your project. If your application or game is built for Day Dream, it supposes to have this SDK installed in your project already.

2) Add `GvrControllerMain` and `GvrEditorEmulator` prefab to the scene.

3) Add `OmniVirtGameController` script to **`GvrControllerMain`** game object. (It is important to add script to the correct one otherwise it would not work).

That's all. Day Dream controller will now magically work with our VR Player in Day Dream mode !