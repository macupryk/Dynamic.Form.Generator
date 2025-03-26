using System.Collections.Generic;

namespace Dynamic.Form.Generator.Shared
{
    public class FormField
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public List<string> Values { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
