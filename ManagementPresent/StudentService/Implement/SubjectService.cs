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
    public class SubjectService : BaseService, ISubjectService
    {
        public async Task<ResponseService<int>> Delete(int Id)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("SubjectDelete", new
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

        public async Task<ResponseService<List<IdAndNameModel>>> SubjectByFacultyAndSemester(FacultyAndSemesterRequest request)
        {
            var response = new ResponseService<List<IdAndNameModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<IdAndNameModel>("SubjectsByFacultyAndSemeterNumber",new {
                    FacultyId = request.FacultyId,
                    SemeterId = request.SemeterId
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


        public async Task<ResponseService<List<IdAndNameModel>>> SubjectHaveClassSubjectOpen(int StudentId)
        {
            var response = new ResponseService<List<IdAndNameModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<IdAndNameModel>("GetOpenClassByStudentId", new
                {
                    Id = StudentId
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

        public async Task<ResponseService<int>> Save(Subject request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("SubjectAdd", new
                    {
                        Name = request.Name,
                        Credits = request.Credits,
                        Semester = request.Semester,
                        UsedCalculate = request.UsedCalculate,
                        FacultyId = request.FacultyId
                    });
                    response.Message = "Thêm mới thành công";
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("SubjectUpdate", new
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Credits = request.Credits,
                        Semester = request.Semester,
                        UsedCalculate = request.UsedCalculate,
                        FacultyId = request.FacultyId
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

        public async Task<ResponseService<Subject>> Subject(int Id)
        {
            var response = new ResponseService<Subject>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Subject>("SubjectGetById", new
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

        public async Task<ResponseService<List<Subject>>> Subjects(FacutylePaginationRequest request)
        {
            var response = new ResponseService<List<Subject>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Subject>("Subjects", new
                {
                    pageIndex = request.pageIndex,
                    pageSize = request.pageSize,
                    FacultyId = request.FacultyId
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
