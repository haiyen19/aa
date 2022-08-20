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
    public class ClassService : BaseService, IClassService
    {
        public async Task<ResponseService<List<ClassViewModel>>> ClassAll(IdCourseAndFacultyRequest request)
        {
            var response = new ResponseService<List<ClassViewModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<ClassViewModel>("ClassAll", new {
                    pageIndex = request.pageIndex,
                    pageSize = request.pageSize,
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

        public async Task<ResponseService<List<IdAndNameModel>>> ClassJonCourseJoinFaculty()
        {
            var response = new ResponseService<List<IdAndNameModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<IdAndNameModel>("ClassAndCourseAndFaculty", null);
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

        public async Task<ResponseService<Class>> ClassGetById(int Id)
        {
            var response = new ResponseService<Class>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Class>("ClassGetById", new
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

        public async Task<ResponseService<int>> Delete(int Id)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("ClassDelete", new
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

        public async Task<ResponseService<int>> Save(Class request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("ClassAdd", new
                    {
                        Name = request.Name,
                        Description = request.Description,
                        CourseId = request.CourseId,
                        FacultyId = request.FacultyId
                    });
                    response.Message = "Thêm mới thành công";
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("ClassUpdate", new
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        CourseId = request.CourseId,
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
    }
}
