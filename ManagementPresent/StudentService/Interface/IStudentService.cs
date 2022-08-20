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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        Task<ResponseService<int>> Add(Student model);
        [OperationContract]
        Task<ResponseService<int>> Update(Student model);
        [OperationContract]
        Task<ResponseService<int>> Delete(int entity);
        [OperationContract]
        Task<ResponseService<List<Student>>> Students(PaginationRequest request);
        [OperationContract]
        Task<ResponseService<Student>> GetById(int Id);
    }
}
