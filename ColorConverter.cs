using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class ColorConverter
{
	/// <summary>
	///Convert the text in the system clipboard from 0-255 integer-style RGB color information to the UnityEngine.Color constructor format.
	/// </summary>
	[MenuItem("Tools/Misc./Clipboard-Text Color Conversion #&c")]
	public static void ConvertColor()
	{
		
		string input = GUIUtility.systemCopyBuffer;
		if (!string.IsNullOrWhiteSpace(input) && input.Length < 40)
		{
			
			// Define a regular expression for finding 3 numbers in between other junk
			Regex rx = new Regex(@"\D*(\d*)\D*(\d*)\D*(\d*)",
			  RegexOptions.Compiled | RegexOptions.IgnoreCase);

			// Find matches
			MatchCollection matches = null;
			try { matches = rx.Matches(input); }
			catch { Debug.Log("ColorConverter: Conversion failed. Unable to perform Regex parsing on the clipboard text."); return; }

			// Validate number of results
			if (matches.Count < 1 || matches[0].Groups.Count < 4) {
				Debug.Log("ColorConverter: Conversion failed. Unable to find three numeric values for color conversion in clipboard text."); return;
			}

			float r = 0f, g = 0f, b = 0f;

			try {
				r = float.Parse(matches[0].Groups[1].Value);
				g = float.Parse(matches[0].Groups[2].Value);
				b = float.Parse(matches[0].Groups[3].Value);
			}
			catch { Debug.Log("ColorConverter: Converstion failed. Unable to parse text matches into valid numbers."); return; }
			
			bool failed = false;
			if (float.IsNaN(r) || r < 0 || r > 255) { failed = true; }
			if (float.IsNaN(g) || g < 0 || g > 255) { failed = true; }
			if (float.IsNaN(b) || b < 0 || b > 255) { failed = true; }
			if (failed) { Debug.Log("ColorConverter: Conversion failed. Unable to find valid numerical values in clipboard text."); return; }
			
			r /= 255f; g /= 255f; b /= 255f;
			
			GUIUtility.systemCopyBuffer = ("new Color(" + r.ToString("0.##") + "f, " + g.ToString("0.##") + "f, " + b.ToString("0.##") + "f)");
			Debug.Log("Successfully converted \"" + input + "\" to \"" + GUIUtility.systemCopyBuffer + "\"");

		}

		else
		{
			Debug.Log("ColorConverter: Conversion failed. Clipboard text was invalid due to length or content.");
		}

	}

}