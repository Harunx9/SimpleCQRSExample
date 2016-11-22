using Autofac;
using Autofac.Integration.Mvc;
using Domain.CommandHandler;
using Domain.Commands;
using Domain.Core;
using Domain.ReadModel;
using Domain.WriteModel;
using PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gui
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlConnection>().As<IDbConnection>().WithParameter("connectionString", ConfigurationManager.ConnectionStrings["cqrs"].ConnectionString);
            builder.RegisterType<Repository<Todo>>().As<IRepository<Todo>>();
            builder.RegisterType<TodoReadService>().As<ITodoReadService>();

            builder.Register(c =>
            {
                var bus = new DomainBus();
                bus.RegisterHandler(typeof(ChangeDetailsCommand), new ChangeDetailsHandler(c.Resolve<IRepository<Todo>>()));
                bus.RegisterHandler(typeof(CreateTodoCommand), new CreateTodoHandler(c.Resolve<IRepository<Todo>>()));
                bus.RegisterHandler(typeof(CloseTodoCommand), new CloseTodoHandler(c.Resolve<IRepository<Todo>>()));
                return bus;
            }
            ).As<IDomainBus>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}