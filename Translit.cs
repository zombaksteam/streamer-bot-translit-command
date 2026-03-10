/*
 * ---------------------------------------------------------
 * 👤 AUTHOR: ZombakUA
 * 🚀 BUILD: v1.0.0 | 2026-03-10
 * 📜 DESCRIPTION: https://www.twitch.tv/zombakua
 * ---------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text;

public class CPHInline
{
    private static readonly Dictionary<char, char> Charmap = new Dictionary<char, char>
    {
        {',', 'б'}, {';', 'ж'}, {':', 'Ж'}, {'?', ','}, {'.', 'ю'}, {'\'', 'є'}, {'[', 'х'},
        {']', 'ї'}, {'{', 'Х'}, {'}', 'Ї'}, {'@', '"'}, {'/', '.'}, {'"', 'Є'}, {'&', '?'},
        {'#', '№'}, {'^', ':'}, {'<', 'Б'}, {'>', 'Ю'}, {'~', 'ʼ'}, {'$', ';'}, {'a', 'ф'},
        {'A', 'Ф'}, {'b', 'и'}, {'B', 'И'}, {'c', 'с'}, {'C', 'С'}, {'d', 'в'}, {'D', 'В'},
        {'e', 'у'}, {'E', 'У'}, {'f', 'а'}, {'F', 'А'}, {'g', 'п'}, {'G', 'П'}, {'h', 'р'},
        {'H', 'Р'}, {'i', 'ш'}, {'I', 'Ш'}, {'j', 'о'}, {'J', 'О'}, {'k', 'л'}, {'K', 'Л'},
        {'l', 'д'}, {'L', 'Д'}, {'m', 'ь'}, {'M', 'Ь'}, {'n', 'т'}, {'N', 'Т'}, {'o', 'щ'},
        {'O', 'Щ'}, {'p', 'з'}, {'P', 'З'}, {'q', 'й'}, {'Q', 'Й'}, {'r', 'к'}, {'R', 'К'},
        {'s', 'і'}, {'S', 'І'}, {'t', 'е'}, {'T', 'Е'}, {'u', 'г'}, {'U', 'Г'}, {'v', 'м'},
        {'V', 'М'}, {'w', 'ц'}, {'W', 'Ц'}, {'x', 'ч'}, {'X', 'Ч'}, {'y', 'н'}, {'Y', 'Н'},
        {'z', 'я'}, {'Z', 'Я'}
    };

    public bool Execute()
    {
        string userName = args["userName"].ToString();
        string lastMsg = CPH.GetGlobalVar<string>("LastMsg_" + userName, true);

        if (!string.IsNullOrEmpty(lastMsg))
        {
            string result = MyTranslitAlgorithm(lastMsg);
            if (lastMsg != result)
            {
                CPH.SendMessage($"@{userName} хотів(-ла) сказати: {result}");
            }
            else
            {
                CPH.SendMessage($"@{userName} не можу транслювати повідомлення");
            }
        }
        else
        {
            CPH.SendMessage($"@{userName} не можу знайти останнє повідомлення");
        }
        return true;
    }

    private string MyTranslitAlgorithm(string input)
    {
        string data = input.Trim();
        if (string.IsNullOrEmpty(data)) return "";

        string user = "";
        char[] chars = data.ToCharArray();

        if (chars[0] == '@')
        {
            int spaceIndex = data.IndexOf(' ');
            if (spaceIndex != -1)
            {
                user = data.Substring(0, spaceIndex);
                data = data.Substring(spaceIndex + 1);
            }
        }

        StringBuilder res = new StringBuilder();
        if (!string.IsNullOrEmpty(user))
        {
            res.Append(user).Append(' ');
        }

        foreach (char c in data)
        {
            if (Charmap.ContainsKey(c))
            {
                res.Append(Charmap[c]);
            }
            else
            {
                res.Append(c);
            }
        }

        return res.ToString();
    }
}
