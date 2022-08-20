using StudentService.Interface;
using StudentService.Model;
using StudentService.Request;
using StudentService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Interface
{
    [ServiceContract]
    public interface ISubjectService
    {
        [OperationContract]
        Task<ResponseService<int>> Save(Subject request);
        [OperationContract]
        Task<ResponseService<List<Subject>>> Subjects(FacutylePaginationRequest request);
        [OperationContract]
        Task<ResponseService<Subject>> Subject(int Id);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<List<IdAndNameModel>>> SubjectByFacultyAndSemester(FacultyAndSemesterRequest request);
        [OperationContract]
        Task<ResponseService<List<IdAndNameModel>>> SubjectHaveClassSubjectOpen(int StudentId);
    }
}
