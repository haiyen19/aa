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
    public class FacutlyService : BaseService, IFacutlyService
    {
        public async Task<ResponseService<Facutly>> Facutly(int Id)
        {
            var response = new ResponseService<Facutly>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Facutly>("FacultyGetById", new
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
                response.Data = await _repository.ExecuteNonQueryAsync("FacultyDelete", new
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

        public async Task<ResponseService<List<Facutly>>> Facutlys()
        {
            var response = new ResponseService<List<Facutly>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Facutly>("Facultys", null);
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

        public async Task<ResponseService<int>> Save(Facutly request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("FacultyAdd", new
                    {
                        Name = request.Name,
                        Description = request.Description
                    });
                    response.Message = "Thêm mới thành công";
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("FacultyUpdate", new
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Description = request.Description
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

        public async Task<ResponseService<int>> Add(Facutly request)
        {
            var response = new ResponseService<int>();

            var data = await _repository.ExecuteNonQueryAsync("FacultyAdd", new
            {
                Name = request.Name,
                Description = request.Description
            });
            if (data == -1)
            {
                response.Success = false;
                response.Message = "Đã có lỗi xảy ra";
            }
            else
            {
                response.Success = true;
                response.Message = "Thêm mới thành công";
            }
            return response;
        }
    }
}
