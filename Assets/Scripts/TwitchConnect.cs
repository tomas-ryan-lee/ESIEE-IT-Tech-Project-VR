using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class TwitchConnect : MonoBehaviour
{
    private TcpClient m_twitchClient;
    private StreamReader m_reader;
    private StreamWriter m_writer;

    public string m_username, m_password, m_channelName;

    void Start()
    {
        Connect();
    }

    void Update()
    {
        if (!m_twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    private void Connect() 
    {
        m_twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        m_reader = new StreamReader(m_twitchClient.GetStream());
        m_writer = new StreamWriter(m_twitchClient.GetStream());

        m_writer.WriteLine("PASS : " + m_password);
        m_writer.WriteLine("NICK : " + m_username);
        m_writer.WriteLine("USER : " + m_username + " 8 * :" + m_username);
        m_writer.WriteLine("JOIN #" + m_channelName);
        m_writer.Flush();
    }

    private void ReadChat()
    {
        if(m_twitchClient.Available > 0)
        {
            var m_message = m_reader.ReadLine();
            print(m_message);
        }
    }
}
