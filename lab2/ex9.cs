/*
 * Copyright (c) 2020 Andrey Mamonov
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;

namespace ex9
{
    class Ex9  // class name should match filename
    {
        static void Main(string[] args)
        {
            Random num = new Random();
            char[] s = new char[4];
            bool flag;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    s[i] = Convert.ToChar(CallNum(num));
                    if (s[i] == 123)
                    {
                        s[i] = ' ';
                    }
                }
                flag = true;
                for(int i = 0; i < 3; i++)
                {
                    if (s[i] == ' ' && s[i + 1] != ' ')
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                {
                    continue;
                }
                if (s[0] == ' ')
                {
                    continue;
                }
                break;
            }           
            for (int i = 0; i != ' ' && i < 4; i++)
            {
                Console.Write(s[i]);
            }
            Console.ReadKey();
        }
        static int CallNum(Random num)
        {
            return num.Next(97, 124);
        }
    }
}

//:]
