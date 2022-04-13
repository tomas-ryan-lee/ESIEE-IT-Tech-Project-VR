using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;

public class TwitchManager : MonoBehaviour
{
    public string m_username;
    public string m_password;
    public string m_channelName;

    private TcpClient m_twitchClient;
    private StreamReader m_reader;
    private StreamWriter m_writer;
    private float m_reconnectTimer;
    private float m_reconnectAfter; 

    // Start is called before the first frame update
    void Start()
    {
        m_reconnectAfter = 60.0f;
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_twitchClient.Available == 0)
        {
            m_reconnectTimer += Time.deltaTime;
        }

        if (m_twitchClient.Available == 0 && m_reconnectTimer >= m_reconnectAfter)
        {
            Connect();
            m_reconnectTimer = 0.0f;
        }

        ReadChat();
    }

    private void Connect()
    {
        m_twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        m_reader = new StreamReader(m_twitchClient.GetStream());
        m_writer = new StreamWriter(m_twitchClient.GetStream());
        m_writer.WriteLine("PASS " + m_password);
        m_writer.WriteLine("NICK " + m_username);
        m_writer.WriteLine("USER " + m_username + " 8 *:" + m_username);
        m_writer.WriteLine("JOIN #" + m_channelName);
        m_writer.Flush();
    }

    private void ReadChat()
    {
        if(m_twitchClient.Available > 0)
        {
            string m_message = m_reader.ReadLine();
            if (m_message.Contains("PRIVMSG"))
            {
                Debug.Log(m_message);
            }
        }
    }
}
