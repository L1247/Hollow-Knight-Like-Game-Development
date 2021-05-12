namespace DDDCore.Model
{
    /// <summary>
    /// </summary>
    /// <typeparam name="B">Builder self</typeparam>
    /// <typeparam name="E">Entity of aggregate root</typeparam>
    public abstract class AbstractBuilder<B , E> where B : new() where E : AggregateRoot
    {
    #region Public Methods

        public abstract E Build();

        public static B NewInstance()
        {
            return new B();
        }

    #endregion
    }
}