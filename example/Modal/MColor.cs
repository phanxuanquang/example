namespace ModelViewer
{
    internal class MColor
    {
        public int id { get; set; }
        public double red { get; set; }
        public double green { get; set; }
        public double blue { get; set; }
        public MColor(int id, double R = 0, double G = 0, double B = 0)
        {
            this.id = id;
            red = R;
            green = G;
            blue = B;
        }
    }
}
