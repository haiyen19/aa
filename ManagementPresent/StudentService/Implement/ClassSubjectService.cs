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

namespace StudentService.Implement
{
    public class ClassSubjectService : BaseService, IClassSubjectService
    {
        public async Task<ResponseService<int>> Delete(int Id)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("OpenClassDelete", new
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

        public async Task<ResponseService<int>> StudentCancelRegist(int Id,int IdStudent)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("CancelResultRegistByStudent", new
                {
                    Id = Id,
                    IdStudent = IdStudent
                });
                response.Success = true;
                response.Message = "Hủy bỏ đăng ký thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<int>> StudentRegist(RegistOpenClassRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                var result = (int)await _repository.ExecuteScalarAsync("StudentRegistSubject", new
                {
                    IdOpenClass = request.IdOpenClass,
                    IdStudent = request.IdStudent,
                    SemesterId = request.SemesterId
                });
                if(result == -1)
                {
                    response.Success = false;
                    response.Message = "Bạn đã đăng ký lớp học này rồi";
                }
                else if(result == -2)
                {
                    response.Success = false;
                    response.Message = "Bạn đã đăng ký 1 lớp học nào đó của môn học này rồi";
                }
                else if (result == -3)
                {
                    response.Success = false;
                    response.Message = "Lớp bạn chọn đã đến mức tối đa sinh viên cho phép";
                }
                else if (result == -4)
                {
                    response.Success = false;
                    response.Message = "Môn học này bạn đủ điểm để không phải học lại";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Bạn đã đăng ký học thành công";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<OpenClassRequest>> GetById(int Id)
        {
            var response = new ResponseService<OpenClassRequest>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<OpenClassRequest>("OpenClassGetById", new
                {
                    Id = Id
                });
                if (data != null)
                {
                    response.Data = data.FirstOrDefault();
                }
                else
                {
                    response.Data = null;
                }
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

        public async Task<ResponseService<List<OpenClassModel>>> OpenClass(int? FacultyId)
        {
            var response = new ResponseService<List<OpenClassModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<OpenClassModel>("ClassSubjectByFaculty", new { 
                    FacultyId = FacultyId
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


        public async Task<ResponseService<List<OpenClassModel>>> OpenClassForLecture(int LectureId)
        {
            var response = new ResponseService<List<OpenClassModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<OpenClassModel>("ClassSubjectByLecture", new
                {
                    LectureId = LectureId
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

        public async Task<ResponseService<List<OpenClassModel>>> OpenClassForRegistStudent(int SubjectId)
        {
            var response = new ResponseService<List<OpenClassModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<OpenClassModel>("ClassSubjectByStudentRegist", new
                {
                    Id  = SubjectId
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


        public async Task<ResponseService<List<OpenClassModel>>> ResultRegistClassSubjectByStudent(int studentId)
        {
            var response = new ResponseService<List<OpenClassModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<OpenClassModel>("ResultRegistByStudent", new
                {
                    Id = studentId
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

        public async Task<ResponseService<int>> SaveOpenClass(OpenClassRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("OpenClassAdd", new
                    {
                        Name = request.Name,
                        SubjectId = request.SubjectId,
                        LecturerId = request.LecturerId,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        Content = request.Content,
                        Location = request.Location,
                        MaxStudent = request.MaxStudent
                    });
                    response.Message = "Thêm mới thành công";
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("OpenClassUpdate", new
                    {
                        Id = request.Id,
                        Name = request.Name,
                        SubjectId = request.SubjectId,
                        LecturerId = request.LecturerId,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        Content = request.Content,
                        Location = request.Location,
                        MaxStudent = request.MaxStudent
                    });
                    response.Message = "Sửa thành công";
                }
                response.Success = true;
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
