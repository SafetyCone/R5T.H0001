using System;


namespace R5T.H0001
{
    public class ModelBuilderOperator : IModelBuilderOperator
    {
        #region Infrastructure

        public static IModelBuilderOperator Instance { get; } = new ModelBuilderOperator();


        private ModelBuilderOperator()
        {
        }

        #endregion
    }
}
