using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SignIn();
    }
      public void SignIn() {
      PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

       internal void ProcessAuthentication(SignInStatus status) {
      if (status == SignInStatus.Success) {
        // Continue with Play Games Services
      } else {
        // Disable your integration with Play Games Services or show a login button
        // to ask users to sign-in. Clicking it should call
        // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
      }
    }
}
