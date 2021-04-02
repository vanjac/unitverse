using UnityEngine;
using System;
using System.Text;

// does NOT extend from Unit. show the script field so it can be easily found
public class GeneratedRelays : MonoBehaviour
{
    void Start() { }  // show enabled checkbox
}

// https://developer.valvesoftware.com/wiki/Logic_relay
// https://developer.valvesoftware.com/wiki/Func_instance_io_proxy
[AddComponentMenu("Units/Relay Interface")]
public class RelayInterface : ScriptGenerator
{
    private readonly string HEADER = string.Join(
        Environment.NewLine,
        "using UnityEngine;",
        "[AddComponentMenu(\"Relays/{0}\")]",
        "public class {0} : GeneratedRelays",
        "{{",
        "");
    private readonly string RELAY_TEMPLATE_VOID = string.Join(
        Environment.NewLine,
        "    public UltEvents.UltEvent {0};",
        "    public void {1}()",
        "    {{",
        "        if (enabled && {0} != null)",
        "            {0}.Invoke();",
        "    }}",
        "");
    private readonly string RELAY_TEMPLATE_ARG = string.Join(
        Environment.NewLine,
        @"    public UltEvents.UltEvent<{2}> {0};",
        "    public void {1}({2} value)",
        "    {{",
        "        if (enabled && {0} != null)",
        "            {0}.Invoke(value);",
        "    }}",
        "");
    private readonly string FOOTER = string.Join(
        Environment.NewLine,
        "}",
        "");

    public string[] relays = new string[0];

    protected override string NamePrefix()
    {
        return "Relay";
    }

    private string TitleCase(string s)
    {
        return Char.ToUpper(s[0]) + s.Substring(1);
    }

    private string LowerCamelCase(string s)
    {
        return Char.ToLower(s[0]) + s.Substring(1);
    }

    protected override string GenerateCode(string className)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(HEADER, className);
        foreach(string r in relays)
        {
            if (r.Contains("("))
            {
                var values = r.Split('(', ')');
                string name = values[0];
                string arg = values[1];
                sb.AppendFormat(RELAY_TEMPLATE_ARG,
                    LowerCamelCase(name), TitleCase(name), arg);
            }
            else
            {
                sb.AppendFormat(RELAY_TEMPLATE_VOID,
                    LowerCamelCase(r), TitleCase(r));
            }
        }
        sb.Append(FOOTER);
        return sb.ToString();
    }
}
