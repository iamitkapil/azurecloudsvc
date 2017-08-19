using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using AKAdStore.Domain.Entities;
using AKAdStore.Domain.Abstract;
using AKAdStore.Domain.Concrete;


namespace AKAdStore.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here

            //Mock<IAdsRepository> mock = new Mock<IAdsRepository>();

            //mock.Setup(m => m.Ads).Returns(new List<Ad> {
            //    new Ad {AdId = 1, Title="Mercedez Benz" , Price = 400000 , Description = "Mercedez Benz is powerful luxury Car available in different classes like A , S and C", Category = Category.Cars  },
            //    new Ad {AdId = 2, Title="BMW" , Price = 380000 , Description = "BMW is powerful luxury Car available in different Series like X , Y and Z", Category = Category.Cars  },
            //    new Ad {AdId = 3, Title="Manali Cottage" , Price = 1200 ,.wi Description = "A cottage is usually a modest, often cosy dwelling, typically in a rural or semi-rural location", Category = Category.RealEstate  },
            //    new Ad {AdId = 4, Title="Noida Farm House" , Price = 6000 , Description = "A farmhouse is a building that serves as the primary residence in a rural or agricultural setting. This is situated in the outskirts of Noida", Category = Category.RealEstate  },
            //    new Ad {AdId = 5, Title="Bracelet" , Price = 400000 , Description = "A bracelet is an article of jewellery that is worn around the wrist.", Category = Category.FreeStuff  }
            //});

            kernel.Bind<IAdsRepository>().To<AdRepository>().WithConstructorArgument("dbconnectionString", String.Empty) ;
        }
    }
}