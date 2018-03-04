using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{

    public InputField displayName, username, password;
    public Button Loginbtn, Registerbtn;
    public Text status;

    private void Awake()
    {
        ToggleButtonStates(false);
    }

    public void ValidateFields()
    {
        if (username.text != "" && password.text != "")
        {
            ToggleButtonStates(true);
        }
        else
        {
            ToggleButtonStates(false);
        }
    }

    public void OnRegister()
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
                    UpdateStatus(response.DisplayName + " registered successfully");
                }
                else
                {
                    UpdateStatus("couldn't register, Error: " + response.Errors);
                    Debug.LogError("couldn't register, Error: " + response.Errors);
                }

            });
    }

    public void OnLogin()
    {
        Debug.Log("Login...");
        new GameSparks.Api.Requests.AuthenticationRequest()
                    .SetUserName(username.text)
                    .SetPassword(password.text)
                    .Send((response) =>
                    {
                        if (!response.HasErrors)
                        {
                            UpdateStatus(response.DisplayName + " Logged in successfully");
                            SceneManager.LoadScene("Leaderboard");

                        }
                        else
                        {
                            UpdateStatus("couldn't register, Error: " + response.Errors);
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
                    UpdateStatus(response.DisplayName + " registered successfully");
                }
                else
                {
                    UpdateStatus("couldn't register, Error: " + response.Errors);
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

