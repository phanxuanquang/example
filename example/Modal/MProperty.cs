namespace ModelViewer
{
    internal class MProperty
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public string value { get; set; }
        public MProperty(int id, string key, string value)
        {
            this.id = id;
            displayName = key;
            this.value = value;
        }
    }
}
