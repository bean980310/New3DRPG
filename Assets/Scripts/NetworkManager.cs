using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    public string connectionIP = "127.0.0.1";
    public int portNumber = 8632;

    private bool connected = false;

    private void OnConnectedToServer()
    {
        connected = true;
    }

    private void OnServerInitialized()
    {
        connected = true;
    }

    private void OnDisconnectedFromServer()
    {
        connected = false;
    }

    private void OnGUI()
    {
        if (!connected)
        {
            connectionIP = GUILayout.TextField(connectionIP);
            int.TryParse(GUILayout.TextField(portNumber.ToString()), out portNumber);

            if (GUILayout.Button("Connect"))
            {
                Network.Connect(connectionIP, portNumber);
            }
            if (GUILayout.Button("Host"))
            {
                Network.InitializeServer(4, portNumber, true);
            }
        }
        else
        {
            GUILayout.Label("Connections : " + Network.connections.Length.ToString());
        }
        if (GUI.Button(new Rect(150, 375, 225, 50), "Back"))
        {
            Application.LoadLevel("Title");
        }
    }
}

