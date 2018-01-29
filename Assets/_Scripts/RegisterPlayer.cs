using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPlayer : MonoBehaviour
{

    public Text displayName, username, password;


    public void Register()
    {
        Debug.Log("Registering...");
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayName.text)
            .SetUserName(username.text)
            .SetPassword(password.text)
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

    public void Login()
    {
        Debug.Log("Login...");
        new GameSparks.Api.Requests.AuthenticationRequest()
                    .SetUserName(username.text)
                    .SetPassword(password.text)
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

    public void LoginByDeviceInfo()
    {
        Debug.Log("Device Login...");
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName(displayName.text)
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
}
