using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.Sql;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.PaymentImport {
    ///<summary>Links a payment imported from an external source.</summary>
    public partial class ImportedPayment : Row {
        ///<summary>Creates a new ImportedPayment instance.</summary>
        public ImportedPayment () : base(Schema) { Initialize(); }
        partial void Initialize();
        
        ///<summary>Creates a strongly-typed ImportedPayments table.</summary>
        public static TypedTable<ImportedPayment> CreateTable() { return new TypedTable<ImportedPayment>(Schema, () => new ImportedPayment()); }
        
        ///<summary>Gets the schema's ImportedPaymentId column.</summary>
        public static ValueColumn ImportedPaymentIdColumn { get; private set; }
        ///<summary>Gets the schema's Payment column.</summary>
        public static ForeignKeyColumn PaymentColumn { get; private set; }
        ///<summary>Gets the schema's Source column.</summary>
        public static ValueColumn SourceColumn { get; private set; }
        ///<summary>Gets the schema's ExternalId column.</summary>
        public static ValueColumn ExternalIdColumn { get; private set; }
        ///<summary>Gets the schema's DateImported column.</summary>
        public static ValueColumn DateImportedColumn { get; private set; }
        ///<summary>Gets the schema's ImportingUser column.</summary>
        public static ValueColumn ImportingUserColumn { get; private set; }
        
        ///<summary>Gets the ImportedPayments schema instance.</summary>
        public static new TypedSchema<ImportedPayment> Schema { get; private set; }
        ///<summary>Gets the SchemaMapping that maps this schema to the SQL Server ImportedPayments table.</summary>
        public static SchemaMapping SchemaMapping { get; private set; }
        
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        static ImportedPayment() {
            #region Create Schema
            Schema = new TypedSchema<ImportedPayment>("ImportedPayments");
            
            Schema.PrimaryKey = ImportedPaymentIdColumn = Schema.Columns.AddValueColumn("ImportedPaymentId", typeof(String), null);
            ImportedPaymentIdColumn.Unique = true;
            ImportedPaymentIdColumn.AllowNulls = false;
            
            PaymentColumn = Schema.Columns.AddForeignKey("Payment", Payment.Schema, "ImportedPayments");
            PaymentColumn.Unique = true;
            PaymentColumn.AllowNulls = false;
            
            SourceColumn = Schema.Columns.AddValueColumn("Source", typeof(String), null);
            SourceColumn.AllowNulls = false;
            
            ExternalIdColumn = Schema.Columns.AddValueColumn("ExternalId", typeof(String), null);
            ExternalIdColumn.AllowNulls = false;
            
            DateImportedColumn = Schema.Columns.AddValueColumn("DateImported", typeof(DateTime), null);
            DateImportedColumn.AllowNulls = false;
            
            ImportingUserColumn = Schema.Columns.AddValueColumn("ImportingUser", typeof(String), null);
            ImportingUserColumn.AllowNulls = false;
            #endregion
            
            #region Create SchemaMapping
            SchemaMapping = new SchemaMapping(Schema, false);
            SchemaMapping.SqlName = "ImportedPayments";
            SchemaMapping.SqlSchemaName = "Billing";
            
            SchemaMapping.Columns.AddMapping(ImportedPaymentIdColumn, "ImportedPaymentId");
            SchemaMapping.Columns.AddMapping(PaymentColumn, "PaymentId");
            SchemaMapping.Columns.AddMapping(SourceColumn, "Source");
            SchemaMapping.Columns.AddMapping(ExternalIdColumn, "ExternalId");
            SchemaMapping.Columns.AddMapping(DateImportedColumn, "DateImported");
            SchemaMapping.Columns.AddMapping(ImportingUserColumn, "ImportingUser");
            #endregion
            SchemaMapping.SetPrimaryMapping(SchemaMapping);
        }
        
        ///<summary>Gets the typed table that contains this row, if any.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public new TypedTable<ImportedPayment> Table { get { return (TypedTable<ImportedPayment>)base.Table; } }
        #region Value Properties
        ///<summary>Gets or sets a unique ID for this row.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String ImportedPaymentId {
            get { return base.Field<String>(ImportedPaymentIdColumn); }
            set { base[ImportedPaymentIdColumn] = value; }
        }
        ///<summary>Gets or sets the payment that was imported.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public Payment Payment {
            get { return base.Field<Payment>(PaymentColumn); }
            set { base[PaymentColumn] = value; }
        }
        ///<summary>Gets or sets the source that the payment was imported from.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String Source {
            get { return base.Field<String>(SourceColumn); }
            set { base[SourceColumn] = value; }
        }
        ///<summary>Gets or sets the payment's ID within the external source.  This is an opaque value, and must be unique within the source.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String ExternalId {
            get { return base.Field<String>(ExternalIdColumn); }
            set { base[ExternalIdColumn] = value; }
        }
        ///<summary>Gets or sets the date that the payment was imported on.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public DateTime DateImported {
            get { return base.Field<DateTime>(DateImportedColumn); }
            set { base[DateImportedColumn] = value; }
        }
        ///<summary>Gets or sets the user that imported the payment.</summary>
        [DebuggerNonUserCode]
        [GeneratedCode("ShomreiTorah.Singularity.Designer", "1.0")]
        public String ImportingUser {
            get { return base.Field<String>(ImportingUserColumn); }
            set { base[ImportingUserColumn] = value; }
        }
        #endregion
        
        #region Partial Methods
        partial void OnColumnChanged(Column column, object oldValue, object newValue);
        
        partial void ValidateImportedPaymentId(String newValue, Action<string> error);
        partial void OnImportedPaymentIdChanged(String oldValue, String newValue);
        
        partial void ValidatePayment(Payment newValue, Action<string> error);
        partial void OnPaymentChanged(Payment oldValue, Payment newValue);
        
        partial void ValidateSource(String newValue, Action<string> error);
        partial void OnSourceChanged(String oldValue, String newValue);
        
        partial void ValidateExternalId(String newValue, Action<string> error);
        partial void OnExternalIdChanged(String oldValue, String newValue);
        
        partial void ValidateDateImported(DateTime newValue, Action<string> error);
        partial void OnDateImportedChanged(DateTime? oldValue, DateTime? newValue);
        
        partial void ValidateImportingUser(String newValue, Action<string> error);
        partial void OnImportingUserChanged(String oldValue, String newValue);
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
            
            if (column == ImportedPaymentIdColumn) {
                ValidateImportedPaymentId((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == PaymentColumn) {
                ValidatePayment((Payment)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == SourceColumn) {
                ValidateSource((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == ExternalIdColumn) {
                ValidateExternalId((String)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == DateImportedColumn) {
                ValidateDateImported((DateTime)newValue, reporter);
                if (!String.IsNullOrEmpty(error)) return error;
            } else if (column == ImportingUserColumn) {
                ValidateImportingUser((String)newValue, reporter);
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
            if (column == ImportedPaymentIdColumn)
            	OnImportedPaymentIdChanged((String)oldValue, (String)newValue);
            else if (column == PaymentColumn)
            	OnPaymentChanged((Payment)oldValue, (Payment)newValue);
            else if (column == SourceColumn)
            	OnSourceChanged((String)oldValue, (String)newValue);
            else if (column == ExternalIdColumn)
            	OnExternalIdChanged((String)oldValue, (String)newValue);
            else if (column == DateImportedColumn)
            	OnDateImportedChanged((DateTime?)oldValue, (DateTime?)newValue);
            else if (column == ImportingUserColumn)
            	OnImportingUserChanged((String)oldValue, (String)newValue);
        }
        #endregion
    }
}
