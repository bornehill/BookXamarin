using System;
using Autofac;
using BookXamarin.View;
using BookXamarin.Service;
using BookXamarin.ViewModel;

namespace BookXamarin.Utils
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookStoreViewModel>();
            builder.RegisterType<BookService>().As<IBookService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
