# Morse Code Translator 
A simple .Net Core library to translate from English to Morse Code and vice versa. The library code can be found in `Morse.cs` and an implementation can be found in `Program.cs`.

# Public Methods
- `Code(string input)` - Class constructor, pass in the string to translate in either English or Morse
- `GetInput()` - Returns the input value pre-translation
- `GetTranslation()` - Returns the translated input
- `Play()` - Play the translated Morse Code with the system speaker, only works on Windows (current limitation of .Net Core)

# Resources
If you are interested in learning Morse Code for whatever reason I would recommend [www.learnmorsecode.com](http://www.learnmorsecode.com/)
