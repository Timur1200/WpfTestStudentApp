//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfTestStudentApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestResult
    {
        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> CorrectAnswer { get; set; }
        public Nullable<double> Result { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Test Test { get; set; }
        public virtual Student Student { get; set; }
    }
}
