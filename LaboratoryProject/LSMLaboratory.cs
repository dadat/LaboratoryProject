using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace LaboratoryProject
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblDoctor : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _docFirstName;
    [ValidateLength(0, 50)]
    private string _docLastName;
    private System.Nullable<System.DateTime> _dateRegistered;
    [ValidateLength(0, 50)]
    private string _codeDoctor;
    private System.Nullable<bool> _isActive;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the DocFirstName entity attribute.</summary>
    public const string DocFirstNameField = "DocFirstName";
    /// <summary>Identifies the DocLastName entity attribute.</summary>
    public const string DocLastNameField = "DocLastName";
    /// <summary>Identifies the DateRegistered entity attribute.</summary>
    public const string DateRegisteredField = "DateRegistered";
    /// <summary>Identifies the CodeDoctor entity attribute.</summary>
    public const string CodeDoctorField = "CodeDoctor";
    /// <summary>Identifies the IsActive entity attribute.</summary>
    public const string IsActiveField = "IsActive";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string DocFirstName
    {
      get { return Get(ref _docFirstName, "DocFirstName"); }
      set { Set(ref _docFirstName, value, "DocFirstName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string DocLastName
    {
      get { return Get(ref _docLastName, "DocLastName"); }
      set { Set(ref _docLastName, value, "DocLastName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateRegistered
    {
      get { return Get(ref _dateRegistered, "DateRegistered"); }
      set { Set(ref _dateRegistered, value, "DateRegistered"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeDoctor
    {
      get { return Get(ref _codeDoctor, "CodeDoctor"); }
      set { Set(ref _codeDoctor, value, "CodeDoctor"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<bool> IsActive
    {
      get { return Get(ref _isActive, "IsActive"); }
      set { Set(ref _isActive, value, "IsActive"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table("tblUsers")]
  public partial class TblUser : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _username;
    [ValidateLength(0, 50)]
    private string _password;
    private System.Nullable<System.DateTime> _dateRegistered;
    private System.Nullable<bool> _isActive;
    [ValidateLength(0, 50)]
    private string _role;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Username entity attribute.</summary>
    public const string UsernameField = "Username";
    /// <summary>Identifies the Password entity attribute.</summary>
    public const string PasswordField = "Password";
    /// <summary>Identifies the DateRegistered entity attribute.</summary>
    public const string DateRegisteredField = "DateRegistered";
    /// <summary>Identifies the IsActive entity attribute.</summary>
    public const string IsActiveField = "IsActive";
    /// <summary>Identifies the Role entity attribute.</summary>
    public const string RoleField = "Role";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string Username
    {
      get { return Get(ref _username, "Username"); }
      set { Set(ref _username, value, "Username"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Password
    {
      get { return Get(ref _password, "Password"); }
      set { Set(ref _password, value, "Password"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateRegistered
    {
      get { return Get(ref _dateRegistered, "DateRegistered"); }
      set { Set(ref _dateRegistered, value, "DateRegistered"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<bool> IsActive
    {
      get { return Get(ref _isActive, "IsActive"); }
      set { Set(ref _isActive, value, "IsActive"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Role
    {
      get { return Get(ref _role, "Role"); }
      set { Set(ref _role, value, "Role"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblPatient : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _firstName;
    [ValidateLength(0, 50)]
    private string _lastName;
    [ValidateLength(0, 50)]
    private string _contact;
    [ValidateLength(0, 200)]
    private string _address;
    [ValidateLength(0, 50)]
    private string _codePatient;
    private System.Nullable<System.DateTime> _dateRegistered;
    private System.Nullable<System.DateTime> _dateUpdated;
    [ValidateLength(0, 50)]
    private string _gender;
    private System.Nullable<int> _age;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the FirstName entity attribute.</summary>
    public const string FirstNameField = "FirstName";
    /// <summary>Identifies the LastName entity attribute.</summary>
    public const string LastNameField = "LastName";
    /// <summary>Identifies the Contact entity attribute.</summary>
    public const string ContactField = "Contact";
    /// <summary>Identifies the Address entity attribute.</summary>
    public const string AddressField = "Address";
    /// <summary>Identifies the CodePatient entity attribute.</summary>
    public const string CodePatientField = "CodePatient";
    /// <summary>Identifies the DateRegistered entity attribute.</summary>
    public const string DateRegisteredField = "DateRegistered";
    /// <summary>Identifies the DateUpdated entity attribute.</summary>
    public const string DateUpdatedField = "DateUpdated";
    /// <summary>Identifies the Gender entity attribute.</summary>
    public const string GenderField = "Gender";
    /// <summary>Identifies the Age entity attribute.</summary>
    public const string AgeField = "Age";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string FirstName
    {
      get { return Get(ref _firstName, "FirstName"); }
      set { Set(ref _firstName, value, "FirstName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string LastName
    {
      get { return Get(ref _lastName, "LastName"); }
      set { Set(ref _lastName, value, "LastName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Contact
    {
      get { return Get(ref _contact, "Contact"); }
      set { Set(ref _contact, value, "Contact"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Address
    {
      get { return Get(ref _address, "Address"); }
      set { Set(ref _address, value, "Address"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodePatient
    {
      get { return Get(ref _codePatient, "CodePatient"); }
      set { Set(ref _codePatient, value, "CodePatient"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateRegistered
    {
      get { return Get(ref _dateRegistered, "DateRegistered"); }
      set { Set(ref _dateRegistered, value, "DateRegistered"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateUpdated
    {
      get { return Get(ref _dateUpdated, "DateUpdated"); }
      set { Set(ref _dateUpdated, value, "DateUpdated"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Gender
    {
      get { return Get(ref _gender, "Gender"); }
      set { Set(ref _gender, value, "Gender"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> Age
    {
      get { return Get(ref _age, "Age"); }
      set { Set(ref _age, value, "Age"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblService : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _titleService;
    [ValidateLength(0, 10)]
    private string _codeService;
    private System.Nullable<decimal> _amountService;
    private System.Nullable<bool> _isActive;
    [ValidateLength(0, 50)]
    private string _classificationService;
    private System.Nullable<System.DateTime> _dateRegistered;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the TitleService entity attribute.</summary>
    public const string TitleServiceField = "TitleService";
    /// <summary>Identifies the CodeService entity attribute.</summary>
    public const string CodeServiceField = "CodeService";
    /// <summary>Identifies the AmountService entity attribute.</summary>
    public const string AmountServiceField = "AmountService";
    /// <summary>Identifies the IsActive entity attribute.</summary>
    public const string IsActiveField = "IsActive";
    /// <summary>Identifies the ClassificationService entity attribute.</summary>
    public const string ClassificationServiceField = "ClassificationService";
    /// <summary>Identifies the DateRegistered entity attribute.</summary>
    public const string DateRegisteredField = "DateRegistered";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string TitleService
    {
      get { return Get(ref _titleService, "TitleService"); }
      set { Set(ref _titleService, value, "TitleService"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeService
    {
      get { return Get(ref _codeService, "CodeService"); }
      set { Set(ref _codeService, value, "CodeService"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<decimal> AmountService
    {
      get { return Get(ref _amountService, "AmountService"); }
      set { Set(ref _amountService, value, "AmountService"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<bool> IsActive
    {
      get { return Get(ref _isActive, "IsActive"); }
      set { Set(ref _isActive, value, "IsActive"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string ClassificationService
    {
      get { return Get(ref _classificationService, "ClassificationService"); }
      set { Set(ref _classificationService, value, "ClassificationService"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateRegistered
    {
      get { return Get(ref _dateRegistered, "DateRegistered"); }
      set { Set(ref _dateRegistered, value, "DateRegistered"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblTransaction : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _codeTransaction;
    [ValidateLength(0, 50)]
    private System.Nullable<System.DateTime> _dateRegistered;
    [ValidateLength(0, 50)]
    private string _codeDoctor;
    [ValidateLength(0, 50)]
    private string _codePatient;
    [ValidateLength(0, 50)]
    private string _codeService;
    private System.Nullable<decimal> _totalAmount;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CodeTransaction entity attribute.</summary>
    public const string CodeTransactionField = "CodeTransaction";
    /// <summary>Identifies the DateRegistered entity attribute.</summary>
    public const string DateRegisteredField = "DateRegistered";
    /// <summary>Identifies the CodeDoctor entity attribute.</summary>
    public const string CodeDoctorField = "CodeDoctor";
    /// <summary>Identifies the CodePatient entity attribute.</summary>
    public const string CodePatientField = "CodePatient";
    /// <summary>Identifies the CodeService entity attribute.</summary>
    public const string CodeServiceField = "CodeService";
    /// <summary>Identifies the TotalAmount entity attribute.</summary>
    public const string TotalAmountField = "TotalAmount";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeTransaction
    {
      get { return Get(ref _codeTransaction, "CodeTransaction"); }
      set { Set(ref _codeTransaction, value, "CodeTransaction"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateRegistered
    {
      get { return Get(ref _dateRegistered, "DateRegistered"); }
      set { Set(ref _dateRegistered, value, "DateRegistered"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeDoctor
    {
      get { return Get(ref _codeDoctor, "CodeDoctor"); }
      set { Set(ref _codeDoctor, value, "CodeDoctor"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodePatient
    {
      get { return Get(ref _codePatient, "CodePatient"); }
      set { Set(ref _codePatient, value, "CodePatient"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeService
    {
      get { return Get(ref _codeService, "CodeService"); }
      set { Set(ref _codeService, value, "CodeService"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<decimal> TotalAmount
    {
      get { return Get(ref _totalAmount, "TotalAmount"); }
      set { Set(ref _totalAmount, value, "TotalAmount"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblLaboratory : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _codePatient;
    [ValidateLength(0, 50)]
    private string _dateLaboratory;
    [ValidateLength(0, 500)]
    private string _request;
    private System.Nullable<decimal> _total;
    [ValidateLength(0, 50)]
    private string _codeLaboratory;
    private System.Nullable<System.DateTime> _dateEncoded;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CodePatient entity attribute.</summary>
    public const string CodePatientField = "CodePatient";
    /// <summary>Identifies the DateLaboratory entity attribute.</summary>
    public const string DateLaboratoryField = "DateLaboratory";
    /// <summary>Identifies the Request entity attribute.</summary>
    public const string RequestField = "Request";
    /// <summary>Identifies the Total entity attribute.</summary>
    public const string TotalField = "Total";
    /// <summary>Identifies the CodeLaboratory entity attribute.</summary>
    public const string CodeLaboratoryField = "CodeLaboratory";
    /// <summary>Identifies the DateEncoded entity attribute.</summary>
    public const string DateEncodedField = "DateEncoded";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string CodePatient
    {
      get { return Get(ref _codePatient, "CodePatient"); }
      set { Set(ref _codePatient, value, "CodePatient"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string DateLaboratory
    {
      get { return Get(ref _dateLaboratory, "DateLaboratory"); }
      set { Set(ref _dateLaboratory, value, "DateLaboratory"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Request
    {
      get { return Get(ref _request, "Request"); }
      set { Set(ref _request, value, "Request"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<decimal> Total
    {
      get { return Get(ref _total, "Total"); }
      set { Set(ref _total, value, "Total"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeLaboratory
    {
      get { return Get(ref _codeLaboratory, "CodeLaboratory"); }
      set { Set(ref _codeLaboratory, value, "CodeLaboratory"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateEncoded
    {
      get { return Get(ref _dateEncoded, "DateEncoded"); }
      set { Set(ref _dateEncoded, value, "DateEncoded"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblXRay : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _codePatient;
    [ValidateLength(0, 50)]
    private string _dateXRay;
    [ValidateLength(0, 50)]
    private string _roentgenography;
    [ValidateLength(0, 50)]
    private string _filmNo;
    [ValidateLength(0, 600)]
    private string _findings;
    [ValidateLength(0, 150)]
    private string _remarks;
    [ValidateLength(0, 100)]
    private string _radiologist;
    [ValidateLength(0, 50)]
    private string _codeXRay;
    private System.Nullable<System.DateTime> _dateEncoded;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CodePatient entity attribute.</summary>
    public const string CodePatientField = "CodePatient";
    /// <summary>Identifies the DateXRay entity attribute.</summary>
    public const string DateXRayField = "DateXRay";
    /// <summary>Identifies the Roentgenography entity attribute.</summary>
    public const string RoentgenographyField = "Roentgenography";
    /// <summary>Identifies the FilmNo entity attribute.</summary>
    public const string FilmNoField = "FilmNo";
    /// <summary>Identifies the Findings entity attribute.</summary>
    public const string FindingsField = "Findings";
    /// <summary>Identifies the Remarks entity attribute.</summary>
    public const string RemarksField = "Remarks";
    /// <summary>Identifies the Radiologist entity attribute.</summary>
    public const string RadiologistField = "Radiologist";
    /// <summary>Identifies the CodeXRay entity attribute.</summary>
    public const string CodeXRayField = "CodeXRay";
    /// <summary>Identifies the DateEncoded entity attribute.</summary>
    public const string DateEncodedField = "DateEncoded";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string CodePatient
    {
      get { return Get(ref _codePatient, "CodePatient"); }
      set { Set(ref _codePatient, value, "CodePatient"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string DateXRay
    {
      get { return Get(ref _dateXRay, "DateXRay"); }
      set { Set(ref _dateXRay, value, "DateXRay"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Roentgenography
    {
      get { return Get(ref _roentgenography, "Roentgenography"); }
      set { Set(ref _roentgenography, value, "Roentgenography"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string FilmNo
    {
      get { return Get(ref _filmNo, "FilmNo"); }
      set { Set(ref _filmNo, value, "FilmNo"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Findings
    {
      get { return Get(ref _findings, "Findings"); }
      set { Set(ref _findings, value, "Findings"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Remarks
    {
      get { return Get(ref _remarks, "Remarks"); }
      set { Set(ref _remarks, value, "Remarks"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Radiologist
    {
      get { return Get(ref _radiologist, "Radiologist"); }
      set { Set(ref _radiologist, value, "Radiologist"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeXRay
    {
      get { return Get(ref _codeXRay, "CodeXRay"); }
      set { Set(ref _codeXRay, value, "CodeXRay"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateEncoded
    {
      get { return Get(ref _dateEncoded, "DateEncoded"); }
      set { Set(ref _dateEncoded, value, "DateEncoded"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblUltrasound : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _codePatient;
    [ValidateLength(0, 50)]
    private string _dateUltrasound;
    [ValidateLength(0, 600)]
    private string _findings;
    [ValidateLength(0, 150)]
    private string _impression;
    [ValidateLength(0, 100)]
    private string _radiologist;
    [ValidateLength(0, 50)]
    private string _codeUltrasound;
    private System.Nullable<System.DateTime> _dateEncoded;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CodePatient entity attribute.</summary>
    public const string CodePatientField = "CodePatient";
    /// <summary>Identifies the DateUltrasound entity attribute.</summary>
    public const string DateUltrasoundField = "DateUltrasound";
    /// <summary>Identifies the Findings entity attribute.</summary>
    public const string FindingsField = "Findings";
    /// <summary>Identifies the Impression entity attribute.</summary>
    public const string ImpressionField = "Impression";
    /// <summary>Identifies the Radiologist entity attribute.</summary>
    public const string RadiologistField = "Radiologist";
    /// <summary>Identifies the CodeUltrasound entity attribute.</summary>
    public const string CodeUltrasoundField = "CodeUltrasound";
    /// <summary>Identifies the DateEncoded entity attribute.</summary>
    public const string DateEncodedField = "DateEncoded";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string CodePatient
    {
      get { return Get(ref _codePatient, "CodePatient"); }
      set { Set(ref _codePatient, value, "CodePatient"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string DateUltrasound
    {
      get { return Get(ref _dateUltrasound, "DateUltrasound"); }
      set { Set(ref _dateUltrasound, value, "DateUltrasound"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Findings
    {
      get { return Get(ref _findings, "Findings"); }
      set { Set(ref _findings, value, "Findings"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Impression
    {
      get { return Get(ref _impression, "Impression"); }
      set { Set(ref _impression, value, "Impression"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Radiologist
    {
      get { return Get(ref _radiologist, "Radiologist"); }
      set { Set(ref _radiologist, value, "Radiologist"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CodeUltrasound
    {
      get { return Get(ref _codeUltrasound, "CodeUltrasound"); }
      set { Set(ref _codeUltrasound, value, "CodeUltrasound"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateEncoded
    {
      get { return Get(ref _dateEncoded, "DateEncoded"); }
      set { Set(ref _dateEncoded, value, "DateEncoded"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the LSMLaboratory model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LSMLaboratoryUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<TblDoctor> TblDoctors
    {
      get { return this.Query<TblDoctor>(); }
    }
    
    public System.Linq.IQueryable<TblUser> TblUsers
    {
      get { return this.Query<TblUser>(); }
    }
    
    public System.Linq.IQueryable<TblPatient> TblPatients
    {
      get { return this.Query<TblPatient>(); }
    }
    
    public System.Linq.IQueryable<TblService> TblServices
    {
      get { return this.Query<TblService>(); }
    }
    
    public System.Linq.IQueryable<TblTransaction> TblTransactions
    {
      get { return this.Query<TblTransaction>(); }
    }
    
    public System.Linq.IQueryable<TblLaboratory> TblLaboratories
    {
      get { return this.Query<TblLaboratory>(); }
    }
    
    public System.Linq.IQueryable<TblXRay> TblXRays
    {
      get { return this.Query<TblXRay>(); }
    }
    
    public System.Linq.IQueryable<TblUltrasound> TblUltrasounds
    {
      get { return this.Query<TblUltrasound>(); }
    }
    
  }

}
