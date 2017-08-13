﻿#if EF_CORE
namespace EntityFrameworkCore.CommonTools
#elif EF_6
namespace EntityFramework.CommonTools
#endif
{
    /// <summary>
    /// An entity can implement this interface if it should use Optimistic Concurrency Check
    /// with populating <see cref="RowVersion"/> from client-side. Allowed types:
    /// <para />
    /// <typeparamref name="TRowVersion"/> is <see cref="T:byte[]"/>: 
    /// RowVersion property should be decorated by [Timestamp] attribute.
    /// RowVersion column should have ROWVERSION type in SQL Server. 
    /// <para />
    /// <para />
    /// <typeparamref name="TRowVersion"/> is <see cref="System.Guid"/>: 
    /// RowVersion property should be decorated by [ConcurrencyCheck] attribute.
    /// It's value is generated by <see cref="System.Guid.NewGuid"/> during each save.
    /// <para />
    /// <typeparamref name="TRowVersion"/> is <see cref="long"/>: 
    /// RowVersion property should be decorated by [ConcurrencyCheck]
    /// and [DatabaseGenerated(DatabaseGeneratedOption.Computed)] attributes.
    /// RowVersion column should be updated by trigger in DB:
    /// <code>
    ///     CREATE TRIGGER TRG_MyTable_UPD
    ///     AFTER UPDATE ON MyTable
    ///         WHEN old.RowVersion = new.RowVersion
    ///     BEGIN
    ///         UPDATE MyTable
    ///         SET RowVersion = RowVersion + 1;
    ///     END;
    /// </code>
    /// </summary>
    public interface IConcurrencyCheckable<TRowVersion>
    {
        TRowVersion RowVersion { get; set; }
    }
}
