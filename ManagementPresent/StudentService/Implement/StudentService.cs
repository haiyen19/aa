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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in both code and config file together.
    public class StudentService : BaseService,IStudentService
    {
        public async Task<ResponseService<int>> Add(Student model)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("StudentAdd", new
                {
                    FullName = model.FullName,
                    Mobile = model.Mobile,
                    Address = model.Address,
                    IdFacutly = model.IdFacutly,
                    Avatar =model.Avatar
                });
                if (response.Data == -1)
                {
                    response.Success = false;
                    response.Message = "Đã có tên này";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Thêm mới thành công";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }

        public async Task<ResponseService<int>> Delete(int entity)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("StudentDelete", new
                {
                    EntityId = entity
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

        public async Task<ResponseService<Student>> GetById(int Id)
        {
            var response = new ResponseService<Student>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Student>("StudentGetById", new
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

        public async Task<ResponseService<List<Student>>> Students(PaginationRequest request)
        {
            var response = new ResponseService<List<Student>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Student>("Students", new
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

        public async Task<ResponseService<int>> Update(Student model)
        {
            var response = new ResponseService<int>();
            try
            {
                response.Data = await _repository.ExecuteNonQueryAsync("StudentUpdate", new
                {
                    EntityId = model.EntityId,
                    FullName = model.FullName,
                    Mobile = model.Mobile,
                    Address = model.Address,
                    IdFacutly = model.IdFacutly,
                    Avatar = model.Avatar
                });
                response.Success = true;
                response.Message = "Sửa thành công";
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
