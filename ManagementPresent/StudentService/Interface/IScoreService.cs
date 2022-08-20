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
    public interface IScoreService
    {
        [OperationContract]
        Task<ResponseService<List<InsertStudentScoreModel>>> StudentsInsertScore(SubjectAndClassIdRequest request);
        [OperationContract]
        Task<ResponseService<List<TopStudentVm>>> TopStudent(TopStudentRequest request);
        [OperationContract]
        Task<ResponseService<List<ScoreStudentViewModel>>> StudentsScoreView(SubjectAndClassIdRequest request);
        [OperationContract]
        Task<ResponseService<int>> SaveScoreAdmin(ScoreStudentRequest request);
        [OperationContract]
        Task<ResponseService<int>> SaveScoreByLecture(SaveScoreByLectureRequest request);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<List<StudentInsertScoreByLecturer>>> StudentsInsertScoreByLecture(int OpenClassId);
        [OperationContract]
        Task<ResponseService<List<ScoreViewModelByStudent>>> ScoreViewByStudent(StudentViewScoreRequest request);
    }
}
