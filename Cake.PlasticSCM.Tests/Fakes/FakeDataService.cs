using System;
using Cake.Core;

namespace Cake.PlasticSCM.Tests.Fakes
{
    class FakeDataService : ICakeDataService
    {
        #region Implementation of ICakeDataResolver

        /// <inheritdoc />
        public TData Get<TData>() where TData : class
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Add<TData>(TData value) where TData : class
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
