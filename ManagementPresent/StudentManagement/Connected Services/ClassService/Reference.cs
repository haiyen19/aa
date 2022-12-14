//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.ClassService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClassService.IClassService")]
    public interface IClassService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/Save", ReplyAction="http://tempuri.org/IClassService/SaveResponse")]
        StudentService.Response.ResponseService<int> Save(StudentService.Model.Class request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/Save", ReplyAction="http://tempuri.org/IClassService/SaveResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> SaveAsync(StudentService.Model.Class request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassAll", ReplyAction="http://tempuri.org/IClassService/ClassAllResponse")]
        StudentService.Response.ResponseService<StudentService.Model.ClassViewModel[]> ClassAll(StudentService.Request.IdCourseAndFacultyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassAll", ReplyAction="http://tempuri.org/IClassService/ClassAllResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.ClassViewModel[]>> ClassAllAsync(StudentService.Request.IdCourseAndFacultyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassGetById", ReplyAction="http://tempuri.org/IClassService/ClassGetByIdResponse")]
        StudentService.Response.ResponseService<StudentService.Model.Class> ClassGetById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassGetById", ReplyAction="http://tempuri.org/IClassService/ClassGetByIdResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Class>> ClassGetByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/Delete", ReplyAction="http://tempuri.org/IClassService/DeleteResponse")]
        StudentService.Response.ResponseService<int> Delete(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/Delete", ReplyAction="http://tempuri.org/IClassService/DeleteResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> DeleteAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassJonCourseJoinFaculty", ReplyAction="http://tempuri.org/IClassService/ClassJonCourseJoinFacultyResponse")]
        StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> ClassJonCourseJoinFaculty();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClassService/ClassJonCourseJoinFaculty", ReplyAction="http://tempuri.org/IClassService/ClassJonCourseJoinFacultyResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> ClassJonCourseJoinFacultyAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClassServiceChannel : StudentManagement.ClassService.IClassService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClassServiceClient : System.ServiceModel.ClientBase<StudentManagement.ClassService.IClassService>, StudentManagement.ClassService.IClassService {
        
        public ClassServiceClient() {
        }
        
        public ClassServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClassServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClassServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClassServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public StudentService.Response.ResponseService<int> Save(StudentService.Model.Class request) {
            return base.Channel.Save(request);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> SaveAsync(StudentService.Model.Class request) {
            return base.Channel.SaveAsync(request);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.ClassViewModel[]> ClassAll(StudentService.Request.IdCourseAndFacultyRequest request) {
            return base.Channel.ClassAll(request);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.ClassViewModel[]>> ClassAllAsync(StudentService.Request.IdCourseAndFacultyRequest request) {
            return base.Channel.ClassAllAsync(request);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.Class> ClassGetById(int Id) {
            return base.Channel.ClassGetById(Id);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Class>> ClassGetByIdAsync(int Id) {
            return base.Channel.ClassGetByIdAsync(Id);
        }
        
        public StudentService.Response.ResponseService<int> Delete(int Id) {
            return base.Channel.Delete(Id);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> DeleteAsync(int Id) {
            return base.Channel.DeleteAsync(Id);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> ClassJonCourseJoinFaculty() {
            return base.Channel.ClassJonCourseJoinFaculty();
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> ClassJonCourseJoinFacultyAsync() {
            return base.Channel.ClassJonCourseJoinFacultyAsync();
        }
    }
}
