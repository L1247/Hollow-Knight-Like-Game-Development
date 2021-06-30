using Main.Decoupling.Stub;

namespace Main.Stub.Decoupling
{
    public class BDataBuilder
    {
        private int cDataValue;

        public static BDataBuilder NewInstance()
        {
            return new BDataBuilder();
        }

        public BData Build()
        {
            // 1
            return new BData(new CData(cDataValue));
            // 2
            // var bData = new BData();
            // bData.SetValue(cDataValue);
            // 3
            // var bData = new BData(cDataValue);
            // return bData;
        }

        public BDataBuilder SetBDataValue(int value)
        {
            cDataValue = value;
            return this;
        }
    }
}