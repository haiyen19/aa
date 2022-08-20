using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentService.Model;
using StudentService.Response;
using System.Threading.Tasks;
using StudentService.Request;

namespace StudentService.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task<ResponseService<CurrentUser>> Login(LoginRequest request);

        [OperationContract]
        Task<ResponseService<int>> Save(User request);
        [OperationContract]
        Task<ResponseService<int>> Delete(int Id);
        [OperationContract]
        Task<ResponseService<User>> User(int Id);
        [OperationContract]
        Task<ResponseService<List<UserViewModel>>> Users(UserPaginationRequest request);
        [OperationContract]
        Task<ResponseService<ProfilesStudent>> ProfileStudent(int Id);
        [OperationContract]
        Task<ResponseService<Profiles>> ProfileLecture(int Id);
        [OperationContract]
        Task<ResponseService<int>> ChangePassword(ChangePasswordRequest request);
    }
}
