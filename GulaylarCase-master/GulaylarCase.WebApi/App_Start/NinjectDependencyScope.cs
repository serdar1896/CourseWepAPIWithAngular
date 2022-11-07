using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace GulaylarCase.WebApi
{
    public class NinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot _resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this._resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = _resolver as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }

            _resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (_resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return _resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_resolver == null)
            {

                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return _resolver.GetAll(serviceType);
        }

    }
}