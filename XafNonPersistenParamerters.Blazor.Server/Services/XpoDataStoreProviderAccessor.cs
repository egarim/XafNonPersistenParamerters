using System;
using DevExpress.ExpressApp.Xpo;

namespace XafNonPersistenParamerters.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
