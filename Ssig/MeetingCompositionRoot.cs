using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace SsigBeta {
    public class MeetingCompositionRoot {
        private readonly IControllerFactory _controllerFactory;

        public MeetingCompositionRoot()
        {
            this._controllerFactory = MeetingCompositionRoot.CreateControllerFactory();
        }

        public IControllerFactory ControllerFactory
        {
            get
            {
                return _controllerFactory;
            }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            string assemblyName = ConfigurationManager.AppSettings["chirpRepositoryAssemblyName"];
            string typeName = ConfigurationManager.AppSettings["chirpRepositoryTypeName"];
            string databaseName = ConfigurationManager.AppSettings["databaseName"];
            DocumentStore documentStore = new DocumentStore();
            documentStore.ConnectionStringName = "RavenDB";
            documentStore.Initialize();
            documentStore.DatabaseCommands.EnsureDatabaseExists(databaseName);
            //var cacheRepository = Activator.CreateInstance(Type.GetType(typeName, true, true), new object[] { 
            //    documentStore, databaseName 
            //});
            var controllerFactory = new MeetingControllerFactory(documentStore);
            return controllerFactory;
        }
    }
}