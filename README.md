# ColorConverterUtility
### Unity Editor Addon
Convert your clipboard text from something useless like this:
- `rgb(66, 180, 255)`

to something useful like this:
- `new Color(0.26f, 0.71f, 1f)`

### Thanks, science.

- Converts 0-255 integer-style RGB information to UnityEngine.Color constructor format with a keyboard shortcut.
- If conversion is successful the result is copied to the clipboard (overwriting your previously copied text).
- Default shortcut is Shift+Alt+C. Outputs to the console indicating success or failure.
- Place the script in "Assets/Editor" in your project directory.
