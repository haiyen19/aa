﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.SubjectService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SubjectService.ISubjectService")]
    public interface ISubjectService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Save", ReplyAction="http://tempuri.org/ISubjectService/SaveResponse")]
        StudentService.Response.ResponseService<int> Save(StudentService.Model.Subject request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Save", ReplyAction="http://tempuri.org/ISubjectService/SaveResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> SaveAsync(StudentService.Model.Subject request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Subjects", ReplyAction="http://tempuri.org/ISubjectService/SubjectsResponse")]
        StudentService.Response.ResponseService<StudentService.Model.Subject[]> Subjects(StudentService.Request.FacutylePaginationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Subjects", ReplyAction="http://tempuri.org/ISubjectService/SubjectsResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Subject[]>> SubjectsAsync(StudentService.Request.FacutylePaginationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Subject", ReplyAction="http://tempuri.org/ISubjectService/SubjectResponse")]
        StudentService.Response.ResponseService<StudentService.Model.Subject> Subject(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Subject", ReplyAction="http://tempuri.org/ISubjectService/SubjectResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Subject>> SubjectAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Delete", ReplyAction="http://tempuri.org/ISubjectService/DeleteResponse")]
        StudentService.Response.ResponseService<int> Delete(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/Delete", ReplyAction="http://tempuri.org/ISubjectService/DeleteResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> DeleteAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/SubjectByFacultyAndSemester", ReplyAction="http://tempuri.org/ISubjectService/SubjectByFacultyAndSemesterResponse")]
        StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> SubjectByFacultyAndSemester(StudentService.Request.FacultyAndSemesterRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/SubjectByFacultyAndSemester", ReplyAction="http://tempuri.org/ISubjectService/SubjectByFacultyAndSemesterResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> SubjectByFacultyAndSemesterAsync(StudentService.Request.FacultyAndSemesterRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/SubjectHaveClassSubjectOpen", ReplyAction="http://tempuri.org/ISubjectService/SubjectHaveClassSubjectOpenResponse")]
        StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> SubjectHaveClassSubjectOpen(int StudentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubjectService/SubjectHaveClassSubjectOpen", ReplyAction="http://tempuri.org/ISubjectService/SubjectHaveClassSubjectOpenResponse")]
        System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> SubjectHaveClassSubjectOpenAsync(int StudentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubjectServiceChannel : StudentManagement.SubjectService.ISubjectService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubjectServiceClient : System.ServiceModel.ClientBase<StudentManagement.SubjectService.ISubjectService>, StudentManagement.SubjectService.ISubjectService {
        
        public SubjectServiceClient() {
        }
        
        public SubjectServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SubjectServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubjectServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubjectServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public StudentService.Response.ResponseService<int> Save(StudentService.Model.Subject request) {
            return base.Channel.Save(request);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> SaveAsync(StudentService.Model.Subject request) {
            return base.Channel.SaveAsync(request);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.Subject[]> Subjects(StudentService.Request.FacutylePaginationRequest request) {
            return base.Channel.Subjects(request);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Subject[]>> SubjectsAsync(StudentService.Request.FacutylePaginationRequest request) {
            return base.Channel.SubjectsAsync(request);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.Subject> Subject(int Id) {
            return base.Channel.Subject(Id);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.Subject>> SubjectAsync(int Id) {
            return base.Channel.SubjectAsync(Id);
        }
        
        public StudentService.Response.ResponseService<int> Delete(int Id) {
            return base.Channel.Delete(Id);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<int>> DeleteAsync(int Id) {
            return base.Channel.DeleteAsync(Id);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> SubjectByFacultyAndSemester(StudentService.Request.FacultyAndSemesterRequest request) {
            return base.Channel.SubjectByFacultyAndSemester(request);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> SubjectByFacultyAndSemesterAsync(StudentService.Request.FacultyAndSemesterRequest request) {
            return base.Channel.SubjectByFacultyAndSemesterAsync(request);
        }
        
        public StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]> SubjectHaveClassSubjectOpen(int StudentId) {
            return base.Channel.SubjectHaveClassSubjectOpen(StudentId);
        }
        
        public System.Threading.Tasks.Task<StudentService.Response.ResponseService<StudentService.Model.IdAndNameModel[]>> SubjectHaveClassSubjectOpenAsync(int StudentId) {
            return base.Channel.SubjectHaveClassSubjectOpenAsync(StudentId);
        }
    }
}