using StudentService.Interface;
using StudentService.Model;
using StudentService.Request;
using StudentService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Implement
{
    public class ScoreService : BaseService, IScoreService
    {
        public async Task<ResponseService<List<InsertStudentScoreModel>>> StudentsInsertScore(SubjectAndClassIdRequest request)
        {
            var response = new ResponseService<List<InsertStudentScoreModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<InsertStudentScoreModel>("GetStudentInsertScoreByClassAndSubject", new
                {
                    ClassId = request.ClassId,
                    SubjectId = request.SubjectId
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<List<TopStudentVm>>> TopStudent(TopStudentRequest request)
        {
            var response = new ResponseService<List<TopStudentVm>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<TopStudentVm>("TopStudentScore", new
                {
                    SemesterId = request.SemesterId,
                    FacultyId = request.FacultyId,
                    CourseId = request.CourseId
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }
        //ScoreViewModelByStudent
        public async Task<ResponseService<List<ScoreViewModelByStudent>>> ScoreViewByStudent(StudentViewScoreRequest request)
        {
            var response = new ResponseService<List<ScoreViewModelByStudent>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<ScoreViewModelByStudent>("ScoreViewByStudentId", new
                {
                    StudentId = request.StudentId,
                    SemesterId = request.SemesterId
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }


        public async Task<ResponseService<List<ScoreStudentViewModel>>> StudentsScoreView(SubjectAndClassIdRequest request)
        {
            var response = new ResponseService<List<ScoreStudentViewModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<ScoreStudentViewModel>("GetStudentInsertScoreByClassAndSubjectView", new
                {
                    ClassId = request.ClassId,
                    SubjectId = request.SubjectId
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<int>> Delete(int Id)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("ScoreDelete", new
                {
                    Id = Id
                });
                response.Success = true;
                response.Message = "Xóa thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }


        public async Task<ResponseService<int>> SaveScoreAdmin(ScoreStudentRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                var data = await _repository.ExecuteNonQueryAsync("SaveScoreAdmin", new
                {
                    StudentId = request.StudentId,
                    SubjectId = request.SubjectId,
                    NumberStudy = request.NumberStudy,
                    Semester = request.Semester,
                    Score1 = request.Score1,
                    Score2 = request.Score2,
                    Score3 = request.Score3,
                    SummaryScore = request.SummaryScore,
                    SummaryScore4 = request.SummaryScore4,
                    Scoreword = request.Scoreword,
                    Evaluate =request.Evaluate
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Nhập điểm thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<int>> SaveScoreByLecture(SaveScoreByLectureRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                var data = await _repository.ExecuteNonQueryAsync("SaveScoreByLecture", new
                {
                    Id = request.Id,
                    Score1 = request.Score1,
                    Score2 = request.Score2,
                    Score3 = request.Score3,
                    SummaryScore = request.SummaryScore,
                    SummaryScore4 = request.SummaryScore4,
                    Scoreword = request.Scoreword,
                    Evaluate = request.Evaluate
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Nhập điểm thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<List<StudentInsertScoreByLecturer>>> StudentsInsertScoreByLecture(int OpenClassId)
        {
            var response = new ResponseService<List<StudentInsertScoreByLecturer>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<StudentInsertScoreByLecturer>("GetStudentInsertScoreByLecturer", new
                {
                    OpenClassId = OpenClassId
                });
                response.Data = data;
                response.Success = true;
                response.Message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }
    }
}
