using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StudentService.Model;
using StudentService.Request;
using StudentService.Response;
namespace StudentService.Interface
{
    [ServiceContract]
    public interface IFacutlyService
    {
        [OperationContract]
        Task<ResponseService<List<Facutly>>> Facutlys();
        [OperationContract]
        Task<ResponseService<int>> Save(Facutly request);
        [OperationContract]
        Task<ResponseService<Facutly>> Facutly(int Id);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<int>> Add(Facutly request);
    }
}
