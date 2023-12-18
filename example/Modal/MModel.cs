namespace ModelViewer
{
    internal class MModel
    {
        public int id { get; set; }
        public int parentModelID { get; set; }
        public string displayName { get; set; }
        public MGeometry geometry { get; set; }
        public MModel(int id, int parentModelID, string displayName, MGeometry geometry = null)
        {
            this.id = id;
            this.parentModelID = parentModelID;
            this.displayName = displayName;
            this.geometry = geometry;
        }
    }
}
