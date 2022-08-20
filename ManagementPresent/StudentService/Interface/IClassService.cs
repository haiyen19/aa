using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentService.Model;
using StudentService.Response;
using System.Threading.Tasks;
using StudentService.Request;


namespace StudentService.Interface
{
    [ServiceContract]
    public interface IClassService
    {
        [OperationContract]
        Task<ResponseService<int>> Save(Class request);
        [OperationContract]
        Task<ResponseService<List<ClassViewModel>>> ClassAll(IdCourseAndFacultyRequest request);
        [OperationContract]
        Task<ResponseService<Class>> ClassGetById(int Id);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<List<IdAndNameModel>>> ClassJonCourseJoinFaculty();
    }
}
