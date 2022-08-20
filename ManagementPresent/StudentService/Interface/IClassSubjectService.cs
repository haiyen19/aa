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
    public interface IClassSubjectService
    {
        [OperationContract]
        Task<ResponseService<List<OpenClassModel>>> OpenClass(int? FacultyId);
        [OperationContract]
        Task<ResponseService<int>> SaveOpenClass(OpenClassRequest request);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<OpenClassRequest>> GetById(int Id);
        [OperationContract]
        Task<ResponseService<List<OpenClassModel>>> OpenClassForLecture(int LectureId);
        [OperationContract]
        Task<ResponseService<List<OpenClassModel>>> OpenClassForRegistStudent(int SubjectId);
        [OperationContract]
        Task<ResponseService<int>> StudentRegist(RegistOpenClassRequest request);
        [OperationContract]
        Task<ResponseService<List<OpenClassModel>>> ResultRegistClassSubjectByStudent(int studentId);
        [OperationContract]
        Task<ResponseService<int>> StudentCancelRegist(int Id, int IdStudent);
    }
}
