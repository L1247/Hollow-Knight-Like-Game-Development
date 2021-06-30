namespace Main.Decoupling.Stub
{
    public class C
    {
        private readonly I_B b;
        public C(I_B b)
        {
            this.b = b;
        }

        public IBData GetResult()
        {
            var result = b.GetResult();
            result.Value -= 1;
            return result;
        }
    }
}