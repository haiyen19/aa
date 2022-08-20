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
    public interface ICourseService
    {
        [OperationContract]
        Task<ResponseService<int>> Save(CourseRequest request);
        [OperationContract]
        Task<ResponseService<List<Course>>> Courses(PaginationRequest request);
        [OperationContract]
        Task<ResponseService<Course>> Course(int Id);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<Course>> CourseByStudentId(int Id);
    }
}
