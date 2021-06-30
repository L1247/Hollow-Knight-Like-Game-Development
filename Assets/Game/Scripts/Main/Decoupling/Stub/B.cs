namespace Main.Decoupling.Stub
{
    public interface I_B
    {
    #region Public Methods

        IBData GetResult();

    #endregion
    }

    public interface IBData
    {
        int Value { get; set; }
    }

    public class BData : IBData
    {
    #region Public Variables

        public int Value { get; set; }

    #endregion

    #region Constructor

        public BData(CData cData)
        {
            Value = cData.Value;
        }

        public BData() { }

        public BData(int value)
        {
            Value = value;
        }

    #endregion

        public void SetValue(int value)
        {

        }
    }

    public class CData
    {
    #region Public Variables

        public int Value { get; }

    #endregion

    #region Constructor

        public CData(int value)
        {
            Value = value;
        }

    #endregion
    }
}