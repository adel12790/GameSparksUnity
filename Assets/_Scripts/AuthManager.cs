using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour {

    public InputField displayName, username, password;
    public Button Loginbtn, Registerbtn;
    public Text status;

    public void Register(string displayName, string username, string password)
    {
        Debug.Log("Registering...");
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayName)
            .SetUserName(username)
            .SetPassword(password)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log(response.DisplayName + " registered successfully");
                }
                else
                {
                    Debug.LogError("couldn't register, Error: " + response.Errors);
                }

            });
    }

    public void Login(string username, string password)
    {
        Debug.Log("Login...");
        new GameSparks.Api.Requests.AuthenticationRequest()
                    .SetUserName(username)
                    .SetPassword(password)
                    .Send((response) =>
                    {
                        if (!response.HasErrors)
                        {
                            Debug.Log(response.DisplayName + " registered successfully");
                        }
                        else
                        {
                            Debug.LogError("couldn't register, Error: " + response.Errors);
                        }

                    });
    }

    public void LoginByDeviceInfo(string displayName)
    {
        Debug.Log("Device Login...");
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName(displayName)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log(response.DisplayName + " registered successfully");
                }
                else
                {
                    Debug.LogError("couldn't register, Error: " + response.Errors);
                }

            });
    }

    // Utilities
    private void ToggleButtonStates(bool toState)
    {
        Registerbtn.interactable = toState;
        Loginbtn.interactable = toState;
    }

    private void UpdateStatus(string message)
    {
        status.text = message;
    }
}
