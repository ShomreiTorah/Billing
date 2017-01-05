using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.Sql;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Migrator {
    ///<summary>Holds a payment pending migration.</summary>
    public partial class StagedPayment : Row {
        ///<summary>Creates a new StagedPayment instance.</summary>
        public StagedPayment () : base(Schema) { Initialize(); }
        partial void Initialize();
        
        ///<summary>Creates a strongly-typed StagedPayments table.</summary>
        public static TypedTable<StagedPayment> CreateTable() { return new TypedTable<StagedPayment>(Schema, () => new StagedPayment()); }
        
        ///<summary>Gets the schema's StagedPaymentId column.</summary>
        public static ValueColumn StagedPaymentIdColumn { get; private set; }
        ///<summary>Gets the schema's StagedPerson column.</summary>
        public static ForeignKeyColumn StagedPersonColumn { get; private set; }
        ///<summary>Gets the schema's Date column.</summary>
        public static ValueColumn DateColumn { get; private set; }
        ///<summary>Gets the schema's Method column.</summary>
        public static ValueColumn MethodColumn { get; private set; }
        ///<summary>Gets the schema's CheckNumber column.</summary>
        public static ValueColumn CheckNumberColumn { get; private set; }
        ///<summary>Gets the schema's Account column.</summary>
        public static ValueColumn AccountColumn { get; private set; }
        ///<summary>Gets the schema's Amount column.</summary>
        public static ValueColumn AmountColumn { get; private set; }
        ///<summary>Gets the schema's Comments column.</summary>
        public static ValueColumn CommentsColumn { get; private set; }
        ///<summary>Gets the schema's ExternalId column.</summary>
        public static ValueColumn ExternalIdColumn { get; private set; }
        ///<summary>Gets the schema's Company column.</summary>
        public static ValueColumn CompanyColumn { get; private set; }
        
        ///<summary>Gets the StagedPayments schema instance.</summary>
        public static new TypedSchema<StagedPayment> Schema { get; private set; }
        ///<summary>Gets the SchemaMapping that maps this schema to the SQL Server StagedPayments table.</summary>
        public static SchemaMapping SchemaMapping { get; private set; }
        
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        static StagedPayment() {
            #region Create Schema
            Schema = new TypedSchema<StagedPayment>("StagedPayments");
            
            Schema.PrimaryKey = StagedPaymentIdColumn = Schema.Columns.AddValueColumn("StagedPaymentId", typeof(Guid), null);
            StagedPaymentIdColumn.Unique = true;
            StagedPaymentIdColumn.AllowNulls = false;
            
            StagedPersonColumn = Schema.Columns.AddForeignKey("StagedPerson", StagedPerson.Schema, "StagedPayments");
            StagedPersonColumn.AllowNulls = false;
            
            DateColumn = Schema.Columns.AddValueColumn("Date", typeof(DateTime), null);
            DateColumn.AllowNulls = false;
            
            MethodColumn = Schema.Columns.AddValueColumn("Method", typeof(String), null);
            MethodColumn.AllowNulls = false;
            
            CheckNumberColumn = Schema.Columns.AddValueColumn("CheckNumber", typeof(String), null);
            CheckNumberColumn.AllowNulls = true;
            
            AccountColumn = Schema.Columns.AddValueColumn("Account", typeof(String), null);
            AccountColumn.AllowNulls = false;
            
            AmountColumn = Schema.Columns.AddValueColumn("Amount", typeof(Decimal), null);
            AmountColumn.AllowNulls = false;
            
            CommentsColumn = Schema.Columns.AddValueColumn("Comments", typeof(String), null);
            CommentsColumn.AllowNulls = true;
            
            ExternalIdColumn = Schema.Columns.AddValueColumn("ExternalId", typeof(String), null);
            ExternalIdColumn.AllowNulls = false;
            
            CompanyColumn = Schema.Columns.AddValueColumn("Company", typeof(String), null);
            CompanyColumn.AllowNulls = true;
            #endregion
            
            #region Create SchemaMapping
            SchemaMapping = new SchemaMapping(Schema, false);
            SchemaMapping.SqlName = "StagedPayments";
            SchemaMapping.SqlSchemaName = "BillingMigration";
            
            SchemaMapping.Columns.AddMapping(StagedPaymentIdColumn, "StagedPaymentId");
            SchemaMapping.Columns.AddMapping(StagedPersonColumn, "StagedPersonId");
            SchemaMapping.Columns.AddMapping(DateColumn, "Date");
            SchemaMapping.Columns.AddMapping(MethodColumn, "Method");
            SchemaMapping.Columns.AddMapping(CheckNumberColumn, "CheckNumber");
            SchemaMapping.Columns.AddMapping(AccountColumn, "Account");
            SchemaMapping.Columns.AddMapping(AmountColumn, "Amount");
            SchemaMapping.Columns.AddMapping(CommentsColumn, "Comments");
            SchemaMapping.Columns.AddMapping(ExternalIdColumn, "ExternalId");
            SchemaMapping.Columns.AddMapping(CompanyColumn, "Company");
            #endregion
            SchemaMapping.SetPrimaryMapping(SchemaMapping);
        }
        
        ///<summary>Gets the typed table that contains this row, if any.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public new TypedTable<StagedPayment> Table { get { return (TypedTable<StagedPayment>)base.Table; } }
        #region Value Properties
        ///<summary>Gets or sets the staged payment id of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public Guid StagedPaymentId {
            get { return base.Field<Guid>(StagedPaymentIdColumn); }
            set { base[StagedPaymentIdColumn] = value; }
        }
        ///<summary>Gets or sets the person who made this payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public StagedPerson StagedPerson {
            get { return base.Field<StagedPerson>(StagedPersonColumn); }
            set { base[StagedPersonColumn] = value; }
        }
        ///<summary>Gets or sets the date of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public DateTime Date {
            get { return base.Field<DateTime>(DateColumn); }
            set { base[DateColumn] = value; }
        }
        ///<summary>Gets or sets the method of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Method {
            get { return base.Field<String>(MethodColumn); }
            set { base[MethodColumn] = value; }
        }
        ///<summary>Gets or sets the check number of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String CheckNumber {
            get { return base.Field<String>(CheckNumberColumn); }
            set { base[CheckNumberColumn] = value; }
        }
        ///<summary>Gets or sets the account of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Account {
            get { return base.Field<String>(AccountColumn); }
            set { base[AccountColumn] = value; }
        }
        ///<summary>Gets or sets the amount of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public Decimal Amount {
            get { return base.Field<Decimal>(AmountColumn); }
            set { base[AmountColumn] = value; }
        }
        ///<summary>Gets or sets the comments of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Comments {
            get { return base.Field<String>(CommentsColumn); }
            set { base[CommentsColumn] = value; }
        }
        ///<summary>Gets or sets the external id of the staged payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String ExternalId {
            get { return base.Field<String>(ExternalIdColumn); }
            set { base[ExternalIdColumn] = value; }
        }
        ///<summary>Gets or sets the company that the payment was made through.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Company {
            get { return base.Field<String>(CompanyColumn); }
            set { base[CompanyColumn] = value; }
        }
        #endregion
        
        #region Partial Methods
        partial void OnColumnChanged(Column column, object oldValue, object newValue);
        
        partial void ValidateStagedPaymentId(Guid newValue, Action<string> error);
        partial void OnStagedPaymentIdChanged(Guid? oldValue, Guid? newValue);
        
        partial void ValidateStagedPerson(StagedPerson newValue, Action<string> error);
        partial void OnStagedPersonChanged(StagedPerson oldValue, StagedPerson newValue);
        
        partial void ValidateDate(DateTime newValue, Action<string> error);
        partial void OnDateChanged(DateTime? oldValue, DateTime? newValue);
        
        partial void ValidateMethod(String newValue, Action<string> error);
        partial void OnMethodChanged(String oldValue, String newValue);
        
        partial void ValidateCheckNumber(String newValue, Action<string> error);
        partial void OnCheckNumberChanged(String oldValue, String newValue);
        
        partial void ValidateAccount(String newValue, Action<string> error);
        partial void OnAccountChanged(String oldValue, String newValue);
        
        partial void ValidateAmount(Decimal newValue, Action<string> error);
        partial void OnAmountChanged(Decimal? oldValue, Decimal? newValue);
        
        partial void ValidateComments(String newValue, Action<string> error);
        partial void OnCommentsChanged(String oldValue, String newValue);
        
        partial void ValidateExternalId(String newValue, Action<string> error);
        partial void OnExternalIdChanged(String oldValue, String newValue);
        
        partial void ValidateCompany(String newValue, Action<string> error);
        partial void OnCompanyChanged(String oldValue, String newValue);
        #endregion
        
        #region Column Callbacks
        ///<summary>Checks whether a value would be valid for a given column in an attached row.</summary>
        ///<param name="column">The column containing the value.</param>
        ///<param name="newValue">The value to validate.</param>
        ///<returns>An error message, or null if the value is valid.</returns>
        ///<remarks>This method is overridden by typed rows to perform custom validation logic.</remarks>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public override string ValidateValue(Column column, object newValue) {
            string error = base.ValidateValue(column, newValue);
            if (!String.IsNullOrEmpty(error)) return error;
            Action<string> reporter = s => error = s;
            
            if (column == StagedPaymentIdColumn) {
                ValidateStagedPaymentId((Guid)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == StagedPersonColumn) {
                ValidateStagedPerson((StagedPerson)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == DateColumn) {
                ValidateDate((DateTime)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == MethodColumn) {
                ValidateMethod((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == CheckNumberColumn) {
                ValidateCheckNumber((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == AccountColumn) {
                ValidateAccount((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == AmountColumn) {
                ValidateAmount((Decimal)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == CommentsColumn) {
                ValidateComments((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == ExternalIdColumn) {
                ValidateExternalId((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == CompanyColumn) {
                ValidateCompany((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            }
            return null;
        }
        ///<summary>Processes an explicit change of a column value.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        protected override void OnValueChanged(Column column, object oldValue, object newValue) {
            base.OnValueChanged(column, oldValue, newValue);
            OnColumnChanged(column, oldValue, newValue);
            if (column == StagedPaymentIdColumn)
            	OnStagedPaymentIdChanged((Guid?)oldValue, (Guid?)newValue);
            else if (column == StagedPersonColumn)
            	OnStagedPersonChanged((StagedPerson)oldValue, (StagedPerson)newValue);
            else if (column == DateColumn)
            	OnDateChanged((DateTime?)oldValue, (DateTime?)newValue);
            else if (column == MethodColumn)
            	OnMethodChanged((String)oldValue, (String)newValue);
            else if (column == CheckNumberColumn)
            	OnCheckNumberChanged((String)oldValue, (String)newValue);
            else if (column == AccountColumn)
            	OnAccountChanged((String)oldValue, (String)newValue);
            else if (column == AmountColumn)
            	OnAmountChanged((Decimal?)oldValue, (Decimal?)newValue);
            else if (column == CommentsColumn)
            	OnCommentsChanged((String)oldValue, (String)newValue);
            else if (column == ExternalIdColumn)
            	OnExternalIdChanged((String)oldValue, (String)newValue);
            else if (column == CompanyColumn)
            	OnCompanyChanged((String)oldValue, (String)newValue);
        }
        #endregion
    }
    
    ///<summary>Holds a person staged to import into the database.</summary>
    public partial class StagedPerson : Row {
        ///<summary>Creates a new StagedPerson instance.</summary>
        public StagedPerson () : base(Schema) { Initialize(); }
        partial void Initialize();
        
        ///<summary>Creates a strongly-typed StagedPeople table.</summary>
        public static TypedTable<StagedPerson> CreateTable() { return new TypedTable<StagedPerson>(Schema, () => new StagedPerson()); }
        
        ///<summary>Gets the schema's StagedPersonId column.</summary>
        public static ValueColumn StagedPersonIdColumn { get; private set; }
        ///<summary>Gets the schema's Person column.</summary>
        public static ForeignKeyColumn PersonColumn { get; private set; }
        ///<summary>Gets the schema's HisName column.</summary>
        public static ValueColumn HisNameColumn { get; private set; }
        ///<summary>Gets the schema's HerName column.</summary>
        public static ValueColumn HerNameColumn { get; private set; }
        ///<summary>Gets the schema's LastName column.</summary>
        public static ValueColumn LastNameColumn { get; private set; }
        ///<summary>Gets the schema's FullName column.</summary>
        public static ValueColumn FullNameColumn { get; private set; }
        ///<summary>Gets the schema's Address column.</summary>
        public static ValueColumn AddressColumn { get; private set; }
        ///<summary>Gets the schema's City column.</summary>
        public static ValueColumn CityColumn { get; private set; }
        ///<summary>Gets the schema's State column.</summary>
        public static ValueColumn StateColumn { get; private set; }
        ///<summary>Gets the schema's Zip column.</summary>
        public static ValueColumn ZipColumn { get; private set; }
        ///<summary>Gets the schema's Phone column.</summary>
        public static ValueColumn PhoneColumn { get; private set; }
        
        ///<summary>Gets the StagedPeople schema instance.</summary>
        public static new TypedSchema<StagedPerson> Schema { get; private set; }
        ///<summary>Gets the SchemaMapping that maps this schema to the SQL Server StagedPeople table.</summary>
        public static SchemaMapping SchemaMapping { get; private set; }
        
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        static StagedPerson() {
            #region Create Schema
            Schema = new TypedSchema<StagedPerson>("StagedPeople");
            
            Schema.PrimaryKey = StagedPersonIdColumn = Schema.Columns.AddValueColumn("StagedPersonId", typeof(Guid), null);
            StagedPersonIdColumn.Unique = true;
            StagedPersonIdColumn.AllowNulls = false;
            
            PersonColumn = Schema.Columns.AddForeignKey("Person", Person.Schema, "StagedPeople");
            PersonColumn.AllowNulls = true;
            
            HisNameColumn = Schema.Columns.AddValueColumn("HisName", typeof(String), null);
            HisNameColumn.AllowNulls = true;
            
            HerNameColumn = Schema.Columns.AddValueColumn("HerName", typeof(String), null);
            HerNameColumn.AllowNulls = true;
            
            LastNameColumn = Schema.Columns.AddValueColumn("LastName", typeof(String), null);
            LastNameColumn.AllowNulls = false;
            
            FullNameColumn = Schema.Columns.AddValueColumn("FullName", typeof(String), null);
            FullNameColumn.AllowNulls = false;
            
            AddressColumn = Schema.Columns.AddValueColumn("Address", typeof(String), null);
            AddressColumn.AllowNulls = true;
            
            CityColumn = Schema.Columns.AddValueColumn("City", typeof(String), null);
            CityColumn.AllowNulls = true;
            
            StateColumn = Schema.Columns.AddValueColumn("State", typeof(String), null);
            StateColumn.AllowNulls = true;
            
            ZipColumn = Schema.Columns.AddValueColumn("Zip", typeof(String), null);
            ZipColumn.AllowNulls = true;
            
            PhoneColumn = Schema.Columns.AddValueColumn("Phone", typeof(String), "");
            PhoneColumn.AllowNulls = false;
            #endregion
            
            #region Create SchemaMapping
            SchemaMapping = new SchemaMapping(Schema, false);
            SchemaMapping.SqlName = "StagedPeople";
            SchemaMapping.SqlSchemaName = "BillingMigration";
            
            SchemaMapping.Columns.AddMapping(StagedPersonIdColumn, "StagedPersonId");
            SchemaMapping.Columns.AddMapping(PersonColumn, "PersonId");
            SchemaMapping.Columns.AddMapping(HisNameColumn, "HisName");
            SchemaMapping.Columns.AddMapping(HerNameColumn, "HerName");
            SchemaMapping.Columns.AddMapping(LastNameColumn, "LastName");
            SchemaMapping.Columns.AddMapping(FullNameColumn, "FullName");
            SchemaMapping.Columns.AddMapping(AddressColumn, "Address");
            SchemaMapping.Columns.AddMapping(CityColumn, "City");
            SchemaMapping.Columns.AddMapping(StateColumn, "State");
            SchemaMapping.Columns.AddMapping(ZipColumn, "Zip");
            SchemaMapping.Columns.AddMapping(PhoneColumn, "Phone");
            #endregion
            SchemaMapping.SetPrimaryMapping(SchemaMapping);
        }
        
        ///<summary>Gets the typed table that contains this row, if any.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public new TypedTable<StagedPerson> Table { get { return (TypedTable<StagedPerson>)base.Table; } }
        #region Value Properties
        ///<summary>Gets or sets the staged person id of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public Guid StagedPersonId {
            get { return base.Field<Guid>(StagedPersonIdColumn); }
            set { base[StagedPersonIdColumn] = value; }
        }
        ///<summary>Gets or sets the person to merge into.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public Person Person {
            get { return base.Field<Person>(PersonColumn); }
            set { base[PersonColumn] = value; }
        }
        ///<summary>Gets or sets the male name of the person being imported.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String HisName {
            get { return base.Field<String>(HisNameColumn); }
            set { base[HisNameColumn] = value; }
        }
        ///<summary>Gets or sets the female name of the person being imported.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String HerName {
            get { return base.Field<String>(HerNameColumn); }
            set { base[HerNameColumn] = value; }
        }
        ///<summary>Gets or sets the last name of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String LastName {
            get { return base.Field<String>(LastNameColumn); }
            set { base[LastNameColumn] = value; }
        }
        ///<summary>Gets or sets the full name of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String FullName {
            get { return base.Field<String>(FullNameColumn); }
            set { base[FullNameColumn] = value; }
        }
        ///<summary>Gets or sets the address of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Address {
            get { return base.Field<String>(AddressColumn); }
            set { base[AddressColumn] = value; }
        }
        ///<summary>Gets or sets the city of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String City {
            get { return base.Field<String>(CityColumn); }
            set { base[CityColumn] = value; }
        }
        ///<summary>Gets or sets the state of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String State {
            get { return base.Field<String>(StateColumn); }
            set { base[StateColumn] = value; }
        }
        ///<summary>Gets or sets the zip of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Zip {
            get { return base.Field<String>(ZipColumn); }
            set { base[ZipColumn] = value; }
        }
        ///<summary>Gets or sets the phone of the staged people.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Phone {
            get { return base.Field<String>(PhoneColumn); }
            set { base[PhoneColumn] = value; }
        }
        #endregion
        
        #region ChildRows Properties
        ///<summary>Gets the payments that will be imported for this person.</summary>
        public IChildRowCollection<StagedPayment> StagedPayments { get { return TypedChildRows<StagedPayment>(StagedPayment.StagedPersonColumn); } }
        #endregion
        
        #region Partial Methods
        partial void OnColumnChanged(Column column, object oldValue, object newValue);
        
        partial void ValidateStagedPersonId(Guid newValue, Action<string> error);
        partial void OnStagedPersonIdChanged(Guid? oldValue, Guid? newValue);
        
        partial void ValidatePerson(Person newValue, Action<string> error);
        partial void OnPersonChanged(Person oldValue, Person newValue);
        
        partial void ValidateHisName(String newValue, Action<string> error);
        partial void OnHisNameChanged(String oldValue, String newValue);
        
        partial void ValidateHerName(String newValue, Action<string> error);
        partial void OnHerNameChanged(String oldValue, String newValue);
        
        partial void ValidateLastName(String newValue, Action<string> error);
        partial void OnLastNameChanged(String oldValue, String newValue);
        
        partial void ValidateFullName(String newValue, Action<string> error);
        partial void OnFullNameChanged(String oldValue, String newValue);
        
        partial void ValidateAddress(String newValue, Action<string> error);
        partial void OnAddressChanged(String oldValue, String newValue);
        
        partial void ValidateCity(String newValue, Action<string> error);
        partial void OnCityChanged(String oldValue, String newValue);
        
        partial void ValidateState(String newValue, Action<string> error);
        partial void OnStateChanged(String oldValue, String newValue);
        
        partial void ValidateZip(String newValue, Action<string> error);
        partial void OnZipChanged(String oldValue, String newValue);
        
        partial void ValidatePhone(String newValue, Action<string> error);
        partial void OnPhoneChanged(String oldValue, String newValue);
        #endregion
        
        #region Column Callbacks
        ///<summary>Checks whether a value would be valid for a given column in an attached row.</summary>
        ///<param name="column">The column containing the value.</param>
        ///<param name="newValue">The value to validate.</param>
        ///<returns>An error message, or null if the value is valid.</returns>
        ///<remarks>This method is overridden by typed rows to perform custom validation logic.</remarks>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public override string ValidateValue(Column column, object newValue) {
            string error = base.ValidateValue(column, newValue);
            if (!String.IsNullOrEmpty(error)) return error;
            Action<string> reporter = s => error = s;
            
            if (column == StagedPersonIdColumn) {
                ValidateStagedPersonId((Guid)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == PersonColumn) {
                ValidatePerson((Person)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == HisNameColumn) {
                ValidateHisName((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == HerNameColumn) {
                ValidateHerName((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == LastNameColumn) {
                ValidateLastName((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == FullNameColumn) {
                ValidateFullName((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == AddressColumn) {
                ValidateAddress((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == CityColumn) {
                ValidateCity((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == StateColumn) {
                ValidateState((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == ZipColumn) {
                ValidateZip((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == PhoneColumn) {
                ValidatePhone((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            }
            return null;
        }
        ///<summary>Processes an explicit change of a column value.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        protected override void OnValueChanged(Column column, object oldValue, object newValue) {
            base.OnValueChanged(column, oldValue, newValue);
            OnColumnChanged(column, oldValue, newValue);
            if (column == StagedPersonIdColumn)
            	OnStagedPersonIdChanged((Guid?)oldValue, (Guid?)newValue);
            else if (column == PersonColumn)
            	OnPersonChanged((Person)oldValue, (Person)newValue);
            else if (column == HisNameColumn)
            	OnHisNameChanged((String)oldValue, (String)newValue);
            else if (column == HerNameColumn)
            	OnHerNameChanged((String)oldValue, (String)newValue);
            else if (column == LastNameColumn)
            	OnLastNameChanged((String)oldValue, (String)newValue);
            else if (column == FullNameColumn)
            	OnFullNameChanged((String)oldValue, (String)newValue);
            else if (column == AddressColumn)
            	OnAddressChanged((String)oldValue, (String)newValue);
            else if (column == CityColumn)
            	OnCityChanged((String)oldValue, (String)newValue);
            else if (column == StateColumn)
            	OnStateChanged((String)oldValue, (String)newValue);
            else if (column == ZipColumn)
            	OnZipChanged((String)oldValue, (String)newValue);
            else if (column == PhoneColumn)
            	OnPhoneChanged((String)oldValue, (String)newValue);
        }
        #endregion
    }
}
