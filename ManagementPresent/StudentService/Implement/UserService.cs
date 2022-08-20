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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : BaseService, IUserService
    {
        public async Task<ResponseService<CurrentUser>> Login(LoginRequest request)
        {
            var response = new ResponseService<CurrentUser>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<CurrentUser>("Login", new
                {
                    UserName = request.UserName,
                    Password = request.Password
                });
                if (data.Count != 0)
                {
                    var user = data.FirstOrDefault();
                    if (user.Active == true)
                    {
                        response.Data = user;
                        response.Success = true;
                        response.Message = "Đăng nhập thành công";
                    }
                    else
                    {
                        response.Data = user;
                        response.Success = true;
                        response.Message = "Tài khoản của bạn không hoạt động";
                    }
                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Tài khoản không tồn tại";
                }
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
                response.Data = await _repository.ExecuteNonQueryAsync("UserDelete", new
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

        public async Task<ResponseService<int>> ChangePassword(ChangePasswordRequest request)
        {
            var response = new ResponseService<int>();
            try
            {
                var result = await _repository.ExecuteScalarAsync("ChangePassword", new
                {
                    Id = request.Id,
                    OldPassword = request.OldPassword,
                    NewPassword = request.NewPassword
                });
                response.Data = (int)result;
                if ((int)result == -1)
                {
                    response.Success = false;
                    response.Message = "Mật khẩu cũ không chính xác";
                    return response;
                }
                response.Success = true;
                response.Message = "Đổi mật khẩu thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + "," + ex.InnerException;
            }
            return response;
        }



        public async Task<ResponseService<List<UserViewModel>>> Users(UserPaginationRequest request)
        {
            var response = new ResponseService<List<UserViewModel>>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<UserViewModel>("Users", new
                {
                    pageIndex = request.pageIndex,
                    pageSize = request.pageSize,
                    TypeUser= request.TypeUser,
                    ClassId = request.ClassId,
                    FacultyId = request.FacultyId,
                    NameSearch = request.NameSearch
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



        public async Task<ResponseService<User>> User(int Id)
        {
            var response = new ResponseService<User>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<User>("UserGetById", new
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


        public async Task<ResponseService<ProfilesStudent>> ProfileStudent(int Id)
        {
            var response = new ResponseService<ProfilesStudent>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<ProfilesStudent>("ProfileStudent", new
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


        public async Task<ResponseService<Profiles>> ProfileLecture(int Id)
        {
            var response = new ResponseService<Profiles>();
            try
            {
                var data = await _repository.ExecuteReaderAsync<Profiles>("ProfileLecture", new
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

        public async Task<ResponseService<int>> Save(User request)
        {
            var response = new ResponseService<int>();
            try
            {
                if (request.Id == null)
                {
                    var result = await _repository.ExecuteScalarAsync("UserAdd", new
                    {
                        FullName = request.FullName,
                        Gender = request.Gender,
                        IdCard = request.IdCard,
                        Email = request.Email,
                        Address = request.Address,
                        Phone = request.Phone,
                        UserLogin = request.UserLogin,
                        Password = request.Password,
                        DayOfBirth = request.DayOfBirth,
                        UserType = request.UserType,
                        ClassId = request.ClassId,
                        FacultyId = request.FacultyId,
                        Active = request.Active,
                        Avatar = request.Avatar
                    });
                    if ((int)result == -1)
                    {
                        response.Data = (int)result;
                        response.Success = false;
                        response.Message = "Tài khoản đăng nhập này đã tồn tại";
                    }
                    else
                    {
                        response.Data = (int)result;
                        response.Success = true;
                        response.Message = "Thêm mới thành công";
                    }
                }
                else
                {
                    response.Data = await _repository.ExecuteNonQueryAsync("UserUpdate", new
                    {
                        Id = request.Id,
                        FullName = request.FullName,
                        Gender = request.Gender,
                        IdCard = request.IdCard,
                        Email = request.Email,
                        Address = request.Address,
                        Phone = request.Phone,
                        UserLogin = request.UserLogin,
                        Password = request.Password,
                        DayOfBirth = request.DayOfBirth,
                        UserType = request.UserType,
                        ClassId = request.ClassId,
                        FacultyId = request.FacultyId,
                        Active = request.Active,
                        Avatar = request.Avatar
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
