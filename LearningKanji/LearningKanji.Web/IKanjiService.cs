using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LearningKanji.Classes.KanjiObject;

namespace LearningKanji.Web
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKanjiService" in both code and config file together.
    [ServiceContract(Namespace = "LearningKanji.Web")]
    public interface IKanjiService
    {
        [OperationContract]
        List<KanjiObject> GetListKanji();
    }
}
