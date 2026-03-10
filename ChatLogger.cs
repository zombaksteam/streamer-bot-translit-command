/*
 * ---------------------------------------------------------
 * 👤 AUTHOR: ZombakUA
 * 🚀 BUILD: v1.0.0 | 2026-03-10
 * 📜 DESCRIPTION: https://www.twitch.tv/zombakua
 * ---------------------------------------------------------
 */

using System;

public class CPHInline
{
    public bool Execute()
    {
        string userName = args["userName"].ToString();
        string message = args["rawInput"].ToString();

        // Ігноруємо повідомлення, якщо воно починається з "!"
        if (message.StartsWith("!")) return true;

        // Якщо це звичайний текст, зберігаємо його у пам'яті
        CPH.SetGlobalVar("LastMsg_" + userName, message, true);

        return true;
    }
}
