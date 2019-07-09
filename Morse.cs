using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Morse
{
    class Translator {
        private static Dictionary<string, string> MorseDictionary = new Dictionary<string, string>() 
        {
            // Alphabet
            { "A", ".-" },
            { "B", "-..." },
            { "C", "-.-." },
            { "D", "-.." },
            { "E", "." },
            { "F", "..-." },
            { "G", "--." },
            { "H", "...." },
            { "I", ".." },
            { "J", ".---" },
            { "K", "-.-" },
            { "L", ".-.." },
            { "M", "--" },
            { "N", "-." },
            { "O", "---" },
            { "P", ".--." },
            { "Q", "--.-" },
            { "R", ".-." },
            { "S", "..." },
            { "T", "-" },
            { "U", "..-" },
            { "V", "...-" },
            { "W", ".--" },
            { "X", "-..-" },
            { "Y", "-.--" },
            { "Z", "--.." },

            // Numbers 
            { "0", "-----" },
            { "1", ".----" },
            { "2", "..---" },
            { "3", "...--" },
            { "4", "....-" },
            { "5", "....." },
            { "6", "-...." },
            { "7", "--..." },
            { "8", "---.." },
            { "9", "----." },

            // Punctuation
            { ".", ".-.-.-" },
            { ",", "--..--" },
            { "?", "..--.." },
            { "'", ".----." },
            { "!", "-.-.--" },
            { "/", "-..-." },
            { "(", "-.--." },
            { ")", "-.--.-" },
            { "&", ".-..." },
            { ":", "---..." },
            { ";", "-.-.-." },
            { "=", "-...-" },
            { "+", ".-.-." },
            { "-", "-....-" },
            { "_", "..--.-" },
            { "\"", ".-..-." },
            { "$", "...-..-" },
            { "@", ".--.-." },
            { "¿", "..-.-" },
            { "¡", "--...-" },            
            
            // Formatting 
            { " ", "/" }
        };

        public static string TranslateCharToMorse(char c)
        {
            string translation = "#";
            string s = c.ToString().ToUpper();
            
            if (MorseDictionary.ContainsKey(s))
            {
                translation = MorseDictionary[s];
            } 
            translation += " ";

            return translation;
        }

        public static string TranslateMorseToChar(string s)
        {
            string translation = "#";            

            if (MorseDictionary.ContainsValue(s))
            {
                translation = MorseDictionary.FirstOrDefault(x => x.Value == s).Key;
            }

            return translation;
        }
    }

    class Code
    {
        // Input value from user in either Morse code or English format
        private string Input;
        // Store the value of the translated input
        private string Translation;

        public Code(string input)
        {
            this.Input = input;
            Translation = Translate();
        }

        public string GetInput()
        {
            return Input;
        }

        public string GetTranslation()
        {
            return Translation;
        }

        public string Translate()
        {
            // Trigger the translate method for either Morse to English or English to Morse depending on 'Input' contents
            if (Regex.Matches(Input, @"[a-zA-Z0-9!$%&*:;#~@]").Count != 0)
            {
                return ToMorse();
            } 
            else
            {
                return ToEnglish();
            }
        }

        private string ToEnglish()
        {
            // Translate to English           
            string[] data = Input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string c in data)
            {
                Translation += Translator.TranslateMorseToChar(c);
            }

            return Translation;
        }

        private string ToMorse()
        {
            // Translate to Morse            
            foreach (char c in Input)
            {
                Translation += Translator.TranslateCharToMorse(c);
            }
            
            return Translation.Trim();
        }

        public void Play()
        {
            try 
            {
                int tone = 415; //G# note
                int dotDuration = 300; //The duration of one time unit
                int dashDuration = dotDuration * 3; //A dash is 3 time units
                int charSpaceDuration = dotDuration * 3; //The pause between characters is 3 time units
                int wordSpaceDuration = dotDuration * 7; //The pause between words is 7 time units
                foreach (char c in Translation)
                {
                    if (c == '.')
                    {
                        Console.Beep(tone, dotDuration);
                    } 
                    else if (c == '-')
                    {
                        Console.Beep(tone, dashDuration);
                    } 
                    else if (c == ' ')
                    {
                        System.Threading.Thread.Sleep(charSpaceDuration);
                    } 
                    else if (c == '/')
                    {
                        System.Threading.Thread.Sleep(wordSpaceDuration);
                    }
                }
            }
            catch (System.PlatformNotSupportedException ex)
            {                
                Console.WriteLine("ERROR: Code.Play() : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }    
}