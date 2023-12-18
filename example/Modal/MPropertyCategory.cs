namespace ModelViewer
{
    internal class MPropertyCategory
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public MPropertyCategory(int id, string displayName)
        {
            this.id = id;
            this.displayName = displayName;
        }
    }
}
