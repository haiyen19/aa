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
    public class CourseService : BaseService, ICourseService
    {
        public async Task<ResponseService<Course>> Course(int Id)
        {
            var response = new ResponseService<Course>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Course>("CourseGetById", new
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

        public async Task<ResponseService<Course>> CourseByStudentId(int Id)
        {
            var response = new ResponseService<Course>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Course>("GetCourseByStudentId", new
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

        public async Task<ResponseService<List<Course>>> Courses(PaginationRequest request)
        {
            var response = new ResponseService<List<Course>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Course>("Courses", new
                {
                    pageIndex = request.pageIndex,
                    pageSize = request.pageSize
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
                response.Data = await _repository.ExecuteNonQueryAsync("CourseDelete", new
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

        public async Task<ResponseService<int>> Save(CourseRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("CourseAdd", new
                    {
                        Name = request.Name,
                        CourseStart = request.CourseStart,
                        CourseEnd = request.CourseEnd,
                        IsActive = request.IsActive
                    });
                    response.Message = "Thêm mới thành công";
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("CourseUpdate", new
                    {
                        Id = request.Id,
                        Name = request.Name,
                        CourseStart = request.CourseStart,
                        CourseEnd = request.CourseEnd,
                        IsActive = request.IsActive
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
